USE SQLTRAINING;

---CREATE TABLE Employee(
--- EmployeeID INT,
--- FirstName VARCHAR(50),
--- LastName VARCHAR(50),
--- Email VARCHAR(100),
--- Department VARCHAR(50),
--- Salary DECIMAL(10,2),
--- DateOfJoining DATE
--- )






INSERT INTO Employee (EmployeeID, FirstName, LastName, Email, Department, Salary, DateOfJoining) VALUES
(1, 'Amit', 'Sharma', 'amit.sharma@company.com', 'IT', 55000.00, '2020-01-15'),
(2, 'Neha', 'Patel', 'neha.patel@company.com', 'HR', 48000.00, '2019-03-10'),
(3, 'Rohit', 'Verma', 'rohit.verma@company.com', 'Finance', 62000.00, '2018-07-25'),
(4, 'Priya', 'Mehta', 'priya.mehta@company.com', 'Marketing', 51000.00, '2021-02-05'),
(5, 'Rahul', 'Singh', 'rahul.singh@company.com', 'Sales', 45000.00, '2022-04-12'),
(6, 'Kiran', 'Joshi', 'kiran.joshi@company.com', 'IT', 58000.00, '2020-06-20'),
(7, 'Anjali', 'Desai', 'anjali.desai@company.com', 'HR', 47000.00, '2019-09-18'),
(8, 'Vikas', 'Gupta', 'vikas.gupta@company.com', 'Finance', 63000.00, '2017-11-30'),
(9, 'Sneha', 'Iyer', 'sneha.iyer@company.com', 'Marketing', 52000.00, '2021-08-14'),
(10, 'Arjun', 'Rao', 'arjun.rao@company.com', 'Sales', 46000.00, '2022-01-19'),
(11, 'Manish', 'Kumar', 'manish.kumar@company.com', 'IT', 60000.00, '2019-05-22'),
(12, 'Pooja', 'Nair', 'pooja.nair@company.com', 'HR', 49000.00, '2020-10-03'),
(13, 'Suresh', 'Yadav', 'suresh.yadav@company.com', 'Finance', 65000.00, '2018-02-11'),
(14, 'Rina', 'Chopra', 'rina.chopra@company.com', 'Marketing', 53000.00, '2021-12-01'),
(15, 'Kunal', 'Malhotra', 'kunal.malhotra@company.com', 'Sales', 47000.00, '2022-06-07'),
(16, 'Deepak', 'Agarwal', 'deepak.agarwal@company.com', 'IT', 61000.00, '2019-08-29'),
(17, 'Meera', 'Kulkarni', 'meera.kulkarni@company.com', 'HR', 50000.00, '2020-04-16'),
(18, 'Nikhil', 'Bansal', 'nikhil.bansal@company.com', 'Finance', 67000.00, '2017-09-09'),
(19, 'Aarti', 'Kapoor', 'aarti.kapoor@company.com', 'Marketing', 54000.00, '2021-03-27'),
(20, 'Sanjay', 'Khanna', 'sanjay.khanna@company.com', 'Sales', 48000.00, '2022-09-02'),
(21, 'Rakesh', 'Mishra', 'rakesh.mishra@company.com', 'IT', 62000.00, '2018-12-14'),
(22, 'Sunita', 'Goyal', 'sunita.goyal@company.com', 'HR', 51000.00, '2020-07-06'),
(23, 'Pankaj', 'Srivastava', 'pankaj.srivastava@company.com', 'Finance', 68000.00, '2017-04-23'),
(24, 'Nisha', 'Saxena', 'nisha.saxena@company.com', 'Marketing', 55000.00, '2021-06-18'),
(25, 'Varun', 'Tiwari', 'varun.tiwari@company.com', 'Sales', 49000.00, '2022-11-11'),
(26, 'Ajay', 'Pandey', 'ajay.pandey@company.com', 'IT', 63000.00, '2019-01-08'),
(27, 'Kavita', 'Bhatt', 'kavita.bhatt@company.com', 'HR', 52000.00, '2020-05-30'),
(28, 'Mohit', 'Chandra', 'mohit.chandra@company.com', 'Finance', 69000.00, '2016-10-21'),
(29, 'Ritu', 'Aggarwal', 'ritu.aggarwal@company.com', 'Marketing', 56000.00, '2021-09-15'),
(30, 'Abhishek', 'Arora', 'abhishek.arora@company.com', 'Sales', 50000.00, '2023-01-05'),
(31, 'Sandeep', 'Jain', 'sandeep.jain@company.com', 'IT', 64000.00, '2018-03-19'),
(32, 'Pallavi', 'Ghosh', 'pallavi.ghosh@company.com', 'HR', 53000.00, '2020-11-22'),
(33, 'Rajesh', 'Malik', 'rajesh.malik@company.com', 'Finance', 70000.00, '2016-06-10'),
(34, 'Tanya', 'Kohli', 'tanya.kohli@company.com', 'Marketing', 57000.00, '2021-04-09'),
(35, 'Ankit', 'Suri', 'ankit.suri@company.com', 'Sales', 51000.00, '2023-02-14'),
(36, 'Vinod', 'Rana', 'vinod.rana@company.com', 'IT', 65000.00, '2017-12-03'),
(37, 'Rekha', 'Mathur', 'rekha.mathur@company.com', 'HR', 54000.00, '2020-02-28'),
(38, 'Ashish', 'Goel', 'ashish.goel@company.com', 'Finance', 71000.00, '2016-08-16'),
(39, 'Swati', 'Bajaj', 'swati.bajaj@company.com', 'Marketing', 58000.00, '2021-07-04'),
(40, 'Naveen', 'Puri', 'naveen.puri@company.com', 'Sales', 52000.00, '2023-03-21'),
(41, 'Gaurav', 'Sethi', 'gaurav.sethi@company.com', 'IT', 66000.00, '2018-05-17'),
(42, 'Preeti', 'Arvind', 'preeti.arvind@company.com', 'HR', 55000.00, '2020-09-01'),
(43, 'Harish', 'Saxena', 'harish.saxena@company.com', 'Finance', 72000.00, '2015-11-26'),
(44, 'Monika', 'Talwar', 'monika.talwar@company.com', 'Marketing', 59000.00, '2021-10-13'),
(45, 'Rohan', 'Batra', 'rohan.batra@company.com', 'Sales', 53000.00, '2023-04-06'),
(46, 'Suresh', 'Patil', 'suresh.patil@company.com', 'IT', 67000.00, '2017-01-20'),
(47, 'Kritika', 'Shetty', 'kritika.shetty@company.com', 'HR', 56000.00, '2020-12-08'),
(48, 'Manoj', 'Deshpande', 'manoj.deshpande@company.com', 'Finance', 73000.00, '2015-03-14'),
(49, 'Isha', 'Choudhary', 'isha.choudhary@company.com', 'Marketing', 60000.00, '2022-01-29'),
(50, 'Akash', 'Thakur', 'akash.thakur@company.com', 'Sales', 54000.00, '2023-05-18'),
(51, 'Ravi', 'Kulkarni', 'ravi.kulkarni@company.com', 'IT', 68000.00, '2018-06-23'),
(52, 'Shilpa', 'Reddy', 'shilpa.reddy@company.com', 'HR', 57000.00, '2021-03-11'),
(53, 'Nitin', 'Joshi', 'nitin.joshi@company.com', 'Finance', 74000.00, '2016-09-07'),
(54, 'Anita', 'Bose', 'anita.bose@company.com', 'Marketing', 61000.00, '2022-02-20'),
(55, 'Vivek', 'Menon', 'vivek.menon@company.com', 'Sales', 55000.00, '2023-06-09'),
(56, 'Prakash', 'Naik', 'prakash.naik@company.com', 'IT', 69000.00, '2017-04-15'),
(57, 'Smita', 'Pawar', 'smita.pawar@company.com', 'HR', 58000.00, '2021-07-27'),
(58, 'Dinesh', 'Kulkarni', 'dinesh.kulkarni@company.com', 'Finance', 75000.00, '2015-01-19'),
(59, 'Neelam', 'Sood', 'neelam.sood@company.com', 'Marketing', 62000.00, '2022-05-03'),
(60, 'Yogesh', 'Rawat', 'yogesh.rawat@company.com', 'Sales', 56000.00, '2023-07-16'),
(61, 'Ramesh', 'Bhat', 'ramesh.bhat@company.com', 'IT', 70000.00, '2018-09-12'),
(62, 'Kiran', 'Malik', 'kiran.malik@company.com', 'HR', 59000.00, '2021-10-25'),
(63, 'Sanjiv', 'Nanda', 'sanjiv.nanda@company.com', 'Finance', 76000.00, '2016-12-05'),
(64, 'Alka', 'Mishra', 'alka.mishra@company.com', 'Marketing', 63000.00, '2022-08-14'),
(65, 'Tarun', 'Ahuja', 'tarun.ahuja@company.com', 'Sales', 57000.00, '2023-08-30'),
(66, 'Mahesh', 'Iyer', 'mahesh.iyer@company.com', 'IT', 71000.00, '2017-11-09'),
(67, 'Anu', 'Chatterjee', 'anu.chatterjee@company.com', 'HR', 60000.00, '2021-01-06'),
(68, 'Rohit', 'Kohli', 'rohit.kohli@company.com', 'Finance', 77000.00, '2015-07-28'),
(69, 'Seema', 'Bansal', 'seema.bansal@company.com', 'Marketing', 64000.00, '2022-09-19'),
(70, 'Nikhil', 'Jha', 'nikhil.jha@company.com', 'Sales', 58000.00, '2023-09-11'),
(71, 'Anand', 'Rao', 'anand.rao@company.com', 'IT', 72000.00, '2018-02-04'),
(72, 'Ritu', 'Chauhan', 'ritu.chauhan@company.com', 'HR', 61000.00, '2021-04-22'),
(73, 'Vijay', 'Sethi', 'vijay.sethi@company.com', 'Finance', 78000.00, '2016-05-17'),
(74, 'Poonam', 'Khandelwal', 'poonam.khandelwal@company.com', 'Marketing', 65000.00, '2022-11-08'),
(75, 'Saurabh', 'Dwivedi', 'saurabh.dwivedi@company.com', 'Sales', 59000.00, '2023-10-03'),
(76, 'Narendra', 'Verma', 'narendra.verma@company.com', 'IT', 73000.00, '2017-06-21'),
(77, 'Megha', 'Shukla', 'megha.shukla@company.com', 'HR', 62000.00, '2021-06-29'),
(78, 'Ajit', 'Kapoor', 'ajit.kapoor@company.com', 'Finance', 79000.00, '2015-10-12'),
(79, 'Rashmi', 'Lal', 'rashmi.lal@company.com', 'Marketing', 66000.00, '2022-12-15'),
(80, 'Karthik', 'Subramanian', 'karthik.subramanian@company.com', 'Sales', 60000.00, '2023-11-27'),
(81, 'Umesh', 'Pandit', 'umesh.pandit@company.com', 'IT', 74000.00, '2018-07-08'),
(82, 'Sonal', 'Joshi', 'sonal.joshi@company.com', 'HR', 63000.00, '2021-09-14'),
(83, 'Hemant', 'Arora', 'hemant.arora@company.com', 'Finance', 80000.00, '2016-01-25'),
(84, 'Geeta', 'Mahajan', 'geeta.mahajan@company.com', 'Marketing', 67000.00, '2023-01-09'),
(85, 'Pranav', 'Nair', 'pranav.nair@company.com', 'Sales', 61000.00, '2024-02-18'),
(86, 'Shankar', 'Das', 'shankar.das@company.com', 'IT', 75000.00, '2017-08-30'),
(87, 'Lata', 'Gupta', 'lata.gupta@company.com', 'HR', 64000.00, '2021-11-05'),
(88, 'Amitabh', 'Mukherjee', 'amitabh.mukherjee@company.com', 'Finance', 81000.00, '2015-04-17'),
(89, 'Nandini', 'Roy', 'nandini.roy@company.com', 'Marketing', 68000.00, '2023-03-22'),
(90, 'Dev', 'Malhotra', 'dev.malhotra@company.com', 'Sales', 62000.00, '2024-04-01'),
(91, 'Kailash', 'Tripathi', 'kailash.tripathi@company.com', 'IT', 76000.00, '2018-10-16'),
(92, 'Anupama', 'Sen', 'anupama.sen@company.com', 'HR', 65000.00, '2022-01-12'),
(93, 'Rajat', 'Sinha', 'rajat.sinha@company.com', 'Finance', 82000.00, '2016-03-03'),
(94, 'Bhavana', 'Menon', 'bhavana.menon@company.com', 'Marketing', 69000.00, '2023-05-29'),
(95, 'Keshav', 'Sharma', 'keshav.sharma@company.com', 'Sales', 63000.00, '2024-06-14'),
(96, 'Mohan', 'Pillai', 'mohan.pillai@company.com', 'IT', 77000.00, '2017-02-07'),
(97, 'Rupal', 'Deshmukh', 'rupal.deshmukh@company.com', 'HR', 66000.00, '2022-04-20'),
(98, 'Aditya', 'Khanna', 'aditya.khanna@company.com', 'Finance', 83000.00, '2015-08-31'),
(99, 'Shweta', 'Bose', 'shweta.bose@company.com', 'Marketing', 70000.00, '2023-07-10'),
(100, 'Arnav', 'Joshi', 'arnav.joshi@company.com', 'Sales', 64000.00, '2024-07-22');


