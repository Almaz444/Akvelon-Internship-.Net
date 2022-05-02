WITH transactions (sender, receiver, amount, transaction_date) AS (
SELECT *
FROM (VALUES
	(5, 2, 10, CAST('2-12-20' AS date)),
	(1, 3, 15, CAST('2-13-20' AS date)), 
	(2, 1, 20, CAST('2-13-20' AS date)), 
	(2, 3, 25, CAST('2-14-20' AS date)), 
	(3, 1, 20, CAST('2-15-20' AS date)), 
	(3, 2, 15, CAST('2-15-20' AS date)), 
	(1, 4, 5, CAST('2-16-20' AS date)))  AS transactions_values(sender, receiver, amount, transaction_date)),
debits (sender,amount) AS (
SELECT 
   sender, 
   SUM(amount) AS debited
FROM transactions
GROUP BY sender),
credits (receiver, amount) AS (
SELECT 
   receiver, 
   SUM(amount) AS credited
FROM transactions
GROUP BY receiver)

SELECT 
   COALESCE(sender, receiver) AS user_id,
   COALESCE(c.amount, 0) - COALESCE(d.amount,0) AS net_change 
FROM debits d
FULL JOIN credits c
ON d.sender = c.receiver
ORDER BY net_change DESC;


