SELECT *
FROM Student
JOIN CourseMembership ON (CourseMembership.StudentId = Student.Id)
JOIN Course ON (Course.Id = CourseMembership.CourseId)
JOIN CourseSubject ON (CourseSubject.CourseId = Course.Id)
GROUP BY SubjectId
HAVING COUNT(*) > 3