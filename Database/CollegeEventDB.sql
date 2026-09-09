/* ============================================================================
   College Event Management System
   Database script for Microsoft SQL Server

   HOW TO RUN
   1. Open SQL Server Management Studio (SSMS).
   2. Open this file.
   3. Make sure the current database at the top of SSMS is "master".
   4. Press Execute (F5).

   The script creates the database, all seven tables, the keys, the
   constraints and a small amount of sample data for the demonstration.
   ============================================================================ */

USE master;
GO

/* Remove the old database if it already exists, so the script can be
   executed again from the beginning without any error. */
IF DB_ID('CollegeEventDB') IS NOT NULL
BEGIN
    ALTER DATABASE CollegeEventDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE CollegeEventDB;
END
GO

CREATE DATABASE CollegeEventDB;
GO

USE CollegeEventDB;
GO

/* ============================================================================
   TABLE 1: Categories
   One category (Technical, Cultural, ...) can be used by many events.
   ============================================================================ */
CREATE TABLE Categories
(
    CategoryID   INT IDENTITY(1,1) NOT NULL,
    CategoryName VARCHAR(100)      NOT NULL,
    Description  VARCHAR(255)      NULL,
    CONSTRAINT PK_Categories PRIMARY KEY (CategoryID),
    CONSTRAINT UQ_Categories_CategoryName UNIQUE (CategoryName)
);
GO

/* ============================================================================
   TABLE 2: Venues
   Capacity can never be zero or a negative number (CHECK constraint).
   ============================================================================ */
CREATE TABLE Venues
(
    VenueID   INT IDENTITY(1,1) NOT NULL,
    VenueName VARCHAR(100)      NOT NULL,
    Location  VARCHAR(150)      NULL,
    Capacity  INT               NULL,
    CONSTRAINT PK_Venues PRIMARY KEY (VenueID),
    CONSTRAINT CK_Venues_Capacity CHECK (Capacity > 0)
);
GO

/* ============================================================================
   TABLE 3: Students
   Student details are stored only once here and are reused by Participants.
   ============================================================================ */
CREATE TABLE Students
(
    StudentID   INT IDENTITY(1,1) NOT NULL,
    StudentName VARCHAR(100)      NOT NULL,
    Email       VARCHAR(150)      NULL,
    Phone       VARCHAR(20)       NULL,
    Program     VARCHAR(100)      NULL,
    Semester    INT               NULL,
    CONSTRAINT PK_Students PRIMARY KEY (StudentID),
    CONSTRAINT CK_Students_Semester CHECK (Semester BETWEEN 1 AND 8)
);
GO

/* ============================================================================
   TABLE 4: Events
   CategoryID and VenueID are foreign keys, so an event can never point to a
   category or a venue that does not exist.
   ============================================================================ */
CREATE TABLE Events
(
    EventID     INT IDENTITY(1,1) NOT NULL,
    EventName   VARCHAR(150)      NOT NULL,
    CategoryID  INT               NULL,
    VenueID     INT               NULL,
    EventDate   DATE              NULL,
    Description VARCHAR(500)      NULL,
    CONSTRAINT PK_Events PRIMARY KEY (EventID),
    CONSTRAINT FK_Events_Categories FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID),
    CONSTRAINT FK_Events_Venues FOREIGN KEY (VenueID) REFERENCES Venues(VenueID)
);
GO

/* ============================================================================
   TABLE 5: Participants
   This table connects one student with one event.
   The UNIQUE constraint stops the same student from being registered twice
   for the same event.
   ============================================================================ */
CREATE TABLE Participants
(
    ParticipantID    INT IDENTITY(1,1) NOT NULL,
    EventID          INT               NOT NULL,
    StudentID        INT               NOT NULL,
    RegistrationDate DATE              NULL,
    CONSTRAINT PK_Participants PRIMARY KEY (ParticipantID),
    CONSTRAINT FK_Participants_Events FOREIGN KEY (EventID) REFERENCES Events(EventID),
    CONSTRAINT FK_Participants_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    CONSTRAINT UQ_Participants_Event_Student UNIQUE (EventID, StudentID)
);
GO

/* ============================================================================
   TABLE 6: Attendance
   Attendance is recorded for a participant, not directly for a student,
   because a student can take part in more than one event.
   ============================================================================ */
