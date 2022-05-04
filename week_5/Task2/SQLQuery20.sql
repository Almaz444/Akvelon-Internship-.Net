WITH attendance (event_date, visitors) AS (
SELECT *
FROM (VALUES
	(CAST('01-01-20' AS date), 10), 
	(CAST('01-04-20' AS date), 109), 
	(CAST('01-05-20' AS date), 150), 
	(CAST('01-06-20' AS date), 99), 
	(CAST('01-07-20' AS date), 145), 
	(CAST('01-08-20' AS date), 1455), 
	(CAST('01-11-20' AS date), 199),
	(CAST('01-12-20' AS date), 188)) AS attendance(event_date, visitors)),
result1 AS (
SELECT *, 
   ROW_NUMBER() OVER (ORDER BY event_date) AS day_num
FROM attendance ),
result2 AS (
SELECT *
FROM result1
WHERE visitors > 100 ),
result3 AS (
SELECT 
   a.day_num AS day1, 
   b.day_num AS day2, 
   c.day_num AS day3
FROM result2 a
JOIN result2 b
ON a.day_num = b.day_num - 1
JOIN result2 c
ON a.day_num = c.day_num - 2)

SELECT 
   event_date, 
   visitors
FROM result1
WHERE day_num IN (SELECT day1 FROM result3)
   OR day_num IN (SELECT day2 FROM result3)
   OR day_num IN (SELECT day3 FROM result3)
