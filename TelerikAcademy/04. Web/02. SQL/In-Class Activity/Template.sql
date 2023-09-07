-- 1. Find all information about all departments.

-- 2. Find all department names.

-- 3. Find the salary of each employee.

-- 4. Write a SQL to find the full name of each employee. 
--       Hint: Full name is constructed by joining first, middle and last name.
SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName) as [Full Name]
FROM Employees

SELECT FirstName + ' ' + ISNULL(MiddleName, ' ') + ' ' + LastName 
FROM Employees

SELECT CONCAT_WS(' ', FirstName, MiddleName, LastName) as [Full Name]
FROM Employees

-- 5. Find all different employee salaries.
SELECT DISTINCT Salary FROM Employees

-- 6. Find all information about the employees whose job title is "Sales Representative" or "Sales Manager".
select * from employees
where jobtitle in ('Sales Representative', 'Sales Manager')

SELECT * 
FROM Employees
WHERE JobTitle = 'Sales Representative' OR JobTitle LIKE '% Sales Manager'

-- 7. Find the names of all employees whose first name starts with "SA".

-- 8. Find the names of all employees whose last name contains "ei".
SELECT *
FROM Employees
WHERE LastName LIKE '%ei%'

-- 9. Find the salary of all employees whose salary is in the range [20000…30000].
SELECT *
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

SELECT *
FROM Employees
WHERE Salary >= 20000 AND Salary <= 30000

-- 10. Find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
SELECT CONCAT_WS(' ', FirstName, MiddleName, LastName) as [Full Name],
		Salary
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 236000)

SELECT * FROM Employees

-- 11. Find all employees that do not have manager.
SELECT CONCAT_WS(' ', FirstName, MiddleName, LastName) as [Full Name]
FROM Employees
WHERE ManagerID IS NULL

-- 12. Find all employees that have salary more than 50000. Order them in decreasing order by salary.
SELECT CONCAT_WS(' ', FirstName, MiddleName, LastName) as [Full Name], Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

-- 13. Find the top 5 best paid employees.
SELECT TOP 5 CONCAT_WS(' ', FirstName, MiddleName, LastName) as [Full Name], Salary
FROM Employees
ORDER By Salary DESC

-- 14. Find all employees along with their address. Use inner join with ON clause.
SELECT CONCAT_WS(' ', e.FirstName, e.MiddleName, e.LastName) as [Full Name], a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID

-- 15. Find all employees and their address. Use equijoins (conditions in the WHERE clause).
SELECT CONCAT_WS(' ', e.FirstName, e.MiddleName, e.LastName) as [Full Name], a.AddressText
FROM Employees AS e, Addresses AS a
WHERE e.AddressID = a.AddressID

-- 16. Find all employees along with their manager.
SELECT CONCAT_WS(' ', e.FirstName, e.MiddleName, e.LastName) as [Employee Name],
		CONCAT_WS(' ', m.FirstName, m.MiddleName, m.LastName) as [Manager Name]
FROM Employees AS e
JOIN Employees AS m 
ON e.ManagerID = m.EmployeeID

-- 17. Find all employees, along with their manager's address. 
--       Hint: Join Employees AS e, Employees AS m and Addresses.
SELECT CONCAT_WS(' ', e.FirstName, e.MiddleName, e.LastName) AS [Employee Name],
		CONCAT_WS(' ', m.FirstName, m.MiddleName, m.LastName) AS [Manager Name],
		CONCAT(a.AddressText, ', ', t.Name)
FROM Employees AS e
JOIN Employees AS m
ON e.ManagerID = m.EmployeeID
JOIN Addresses AS a
ON m.AddressID = a.AddressID
JOIN Towns AS t
ON a.TownID = t.TownID

