# College Event Management System (CEMS)

A desktop application for managing college events, built as a group project (Group 10).

## Technology Stack
- **Language:** C#
- **UI Framework:** Windows Forms
- **Data Access:** ADO.NET (SqlConnection, SqlCommand, SqlDataAdapter, DataTable)
- **Database:** Microsoft SQL Server
- **Theme:** Orchid Purple

## Team — Group 10
| Member | Responsibility |
|---|---|
| Samikshya Saud | Project Lead — Student Registration & Search, integration, testing |
| Samriddha Poudel | Database (SQL Server), ADO.NET DatabaseHelper, Category & Venue modules |
| Sajan Shrestha | Event Management, Participant Management |
| Samir Khatri | Attendance, Certificate Records, Dashboard |

## Modules
1. Dashboard — summary counts + upcoming events
2. Event Management
3. Category Management
4. Venue Management
5. Student Registration & Search
6. Participant Management
7. Attendance Tracking
8. Certificate Records

## Database
7 tables with proper primary keys, foreign keys, unique and check constraints:
Categories, Venues, Students, Events, Participants, Attendance, Certificates.

Script location: Database/CollegeEventDB.sql

## Setup Instructions
1. Install SQL Server (Express edition is enough) and SQL Server Management Studio (SSMS).
2. Open Database/CollegeEventDB.sql in SSMS and execute it (F5). This creates the CollegeEventDB database with sample data.
3. Open CollegeEventManagementSystem.sln in Visual Studio.
4. Check App.config — the connection string's Data Source must match your local SQL Server instance name (default: .\SQLEXPRESS).
5. Build and run the project (F5).

## Project Structure
CollegeEventManagementSystem/
- Forms/  -> All UI forms (one per module)
- Data/   -> DatabaseHelper.cs (central ADO.NET logic)
- UI/     -> Theme.cs (Orchid Purple styling)
- Assets/ -> Logo and images
- Program.cs -> Application entry point

## Key Features
- Full CRUD on all modules
- Parameterized SQL queries (SQL injection safe)
- Foreign key and duplicate-entry error handling
- Search functionality (Student search by name/email)
- Dashboard with live database summary
