<<<<<<< HEAD
--To create database Schema
CREATE DATABASE PostQuery;

--add table customer
CREATE TABLE customer (
	customer_id SERIAL PRIMARY KEY, --AUTO INCREAMENT
	first_name VARCHAR(50) NOT NULL,
	last_name VARCHAR(50) NOT NULL,
	email VARCHAR(50) UNIQUE NOT NULL,
	created_date TIMESTAMPTZ NOT NULL DEFAULT NOW(),
   	updated_date TIMESTAMPTZ 
);

--fetch all customers 
SELECT * FROM customer;

 --Drop the Customer Table If Exists
DROP TABLE IF EXISTS customer;		--remove customer table

-- Add a New Column to Customer
ALTER TABLE customer ADD COLUMN active BOOLEAN;

--Drop the Newly Added Column
ALTER TABLE customer DROP COLUMN active;

-- Rename Columns
ALTER TABLE customer RENAME COLUMN email TO email_address;
--ALTER TABLE customer RENAME COLUMN email_address TO email;

--Rename Table
--ALTER TABLE customer RENAME TO users; -- Rename customer to users
ALTER TABLE users RENAME TO customer;

-- Create Orders Table
CREATE TABLE orders (
    order_id SERIAL PRIMARY KEY,
    customer_id INTEGER NOT NULL REFERENCES customer(customer_id),
    order_date TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    order_number VARCHAR(50) NOT NULL,
    order_amount DECIMAL(10,2) NOT NULL
);

SELECT * FROM orders;

-- Insert a Single Record in Customer
INSERT INTO customer(first_name, last_name, email, created_date, updated_date, active)
VALUES ('Vishal', 'Vasoya', '.vishal.vasoya@tatvasoft.com', NOW(), NULL, true);

-- Insert a Single Record in Customer
INSERT INTO customer(first_name, last_name, email, created_date, updated_date, active)
VALUES ('Bansi', 'Shah', '.bansi.shah@tatvasoft.com', NOW(), NULL, true);


-- Insert Multiple Customer Records
INSERT INTO customer (first_name, last_name, email, created_date, updated_date, active) VALUES
  ('John', 'Doe', 'johndoe@example.com', NOW(), NULL, true),
  ('Alice', 'Smith', 'alicesmith@example.com', NOW(), NULL, true),
  ('Bob', 'Johnson', 'bjohnson@example.com', NOW(), NULL, true),
  ('Emma', 'Brown', 'emmabrown@example.com', NOW(), NULL, true),
  ('Michael', 'Lee', 'michaellee@example.com', NOW(), NULL, false),
  ('Sarah', 'Wilson', 'sarahwilson@example.com', NOW(), NULL, true),
  ('David', 'Clark', 'davidclark@example.com', NOW(), NULL, true),
  ('Olivia', 'Martinez', 'oliviamartinez@example.com', NOW(), NULL, true),
  ('James', 'Garcia', 'jamesgarcia@example.com', NOW(), NULL, false),
  ('Sophia', 'Lopez', 'sophialopez@example.com', NOW(), NULL, false),
  ('Jennifer', 'Davis', 'jennifer.davis@example.com', NOW(), NULL, true),
  ('Jennie', 'Terry', 'jennie.terry@example.com', NOW(), NULL, true),
  ('JENNY', 'SMITH', 'jenny.smith@example.com', NOW(), NULL, false),
  ('Hiren', 'Patel', 'hirenpatel@example.com', NOW(), NULL, false);

INSERT INTO customer (customer_id, first_name, last_name, email)
VALUES (2, 'Test', 'User', 'testuser@example.com');

-- Insert Orders
INSERT INTO orders (customer_id, order_date, order_number, order_amount) VALUES
  (1, '2024-01-01', 'ORD001', 50.00),
  (2, '2024-01-01', 'ORD002', 35.75),
  (3, '2024-01-01', 'ORD003', 100.00),
  (4, '2024-01-01', 'ORD004', 30.25),
  (5, '2024-01-01', 'ORD005', 90.75),
  (6, '2024-01-01', 'ORD006', 25.50),
  (7, '2024-01-01', 'ORD007', 60.00),
  (8, '2024-01-01', 'ORD008', 42.00),
  (9, '2024-01-01', 'ORD009', 120.25),
  (10,'2024-01-01', 'ORD010', 85.00),
  (1, '2024-01-02', 'ORD011', 55.00),
  (1, '2024-01-03', 'ORD012', 80.25),
  (2, '2024-01-03', 'ORD013', 70.00),
  (3, '2024-01-04', 'ORD014', 45.00),
  (1, '2024-01-05', 'ORD015', 95.50),
  (2, '2024-01-05', 'ORD016', 27.50),
  (2, '2024-01-07', 'ORD017', 65.75),
  (2, '2024-01-10', 'ORD018', 75.50);


-- Basic Select Queries
--SELECT first_name FROM customer;
--SELECT first_name, last_name, email FROM customer;
SELECT * FROM customer;