-- 18. Find all departments and all town names as a single list. 
--       Hint: Use UNION (https://www.w3schools.com/sql/sql_union.asp)
SELECT Name, 'Department' as [Type]
FROM Departments
UNION ALL
SELECT Name, 'Town'
FROM Towns

-- 19. Write a SQL query that lists the name of each employee along with the name of their manager.
--       Hint: Use RIGHT OUTER JOIN (https://www.w3schools.com/sql/sql_join_right.asp). Rewrite the query using LEFT OUTER JOIN.
--             The expected result after using RIGHT OUTER JOIN is shown below.

-- | Employee                 | Manager            |
-- | ------------------------ | ------------------ |
-- | Ken Sanchez              | NULL               |
-- | Martin Kulov             | NULL               |
-- | George Denchev           | NULL               |
-- | Ovidiu Cracium           | Roberto Tamburello |
-- | Michael Sullivan         | Roberto Tamburello |
-- | Sharon Salavaria         | Roberto Tamburello |
-- | Dylan Miller             | Roberto Tamburello |
-- | Rob Walters              | Roberto Tamburello |
-- | Gail Erickson            | Roberto Tamburello |
-- | Jossef Goldberg          | Roberto Tamburello |
-- | Kevin Brown              | David Bradley      |
-- | Sariya Harnpadoungsataya | David Bradley      |
-- | Jill Williams            | David Bradley      |
-- | Mary Gibson              | David Bradley      |
-- | Terry Eminhizer          | David Bradley      |

SELECT CONCAT( e.FirstName, ' ',e.LastName) AS Employee,
ISNULL((m.FirstName + ' ' + m.LastName), 'NULL') AS [Manager]
FROM Employees AS e
LEFT JOIN Employees AS m ON e.ManagerID = m.EmployeeID

SELECT CONCAT( e.FirstName, ' ',e.LastName) AS Employee,
m.FirstName + ' ' + m.LastName AS [Manager]
FROM Employees AS e
LEFT JOIN Employees AS m ON e.ManagerID = m.EmployeeID

SELECT CONCAT( e.FirstName, ' ',e.LastName) AS Employee,
m.FirstName + ' ' + m.LastName AS [Manager]
FROM Employees AS m
RIGHT JOIN Employees AS e ON e.ManagerID = m.EmployeeID


-- 20. Find the names of all employees who were hired between 1995 and 2005 and are part of the "Sales" or "Finance" departments.
SELECT CONCAT( e.FirstName, ' ',e.LastName) AS Employee,
       d.Name AS Department,
	   FORMAT(e.HireDate, 'yyyy') AS [Hire Date]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE (e.HireDate BETWEEN '1995' AND '2005') AND d.Name IN ('Sales', 'Finance')

-- 21. Find the names and salaries of the employees that take the minimal salary in the company.
--       Hint: Use a nested SELECT statement.
SELECT CONCAT( e.FirstName, ' ',e.LastName) AS Employee,
       e.Salary AS Salary
FROM Employees e
WHERE e.Salary = (
					SELECT MIN(Salary) 
					FROM Employees
				 )

-- 22. Find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
SELECT CONCAT( e.FirstName, ' ',e.LastName) AS Employee,
       e.Salary AS Salary
FROM Employees e
WHERE e.Salary <= (
					SELECT MIN(Salary) + MIN(Salary) * 0.1
					FROM Employees
				  ) 

SELECT CONCAT( e.FirstName, ' ',e.LastName) AS Employee,
       e.Salary AS Salary
FROM Employees e
WHERE e.Salary <= (
					SELECT MIN(Salary) * 1.1
					FROM Employees
				  ) 

-- 23. Find the full name, salary and department of the employees that take the minimal salary in their department.
--       Hint: Use a nested SELECT statement.
select concat(e.FirstName, ' ', e.MiddleName, ' ', e.LastName) as FullName, e.Salary, e.DepartmentID
from Employees e
join (	select DepartmentID, min(Salary) as MinSalary
		from Employees
		group by DepartmentID) m 
on e.DepartmentID = m.DepartmentID and e.Salary = m.MinSalary


SELECT CONCAT( e.FirstName, ' ',e.LastName) AS Employee,
       e.Salary AS Salary,
	   d.Name
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE e.Salary IN (
					SELECT MIN(Salary)
					FROM Employees
					GROUP BY DepartmentID
				  )

SELECT CONCAT( e.FirstName, ' ',e.LastName) AS Employee,
       e.Salary AS Salary,
	   d.Name
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = 
				(
					SELECT MIN(e1.Salary)
					FROM Employees e1
					WHERE e1.DepartmentID = d.DepartmentID
				)

SELECT 
    E.FirstName + ' ' + E.LastName AS FullName,
    E.Salary,
    D.Name AS Department
FROM
    Employees E
JOIN
    Departments D 
ON E.DepartmentID = D.DepartmentID
WHERE
    E.Salary = (
        SELECT MIN(Salary)
        FROM Employees
        WHERE DepartmentID = E.DepartmentID
    );

-- 24. Find the number of employees and average salary for each department.
--       Hint: The expected result is shown below.

-- | Department                 | Employees | Average Salary |
-- | -------------------------- | --------- | -------------- |
-- | Executive                  | 2         | 92800.00       |
-- | Research and Development   | 6         | 45133.00       |
-- | Engineering                | 6         | 40167.00       |
-- | Information Services       | 10        | 34180.00       |
-- | Sales                      | 18        | 29989.00       |
-- | Tool Design                | 4         | 27150.00       |
-- | Finance                    | 10        | 23930.00       |
-- | Purchasing                 | 12        | 18983.00       |
-- | Production Control         | 6         | 18683.00       |
-- | Human Resources            | 6         | 18017.00       |
-- | Quality Assurance          | 7         | 17543.00       |
-- | Document Control           | 5         | 14400.00       |
-- | Production                 | 179       | 14163.00       |
-- | Marketing                  | 8         | 14063.00       |
-- | Facilities and Maintenance | 7         | 13057.00       |
-- | Shipping and Receiving     | 6         | 10867.00       |
SELECT d.Name as [Department],
	   COUNT(e.EmployeeID) AS [Employees],
	   ROUND(AVG(e.Salary), 0) AS [Average Salary]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name
ORDER BY [Average Salary] DESC

-- 25. Find the average salary in the "Sales" department.
SELECT ROUND(AVG(e.Salary), 0) AS [Average Salary]
FROM Employees e
JOIN Departments d
--ON e.DepartmentID = d.DepartmentID 
ON d.Name LIKE 'Sales'
AND e.DepartmentID = d.DepartmentID 

SELECT ROUND(AVG(e.Salary), 0) AS [Average Salary]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID 
WHERE d.Name LIKE 'Sales'

select avg(Salary) as [Average Salary In Sales]
from Employees
where DepartmentID = (select DepartmentID from Departments where Name = 'Sales')

-- 26. Find the number of employees in the "Sales" department.
SELECT COUNT(*) AS [Employees in Sales] 
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID 
WHERE d.Name = 'Sales'

-- 27. Find the number of all employees that have a manager.

-- 28. Find the number of all employees that have no manager.

-- 29. Find all employees along with their manager. For employees without a manager display the value "(shef4e)".

-- 30. Find all departments and the average salary for each of them.
SELECT d.Name, ROUND(AVG(e.Salary), 0) AS [Average Salary]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID 
GROUP BY d.Name
ORDER BY [Average Salary] DESC

-- 31. Find the number of employees in each town's department. The result table should have 3 columns - Town, Department and Employees Count. 
--       Hint: The expected table has 85 rows. The first 12 rows are shown below.

-- | Town	    | Department	                | Employees Count |
-- | ---------- | ----------------------------- | --------------- |
-- | Bellevue	| Production	                | 22              |
-- | Bellevue	| Purchasing	                | 5               |
-- | Bellevue	| Production Control	        | 2               |
-- | Bellevue	| Marketing	                    | 2               |
-- | Bellevue	| Engineering	                | 1               |
-- | Bellevue	| Human Resources	            | 1               |
-- | Bellevue	| Information Services	        | 1               |
-- | Bellevue	| Research and Development	    | 1               |
-- | Bellevue	| Sales	                        | 1               |
-- | Berlin	    | Sales	                        | 1               |
-- | Bordeaux	| Sales	                        | 1               |
SELECT t.Name AS [Town],
       d.Name AS [Department],
	   COUNT(*) AS [Employees Count]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
JOIN Addresses a 
ON e.AddressID = a.AddressID
JOIN Towns t
ON t.TownID = a.TownID
GROUP BY d.Name, t.Name
ORDER BY t.Name, [Employees Count] DESC

SELECT Towns.Name, Departments.Name AS DepartmentName, COUNT(Employees.EmployeeID) AS NumberOfEmployees
FROM Towns
INNER JOIN Addresses ON Towns.TownID = Addresses.TownID
INNER JOIN Employees ON Employees.AddressID = Addresses.AddressID
INNER JOIN Departments ON Employees.DepartmentID = Departments.DepartmentID
GROUP BY Towns.Name, Departments.Name
ORDER BY Towns.Name ASC, NumberOfEmployees DESC;

SELECT t.Name AS TOWN, d.Name AS Department,
COUNT(e.EmployeeID) AS [Employees Count]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID=d.DepartmentID
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
GROUP BY d.Name, t.Name
ORDER BY t.Name, [Employees Count] desc;

-- 32. Display the first and last name of all managers with exactly 5 employees. 
SELECT * FROM 
	(SELECT Manager.FirstName, Manager.LastName, COUNT (Employee.ManagerID) as EmployeeCount
	 FROM Employees as Employee JOIN Employees as Manager
	 ON Employee.ManagerID = Manager.EmployeeID
	 GROUP BY Employee.ManagerID, Manager.FirstName, Manager.LastName
	) as TempTable
WHERE EmployeeCount = 5;

SELECT CONCAT_WS(' ', Managers.FirstName, Managers.LastName) Name 
	FROM Employees AS Managers
    JOIN Employees AS Inferiors ON Inferiors.ManagerID = Managers.EmployeeID
    GROUP BY CONCAT_WS(' ', Managers.FirstName, Managers.LastName)
    HAVING COUNT(*) = 5

SELECT CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName, COUNT(e.EmployeeID) AS NumberOfEmplyees
FROM Employees e
LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID
WHERE m.ManagerID IS NOT NULL
GROUP BY m.ManagerID, m.FirstName, m.LastName
HAVING COUNT(e.EmployeeID) = 5;

SELECT m.ManagerID, m.FirstName
FROM Employees m
GROUP BY m.ManagerID, m.FirstName
HAVING COUNT(m.ManagerID) = 5;

-- 33. Find the minimal and average employee salary for each department.

-- 34. Find the town with most employees.
select top 1 t.Name as Town, count(*) as Employees
from Employees e
join Addresses a on a.AddressID = e.AddressID
join Towns t on t.TownID = a.TownID
group by t.Name
order by Employees desc

SELECT Towns.Name Town, Count(*) Employees FROM Employees
    JOIN Addresses ON Employees.AddressID = Addresses.AddressID
    JOIN Towns ON Addresses.TownID = Towns.TownID
    GROUP BY Towns.Name
    ORDER BY Count(*) DESC

Select TOP 1
    t.Name 'Town with most employees'
FROM Employees e, Addresses a, Towns t
WHERE e.AddressID = a.AddressID AND a.TownID = t.TownID
GROUP BY t.Name
ORDER BY COUNT(e.EmployeeID) DESC