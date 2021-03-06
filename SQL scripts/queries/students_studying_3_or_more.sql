SELECT *
FROM Student
JOIN CourseMembership ON (CourseMembership.StudentId = Student.Id)
JOIN Course ON (Course.Id = CourseMembership.CourseId)
JOIN CourseSubject ON (CourseSubject.CourseId = Course.Id)
JOIN Subject ON (CourseSubject.SubjectId = Subject.Id)
GROUP BY CourseSubject.CourseId, CourseMembership.StudentId
HAVING COUNT(*) > 3;
