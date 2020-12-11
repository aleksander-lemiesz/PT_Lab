insert into Books(id, title, author, type, penaltyCost, returnDate, state)
 
(2, 'Ginger Kid', 'Steve Hofstetter', 'Biography', 17, CONVERT(date, getdate()), 1),
(3, 'Partials', 'Dan Wells', 'Fantasy', 13, CONVERT(date, getdate()), 1),
(4, 'Revived', 'Cat Patrick', 'Fantasy', 10, CONVERT(date, getdate()), 1),
(5, 'Ignite me', 'Tahreth Mafi', 'Fantasy', 20, CONVERT(date, getdate()), 1),
(6, 'Shatter me', 'Tahreth Mafi', 'Fantasy', 20, CONVERT(date, getdate()), 1),
(7, 'Restore me', 'Tahreth Mafi', 'Fantasy', 20, CONVERT(date, getdate()), 1),
(8, 'Unravel me', 'Tahreth Mafi', 'Fantasy', 20, CONVERT(date, getdate()), 1),
(9, 'Before I fall', 'Lauren Oliver', 'Drama', 10, CONVERT(date, getdate()), 1),
(10, 'Crossed', 'Ally Condie', 'Fantasy', 10, CONVERT(date, getdate()), 1),
(11, 'The maze runner', 'James Dashner', 'Action', 20, CONVERT(date, getdate()), 1),
(12, 'Monument 14', 'Emmy Laybourne', 'Apocaliptic', 9, CONVERT(date, getdate()), 1),
(13, 'Passenger', 'Alexandra Bracken', 'Futuristic', 19, CONVERT(date, getdate()), 1),
(14, 'Wayfarer', 'Alexandra Bracken', 'Futuristic', 19, CONVERT(date, getdate()), 1),
(15, 'The future of us', 'Asher', 'Fantasy', 15, CONVERT(date, getdate()), 1),
(16, 'Passenger', 'Alexandra Bracken', 'Futuristic', 19, CONVERT(date, getdate()), 1),
(17, 'Passenger', 'Alexandra Bracken', 'Futuristic', 19, CONVERT(date, getdate()), 1),
(18, 'Tomorrow', 'John Marsden', 'War', 19, CONVERT(date, getdate()), 1),
(19, 'I am not a serial killer', 'Dan Wells', 'Thriller', 5, CONVERT(date, getdate()), 1),
(20, 'Little Women', 'Louisa May Alcott', 'Drama', 19, CONVERT(date, getdate()), 1)

update Books
set returnDate = CONVERT(date, getdate())
where id = 1;
select * from Books

delete from Customers
where id = 100

insert into Customers(id, name, money)
 values
(1, 'Mary Smith', 100),
(2, 'Indiana Jones', 50),
(3, 'Patricia Williams', 1000),
(4, 'John Taylor', 75),
(5, 'Jennifer Davies', 66),
(6, 'Robert Thomas', 74),
 (7, 'Linda Johnson', 120),
 (8, 'William Roberts', 165),
 (9, 'Elizabeth Walker', 83),
 (10, 'David Wright', 200),
 (11, 'Barbara Robinson', 76),
 (12, 'Richard Thompson', 253),
 (13, 'Susan White', 57),
 (14, 'Joseph Hughes', 26),
 (15, 'Jessica Edwards', 678),
 (16, 'Thomas Green', 45),
 (17, 'Sarah Lewis', 94),
 (18, 'Charles Wood', 35),
 (19, 'Karen Harris', 56),
 (20, 'Christopher Martin', 64)

 select * from Customers;