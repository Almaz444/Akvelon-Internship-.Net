WITH projects (task_id, start_date, end_date) AS (
SELECT *	
FROM (VALUES
	(1, CAST('10-01-20' AS date), CAST('10-02-20' AS date)), 
	(2, CAST('10-02-20' AS date), CAST('10-03-20' AS date)), 
	(3, CAST('10-03-20' AS date), CAST('10-04-20' AS date)), 
	(4, CAST('10-13-20' AS date), CAST('10-14-20' AS date)), 
	(5, CAST('10-14-20' AS date), CAST('10-15-20' AS date)), 
	(6, CAST('10-28-20' AS date), CAST('10-29-20' AS date)), 
	(7, CAST('10-30-20' AS date), CAST('10-31-20' AS date))) AS projects_values (task_id, start_date,end_date)),
result1(start_date) AS (
SELECT
	start_date
FROM projects
WHERE start_date NOT IN (SELECT end_date FROM projects)),
result2(end_date) AS (
SELECT 
	end_date
FROM projects
WHERE end_date NOT IN (SELECT start_date FROM projects)),
result3(start_date, end_date) AS (
SELECT 
   start_date, 
   MIN(end_date) AS end_date
FROM result1, result2
WHERE start_date < end_date
GROUP BY start_date)

SELECT 
   *, 
   project_duration = (SELECT DATEDIFF(day, start_date, end_date))
FROM result3
ORDER BY 3, 1


