# Academy management application

This project is intended for management of an academy consisting of the following sections:

1. Academy 
   - Name and description of Learning Academy (Web Design, Online Marketing, Front-End Development)
   - Every academy has list of Subjects for their area 
   
2. Academy Year Program - yearly occurences of selected academy in date range
   - List of days that are non-working
      - EventType : Public Holiday or Closed Day
   - Current status of activity
   - Groups with members as students and mentors
   
3. Users management
   - Creating new user as:
      - username formatted as 'firstname.lastname'
      - e-mail provided by user
      password is generated and credentials are sent to user's email with activation link

4. Roles of users
   - Administrator
   - Academy Employee
   - Mentor
   - Student
   
   The Administrator would manage users, roles, classrooms, category of ratings;
   The Academy Employee would manage the academy year program with the groups, mentors, students;
   and the Mentor would manage details of the current teaching program, ratings, schedules.
   
5. Managing groups of students and mentors for every academy year program
   - List of Mentors - every group can have multiple mentors with types:
      - Trainer
      - CoTrainer and
      - Assistant
   - List of Students
   
6. Rating for Category and Subcategory
   - Categories: subject, project, exam, test
   - Subcategories: subject (regularity, activity, homework), project (topic, preparation, presentation), exam and test (different segments)
   
7. Schedules
   - different groups in an academy year program with same subjects would have classes in different classrooms and datetime, excluded non-working days within period

> For each academy program year, there should be different data for students, mentors, subjects...

8. Mentor dashboard
9. Student dashboard


## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- Download and install NodeJs
- Install TypeScript
```
npm install typings -g
```
- Make sure that you have .NetCore 3.1.0 installed on your machine

**Install libraries**
* npm install / npm update

* Visual Studio 2019 or above
* Visual Studio Code

### Parameters
 - In appsettings.json file add your data for Smtp email and pass, connection string, and client urls