SELECT * FROM Employee;

--- 1. Write a SQL query to retrieve the TOP 5 highest-paid employees. Ensure the result is correct by applying proper ordering.

SELECT Top 5 *  FROM Employee
ORDER BY Employee.Salary DESC;


---2. Write a query to fetch DISTINCT department names from the Employee table where the department name starts with the letter 'S'.

SELECT DISTINCT Department FROM Employee 
WHERE Department like 's%' ; 


---3. Write a query to retrieve employees whose Department is IN ('HR', 'Finance', 'IT') AND whose Salary is greater than 50,000.

SELECT * FROM Employee 
where (Department IN ('HR', 'Finance', 'IT')) AND (Salary >50000);


---4. Write a query to retrieve employees who belong to the 'Sales' department OR have a Salary greater than 75,000. Explain your filtering logic using SQL comments.

SELECT * FROM Employee 
WHERE  (Department = 'Sales') OR (Salary > 75000);

/* Here we can use multiple condition via OR/AND type of Logical operator in SQl. 
   We have to put those Condition after the WHERE Clouse which check's 
   if any one Condition is true then where clouse consider that predicate true
   and include that row into the result.
*/

 ---5. Write a query to find all employees whose Email contains their FirstName anywhere in the email using the LIKE operator.

SELECT * FROM Employee 
WHERE Email like '%'+FirstName+'%';

 ---6. Write a query to display employees ordered by DateOfJoining (oldest first) and return rows 6 to 10 using  FETCH.

SELECT * FROM Employee
ORDER BY DateOfJoining
OFFSET 5 rows
FETCH NEXT 5 rows ONLY;

---7. Write a query to retrieve employees where:
--- - Department is 'IT' AND Salary is greater than 60,000
--- OR
--- - Department is 'HR' AND DateOfJoining is before '2020-01-01'
--- Use parentheses correctly to control logical precedence.

SELECT * FROM Employee
WHERE ((Department = 'IT') AND (Salary > 60000)) OR ((Department = 'HR') AND (DateOfJoining <  '2020-01-01')); 

