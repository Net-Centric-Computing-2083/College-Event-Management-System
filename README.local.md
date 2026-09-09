# College Event Management System

A desktop application that helps a college manage its events, students,
participants, attendance and certificate records.

Built with **C# Windows Forms** and **Microsoft SQL Server**, using **ADO.NET**
for all database communication.

---

## Project Description

Colleges organise many events in one academic year: technical symposiums,
cultural programs, sports days and seminars. Keeping the records of these
events, of the students who take part in them, of who attended and of which
certificates were issued is difficult on paper.

This system stores all of that information in one relational SQL Server
database and gives the college staff a simple desktop screen for every task.
Records are shown in DataGridViews, data is entered through normal Windows
Forms controls, and every database operation uses parameterized ADO.NET
queries.

---

## Features

- Dashboard with live totals (events, students, participants, certificates) and a list of upcoming events
- Event management with category and venue chosen from database-filled ComboBoxes
- Event category management
- Venue management with capacity validation
- Student registration
- Student search by name or email (parameterized `LIKE` query)
- Participant registration with duplicate registration blocked
- Participant management with filtering by event
- Attendance recording (Present / Absent) per event
- Certificate record management with unique certificate numbers
- Full CRUD (Create, Read, Update, Delete) on events, students, categories and venues
- JOIN queries everywhere, so grids show names instead of ID numbers
- Input validation with friendly messages
- Error handling that never shows raw SQL Server errors to the user
- Consistent Orchid Purple user interface

---

## Technology Used

| Item | Choice |
|---|---|
| Language | C# |
| Application type | Desktop |
| UI framework | Windows Forms |
| Target framework | .NET Framework 4.7.2 |
| Database | Microsoft SQL Server |
| Database access | ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataAdapter`, `DataTable`) |
| Data display | DataGridView |
| IDE | Visual Studio |

No ORM, no Entity Framework, no external NuGet packages.

---

## Requirements

1. Windows 10 or Windows 11
2. Visual Studio 2019 or 2022, with the **.NET desktop development** workload
3. .NET Framework 4.7.2 (or newer) developer pack
4. Microsoft SQL Server (Express edition is enough)
5. SQL Server Management Studio (SSMS)

---

## Database Setup

1. Open **SQL Server Management Studio** and connect to your SQL Server instance.
2. Open the file `Database/CollegeEventDB.sql`.
3. Make sure the database selected at the top of SSMS is `master`.
4. Press **Execute** (F5).

The script creates the `CollegeEventDB` database, all seven tables, the primary
keys, the foreign keys, the constraints, the indexes and the sample data.
It can be executed again at any time to reset the database.

---

## How to Run

1. Open `CollegeEventManagementSystem.sln` in Visual Studio.
2. Configure the connection string (next section).
3. Press **Build → Build Solution**.
4. Press **Start** (F5).

If the database cannot be reached, the application shows a clear message when
it starts instead of crashing.

---

## How to Configure the Connection String

The connection string is written in exactly one place:

```
CollegeEventManagementSystem/App.config
```

```xml
<add name="CollegeEventDB"
     connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=CollegeEventDB;Integrated Security=True;"
     providerName="System.Data.SqlClient" />
