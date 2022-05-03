WITH stations (id, city, state, latitude, longitude) AS (
SELECT *
FROM (VALUES
	(1, 'Asheville', 'North Carolina', 35.6, 82.6),
	(2, 'Burlington', 'North Carolina', 36.1, 79.4),
	(3, 'Chapel Hill', 'North Carolina', 35.9, 79.1),
	(4, 'Davidson', 'North Carolina', 35.5, 80.8),
	(5, 'Elizabeth City', 'North Carolina', 36.3, 76.3),
	(6, 'Fargo', 'North Dakota', 46.9, 96.8),
	(7, 'Grand Forks', 'North Dakota', 47.9, 97.0),
	(8, 'Hettinger', 'North Dakota', 46.0, 102.6),
	(9, 'Inkster', 'North Dakota', 48.2, 97.6)) AS stations_values (id, city, state, latitude, longitude)),
result1 (id, city,state, latitude, longitude, row_number_state, row_count) AS (
SELECT 
   *, 
   ROW_NUMBER() OVER (PARTITION BY state ORDER BY latitude ASC) AS row_number_state, 
   COUNT(*) OVER (PARTITION BY state) AS row_count
FROM stations )

SELECT 
   state, 
   AVG(latitude) AS median_latitude
FROM result1
WHERE row_number_state >= 1.0*row_count/2 
AND row_number_state <= 1.0*row_count/2 + 1
GROUP BY state

