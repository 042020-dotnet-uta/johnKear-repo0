--Create Table for Department with Primary ID, firstname, lastname, ssn and DeptId foreign key that references Department.ID

CREATE TABLE Department
(
  ID int NOT NULL PRIMARY KEY,
  Name varchar(255) NOT NULL,
  Location varchar(255),
);
GO

CREATE TABLE Employee
(
  ID int NOT NULL PRIMARY KEY,
  FirstName varchar(255) NOT NULL,
  LastName varchar(255) NOT NULL,
  SSN int,
  DeptID int FOREIGN KEY REFERENCES Department(ID),
);
GO

CREATE TABLE EmpDetails
(
  ID int NOT NULL PRIMARY KEY,
  EmployeeID int FOREIGN KEY REFERENCES Employee(ID),
  Salary float,
  Address1 varchar(255),
  Address2 varchar(255),
  City varchar(255),
  State varchar(255),
  Country varchar(255),
);
GO

--