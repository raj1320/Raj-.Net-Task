
--- Some Basic Operation Before Performing A task...
ALTER TABLE Employee
ALTER COLUMN Email VARCHAR(100) NOT NULL;

ALTER TABLE Employee
ADD CONSTRAINT UQ_Employee_Email UNIQUE(email) ;

CREATE TABLE Orders (
     OrderId INT PRIMARY KEY,
     OrderPrice DECIMAL(10,2),
     ProductIDs NVARCHAR(MAX),
     OrderStatus VARCHAR(100) DEFAULT 'Active',
     EmployeeID INT FOREIGN KEY
     REFERENCES Employee(EmployeeID)
);
  
CREATE TABLE Products
  (
    ProductId INT ,
    ProductName VARCHAR(100)
  ); 

CREATE TABLE OrderAudit(
   OrderId INT FOREIGN KEY
   REFERENCES Orders(OrderId),
   InsertedDate DATE,
   EmployeeID INT FOREIGN KEY
   REFERENCES Employee(EmployeeID)
);

 INSERT INTO Products (ProductId,ProductName) VALUES
 (1,'soffa'),
 (2,'Fan'),
 (3,'Table'),
 (4,'Notbook');



---  Task 1 ---
   -- Explore SCALER FUNCTION and ALSO Explore DATEDIFF() Function
    CREATE FUNCTION CalculateExperience
    (
        @DateOfJoining DATE
    )
    RETURNS DECIMAL(10,1)
    AS
    BEGIN
        DECLARE @CurrentDate Date=GETUTCDATE();
        DECLARE @Exp Decimal(10,1);
        SET @Exp = DATEDIFF(DAY,@DateOfJoining,@CurrentDate)/365.25;
        RETURN @Exp
    END;


--- Task 2 ---
    -- Return Table  
    CREATE FUNCTION NewEmployeeTable
    (
       @DepartmentId INT
    )
    RETURNS @RESULT TABLE 
    (
  
       FirstName VARCHAR(100),
       LastName VARCHAR(100),
       Salary DECIMAL(10,2),
       DateOfJoining DATE,
       IsSeniorEmployee VARCHAR(4)
    )
    AS 
    BEGIN
  
      INSERT INTO @RESULT
      SELECT FirstName ,LastName, Salary, DateOfJoining , IsSeniorEmployee =
          Case 
              WHEN  dbo.CalculateExperience(DateOfJoining) >=5 THEN 'YES'
              ELSE 'NO'
          END 
       FROM Employee  WHERE DepartmentID = @DepartmentId;

  
      RETURN
    END;


--- Task 3 ---
    -- Handle Exception by TRY-CATCH if Exception come
    CREATE PROCEDURE AddAfterValidate
          @EMployeeID INT, 
          @EmployeeFirstName VARCHAR(100),
          @EmployeeLastName VARCHAR(100),
          @EmployeeSalary DECIMAL(10,2),
          @EmployeeDateOfJoining DATE,
          @EmployeeEmail VARCHAR(100),
          @DepartmentID INT 
    AS
    BEGIN

      BEGIN TRY
          INSERT INTO Employee(EmployeeID,FirstName,LastName,Email,Salary,DateOfJoining,DepartmentID) VALUES (
            @EMployeeID,
            @EmployeeFirstName,
            @EmployeeLastName,
            @EmployeeEmail,
            @EmployeeSalary,
            @EmployeeDateOfJoining,
            @DepartmentID
          );
      END TRY

      BEGIN CATCH 
         SELECT  ERROR_MESSAGE() AS ErrorMessage;
      END CATCH

    END;


--- Task 4 ---
 
    -- Here First i filter those employee whoes DateOfJoining is before @EndDate,
    -- Then for calculating endividual revenue according to the working month of each employee 
    -- Use cases & when if Employee DateOfJoining is before the StartDate then only add amount for which he or she is elijible Salary*(@EndDate - @StartDate)Month
    -- End for Employee whoes DateOfJoining after the StartDate then only add amount for which he or she is elijible Salary*(@DateOfJoining - @StartDate)Month

    CREATE PROCEDURE FindTotalRevenueTenureWise 
        @StartDate DATE,
        @EndDate DATE
    AS 
    BEGIN

      SELECT n.DepartmentID, sum(n.newfield) AS REVENUE FROM
         (SELECT *, 
         ((DATEDIFF (DAY,CASE WHEN DateOfJoining < @StartDate THEN @StartDate ELSE DateOfJoining END, @EndDate)/365.25)/12.00)*Salary AS newfield
         FROM Employee WHERE
          DateOfJoining < @EndDate) AS n
      GROUP BY n.DepartmentID;

    END;
  

--- Task 5 ---
    -- Implement Trigger 
    CREATE TRIGGER AlertOnInsertion
    ON Orders
    AFTER INSERT
    AS
    BEGIN
      INSERT INTO OrderAudit(OrderId,InsertedDate,EmployeeID)
      SELECT OrderId , GETUTCDATE() , EmployeeID
      FROM inserted

       PRINT 'DATA INSERTED Successfully..'
    END;
 

--- Task 6 ---

    -- Here i am using [1,2,3] king of NVARCHAR data type which is use to contains charecter from multiple languages and script
    -- Which is latter access by OPENJSON method 

    CREATE TRIGGER OnProductDelete
    ON Products 
    INSTEAD OF DELETE 
    AS
    BEGIN
    
        IF exists(SELECT 1 FROM Orders 
                  WHERE
                  Exists(SELECT 1 FROM OPENJSON(ProductIDs) WHERE VALUE in (SELECT ProductId FROM deleted))
                  AND OrderStatus = 'Active')
           BEGIN
                  PRINT 'You can not delete Product, because it is Now on Active Order'
           END  
 
        ELSE

           BEGIN
                  DELETE FROM Products WHERE ProductId IN (SELECT ProductId FROM deleted);
           END

    END;


-- Execute For Query Result --- 

-- For T1 --
SELECT * FROM dbo.NewEmployeeTable(2);

-- For T2 --
SELECT FirstName, dbo.CalculateExperience(DateOfJoining) AS Experience FROM Employee;

-- For T3 --
DECLARE @date DATE =  GETUTCDATE();
EXEC dbo.AddAfterValidate 101,'TEST','TEST',12000.00,@date,'amit.sharma@company.com',2;

-- For T4 --
EXEC dbo.FindTotalRevenueTenureWise '2017-11-30','2020-12-30';
EXEC dbo.FindTotalRevenueTenureWise '2017-11-30','2025-12-30';

-- For T5 --
INSERT INTO Orders (OrderId,OrderPrice,ProductIDs,OrderStatus,EmployeeID) 
  VALUES (11,12000,'[1,4,6]','Active',2),
  (12,1000,'[3,2,1]','Received',1),
  (13,2500,'[2,4,1]','Received',4);
SELECT * FROM OrderAudit

-- For T6 --
DELETE FROM products WHERE productId = 1;