CREATE TABLE Attendance
(
    AttendanceID   INT IDENTITY(1,1) NOT NULL,
    ParticipantID  INT               NOT NULL,
    AttendanceDate DATE              NULL,
    Status         VARCHAR(20)       NULL,
    CONSTRAINT PK_Attendance PRIMARY KEY (AttendanceID),
    CONSTRAINT FK_Attendance_Participants FOREIGN KEY (ParticipantID) REFERENCES Participants(ParticipantID),
    CONSTRAINT CK_Attendance_Status CHECK (Status IN ('Present', 'Absent')),
    CONSTRAINT UQ_Attendance_Participant_Date UNIQUE (ParticipantID, AttendanceDate)
);
GO

/* ============================================================================
   TABLE 7: Certificates
   Every certificate number must be unique in the whole college.
   ============================================================================ */
CREATE TABLE Certificates
(
    CertificateID   INT IDENTITY(1,1) NOT NULL,
    ParticipantID   INT               NOT NULL,
    CertificateNo   VARCHAR(100)      NOT NULL,
    CertificateType VARCHAR(100)      NULL,
    IssueDate       DATE              NULL,
    CONSTRAINT PK_Certificates PRIMARY KEY (CertificateID),
    CONSTRAINT FK_Certificates_Participants FOREIGN KEY (ParticipantID) REFERENCES Participants(ParticipantID),
    CONSTRAINT UQ_Certificates_CertificateNo UNIQUE (CertificateNo)
);
GO

/* ============================================================================
   INDEXES
   The foreign key columns are used in almost every JOIN query of the
   application, so a small index on each of them keeps the searches fast.
   ============================================================================ */
CREATE INDEX IX_Events_CategoryID ON Events(CategoryID);
CREATE INDEX IX_Events_VenueID ON Events(VenueID);
CREATE INDEX IX_Participants_EventID ON Participants(EventID);
CREATE INDEX IX_Participants_StudentID ON Participants(StudentID);
CREATE INDEX IX_Attendance_ParticipantID ON Attendance(ParticipantID);
CREATE INDEX IX_Certificates_ParticipantID ON Certificates(ParticipantID);
GO

/* ============================================================================
   SAMPLE DATA
   All names below are fictional and are used only for the demonstration.
   ============================================================================ */

INSERT INTO Categories (CategoryName, Description) VALUES
('Technical',  'Technical events such as coding contests and exhibitions'),   -- CategoryID 1
('Cultural',   'Cultural events such as music, dance and drama'),             -- CategoryID 2
('Sports',     'Indoor and outdoor sports events'),                           -- CategoryID 3
('Seminar',    'Seminars, workshops and guest lectures');                     -- CategoryID 4
GO

INSERT INTO Venues (VenueName, Location, Capacity) VALUES
('Main Auditorium', 'Block A, Ground Floor', 500),   -- VenueID 1
('Seminar Hall',    'Block B, Second Floor', 150),   -- VenueID 2
('Computer Lab',    'Block C, First Floor',   60),   -- VenueID 3
('College Ground',  'Main Campus',          1000);   -- VenueID 4
GO

INSERT INTO Students (StudentName, Email, Phone, Program, Semester) VALUES
('Aarav Sharma',     'aarav.sharma@example.com',     '9801000001', 'BSc CSIT', 5),  -- StudentID 1
('Nisha Karki',      'nisha.karki@example.com',      '9801000002', 'BSc CSIT', 5),  -- StudentID 2
('Rohan Thapa',      'rohan.thapa@example.com',      '9801000003', 'BCA',      3),  -- StudentID 3
('Anisha Gurung',    'anisha.gurung@example.com',    '9801000004', 'BBA',      4),  -- StudentID 4
('Bibek Adhikari',   'bibek.adhikari@example.com',   '9801000005', 'BSc CSIT', 7),  -- StudentID 5
('Sneha Rai',        'sneha.rai@example.com',        '9801000006', 'BCA',      2),  -- StudentID 6
('Prakash Bhandari', 'prakash.bhandari@example.com', '9801000007', 'BIM',      6),  -- StudentID 7
('Sarita Magar',     'sarita.magar@example.com',     '9801000008', 'BBA',      1);  -- StudentID 8
GO

/* The event dates are calculated from today's date, so the application always
   has both finished events and upcoming events for the demonstration. */
