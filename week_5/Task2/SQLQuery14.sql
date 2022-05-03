WITH employee (id, pay_month, salary) AS (
SELECT *
FROM (VALUES
	(1, 1, 20),
	(2, 1, 20),
	(1, 2, 30),
	(2, 2, 30),
	(3, 2, 40),
	(1, 3, 40),
	(3, 3, 60),
	(1, 4, 60),
	(3, 4, 70)) AS employee_values (id, pay_month, salary)),
result1 (id, pay_month, salary, month_rank) AS (
SELECT *, 
   RANK() OVER (PARTITION BY id ORDER BY pay_month DESC) AS month_rank
FROM employee)

SELECT 
   id, 
   pay_month, 
   salary, 
   SUM(salary) OVER (PARTITION BY id ORDER BY month_rank DESC) AS cumulative_sum
FROM result1 
WHERE month_rank != 1
AND month_rank <= 4
ORDER BY 1, 2
