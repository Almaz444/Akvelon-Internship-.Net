WITH scores (id, score) AS (
SELECT *
FROM (VALUES
	(1, 3.50),
	(2, 3.65),
	(3, 4.00),
	(4, 3.85),
	(5, 4.00),
	(6, 3.65)) AS scores_values (id, score))

SELECT 
   s1.score, 
   COUNT(DISTINCT s2.score) AS score_rank
FROM scores s1 
JOIN scores s2
ON s1.score <= s2.score
GROUP BY s1.id, s1.score
ORDER BY 1 DESC