INSERT INTO Events (EventName, CategoryID, VenueID, EventDate, Description) VALUES
('Technical Symposium',     1, 1, DATEADD(DAY, -20, CAST(GETDATE() AS DATE)), 'Project exhibition and technical paper presentation'), -- EventID 1
('Annual Sports Day',       3, 4, DATEADD(DAY, -10, CAST(GETDATE() AS DATE)), 'Athletics, football and volleyball competitions'),     -- EventID 2
('Cultural Program',        2, 1, DATEADD(DAY,   7, CAST(GETDATE() AS DATE)), 'Music, dance and drama performances by students'),     -- EventID 3
('Career Seminar',          4, 2, DATEADD(DAY,  20, CAST(GETDATE() AS DATE)), 'Career guidance session for final year students'),     -- EventID 4
('Inter-College Hackathon', 1, 3, DATEADD(DAY,  35, CAST(GETDATE() AS DATE)), 'Twenty four hour software development competition');   -- EventID 5
GO

INSERT INTO Participants (EventID, StudentID, RegistrationDate) VALUES
(1, 1, DATEADD(DAY, -25, CAST(GETDATE() AS DATE))),   -- ParticipantID 1
(1, 2, DATEADD(DAY, -25, CAST(GETDATE() AS DATE))),   -- ParticipantID 2
(1, 3, DATEADD(DAY, -24, CAST(GETDATE() AS DATE))),   -- ParticipantID 3
(1, 4, DATEADD(DAY, -24, CAST(GETDATE() AS DATE))),   -- ParticipantID 4
(2, 2, DATEADD(DAY, -15, CAST(GETDATE() AS DATE))),   -- ParticipantID 5
(2, 5, DATEADD(DAY, -15, CAST(GETDATE() AS DATE))),   -- ParticipantID 6
(2, 6, DATEADD(DAY, -14, CAST(GETDATE() AS DATE))),   -- ParticipantID 7
(3, 1, DATEADD(DAY,  -5, CAST(GETDATE() AS DATE))),   -- ParticipantID 8
(3, 7, DATEADD(DAY,  -5, CAST(GETDATE() AS DATE))),   -- ParticipantID 9
(3, 8, DATEADD(DAY,  -4, CAST(GETDATE() AS DATE))),   -- ParticipantID 10
(4, 3, DATEADD(DAY,  -3, CAST(GETDATE() AS DATE))),   -- ParticipantID 11
(4, 5, DATEADD(DAY,  -3, CAST(GETDATE() AS DATE))),   -- ParticipantID 12
(5, 4, DATEADD(DAY,  -2, CAST(GETDATE() AS DATE))),   -- ParticipantID 13
(5, 6, DATEADD(DAY,  -2, CAST(GETDATE() AS DATE)));   -- ParticipantID 14
GO

INSERT INTO Attendance (ParticipantID, AttendanceDate, Status) VALUES
(1, DATEADD(DAY, -20, CAST(GETDATE() AS DATE)), 'Present'),
(2, DATEADD(DAY, -20, CAST(GETDATE() AS DATE)), 'Present'),
(3, DATEADD(DAY, -20, CAST(GETDATE() AS DATE)), 'Absent'),
(4, DATEADD(DAY, -20, CAST(GETDATE() AS DATE)), 'Present'),
(5, DATEADD(DAY, -10, CAST(GETDATE() AS DATE)), 'Present'),
(6, DATEADD(DAY, -10, CAST(GETDATE() AS DATE)), 'Present'),
(7, DATEADD(DAY, -10, CAST(GETDATE() AS DATE)), 'Absent');
GO

INSERT INTO Certificates (ParticipantID, CertificateNo, CertificateType, IssueDate) VALUES
(1, 'CERT-2001', 'Participation', DATEADD(DAY, -18, CAST(GETDATE() AS DATE))),
(2, 'CERT-2002', 'Winner',        DATEADD(DAY, -18, CAST(GETDATE() AS DATE))),
(4, 'CERT-2003', 'Participation', DATEADD(DAY, -18, CAST(GETDATE() AS DATE))),
(5, 'CERT-2004', 'Participation', DATEADD(DAY,  -8, CAST(GETDATE() AS DATE))),
(6, 'CERT-2005', 'Runner-up',     DATEADD(DAY,  -8, CAST(GETDATE() AS DATE)));
GO

/* ============================================================================
   QUICK CHECK
   These SELECT statements show that the sample data was inserted correctly.
   ============================================================================ */
SELECT 'Categories' AS TableName, COUNT(*) AS TotalRows FROM Categories
UNION ALL SELECT 'Venues',       COUNT(*) FROM Venues
UNION ALL SELECT 'Students',     COUNT(*) FROM Students
UNION ALL SELECT 'Events',       COUNT(*) FROM Events
UNION ALL SELECT 'Participants', COUNT(*) FROM Participants
UNION ALL SELECT 'Attendance',   COUNT(*) FROM Attendance
UNION ALL SELECT 'Certificates', COUNT(*) FROM Certificates;
GO
