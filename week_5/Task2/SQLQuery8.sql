WITH users (user_id, name, join_date) AS (
SELECT *
FROM (VALUES
	(1, 'Jon', CAST('2-14-20' AS date)), 
	(2, 'Jane', CAST('2-14-20' AS date)), 
	(3, 'Jill', CAST('2-15-20' AS date)), 
	(4, 'Josh', CAST('2-15-20' AS date)), 
	(5, 'Jean', CAST('2-16-20' AS date)), 
	(6, 'Justin', CAST('2-17-20' AS date)),
	(7, 'Jeremy', CAST('2-18-20' AS date))) AS users_values (user_id, name, join_date)),
user_events ( user_id, type, access_date	) AS (
	SELECT *	
	FROM (VALUES
	(1, 'F1', CAST('3-1-20' AS date)), 
	(2, 'F2', CAST('3-2-20' AS date)), 
	(2, 'P', CAST('3-12-20' AS date)),
	(3, 'F2', CAST('3-15-20' AS date)), 
	(4, 'F2', CAST('3-15-20' AS date)), 
	(1, 'P', CAST('3-16-20' AS date)), 
	(3, 'P', CAST('3-22-20' AS date))) AS events_values (user_id, type, access_date)),
result1 (user_id, type, f2_date) AS (
SELECT DISTINCT
	user_id, 
	type, 
	access_date
FROM user_events
WHERE type = 'F2' ),
result2 (user_id, type, premium_date) AS (
SELECT DISTINCT
	user_id, 
	type, 
	access_date 
FROM user_events
WHERE type = 'P' ),
result3 (upgrade_time) AS (
SELECT 
	upgrade_time = (SELECT DATEDIFF(day, u.join_date, result2.premium_date))
FROM users u
JOIN result1
ON u.user_id = result1.user_id
LEFT JOIN result2
ON u.user_id = result2.user_id )

SELECT 
   CONVERT (DOUBLE PRECISION, ROUND(AVG(CASE WHEN upgrade_time < 30 THEN 1.0 ELSE 0 END), 2)) AS upgrade_rate
FROM result3




