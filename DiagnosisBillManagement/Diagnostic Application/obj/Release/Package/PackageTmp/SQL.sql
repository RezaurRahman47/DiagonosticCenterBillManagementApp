
--/*	create testtype table  
--===============================*/
--create table testtype(
--id	int primary key identity,
--name varchar(100) not null,
--created_at date not null,
--)

--#checking - insert data
--insert into testtype values('blood', '2017-06-21')

--#checking - result
--select * from testtype;


--CREATE TABLE TestSetup(
--	id int PRIMARY KEY IDENTITY,
--	testname varchar(150) NOT NULL,
--	fee decimal(12, 2) NOT NULL,
--	type_id int FOREIGN KEY REFERENCES TestType(id),
--	created_at date,
--)



--TESTSETUPVIEW CREATED
--CREATE VIEW TestSetup_View AS
--SELECT testname, fee, name FROM TestType tt, TestSetup ts
--WHERE tt.id = ts.type_id


--CREATE TABLE Patient(
--	id int PRIMARY KEY IDENTITY,
--	patient_name VARCHAR(50),
--	date_of_birth DATE,
--	bill_no VARCHAR(50),
--	mobile VARCHAR(11),
--	paymentStatus bit,
--	created_at DATE,
--)


--CREATE TABLE PatientTest(
--	id int PRIMARY KEY IDENTITY,
--	patientID int FOREIGN KEY REFERENCES Patient(id),
--	testSetupID int FOREIGN KEY REFERENCES TestSetup(id),
--	billNo VARCHAR(10),
--	created_at Date,
--)

