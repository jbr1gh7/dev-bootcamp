SELECT *
FROM Student
JOIN CourseMembership ON (CourseMembership.StudentId = Student.Id)
JOIN Course ON (Course.Id = CourseMembership.CourseId)
WHERE Course.IsPartFunded = true;
