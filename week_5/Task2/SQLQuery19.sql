WITH users (user_id, join_date, invited_by) AS (
SELECT *
FROM (VALUES
	(1, CAST('01-01-20' AS date), 0), 
	(2, CAST('01-10-20' AS date), 1), 
	(3, CAST('02-05-20' AS date), 2), 
	(4, CAST('02-12-20' AS date), 3), 
	(5, CAST('02-25-20' AS date), 2), 
	(6, CAST('03-01-20' AS date), 0), 
	(7, CAST('03-01-20' AS date), 4),
	(8, CAST('03-04-20' AS date), 7)) AS stations_values (user_id, join_date, invited_by)),
result1 AS (
SELECT 
	CAST(MONTH(u2.join_date) AS INT) AS month,
	cycle_time = (SELECT DATEDIFF(day, u2.join_date , u1.join_date))
FROM users u1
JOIN users u2
ON u1.invited_by = u2.user_id )

SELECT 
   month, 
   FORMAT(AVG(cycle_time*1.0), 'N1')AS cycle_time_month_avg
FROM result1
GROUP BY month
ORDER BY 1


