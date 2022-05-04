WITH trips (trip_id, rider_id, driver_id, status, request_date) AS (
SELECT *
FROM (VALUES
	(1, 1, 10, 'completed', CAST('2020-10-01' AS date)),
	(2, 2, 11, 'cancelled_by_driver', CAST('2020-10-01' AS date)),
	(3, 3, 12, 'completed', CAST('2020-10-01' AS date)),
	(4, 4, 10, 'cancelled_by_rider', CAST('2020-10-02' AS date)),
	(5, 1, 11, 'completed', CAST('2020-10-02' AS date)),
	(6, 2, 12, 'completed', CAST('2020-10-02' AS date)),
	(7, 3, 11, 'completed', CAST('2020-10-03' AS date))) AS trips_values (trip_id, rider_id, driver_id, status, request_date)),
users (user_id, banned, type) AS (
SELECT *
FROM (VALUES
	(1, 'no', 'rider'),
	(2, 'yes', 'rider'),
	(3, 'no', 'rider'),
	(4, 'no', 'rider'),
	(10, 'no', 'driver'),
	(11, 'no', 'driver'),
	(12, 'no', 'driver')) AS users_values (user_id, banned, type))
SELECT 
   request_date, 
   FORMAT(1 - AVG(CASE WHEN status = 'completed' THEN 1.0 ELSE 0 END), 'N1')AS cancel_rate
FROM trips
WHERE rider_id NOT IN (SELECT user_id 
                       FROM users
                       WHERE banned = 'yes' )
AND driver_id NOT IN (SELECT user_id 
                      FROM users
                      WHERE banned = 'yes' )
GROUP BY request_date
HAVING DAY (request_date) <= 2