WITH users(user_id, action,action_date) AS (
SELECT *
FROM ( VALUES 
	(1, 'start', CAST('2-12-20' AS date)), 
	(1, 'cancel', CAST('2-13-20' AS date)), 
	(2, 'start', CAST('2-11-20' AS date)), 
	(2, 'publish', CAST('2-14-20' AS date)), 
	(3, 'start', CAST('2-15-20' AS date)), 
	(3, 'cancel', CAST('2-15-20' AS date)), 
	(4, 'start', CAST('2-18-20' AS date)), 
	(1, 'publish', CAST('2-19-20' AS date)))  AS users_values(user_id, action, action_date)),
result (user_id,action,action_date,date_rank) AS (
SELECT 
   *, 
   ROW_NUMBER() OVER (PARTITION BY user_id ORDER BY action_date DESC) AS date_rank
FROM users ),
result_latest(user_id,action,action_date,date_rank) AS (
SELECT *
FROM result
WHERE date_rank = 1 ),
result_after_latest(user_id,action,action_date,date_rank) AS (
SELECT *
FROM result
WHERE date_rank = 2)

SELECT 
    r1.user_id,
	days_elapsed = (SELECT DATEDIFF(day, r2.action_date, r1.action_date) )
FROM result_latest r1
LEFT JOIN result_after_latest r2
ON r1.user_id = r2.user_id
ORDER BY 1