```

Change only the `Data Source` part to match your own SQL Server instance name:

| Situation | Value |
|---|---|
| SQL Server Express (default) | `.\SQLEXPRESS` |
| Default local instance | `(local)` or `localhost` |
| Named computer | `DESKTOP-ABC123` |

If your server uses a username and password instead of a Windows login:

```
Data Source=.\SQLEXPRESS;Initial Catalog=CollegeEventDB;User ID=sa;Password=yourpassword;
```

To find the instance name, open SSMS and look at the "Server name" box in the
connection dialog.

---

## Project Structure

```
CollegeEventManagementSystem/
│
├── CollegeEventManagementSystem.sln
│
├── CollegeEventManagementSystem/
│   ├── Forms/
│   │   ├── MainForm.cs              (header, sidebar, content area)
│   │   ├── DashboardForm.cs         (summary cards, upcoming events)
│   │   ├── EventForm.cs
│   │   ├── CategoryForm.cs
│   │   ├── VenueForm.cs
│   │   ├── StudentForm.cs           (registration + search)
│   │   ├── ParticipantForm.cs       (registration + management)
│   │   ├── AttendanceForm.cs
│   │   └── CertificateForm.cs
│   │
│   ├── Data/
│   │   └── DatabaseHelper.cs        (all ADO.NET connection logic)
│   │
│   ├── UI/
│   │   └── Theme.cs                 (all colours and control styling)
│   │
│   ├── Assets/                      (place logo.png here if available)
│   ├── Program.cs
│   ├── App.config                   (connection string)
│   └── CollegeEventManagementSystem.csproj
│
├── Database/
│   └── CollegeEventDB.sql
│
├── README.md
└── .gitignore
```

There is no `Models` folder. Query results are read straight into a `DataTable`
and bound to the DataGridView, which is the normal ADO.NET way of working, so
extra model classes would not be used by anything.

---

## Main Modules

| Module | Screen | What it does |
|---|---|---|
| Dashboard | `DashboardForm` | Totals from the database and the next events |
| Events | `EventForm` | Add, update, delete and list events |
| Categories | `CategoryForm` | Manage event categories |
| Venues | `VenueForm` | Manage venues and their capacity |
| Students | `StudentForm` | Register, update, delete and search students |
| Participants | `ParticipantForm` | Register students in events and manage those records |
| Attendance | `AttendanceForm` | Record Present / Absent per event |
| Certificates | `CertificateForm` | Manage certificate records |

---

## Database Tables

| Table | Primary key | Foreign keys |
|---|---|---|
| Categories | CategoryID | — |
| Venues | VenueID | — |
| Students | StudentID | — |
| Events | EventID | CategoryID → Categories, VenueID → Venues |
| Participants | ParticipantID | EventID → Events, StudentID → Students |
| Attendance | AttendanceID | ParticipantID → Participants |
| Certificates | CertificateID | ParticipantID → Participants |

Relationships:

```
Categories 1 ─── * Events
Venues     1 ─── * Events
Students   1 ─── * Participants
Events     1 ─── * Participants
Participants 1 ─ * Attendance
Participants 1 ─ * Certificates
```

Extra constraints:

- `UNIQUE (CategoryName)` — no two categories with the same name
- `CHECK (Capacity > 0)` — a venue cannot have zero or negative capacity
- `CHECK (Semester BETWEEN 1 AND 8)`
- `UNIQUE (EventID, StudentID)` — a student cannot register twice for one event
- `CHECK (Status IN ('Present','Absent'))`
- `UNIQUE (CertificateNo)` — certificate numbers are never repeated

---

## ADO.NET Implementation

All database work goes through `Data/DatabaseHelper.cs`:

| Method | Used for |
|---|---|
| `GetConnection()` | creates a `SqlConnection` from the App.config string |
| `GetDataTable(sql, parameters)` | SELECT queries — `SqlDataAdapter` fills a `DataTable` |
| `ExecuteNonQuery(sql, parameters)` | INSERT, UPDATE and DELETE |
| `ExecuteScalar(sql, parameters)` / `GetCount(...)` | single values such as `COUNT(*)` |
| `Param(name, value)` | builds a `SqlParameter`, storing empty text as NULL |
| `IsForeignKeyError(ex)` / `IsDuplicateError(ex)` | turns SQL error numbers 547, 2627 and 2601 into friendly messages |

Every query is parameterized. User input is never joined into the SQL text,
so SQL injection is not possible. Example from the student search:

```sql
SELECT StudentID, StudentName, Email, Phone, Program, Semester
FROM Students
WHERE StudentName LIKE @Search OR Email LIKE @Search
ORDER BY StudentName
```

---

## Testing

Test checklist used before submission. Every item was checked with the sample
data created by `CollegeEventDB.sql`.

**Categories**
- [ ] Add a category
- [ ] Add a category with an empty name (validation message appears)
- [ ] Add a duplicate category name (friendly duplicate message)
- [ ] Update a category
- [ ] Delete a category that has no events
- [ ] Delete a category used by an event (friendly relationship message)

**Venues**
- [ ] Add a venue
- [ ] Add a venue with capacity 0 or a negative number (validation message)
- [ ] Add a venue with text in the capacity box (validation message)
- [ ] Update a venue
- [ ] Delete a venue that has no events
- [ ] Delete a venue used by an event (friendly relationship message)

**Students**
- [ ] Register a student
- [ ] Register with an empty name (validation message)
- [ ] Register with an invalid email (validation message)
- [ ] Register with semester 0 or 12 (validation message)
- [ ] Search by part of a name
- [ ] Search by part of an email
- [ ] Search with no match (information message)
- [ ] Show All returns to the full list
- [ ] Update a student
- [ ] Delete a student who has no participant record
- [ ] Delete a student registered in an event (friendly relationship message)

**Events**
- [ ] Add an event
- [ ] Add without selecting a category or a venue (validation message)
- [ ] Category and Venue ComboBoxes are filled from the database
- [ ] Grid shows category and venue names, not ID numbers
- [ ] Select a row and the form fields are filled
- [ ] Update an event
- [ ] Delete an event with no participants
- [ ] Delete an event that has participants (friendly relationship message)

**Participants**
- [ ] Register a student in an event
- [ ] Register the same student in the same event again (duplicate message)
- [ ] Grid shows student name and event name
- [ ] Filter the list by one event
- [ ] Update a participant record
- [ ] Delete a participant with no attendance or certificate
- [ ] Delete a participant that has attendance or certificates (friendly message)

**Attendance**
- [ ] Choose an event and see its participants in the ComboBox
- [ ] Save attendance as Present
- [ ] Save attendance as Absent
- [ ] Save the same participant twice on the same date (duplicate message)
- [ ] Update an attendance record
- [ ] Delete an attendance record
- [ ] Choose an event with no participants (information message)

**Certificates**
- [ ] Add a certificate record
- [ ] Add with an empty certificate number (validation message)
- [ ] Add a duplicate certificate number (duplicate message)
- [ ] Update a certificate record
- [ ] Delete a certificate record

**General**
- [ ] The application starts and opens the dashboard
- [ ] Dashboard totals match the database
- [ ] Every sidebar button opens the correct screen
- [ ] Every DataGridView loads its records
- [ ] All grids are read-only (records cannot be edited directly in the grid)
- [ ] Clear resets the form on every screen
- [ ] A wrong connection string produces a clear message, not a crash
- [ ] Exit asks for confirmation

---

## Limitations

- The application does not have a login system, because user authentication was
  not part of the project scope.
- Certificates are stored as records only. The system does not print or generate
  PDF certificate files.
- The application is designed for a single computer connected to one SQL Server
  instance. It is not a client-server or web application.
- Reports are shown on screen only; there is no export to Excel or PDF.

---

## Future Enhancements

- User login with staff and administrator roles
- Printing and PDF generation of certificates
- Exporting event and attendance reports to Excel or PDF
- Event budget and expense tracking
- Email notification to registered participants
- Attendance summary charts per event

---

## Note about the logo

The header shows a clean `ORCHID COLLEGE` text placeholder. If the official
college logo image is available, save it as `Assets/logo.png` inside the project
and set its **Copy to Output Directory** property to **Copy if newer**. The
application then shows the image automatically. No imitation logo is included in
the project.
