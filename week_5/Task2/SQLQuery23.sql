WITH salaries (month, salary) AS (
SELECT *
FROM (VALUES
	(1, 2000),
	(2, 3000),
	(3, 5000),
	(4, 4000),
	(5, 2000),
	(6, 1000),
	(7, 2000),
	(8, 4000),
	(9, 5000)) AS salaries_values (month, salary))
SELECT 
   s1.month, 
   SUM(s2.salary) AS salary_3mos
FROM salaries s1
JOIN salaries s2
ON s1.month <= s2.month 
AND s1.month > s2.month - 3
GROUP BY s1.month
HAVING s1.month < 7
ORDER BY 1

