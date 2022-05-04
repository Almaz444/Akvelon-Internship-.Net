WITH orders (order_id, customer_id, product_id) AS (
SELECT *
FROM (VALUES
	(1, 1, 1),
	(1, 1, 2),
	(1, 1, 3),
	(2, 2, 1),
	(2, 2, 2),
	(2, 2, 4),
	(3, 1, 5)) AS orders_values(order_id, customer_id, product_id)),
products (id, name) AS (
SELECT *
FROM (VALUES
	(1, 'A'),
	(2, 'B'),
	(3, 'C'),
	(4, 'D'),
	(5, 'E')) AS products_values(id, name)),
result1 AS (
SELECT 
   o1.product_id AS prod_1, 
   o2.product_id AS prod_2
FROM orders o1
JOIN orders o2
ON o1.order_id = o2.order_id
AND o1.product_id < o2.product_id),
result2 AS (
SELECT
	CONCAT(p1.name, ' ', p2.name) AS product_pair
FROM result1
JOIN products p1
ON result1.prod_1 = p1.id
JOIN products p2
ON result1.prod_2 = p2.id )

SELECT 
	TOP 3
	*, 
   COUNT(*) AS purchase_freq
FROM result2
GROUP BY product_pair
ORDER BY 2 DESC




