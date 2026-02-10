use SQLTRAINING
--- before performing a task do some required operations ,like Modified the previous Employee Table
	

	-- Create Department Table
	Create Table Department(
	  DepartmentId Int Primary Key,
	  DepartmentName Varchar(500)
	);

	-- Insert Value to appropriate Fields
	insert into Department(DepartmentId,DepartmentName)
	Values (1,'IT'),
	(2,'HR'),
	(3,'Sales'),
	(4,'Finance'),
	(5,'Marketing');

	-- Add DepartmentID Field to the Employee
	ALTER TABLE Employee
	ADD  DepartmentID int 
	foreign key(DepartmentID)
	references  Department(DepartmentID);

	-- Fill The DepartmentID Field with proper values
	update Employee
	set DepartmentId =
	case
		when Department = 'IT' then 1
		when Department = 'HR' then 2
		when Department = 'Sales' then 3
		when Department = 'Finance' then 4
	else 5
	end ;

	-- Remove the Department Table which state the name of Department in Employee
	Alter table Employee
	Drop column Department;

	--First Make Normal EmployeeID as Not Null
	alter table Employee
	alter column EmployeeID int Not Null;

	-- Then Make EmployeeID as a Primary Key 
	alter table Employee
	add constraint PK_Employee primary key (EmployeeID);


---Create a view named vw_EmployeeBasicInfo that displays:
	

	create view vw_EmployeeBasicInfo AS
	select 
	   EmployeeID ,
	   CONCAT(FirstName,' ',LastName) AS fullname ,
	   DepartmentID
	from Employee ;

	select * from vw_EmployeeBasicInfo;


---Create a CTE that fetches only Finance department employees and then select data from that CTE.


	WITH FetchFinanceEmployee As
	(
	  select e.FirstName,e.LastName,e.Email ,e.Salary,e.DateOfJoining,d.DepartmentName from Employee e
	  join Department d
	  on e.DepartmentID=d.DepartmentID where d.DepartmentName='Finance'
	) select * from FetchFinanceEmployee;


---Create a local temporary table that stores only HR employees and select data from TempTable.


	create table  #HREmployee(
	   EmployeeId Int Primary key,
	   FirstName Varchar(50),
	   LastName Varchar(50),
	   Email Varchar(500),
	   Salary Decimal(10,2),
	   DateOfJoining Date,
	   DepartmentID int,
	   foreign key (DepartmentID)  
	   references Department(DepartmentID)
	);

	insert into #HREmployee
	select * from Employee where DepartmentID=2;
	
	select * from #HREmployee;



---Create an Employee Table with appropriate columns. Create a Skill Table with  appropriate columns. Write a query to fetch employees who have more than one entry in EmployeeSkill.


	CREATE TABLE  Skills(
  
	   SkillID int,
	   SkillName Varchar(200)
	);

	INSERT INTO Skills(SkillID,SkillName) 
	values(1,'Coding'),
	(2,'Singing'),
	(3,'Listening'),
	(4,'Music'),
	(5,'Playing');

	CREATE TABLE EmployeeSkill(

	 EmployeeID int ,
	 SkillID int,
	);

	insert  into EmployeeSkill(EmployeeID,SkillID)
	values (1,1),
	(1,3),
	(1,2),
	(2,3),
	(2,4),
	(4,3),
	(6,1),
	(8,2);

	select * from Employee where EmployeeID in (select EmployeeID from EmployeeSkill 
	group by EmployeeID
	having Count(*)  > 1);




--Define primary key, foreign key and unique key for tables.


	-- make first field Not Null 
	alter table Skills
	alter column SkillID int Not Null;

	-- Then define it as Primary Key 
	alter table Skills 
	add constraint PK_Skills primary key (SkillID);

	-- first define Foreign Key 
	alter table EmployeeSkill
	add constraint FK_EmployeeID Foreign key (EmployeeID)
	references Employee(EmployeeID);

	-- fisrt define Foreign Key
	alter table EmployeeSkill
	add constraint FK_SkillID Foreign key (SkillID)
	references Skills(SkillID);

	-- Then define this both combine as Primary Key 
	alter table EmployeeSkill
	add constraint PK_EmployeeSkill primary key (EmployeeID,SkillID);

