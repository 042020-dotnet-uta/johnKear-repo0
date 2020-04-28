-- add at least 3 records into each table.
-- add department Marketing
INSERT INTO Department (Name, Location)
VALUES ('Marketing', '406 Oklahoma St.
Teaneck, NJ 07666'), ('Billing', '406 Oklahoma St.
Teaneck, NJ 07666'), ('Human Resources', '406 Oklahoma St.
Teaneck, NJ 07666');

-- add employee Tina Smith
INSERT INTO Employee (FirstName, LastName, SSN, DeptID)
VALUES ('Tina', 'Smith', '123-45-6789', (SELECT ID FROM Department WHERE Name = 'Marketing')), 
('John', 'Kear', '987-65-4321', (SELECT ID FROM Department WHERE Name = 'Billing')), 
('Arthur', 'Pendragon', '789-56-4321', (SELECT ID FROM Department WHERE Name = 'Human Resources'));


INSERT INTO EmpDetails (EmployeeID, Salary, Address1, City, State, Country)
VALUES ((SELECT ID FROM Employee WHERE FirstName = 'Tina'), 45000, '7174 Bridge Ave.', 'Wethersfield', 'Conneticut', '06109'),
((SELECT ID FROM Employee WHERE FirstName = 'John'), 35000, '727 Valley Dr.', 'Neptune', 'New Jersey', '07753'),
((SELECT ID FROM Employee WHERE FirstName = 'Arthur'), 45000, '7174 Bridge Ave.', 'Wethersfield', 'Conneticut', '06109');

-- list all employees in Marketing
SELECT * FROM Employee WHERE DeptID = (SELECT ID FROM Department WHERE Name = 'Marketing');

-- report total salary of marketing
SELECT SUM(Salary) AS 'Marketing Salaries' FROM EmpDetails WHERE EmployeeID = (SELECT ID FROM Employee WHERE DeptID = (SELECT ID FROM Department WHERE Name = 'Marketing'))

-- report total employees by department.
SELECT
	d.Name,
	COUNT(*) headcount
FROM
	Employee e
INNER JOIN Department d ON d.ID = e.DeptID 
GROUP BY
	d.Name ORDER BY d.Name ASC;

-- increase salary of Tina Smith to $90,000
UPDATE EmpDetails 
SET Salary = 90000
Where EmployeeID = (SELECT ID FROM Employee WHERE FirstName = 'Tina') 
SELECT Salary FROM EmpDetails WHERE EmployeeID = (SELECT ID FROM Employee WHERE FirstName = 'Tina');