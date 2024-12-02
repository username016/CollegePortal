Project Disterbution:


1.)CollegePoratal.Entities
Models -> Mohammed 

2.)CollegePortal.Operations

controllers-> ayat (corrections done by ding and mohammed as shown in git)
datalayer -> mohmammed
views-> ding (student views done by ayat)

3.)CollegePortal.Services
DbContext -> mohammed
migrations -> mohammed
repositories and implentations -> mohammed (tutor repository and implementation done by ayat)

What does everything do?
1. CollegePortal.Entities
Models
GymRoomBookings.cs, LostAndFound.cs, Student.cs, StudyRoomBookings.cs, TutorBookings.cs: These are model classes that define the structure of data objects used throughout the application. They represent entities such as gym room bookings, lost and found items, students, study room bookings, and tutor bookings.
2. CollegePortal.Operations
Controllers

GymRoomController.cs, HomeController.cs, LFController.cs, LoginController.cs, StudentController.cs, StudyRoomController.cs, TutorController.cs: These are controllers that handle HTTP requests, process user input, and return views or API responses. Each controller corresponds to a specific part of the application (e.g., gym room management, lost and found, login).
DataLayer

CollegePortal.db, CollegePortal.db-shm, CollegePortal.db-wal: These files are part of the SQLite database. The .db file stores the main database, while .shm and .wal files are used for database transactions and performance optimizations.
Models

ErrorViewModel.cs: Likely used to represent error information for displaying user-friendly error messages in the views.
LoginModel.cs: Likely used to handle login-related data, such as username and password.
Views

GymViews, LFViews, StudentViews, StudyRoomViews, TutorViews: These folders contain Razor views (HTML templates with embedded C# code) for displaying data and user interfaces for each module.
AllBookings.cshtml, Login.cshtml: Specific Razor views for displaying all bookings and the login page, respectively.
Shared

_ViewImports.cshtml, _ViewStart.cshtml: Common Razor files. _ViewImports.cshtml is used to import namespaces and directives, while _ViewStart.cshtml sets layout files for views.
Properties

Project settings like assembly information and other metadata.
Program.cs

This file is the entry point of the application. It configures and starts the application.
3. CollegePortal.Services
DbContext
Used for interacting with the database through Entity Framework Core. It manages entities, querying, saving, and migrations.
Migrations
Contains database migration files, which represent changes to the database schema.
Repositories and Implementations
Likely includes classes for implementing the repository pattern. These are used to abstract data access logic from controllers and services.
Miscellaneous
GuideForDevs.txt, MeetingLogs.txt, readme.txt: Documentation files for the development team, possibly containing setup instructions, development guidelines, and meeting notes.
Let me know if you'd like a detailed explanation or assistance with specific parts!