-- Order By Queries  
--SELECT first_name, last_name FROM customer ORDER BY first_name ASC;
--SELECT first_name, last_name FROM customer ORDER BY last_name DESC;
SELECT customer_id, first_name, last_name FROM customer ORDER BY first_name ASC, last_name DESC;


-- WHERE Clause Examples
SELECT last_name, first_name FROM customer WHERE first_name = 'Hiren';
--SELECT customer_id, first_name, last_name FROM customer WHERE first_name = 'Bansi' AND last_name = 'Shah';
--SELECT customer_id, first_name, last_name FROM customer WHERE first_name IN ('John', 'David', 'James');
--SELECT first_name, last_name FROM customer WHERE first_name LIKE '%EN%';
--SELECT first_name, last_name FROM customer WHERE first_name ILIKE '%EN%';


-- Join Examples
SELECT * FROM orders AS o INNER JOIN customer AS c ON o.customer_id = c.customer_id;
SELECT * FROM customer AS c LEFT JOIN orders AS o ON c.customer_id = o.customer_id;


-- Aggregation with GROUP BY
SELECT c.customer_id, c.first_name, c.last_name, c.email,
       COUNT(o.order_id) AS NoOrders,
       SUM(o.order_amount) AS Total
FROM customer AS c
INNER JOIN orders AS o ON c.customer_id = o.customer_id
GROUP BY c.customer_id;  



--  GROUP BY with HAVING
SELECT c.customer_id, c.first_name, c.last_name, c.email,
       COUNT(o.order_id) AS No_Orders,
       SUM(o.order_amount) AS Total
FROM customer AS c
INNER JOIN orders AS o ON c.customer_id = o.customer_id
GROUP BY c.customer_id
HAVING COUNT(o.order_id) > 1;


--  Subqueries
SELECT * FROM orders WHERE customer_id IN (
  SELECT customer_id FROM customer WHERE active = true
);

SELECT customer_id, first_name, last_name, email
FROM customer
WHERE EXISTS (
  SELECT 1 FROM orders WHERE orders.customer_id = customer.customer_id
);



-- Update Statement
UPDATE customer
SET first_name = 'bansi', last_name = 'shah', email = 'bansi.shah@tatvasoft.com'
WHERE customer_id = 1;


-- Delete Statement
DELETE FROM customer WHERE customer_id = 11;

 SELECT * FROM customer;
=======
--To create database Schema
CREATE DATABASE PostQuery;

--add table customer
CREATE TABLE customer (
	customer_id SERIAL PRIMARY KEY, --AUTO INCREAMENT
	first_name VARCHAR(50) NOT NULL,
	last_name VARCHAR(50) NOT NULL,
	email VARCHAR(50) UNIQUE NOT NULL,
	created_date TIMESTAMPTZ NOT NULL DEFAULT NOW(),
   	updated_date TIMESTAMPTZ 
);

--fetch all customers 
SELECT * FROM customer;

 --Drop the Customer Table If Exists
DROP TABLE IF EXISTS customer;		--remove customer table

-- Add a New Column to Customer
ALTER TABLE customer ADD COLUMN active BOOLEAN;

--Drop the Newly Added Column
ALTER TABLE customer DROP COLUMN active;

-- Rename Columns
ALTER TABLE customer RENAME COLUMN email TO email_address;
--ALTER TABLE customer RENAME COLUMN email_address TO email;

--Rename Table
--ALTER TABLE customer RENAME TO users; -- Rename customer to users
ALTER TABLE users RENAME TO customer;

-- Create Orders Table
CREATE TABLE orders (
    order_id SERIAL PRIMARY KEY,
    customer_id INTEGER NOT NULL REFERENCES customer(customer_id),
    order_date TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    order_number VARCHAR(50) NOT NULL,
    order_amount DECIMAL(10,2) NOT NULL
);

SELECT * FROM orders;

-- Insert a Single Record in Customer
INSERT INTO customer(first_name, last_name, email, created_date, updated_date, active)
VALUES ('Vishal', 'Vasoya', '.vishal.vasoya@tatvasoft.com', NOW(), NULL, true);

-- Insert a Single Record in Customer
INSERT INTO customer(first_name, last_name, email, created_date, updated_date, active)
VALUES ('Bansi', 'Shah', '.bansi.shah@tatvasoft.com', NOW(), NULL, true);


