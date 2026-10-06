-- Create the database
CREATE DATABASE CourseManagement;
USE CourseManagement;

-- Users Table (Admins, Instructors, and Students)
CREATE TABLE Users (
    UserID INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Password VARCHAR(255) NOT NULL, -- Plain text password
    Role ENUM('Admin', 'Instructor', 'Student') NOT NULL -- Defines user type
);

-- Students Table (Links to Users)
CREATE TABLE Students (
    StudentID INT PRIMARY KEY, -- Same as UserID
    FOREIGN KEY (StudentID) REFERENCES Users(UserID) ON DELETE CASCADE
);

-- Courses Table (Now linked to Instructors in Users Table)
CREATE TABLE Courses (
    CourseID INT AUTO_INCREMENT PRIMARY KEY,
    InstructorID INT NOT NULL, -- Now references Users instead of a separate Instructors table
    Title VARCHAR(100) NOT NULL,
    Description TEXT NULL,
    Duration INT NULL, -- Handled in application logic
    MaxCapacity INT NULL, -- Handled in application logic
    Syllabus TEXT NULL,
    FOREIGN KEY (InstructorID) REFERENCES Users(UserID) ON DELETE CASCADE
);

-- Enrollments Table (Many-to-Many: Students ↔ Courses)
CREATE TABLE Enrollments (
    EnrollmentID INT AUTO_INCREMENT PRIMARY KEY,
    StudentID INT NOT NULL,
    CourseID INT NOT NULL,
    Status ENUM('Pending', 'Approved', 'Rejected') DEFAULT 'Pending',
    EnrollmentDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID) ON DELETE CASCADE,
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID) ON DELETE CASCADE,
    UNIQUE (StudentID, CourseID) -- Prevent duplicate enrollments
);

-- Assignments Table
CREATE TABLE Assignments (
    AssignmentID INT AUTO_INCREMENT PRIMARY KEY,
    CourseID INT NOT NULL,
    Title VARCHAR(100) NOT NULL,
    Description TEXT NULL,
    DueDate DATETIME NULL, -- Handled in application logic
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID) ON DELETE CASCADE
);

-- Submissions Table
CREATE TABLE Submissions (
    SubmissionID INT AUTO_INCREMENT PRIMARY KEY,
    StudentID INT NOT NULL,
    AssignmentID INT NOT NULL,
    SubmissionDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    FilePath VARCHAR(255) NOT NULL, -- Path to submitted file
    Grade DECIMAL(5,2) NULL, -- Handled in application logic
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID) ON DELETE CASCADE,
    FOREIGN KEY (AssignmentID) REFERENCES Assignments(AssignmentID) ON DELETE CASCADE,
    UNIQUE (StudentID, AssignmentID) -- Prevent multiple submissions
);

-- Insert Sample Data
INSERT INTO Users (FirstName, LastName, Email, Password, Role) VALUES
('Admin', 'User', 'admin@example.com', 'admin123', 'Admin'),
('John', 'Doe', 'johndoe@example.com', 'password123', 'Instructor'),
('Jane', 'Smith', 'janesmith@example.com', 'password123', 'Student'),
('Alice', 'Brown', 'alicebrown@example.com', 'password123', 'Student');

-- Link Students to Users
INSERT INTO Students (StudentID) VALUES
(3), (4); -- StudentID matches UserID

-- Insert Sample Courses (Assigned to Instructor)
INSERT INTO Courses (InstructorID, Title, Description, Duration, MaxCapacity, Syllabus) VALUES
(2, 'Introduction to Programming', 'Learn programming basics.', 10, 50, 'Week 1: Basics\nWeek 2: Loops...'),
(2, 'Database Management', 'Covers SQL and database concepts.', 8, 40, 'Week 1: SQL Basics\nWeek 2: Joins...');

-- Insert Sample Enrollments (Pending/Approved)
INSERT INTO Enrollments (StudentID, CourseID, Status) VALUES
(3, 1, 'Approved'), -- Jane Smith in "Introduction to Programming"
(4, 2, 'Pending');  -- Alice Brown in "Database Management"

-- Insert Sample Assignments
INSERT INTO Assignments (CourseID, Title, Description, DueDate) VALUES
(1, 'Project 1', 'Create a simple C# application.', '2025-03-15'),
(2, 'SQL Query Assignment', 'Write SQL queries for given problems.', '2025-03-20');

-- Insert Sample Submissions (Jane submitted, Alice hasn't yet)
INSERT INTO Submissions (StudentID, AssignmentID, FilePath, Grade) VALUES
(3, 1, 'submissions/jane_project1.pdf', 85.50);
