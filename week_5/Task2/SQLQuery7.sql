WITH mobile (user_id, page_url) AS (
SELECT *
FROM (VALUES
	(1, 'A'), 
	(2, 'B'), 
	(3, 'C'), 
	(4, 'A'),
	(9, 'B'),
	(2, 'C'), 
	(10, 'B')) AS mobile_values (user_id, page_url)),
web ( user_id, page_url) AS (
	SELECT *	
	FROM (VALUES
	(6, 'A'), 
	(2, 'B'), 
	(3, 'C'), 
	(7, 'A'), 
	(4, 'B'), 
	(8, 'C'), 
	(5, 'B')) AS web_values (user_id, page_url)),
mobile_web (mobile_user, web_user) AS (
SELECT DISTINCT
	m.user_id AS mobile_user,
	w.user_id AS web_user
FROM mobile m 
FULL JOIN web w
ON m.user_id = w.user_id)
SELECT 
   CONVERT(DOUBLE PRECISION, AVG(CASE WHEN mobile_user IS NOT NULL AND web_user IS NULL THEN 1.0 ELSE 0 END)) AS mobile_fraction,
   CONVERT(DOUBLE PRECISION, AVG(CASE WHEN web_user IS NOT NULL AND mobile_user IS NULL THEN 1.0 ELSE 0 END)) AS web_fraction,
   CONVERT(DOUBLE PRECISION, AVG(CASE WHEN web_user IS NOT NULL AND mobile_user IS NOT NULL THEN 1.0 ELSE 0 END)) AS both_fraction
FROM mobile_web