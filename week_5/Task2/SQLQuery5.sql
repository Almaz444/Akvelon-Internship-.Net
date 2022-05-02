WITH users (user_id, product_id, transaction_date) AS (
SELECT *
FROM ( VALUES
	(1, 101, CAST('2-12-20' AS date)), 
	(2, 105, CAST('2-13-20' AS date)), 
	(1, 111, CAST('2-14-20' AS date)), 
	(3, 121, CAST('2-15-20' AS date)), 
	(1, 101, CAST('2-16-20' AS date)), 
	(2, 105, CAST('2-17-20' AS date)),
	(4, 101, CAST('2-16-20' AS date)), 
	(3, 105, CAST('2-15-20' AS date))) AS users_values(user_id, product_id, transaction_date)),
result1 (user_id, product_id, transaction_date, transaction_number) AS (
SELECT 
   *, 
   ROW_NUMBER() OVER (PARTITION BY user_id ORDER BY transaction_date) AS transaction_number
FROM users),
result2(user_id, transaction_date) AS (
SELECT 
   user_id, 
   transaction_date
FROM result1
WHERE transaction_number = 2 ),
result3(user_id) AS (
SELECT 
   DISTINCT user_id
FROM  users)

SELECT 
   result3.user_id, 
   transaction_date AS superuser_date
FROM result2
RIGHT JOIN result3
ON result3.user_id = result2.user_id
ORDER BY CASE WHEN transaction_date is null THEN 1 ELSE 0 END, transaction_date


