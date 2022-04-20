CREATE TABLE IF NOT EXISTS Course (
	Id VARCHAR(36) NOT NULL,
    Name VARCHAR(30),
    Description TEXT,
    PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS Student (
	Id varchar(36) NOT NULL,
    FirstName VARCHAR(40),
    LastName VARCHAR(70),
    PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS Subject (
	Id varchar(36) NOT NULL,
    Name VARCHAR(30),
    Description TEXT,
    PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS CourseSubject (
    CourseId VARCHAR(36),
    SubjectId VARCHAR(36),
    PRIMARY KEY (Id),
    FOREIGN KEY (CourseID) REFERENCES Course(Id),
    FOREIGN KEY (SubjectId) REFERENCES Subject(Id)
);

CREATE TABLE IF NOT EXISTS CourseMembership (
    CourseId VARCHAR(36),
    StudentId VARCHAR(36),
    PRIMARY KEY (Id),
	FOREIGN KEY (CourseID) REFERENCES Course(Id),
    FOREIGN KEY (StudentId) REFERENCES Student(Id)
);
