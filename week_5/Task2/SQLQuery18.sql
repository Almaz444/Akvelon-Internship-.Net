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
result1 (city, city1, city2, city1_lat, city1_long, city2_lat, city2_long) AS (
SELECT 
   s1.state, 
   s1.city AS city1, 
   s2.city AS city2, 
   s1.latitude AS city1_lat, 
   s1.longitude AS city1_long, 
   s2.latitude AS city2_lat, 
   s2.longitude AS city2_long
FROM stations s1
JOIN stations s2
ON s1.state = s2.state 
AND s1.city < s2.city ),
result2 (state, city1, city2, city1_lat, city1_long, city2_lat, city2_long, distance) AS (
SELECT 
	*, 
	POWER(( POWER((city1_lat - city2_lat),2)*1.0 + POWER((city1_long - city2_long),2)*1.0), 0.5) AS distance
FROM result1 ),
result3 (state, city1, city2, city1_lat, city1_long, city2_lat, city2_long, distance, dist_rank) AS (
SELECT 
	*, 
	RANK() OVER (PARTITION BY state ORDER BY distance DESC) AS dist_rank
FROM result2 )

SELECT 
   state, 
   city1, 
   city2, 
   distance
FROM result3
WHERE dist_rank = 1


