WITH users (user_id, action, date) AS (
SELECT *
FROM ( VALUES
	(1,'start', CAST('01-01-20'AS date)), 
	(1,'cancel', CAST('01-02-20'AS date)), 
	(2,'start', CAST('01-03-20'AS date)), 
	(2,'publish', CAST('01-04-20'AS date)), 
	(3,'start', CAST('01-05-20'AS date)), 
	(3,'cancel', CAST('01-06-20'AS date)), 
	(1,'start', CAST('01-07-20'AS date)), 
	(1,'publish', CAST('01-07-20'AS date)))  AS users_values(user_id,action,date)),
result AS (
SELECT 
	user_id,
	SUM(CASE WHEN action = 'start' THEN 1.0 ELSE 0 END) AS starts, 
	SUM(CASE WHEN action = 'cancel' THEN 1.0 ELSE 0 END) AS cancels, 
	SUM(CASE WHEN action = 'publish' THEN 1.0 ELSE 0 END) AS publishes
FROM users
GROUP BY user_id)
SELECT 
   r.user_id, 
   FORMAT(r.publishes/r.starts, 'N1') AS publish_rate, 
   FORMAT(r.cancels/r.starts, 'N1')AS cancel_rate
FROM result r;
