WITH friends (user_id, friend) AS (
SELECT *
FROM( VALUES
	(1, 2),
	(1, 3),
	(1, 4),
	(2, 1),
	(3, 1),
	(3, 4),
	(4, 1),
	(4, 3)) AS friend_values(user_id, friend)),
likes (user_id, page_likes) 
AS (
SELECT *
FROM( VALUES
	(1, 'A'),
	(1, 'B'),
	(1, 'C'),
	(2, 'A'),
	(3, 'B'),
	(3, 'C'),
	(4, 'B')) AS like_values(user_id, friend)),
result1 (user_id, page_likes, friend) AS (
SELECT 
	l.user_id, 
	l.page_likes, 
	f.friend
FROM likes l
	JOIN friends f
	ON l.user_id = f.user_id ),
result2 (user_id, page_likes, friend, friend_likes) AS (
SELECT 
	result1.user_id,
	result1.page_likes, 
	result1.friend, 
	l.page_likes AS friend_likes
FROM result1
	LEFT JOIN likes l
	ON result1.friend = l.user_id
	AND result1.page_likes = l.page_likes)
SELECT DISTINCT 
	friend AS user_id, 
	page_likes AS recommended_page
FROM result2
WHERE friend_likes IS NULL
ORDER BY friend


