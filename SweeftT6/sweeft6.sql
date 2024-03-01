/*if EXISTS(SELECT * from sys.databases WHERE name = 'school')
BEGIN
	drop DATABASE school;
END*/
CREATE DATABASE school;
USE school;

-- task 1: creating tables

CREATE TABLE Teacher(
	tId int identity(1,1) PRIMARY KEY,
	name varchar(30),
	surName varchar(50),
	gender varchar(15),
	subject varchar(50)
);

CREATE TABLE Pupil(
	pId int identity(1,1) PRIMARY KEY,
	name varchar(30),
	surName varchar(50),
	gender varchar(15),
	class varchar(50)
);

--junction table
CREATE TABLE TeacherPupil(
	tId int,
	pId int,
	PRIMARY KEY (tId, pId),
	FOREIGN KEY (tId) REFERENCES Teacher(tId),
	FOREIGN KEY (pId) REFERENCES Pupil(pId)
);

-- task 2: showing all teachers who teach pupils named Giorgi
--at first insert some values to see results
--insert teachers
INSERT INTO Teacher (name, surName, gender, subject)
VALUES ('Tamar', 'Chkhaidze', 'Female', 'Chemisry'),
       ('Tsitsana', 'Mgaloblishvili', 'Female', 'Science'),
       ('David', 'Natroshvili', 'Male', 'Math');
--insert pupils
INSERT INTO Pupil (name, surName, gender, class)
VALUES ('Giorgi', 'Gotsiridze', 'Male', '7th A class'),
       ('Mariam', 'Abuladze', 'Female', '11th B class'),
       ('Giorgi', 'Salukvadze', 'Male', '9th B Class');

--insert teacher-pupil
INSERT INTO TeacherPupil (tId, pId)
VALUES (1, 3),  -- Tamar-Giorgi3
       (2, 2), -- Tsitsana- Mariam
	   (1, 2),  --Tamar-Mariam
       (3, 1),  -- David-Giorgi1
	   (3, 3);	-- David-Giorgi3

--select all teachers who teaches any pupil named Giorgi
SELECT DISTINCT t.*
FROM Teacher t
JOIN TeacherPupil tp ON t.tId = tp.tId
JOIN Pupil p ON tp.pId = p.pId
WHERE p.name = 'Giorgi';
--result will be teacher 1 and 3 (Tamar and David)