WITH attendance (student_id, school_date, attendance) AS (
SELECT *
FROM (VALUES
	(1, CAST('2020-04-03' AS date), 0),
	(2, CAST('2020-04-03' AS date), 1),
	(3, CAST('2020-04-03' AS date), 1), 
	(1, CAST('2020-04-04' AS date), 1), 
	(2, CAST('2020-04-04' AS date), 1), 
	(3, CAST('2020-04-04' AS date), 1), 
	(1, CAST('2020-04-05' AS date), 0), 
	(2, CAST('2020-04-05' AS date), 1), 
	(3, CAST('2020-04-05' AS date), 1), 
	(4, CAST('2020-04-05' AS date), 1)) AS attendance_values (student_id, school_date, attendance)),
students (student_id, school_id, grade_level, date_of_birth) AS (
SELECT *
FROM (VALUES
	(1, 2, 5, CAST('2012-04-03' AS date)),
	(2, 1, 4, CAST('2013-04-04' AS date)),
	(3, 1, 3, CAST('2014-04-05' AS date)), 
	(4, 2, 4, CAST('2013-04-03' AS date))) AS students_values (student_id, school_id, grade_level, date_of_birht))

SELECT 
	CONVERT (DOUBLE PRECISION, ROUND(AVG(CAST(attendance AS decimal)), 2)) AS birthday_attendance
FROM attendance a
JOIN students s
ON a.student_id = s.student_id
AND MONTH(a.school_date) =  MONTH(s.date_of_birth)
AND DAY(a.school_date) = DAY(s.date_of_birth)
