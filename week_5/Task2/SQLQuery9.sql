WITH friends (user1, user2) AS (
SELECT * 
FROM (VALUES
	(1, 2), 
	(1, 3), 
	(1, 4), 
	(2, 3)) AS friends_values(user1, user2)),
result(user_id) AS(
SELECT 
	user1 AS user_id
FROM friends
UNION ALL
SELECT 
	user2 AS user_id
FROM friends)

SELECT 
   user_id, 
   COUNT(*) AS friend_count
FROM result
GROUP BY user_id
ORDER BY 2 DESC
