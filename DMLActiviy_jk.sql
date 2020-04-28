-- basic exercises in groups of 3 (Chinook database)
-- 1. List all customers (full names, customer ID, and country) who are not in the US
SELECT FirstName+ ' ' +LastName AS 'Full Name', CustomerId, Country 
FROM Customer
WHERE Country != 'USA';

-- 2. List all customers from brazil
SELECT * FROM Customer WHERE Country = 'brazil';

-- 3. List all sales agents
SELECT * FROM Employee WHERE Title LIKE '%Sales%Agent%';

-- 4. Show a list of all countries in billing addresses on invoices.
SELECT DISTINCT BillingCountry FROM Invoice;

-- 5. How many invoices were there in 2009, and what was the sales total for that year?
SELECT COUNT(InvoiceId) AS 'Total Sales', SUM(Total) AS 'Sales Total' FROM Invoice WHERE InvoiceDate LIKE '%2009%';

-- 6. How many line items were there for invoice #37?
SELECT COUNT(*) AS '# Line Items' FROM InvoiceLine WHERE InvoiceId = '37';

-- 7. How many invoices per country?
select Count(*) as '# of Invoices', BillingCountryFrom Invoice Group By BillingCountry;

-- 8. Show total sales per country, ordered by highest sales first.
select SUM(Total) as 'Country Sales', BillingCountryFrom Invoice Group By BillingCountry Order By [Country Sales] DESC;

