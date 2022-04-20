CREATE TABLE IF NOT EXISTS Course (
	Id VARCHAR(36) NOT NULL,
	CourseSubjectsId VARCHAR(36),
	CourseMembershipId VARCHAR(36),
    Name VARCHAR(30),
    Description TEXT,
    PRIMARY KEY (Id),
    FOREIGN KEY (CourseSubjectsId) REFERENCES CourseSubjects(Id),
    FOREIGN KEY (CourseMembershipId)  REFERENCES CourseMembership(Id)
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
	Id VARCHAR(36) NOT NULL,
    PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS CourseMembership (
	Id VARCHAR(36) NOT NULL,
    PRIMARY KEY (Id)
);