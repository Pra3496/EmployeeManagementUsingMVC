CREATE DATABASE EmployeeManegmentDB;

use EmployeeManegmentDB;


        public string connectionString = this.Iconfiguration.GetConnectionString("EmployeeDB"); // @"data source=.;initial catalog=EmployeeManegmentDB;trusted_connection=True;TrustServerCertificate=True";

CREATE TABLE EmployeeDetail(
EmpId BIGINT IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(50),
ProfileImg VARCHAR(50),
Gender CHAR(2),
Department VARCHAR(max),
Salary DECIMAL(10,2),
StartDate DATETIME,
Notes VARCHAR(max)
);

drop table EmployeeDetail;

ALTER TABLE EmployeeDetail
RENAME COLUMN Deparment to Department;


INSERT INTO EmployeeDetail VALUES('pranav','myxom/jkf/oop.png','M','Sr.Engg',100000.00,'2023-09-30','Remarks');

﻿ALTER PROCEDURE spAddingNewDataToEmpDB(
    @Name VARCHAR(50),
    @ProfileImg VARCHAR(50),
    @Gender VARCHAR(2),
    @Department VARCHAR(max),
    @Salary DECIMAL(10,2),
    @StartDate DATETIME,
    @Notes VARCHAR(max)
)
AS BEGIN

BEGIN TRY

INSERT INTO EmployeeDetail VALUES(@Name, @ProfileImg, @Gender, @Department, @Salary, @StartDate, @Notes);

END TRY
BEGIN CATCH

SELECT ERROR_MESSAGE() AS ErrorMessage; 

END CATCH

END


CREATE PROCEDURE spRetriveDataOfEmp

AS BEGIN

BEGIN TRY

SELECT * FROM  EmployeeDetail;

END TRY
BEGIN CATCH

SELECT ERROR_MESSAGE() AS ErrorMessage; 

END CATCH

END

EXEC spRetriveDataOfEmp;




Create or Alter Procedure spUpdateEmployeeDeatils(
	@EmpId BIGINT,
    @Name VARCHAR(50),
    @ProfileImg VARCHAR(50),
    @Gender CHAR(2),
    @Department VARCHAR(max),
    @Salary DECIMAL(10,2),
    @StartDate DATETIME,
    @Notes VARCHAR(max)
)
As
Begin
Begin Try
Update  EmployeeDetail Set Name=@Name,ProfileImg=@ProfileImg,Gender=@Gender,Department=@Department,
Salary=@Salary,StartDate=@StartDate,Notes=@Notes where EmpId = @EmpId;
End Try
Begin Catch
Select ERROR_MESSAGE() as ErrorMessage;
End Catch;
End

SELECT * FROM EmployeeDetail


Create or Alter Procedure spDeleteEmployeeDeatils(
	@EmpId BIGINT
)
As
Begin
Begin Try
Delete from EmployeeDetail where EmpId = @EmpId;
End Try
Begin Catch
Select ERROR_MESSAGE() as ErrorMessage;
End Catch;
End


