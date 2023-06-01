-- 1. Find all information about all departments.
SELECT * FROM departments;
-- 2. Find all department names.
SELECT Departments.Name FROM Departments;
-- 3. Find the salary of each employee.
SELECT Employees.Salary FROM Employees
-- 4. Write a SQL to find the full name of each employee. 
--       Hint: Full name is constructed by joining first, middle and last name.
SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName) FROM Employees;
-- 5. Find all different employee salaries.
SELECT DISTINCT Salary FROM Employees;
-- 6. Find all information about the employees whose job title is "Sales Representative" or "Sales Manager".
SELECT * FROM Employees WHERE JobTitle IN ('Sales Representative', 'Sales Manager');
-- 7. Find the names of all employees whose first name starts with "SA".
SELECT * FROM Employees WHERE FirstName LIKE 'SA%';
-- 8. Find the names of all employees whose last name contains "ei".
SELECT * FROM Employees WHERE LastName LIKE '%ei%';
-- 9. Find the salary of all employees whose salary is in the range [20000…30000].
SELECT * FROM Employees WHERE Salary BETWEEN 20000 AND 30000;
-- 10. Find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
SELECT * FROM Employees WHERE Salary IN (25000, 14000, 12500, 23600);
-- 11. Find all employees that do not have manager.
SELECT * FROM Employees WHERE ManagerID IS NULL;
-- 12. Find all employees that have salary more than 50000. Order them in decreasing order by salary.
SELECT * FROM Employees WHERE Salary > 50000 ORDER BY Salary DESC;
-- 13. Find the top 5 best paid employees.
SELECT TOP 5 CONCAT(FirstName, ' ', LastName, ' receives $', Salary)
FROM Employees
ORDER BY Salary DESC
-- 14. Find all employees along with their address. Use inner join with ON clause.
SELECT e.EmployeeID, e.FirstName, e.LastName, a.AddressText, e.AddressID, a.AddressID
FROM Employees e 
JOIN Addresses a
ON e.AddressID = a.AddressID
-- 15. Find all employees and their address. Use equijoins (conditions in the WHERE clause).
SELECT e.*, a.AddressText
FROM employees e, addresses a
WHERE e.AddressID = a.AddressID;
-- 16. Find all employees along with their manager.
SELECT e.*, m.FirstName AS ManagerFirstName, m.LastName AS ManagerLastName, a.AddressText AS ManagerAdress
FROM employees e
LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID
LEFT JOIN Addresses a ON m.AddressID = a.AddressID;
-- 17. Find all employees, along with their manager's address. 
--       Hint: Join Employees AS e, Employees AS m and Addresses.
SELECT e.*, m.FirstName AS ManagerFirstName, m.LastName AS ManagerLastName, a.AddressText +', ' + t.Name AS ManagerAdress
FROM Employees e
LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID
LEFT JOIN Addresses a ON m.AddressID = a.AddressID
LEFT JOIN Towns t ON t.TownID = a.TownID;
-- 18. Find all departments and all town names as a single list. 
--       Hint: Use UNION (https://www.w3schools.com/sql/sql_union.asp)
SELECT d.Name
FROM Departments d
UNION 
SELECT t.Name
FROM Towns t
-- 19. Write a SQL query that lists the name of each employee along with the name of their manager.
--       Hint: Use RIGHT OUTER JOIN (https://www.w3schools.com/sql/sql_join_right.asp). Rewrite the query using LEFT OUTER JOIN.
--             The expected result after using RIGHT OUTER JOIN is shown below.
--RIGHT
SELECT CONCAT(e.FirstName, ' ', e.LastName) as Employee,
       CONCAT(m.FirstName, ' ', m.LastName) as Manager
FROM Employees m 
RIGHT JOIN Employees e
    ON e.ManagerID = m.EmployeeID
-- LEFT
SELECT CONCAT(e.FirstName, ' ', e.LastName) as Employee,
       CONCAT(m.FirstName, ' ', m.LastName) as Manager
FROM Employees e 
LEFT JOIN Employees m
    ON e.ManagerID = m.EmployeeID
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
-- 20. Find the names of all employees who were hired between 1995 and 2005 and are part of the "Sales" or "Finance" departments.
SELECT CONCAT(e.FirstName, ' ', e.LastName, ' - ', d.Name, ', [', DatePart(YEAR, e.HireDate), ']')
FROM Employees e 
JOIN Departments d
    ON e.DepartmentID = d.DepartmentID   
WHERE d.Name IN ('Sales', 'Finance')
    AND DATEPART(YEAR, e.HireDate) BETWEEN 1995 AND 2005


-- 21. Find the names and salaries of the employees that take the minimal salary in the company.
--       Hint: Use a nested SELECT statement.
SELECT e.FirstName, e.LastName, e.Salary
FROM Employees e
WHERE e.Salary = (SELECT MIN(Salary) FROM Employees);
-- 22. Find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
SELECT e.FirstName, e.LastName, e.Salary
FROM Employees e
WHERE e.Salary <= 1.1 * (SELECT MIN(Salary) FROM Employees);
-- 23. Find the full name, salary and department of the employees that take the minimal salary in their department.
--       Hint: Use a nested SELECT statement.
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS FullName, e.Salary, d.Name
FROM Employees e
INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = (SELECT MIN(Salary) FROM Employees WHERE DepartmentID = e.DepartmentID);
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
SELECT d.Name, COUNT(e.EmployeeID) AS Employees, AVG(e.Salary) AS AverageSalary
FROM Departments d
LEFT JOIN Employees e ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name
ORDER BY AverageSalary DESC;
-- 25. Find the average salary in the "Sales" department.
SELECT AVG(Salary) AS AverageSalary
FROM Employees
WHERE DepartmentID = (SELECT DepartmentID FROM Departments WHERE Departments.Name = 'Sales');
-- 26. Find the number of employees in the "Sales" department.
SELECT COUNT(*) AS EmployeeCount
FROM Employees
WHERE DepartmentID = (SELECT DepartmentID FROM Departments WHERE Departments.Name = 'Sales');
-- 27. Find the number of all employees that have a manager.
SELECT COUNT(*) AS EmployeeCount
FROM Employees
WHERE ManagerID IS NOT NULL;
-- 28. Find the number of all employees that have no manager.
SELECT COUNT(*) AS EmployeeCount
FROM Employees
WHERE ManagerID IS NULL;
-- 29. Find all employees along with their manager. For employees without a manager display the value "(shef4e)".
SELECT e.FirstName + ' ' + e.LastName AS Employee, ISNULL(m.FirstName + ' ' + m.LastName, '(shef4e)') AS Manager
FROM Employees e
LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID;
-- 30. Find all departments and the average salary for each of them.
SELECT d.Name, AVG(e.Salary) AS AverageSalary
FROM Departments d
JOIN Employees e ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name;
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
SELECT t.Name AS Town, d.Name AS Department, COUNT(*) AS EmployeesCount
FROM Employees e
JOIN Addresses a ON e.AddressID = a.AddressID
JOIN Departments d ON e.DepartmentID = d.DepartmentID
JOIN Towns t ON a.TownID = t.TownID
GROUP BY t.Name, d.Name
ORDER BY t.Name ASC,EmployeesCount DESC;
-- 32. Display the first and last name of all managers with exactly 5 employees. 
SELECT m.FirstName, m.LastName
FROM Employees m
JOIN Employees e ON m.EmployeeID = e.ManagerID
GROUP BY m.EmployeeID, m.FirstName, m.LastName
HAVING COUNT(*) = 5;
-- 33. Find the minimal and average employee salary for each department.
SELECT d.Name, MIN(e.Salary) AS MinimalSalary, AVG(e.Salary) AS AverageSalary
FROM Departments d
JOIN Employees e ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name;
-- 34. Find the town with most employees.
SELECT TOP 1 a.TownID, COUNT(*) AS EmployeeCount
FROM Employees e
JOIN Addresses a ON e.AddressID = a.AddressID
GROUP BY a.TownID
ORDER BY COUNT(*) DESC;