-- Insert Multiple Customer Records
INSERT INTO customer (first_name, last_name, email, created_date, updated_date, active) VALUES
  ('John', 'Doe', 'johndoe@example.com', NOW(), NULL, true),
  ('Alice', 'Smith', 'alicesmith@example.com', NOW(), NULL, true),
  ('Bob', 'Johnson', 'bjohnson@example.com', NOW(), NULL, true),
  ('Emma', 'Brown', 'emmabrown@example.com', NOW(), NULL, true),
  ('Michael', 'Lee', 'michaellee@example.com', NOW(), NULL, false),
  ('Sarah', 'Wilson', 'sarahwilson@example.com', NOW(), NULL, true),
  ('David', 'Clark', 'davidclark@example.com', NOW(), NULL, true),
  ('Olivia', 'Martinez', 'oliviamartinez@example.com', NOW(), NULL, true),
  ('James', 'Garcia', 'jamesgarcia@example.com', NOW(), NULL, false),
  ('Sophia', 'Lopez', 'sophialopez@example.com', NOW(), NULL, false),
  ('Jennifer', 'Davis', 'jennifer.davis@example.com', NOW(), NULL, true),
  ('Jennie', 'Terry', 'jennie.terry@example.com', NOW(), NULL, true),
  ('JENNY', 'SMITH', 'jenny.smith@example.com', NOW(), NULL, false),
  ('Hiren', 'Patel', 'hirenpatel@example.com', NOW(), NULL, false);

INSERT INTO customer (customer_id, first_name, last_name, email)
VALUES (2, 'Test', 'User', 'testuser@example.com');

-- Insert Orders
INSERT INTO orders (customer_id, order_date, order_number, order_amount) VALUES
  (1, '2024-01-01', 'ORD001', 50.00),
  (2, '2024-01-01', 'ORD002', 35.75),
  (3, '2024-01-01', 'ORD003', 100.00),
  (4, '2024-01-01', 'ORD004', 30.25),
  (5, '2024-01-01', 'ORD005', 90.75),
  (6, '2024-01-01', 'ORD006', 25.50),
  (7, '2024-01-01', 'ORD007', 60.00),
  (8, '2024-01-01', 'ORD008', 42.00),
  (9, '2024-01-01', 'ORD009', 120.25),
  (10,'2024-01-01', 'ORD010', 85.00),
  (1, '2024-01-02', 'ORD011', 55.00),
  (1, '2024-01-03', 'ORD012', 80.25),
  (2, '2024-01-03', 'ORD013', 70.00),
  (3, '2024-01-04', 'ORD014', 45.00),
  (1, '2024-01-05', 'ORD015', 95.50),
  (2, '2024-01-05', 'ORD016', 27.50),
  (2, '2024-01-07', 'ORD017', 65.75),
  (2, '2024-01-10', 'ORD018', 75.50);


-- Basic Select Queries
--SELECT first_name FROM customer;
--SELECT first_name, last_name, email FROM customer;
SELECT * FROM customer;


-- Order By Queries  
--SELECT first_name, last_name FROM customer ORDER BY first_name ASC;
--SELECT first_name, last_name FROM customer ORDER BY last_name DESC;
SELECT customer_id, first_name, last_name FROM customer ORDER BY first_name ASC, last_name DESC;


-- WHERE Clause Examples
SELECT last_name, first_name FROM customer WHERE first_name = 'Hiren';
--SELECT customer_id, first_name, last_name FROM customer WHERE first_name = 'Bansi' AND last_name = 'Shah';
--SELECT customer_id, first_name, last_name FROM customer WHERE first_name IN ('John', 'David', 'James');
--SELECT first_name, last_name FROM customer WHERE first_name LIKE '%EN%';
--SELECT first_name, last_name FROM customer WHERE first_name ILIKE '%EN%';


-- Join Examples
SELECT * FROM orders AS o INNER JOIN customer AS c ON o.customer_id = c.customer_id;
SELECT * FROM customer AS c LEFT JOIN orders AS o ON c.customer_id = o.customer_id;


-- Aggregation with GROUP BY
SELECT c.customer_id, c.first_name, c.last_name, c.email,
       COUNT(o.order_id) AS NoOrders,
       SUM(o.order_amount) AS Total
FROM customer AS c
INNER JOIN orders AS o ON c.customer_id = o.customer_id
GROUP BY c.customer_id;  



--  GROUP BY with HAVING
SELECT c.customer_id, c.first_name, c.last_name, c.email,
       COUNT(o.order_id) AS No_Orders,
       SUM(o.order_amount) AS Total
FROM customer AS c
INNER JOIN orders AS o ON c.customer_id = o.customer_id
GROUP BY c.customer_id
HAVING COUNT(o.order_id) > 1;


--  Subqueries
SELECT * FROM orders WHERE customer_id IN (
  SELECT customer_id FROM customer WHERE active = true
);

SELECT customer_id, first_name, last_name, email
FROM customer
WHERE EXISTS (
  SELECT 1 FROM orders WHERE orders.customer_id = customer.customer_id
);



-- Update Statement
UPDATE customer
SET first_name = 'bansi', last_name = 'shah', email = 'bansi.shah@tatvasoft.com'
WHERE customer_id = 1;


-- Delete Statement
DELETE FROM customer WHERE customer_id = 11;

 SELECT * FROM customer;
>>>>>>> 57a2bd3 (Day to Basics of Angular)
