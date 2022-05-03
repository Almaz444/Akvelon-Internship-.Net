WITH customers (id, name) AS (
SELECT *
FROM (VALUES
	(1, 'Daniel'),
	(2, 'Diana'),
	(3, 'Elizabeth'),
	(4, 'John')) AS customers_values (id,name)),
orders (order_id, customer_id, product_name) AS (
SELECT *
FROM (VALUES
	(1, 1, 'A'),
	(2, 1, 'B'),
	(3, 2, 'A'),
	(4, 2, 'B'),
	(5, 2, 'C'),
	(6, 3, 'A'), 
	(7, 3, 'A'),
	(8, 3, 'B'),
	(9, 3, 'D')) AS orders_values (order_id, customer_id, product_name))

SELECT DISTINCT 
	id, 
	name
FROM orders o
JOIN customers c
ON o.customer_id = c.id
WHERE customer_id IN (SELECT customer_id 
                      FROM orders 
                      WHERE product_name = 'A') 
AND customer_id IN (SELECT customer_id 
                    FROM orders 
                    WHERE product_name = 'B') 
AND customer_id NOT IN (SELECT customer_id 
                        FROM orders 
                        WHERE product_name = 'C')
ORDER BY id