---- Table Creation -----
	
	CREATE TABLE Employees(

	   EmployeeId INT PRIMARY KEY,
	   Name VARCHAR(100) NOT NULL,
	   Salary INT CHECK (Salary > 15000),
	   HireDate DATE, 
	   DepartmentId INT FOREIGN KEY(DepartmentId)
	   REFERENCES Departments(DepartmentId)

	);

	CREATE TABLE Departments(

	  DepartmentId INT PRIMARY KEY,
	  DepartmentName VARCHAR(100) UNIQUE NOT NULL 
	);


---- Execute Queries To See The Task Result

	---Alter Table & Comstraint

		-- Task1 --
		ALTER TABLE Employees
		ADD Email VARCHAR(100) UNIQUE;

		-- Task2 --
		ALTER TABLE Employees
		ADD IsActive BIT DEFAULT(1);

		-- Task3 --
		ALTER TABLE Employees
		DROP CONSTRAINT CK__Employees__Salar__65370702 

		ALTER TABLE Employees
		ALTER COLUMN Salary DECIMAL(10,2) 

		-- Task4 --
		ALTER TABLE Employees
		ADD CONSTRAINT  HireDate CHECK(HireDate <= GETUTCDATE());  




	----DML----

		---Task1---
		INSERT INTO Departments
		(DepartmentId,DepartmentName)
		VALUES
		(1,'HR'),
		(2,'IT'),
		(3,'PRODUCTION'),
		(4,'MARKETING'),
		(5,'SALES');

		INSERT INTO Employees
		(EmployeeId,Name,Email,Salary,HireDate,DepartmentId)
		VALUES
		(1, 'Amit Sharma', 'amit.sharma@company.com',  55000.00, '2020-01-15',2),
		(2, 'Neha Patel', 'neha.patel@company.com', 48000.00, '2019-03-10',2),
		(3, 'Rohit Verma', 'rohit.verma@company.com', 62000.00, '2018-07-25',5),
		(4, 'Priya Mehta', 'priya.mehta@company.com', 51000.00, '2021-02-05',3),
		(5, 'Rahul Singh', 'rahul.singh@company.com', 45000.00, '2022-04-12',4),
		(6, 'Kiran Joshi', 'kiran.joshi@company.com', 58000.00, '2020-06-20',5),
		(7, 'Anjali Desai', 'anjali.desai@company.com', 47000.00, '2019-09-18',2),
		(8, 'Vikas Gupta', 'vikas.gupta@company.com', 63000.00, '2017-11-30',2),
		(9, 'Sneha Iyer', 'sneha.iyer@company.com',  52000.00, '2021-08-14',1);

		select * from Employees;

		--- Task2 ---
		UPDATE Employees 
		SET Salary = Salary + Salary*0.05 WHERE DepartmentId = 1;

		--- Task3 ---
		UPDATE Employees
		SET IsActive = 0 WHERE HireDate < '2019-01-20';

		--- Task4 ---
		DELETE FROM  Employees
		WHERE IsActive = 0;

		--- Task5 ---
		UPDATE Employees
		SET DepartmentID = 5 WHERE EmployeeID IN (2,3);



	---- Joins ----

		---  Task1 ---

		SELECT e.Name,e.Salary,e.HireDate,e.Email,d.DepartmentName FROM Employees e 
		inner join Departments d
		ON e.DepartmentId=d.DepartmentId;

		--- Task2 ---
		INSERT INTO Departments
		(DepartmentId,DepartmentName)
		Values
		(6,'RESEARCH'),
		(7,'FINANCE');

		SELECT d.DepartmentName FROM Departments d 
		LEFT JOIN Employees e
		ON d.DepartmentId = e.DepartmentId
		WHERE e.DepartmentId IS NULL;


		--- Task3 ---
		select DepartmentName , Salary from (select DepartmentId, Max(Salary) as Salary from Employees
		Group by DepartmentId) as e
		RIGHT JOIN Departments d 
		on d.DepartmentId = e.DepartmentId

