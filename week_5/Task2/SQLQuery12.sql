WITH hackers (hacker_id, name) AS (
SELECT *
FROM (VALUES
	(1, 'John'),
	(2, 'Jane'),
	(3, 'Joe'),
	(4, 'Jim')) AS hackers_values (hacker_id, name)),
submissions (submission_id, hacker_id, challenge_id, score) AS (
SELECT *
FROM (VALUES
	(101, 1, 1, 10),
	(102, 1, 1, 12),
	(103, 2, 1, 11),
	(104, 2, 1, 9),
	(105, 2, 2, 13),
	(106, 3, 1, 9),
	(107, 3, 2, 12),
	(108, 3, 2, 15),
	(109, 4, 1, 0)) AS submissions_values(submission_id, hacker_id, challenge_id, score)),
result (hacker_id, challenge_id, max_score) AS (
SELECT 
   hacker_id, 
   challenge_id, 
   MAX(score) AS max_score
FROM submissions 
GROUP BY hacker_id,challenge_id)

SELECT 
   r.hacker_id, 
   h.name, 
   SUM(r.max_score) AS total_score
FROM result r
JOIN hackers h
ON r.hacker_id = h.hacker_id
GROUP BY r.hacker_id, h.name
HAVING SUM(max_score) > 0
ORDER BY 3 DESC, 1



