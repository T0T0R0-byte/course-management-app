# Course Management App

![Language: C#](https://img.shields.io/badge/Language-C%23-239120)
![.NET 6](https://img.shields.io/badge/.NET-6.0-512BD4)
![UI: WinForms](https://img.shields.io/badge/UI-WinForms-blue)
![Database: MySQL](https://img.shields.io/badge/Database-MySQL-4479A1)
![License: MIT](https://img.shields.io/badge/License-MIT-green)

A Windows desktop application for running courses end to end: users and roles, course catalogue,
enrollments with approval, assignments, and grades. Three roles get their own dashboard - admin,
instructor, student - and the app routes you to the right one after sign-in.

Built as first-year coursework for a systems development and analysis module: take a system from
requirements through analysis, design and a working database-backed implementation.

## What it does

| Role | Capabilities |
|---|---|
| **Admin** | Create and manage users, courses and enrollments; approve or reject enrollment requests; reports over users, courses and enrollments |
| **Instructor** | Add assignments to their own courses; assign grades to student submissions; view students enrolled in their courses |
| **Student** | Browse available courses, enroll (lands as a pending request), view enrolled courses and their grades |

Sign-in is a single query against `Users` on email plus password; the returned role decides which
dashboard opens and what that user can reach afterwards.

## Architecture

| Layer | Files | Responsibility |
|---|---|---|
| Entry point | `Program.cs` | Starts `LoginForm` |
| Forms (UI) | `LoginForm`, `RegisterForm`, `*Dashboard`, `Manage*Form`, `AssignGradesForm`, `ReportsForm`, `View*Form` | Presentation and user actions; no SQL |
| Managers | `UserManager`, `CourseManager`, `EnrollmentManager`, `AssignmentManager`, `InstructorManager`, `StudentManager`, `AdminManager`, `ReportManager` | All database access, one class per entity |
| Models | `User`, `Admin`, `Instructor`, `Student`, `Course`, `Enrollment`, `Assignment` | Plain data classes |
| Data access | `DatabaseHelper` | Single MySQL connection, `ExecuteQuery` with parameters, `DataTable` results |

Every statement in the managers is parameterised (`@Email`, `@Password`, `@CourseID`, ...) rather than
built by string concatenation, so the SQL-injection surface is closed by construction.

## Database

Six tables, defined in [`database/schema.sql`](database/schema.sql) with sample data included:

| Table | Purpose |
|---|---|
| `Users` | All accounts; role is an `ENUM('Admin','Instructor','Student')` |
| `Students` | Extends a user row whose role is student (1:1 on `UserID`) |
| `Courses` | Course details, owned by an instructor via `InstructorID` |
| `Enrollments` | Many-to-many student to course, with `Status` of `Pending`/`Approved`/`Rejected` and a `UNIQUE (StudentID, CourseID)` guard against duplicates |
| `Assignments` | Assignments belonging to a course, with a due date |
| `Submissions` | One row per student per assignment (`UNIQUE`), holding file path and grade |

## Running it

```bash
mysql -u root -p < database/schema.sql        # creates the CourseManagement database + demo data
```

Then open `src/CourseManagementApp.sln` in Visual Studio 2022 (or build the project directly with the
.NET 6 SDK), point the connection string in `src/CourseManagementApp/DatabaseHelper.cs` at your MySQL
instance, and run. The form that opens is the login screen; the schema seeds `admin@example.com`,
`johndoe@example.com` and two student accounts so you can see each dashboard. Those credentials are
local demo data, not real accounts.

## Known limitations

Called out honestly rather than left as traps for the next person:

- **Passwords are stored and compared in plaintext.** The schema says so in a column comment, and the
  login query compares the raw string. Fine for a first-year exercise, not for anything real, where
  this needs a salted hash.
- **The connection string is hardcoded** in `DatabaseHelper.cs` with an empty root password.
- **Database errors are swallowed**: `ExecuteQuery` catches exceptions, writes them to the console and
  returns an empty table, so a failure can look like "no results".
- **No automated tests.** Verification was manual, clicking through each role's screens.
- **Some CRUD logic is repeated across forms** rather than funnelled through one repository layer.

## Credits

Solo coursework: **Faraj Farook** (CB012653). Built for a first-year systems development and analysis
module.

## License

MIT, see [LICENSE](LICENSE).
