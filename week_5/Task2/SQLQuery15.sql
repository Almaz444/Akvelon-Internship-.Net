WITH teams (team_id, team_name) AS (
SELECT *
FROM (VALUES
	(1, 'New York'),
	(2, 'Atlanta'),
	(3, 'Chicago'),
	(4, 'Toronto'),
	(5, 'Los Angeles'),
	(6, 'Seattle')) AS teams_values (team_id, team_name)),
matches (match_id, host_team, guest_team, host_goals, guest_goals) AS (
SELECT *
FROM (VALUES
	(1, 1, 2, 3, 0),
	(2, 2, 3, 2, 4),
	(3, 3, 4, 4, 3),
	(4, 4, 5, 1, 1),
	(5, 5, 6, 2, 1),
	(6, 6, 1, 1, 2)) AS matches_values(match_id, host_team, guest_team, host_goals, guest_goals)),
result1 (match_id, host_team, guest_team, host_goals, guest_goals, host_points, guest_points) AS (
SELECT 
   *, 
   CASE WHEN host_goals > guest_goals THEN 3 
        WHEN host_goals = guest_goals THEN 1 
        ELSE 0 END AS host_points, 
   CASE WHEN host_goals < guest_goals THEN 3 
   WHEN host_goals = guest_goals THEN 1 
   ELSE 0 END AS guest_points
FROM matches)

SELECT 
   t.team_name, 
   a.host_points + b.guest_points AS total_points
FROM teams t
JOIN result1 a
ON t.team_id = a.host_team
JOIN result1 b
ON t.team_id = b.guest_team
ORDER BY 2 DESC, 1


