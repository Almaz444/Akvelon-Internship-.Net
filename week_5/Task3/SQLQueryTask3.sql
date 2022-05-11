USE AkvelonDB
CREATE TABLE players
(
    id INT,
    name VARCHAR(50) NOT NULL,
    dob datetime NOT NULL,
    jersey_number INT NOT NULL,
    city VARCHAR(50) NOT NULL
 )
INSERT INTO players
VALUES  
(6, 'Mane', '03-JAN-1985', 2, 'Liverpool'), 
(2, 'Jon','02-FEB-1974', 1, 'Manchester'),
(9, 'Wise','11-NOV-1987', 8, 'Manchester'), 
(3, 'Jonny','07-MAR-1988', 3, 'Leeds'), 
(1, 'Jolly', '12-JUN-1989', 4, 'London'),
(4, 'Laura', '22-DEC-1981', 9, 'Liverpool'),
(7, 'Joseph', '09-APR-1982', 10, 'London'),  
(5, 'Alan', '29-JUL-1993', 6, 'London'), 
(8, 'Nike', '16-AUG-1974', 7, 'Liverpool'),
(10, 'Mike', '28-OCT-1990', 5, 'Leeds'),
(16, 'Mane', '03-JAN-1985', 12, 'Liverpool'), 
(12, 'Jon','02-FEB-1974', 11, 'Manchester'),
(19, 'Wise','11-NOV-1987', 18, 'Manchester'), 
(13, 'Jonny','07-MAR-1988', 13, 'Leeds'), 
(11, 'Jolly', '12-JUN-1989', 14, 'London'),
(14, 'Laura', '22-DEC-1981', 19, 'Liverpool'),
(17, 'Joseph', '09-APR-1982', 20, 'London'),  
(15, 'Alan', '29-JUL-1993', 16, 'London'), 
(18, 'Nike', '16-AUG-1974', 17, 'Liverpool'),
(30, 'Mike', '28-OCT-1990', 15, 'Leeds'),
(26, 'Mane', '03-JAN-1985', 22, 'Liverpool'), 
(22, 'Jon','02-FEB-1974', 21, 'Manchester'),
(29, 'Wise','11-NOV-1987', 28, 'Manchester'), 
(23, 'Jonny','07-MAR-1988', 23, 'Leeds'), 
(21, 'Jolly', '12-JUN-1989', 24, 'London'),
(24, 'Laura', '22-DEC-1981', 29, 'Liverpool'),
(27, 'Joseph', '09-APR-1982', 30, 'London'),  
(25, 'Alan', '29-JUL-1993', 26, 'London'), 
(28, 'Nike', '16-AUG-1974', 27, 'Liverpool'),
(40, 'Mike', '28-OCT-1990', 25, 'Leeds');

SET  STATISTICS TIME ON
SELECT  
	* 
FROM players 
WHERE id = 40
SET STATISTICS TIME OFF

CREATE NONCLUSTERED INDEX IX_tblPlayers_Name
ON players(id ASC)

SET  STATISTICS TIME ON
SELECT  
	* 
FROM players 
WHERE id = 40
SET  STATISTICS TIME OFF

ALTER TABLE players
ADD CONSTRAINT UQ_jersey_number UNIQUE(jersey_number);

CREATE CLUSTERED INDEX IX_jersey_number
ON players(jersey_number ASC)

SELECT  
	* 
FROM players 






