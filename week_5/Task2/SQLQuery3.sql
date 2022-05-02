WITH items (date, item) AS (
SELECT *
FROM (VALUES
	(CAST('01-01-20' AS date),'apple'), 
	(CAST('01-01-20' AS date),'apple'), 
	(CAST('01-01-20' AS date),'pear'), 
	(CAST('01-01-20' AS date),'pear'), 
	(CAST('01-02-20' AS date),'pear'), 
	(CAST('01-02-20' AS date),'pear'), 
	(CAST('01-02-20' AS date),'pear'), 
	(CAST('01-02-20' AS date),'orange')) AS item_values(date, item)),
result (date,item,item_count) AS (
SELECT 
   date, 
   item, 
   COUNT(*) AS item_count
FROM items
GROUP BY date,item
order by date offset 0 rows),
calculation AS (
SELECT 
   *, 
   RANK() OVER (PARTITION BY date ORDER BY item_count DESC) AS date_rank
FROM result)

SELECT 
   date, 
   item
FROM calculation
WHERE date_rank = 1




