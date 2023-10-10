use mmabooks;
/* Lab 1 */

-- 1. Select all of the customers who live in NY state.  Show id, name, city and state.
select customerid, name, state
from customers
where state = 'NY'
order by name;

-- 2. Select all of the states that start with A .  Show both code and name. 
select statecode, statename
from states
where statename like 'A%';

-- 3. Select all of the Products that have a price between 50 and 60 dollars.  Show code, description, price and quantity.  Sort by price. 
select productcode, description, unitprice, onhandquantity
from products
where unitprice <= 60 and unitprice >= 50
order by unitprice;

-- 4. Get the value of the inventory that we have on hand for each product.  Show code, description, price, quantity and value.  Sort by value.
select productcode, description, unitprice, onhandquantity 
from products 
order by onhandquantity;

-- 5. Get me a list of the invoices.  Show invoice id, customerid, invoice month as a number, invoice month as a word, invoice year.  Sort by year and month number. 
select InvoiceID, customerid, month(invoicedate) as MonthDate, monthname(invoicedate) as Month, year(invoicedate) as Year
from invoices
order by Year, MonthDate;

-- 6. Get me all of the information for the following products:  A4CS, ADC4, CS10 
select *
from products
where productcode in ('A4CS', 'ADC4', 'CS10');
 
-- 7. Add the name of the state to the result set from #1
select customerid, name, city, state, statename
from customers c join states s on
	c.state = s.statecode
where state = 'NY'
order by name;

-- 8. Add the customer's name to the result set from #5
select name, InvoiceID, i.customerid, month(invoicedate) as MonthDate, monthname(invoicedate) as Month, year(invoicedate) as Year
from invoices i join customers c on
i.customerid = c.customerid
order by Year, MonthDate;

-- 9. Get me a list of all of the products that have been ordered.  Show all of the product information 
--    as well as the invoice id and the quantity ordered on each invoice. 
select p.productcode, description, p.unitprice, onhandquantity, il.invoiceid, il.quantity, il.unitprice
from products p join invoicelineitems il 
on p.productcode = il.productcode;

-- 10. Get me a list of all of the invoices.  Show this invoiceid, customerid and invoicedate 
-- as well as the productcode, description, unitprice and quantity for each product ordered on the invoice. 
-- You'll have more than one record for each invoice.
select i.invoiceid, customerid, invoicedate, p.productcode, description, p.unitprice, quantity
from products p join invoicelineitems il
on p.productcode = il.productcode
join invoices i 
on i.invoiceid = il.invoiceid
order by invoiceid;

-- 11. Add the customer's name and statecode to the results from #10. 
select i.invoiceid, c.customerid, invoicedate, p.productcode, description, p.unitprice, quantity, name, state
from products p join invoicelineitems il
on p.productcode = il.productcode
join invoices i 
on i.invoiceid = il.invoiceid
join customers c
on c.customerid = i.customerid
order by invoiceid;

-- 12. Add the name of the state to the results from #11. 
select i.invoiceid, c.customerid, invoicedate, p.productcode, description, p.unitprice, quantity, name, state, statename
from products p join invoicelineitems il
on p.productcode = il.productcode
join invoices i 
on i.invoiceid = il.invoiceid
join customers c
on c.customerid = i.customerid
join states s
on s.statecode = c.state
order by invoiceid;

-- 13. How many products do we have? 
select count(*) as TotalProductCount
from products;

-- 14. How many customers do we have? 
select count(*) as TotalCustomerCount
from customers;

-- 15. What's the total value of all of the products we have on hand? 
select sum(unitprice * onhandquantity) as TotalValue
from products;

-- 16. What's the total value of ALL of the products we have sold?  
-- Use the itemtotal from invoicelineitems to do the calculation.
select sum(itemtotal * quantity) as TotalValueProductsSole
from invoicelineitems;

-- 17. What's the total value of EACH products we have sold?  Use the itemtotal from invoicelineitems to do the calculation.  
-- Show the productcode as well as the total for that product. 
select productcode, sum(itemtotal) as TotalSold
from invoicelineitems 
group by productcode;

-- 18. Add the product description to #17. 
select description, il.productcode, sum(itemtotal) as TotalSold
from invoicelineitems il join products p 
on il.productcode = p.productcode
group by productcode;

-- 19. How many orders (invoices) has each customer placed?  Show customerid, name and count. 
select name, count(c.customerid)
from customers c join invoices i 
on c.customerid = i.customerid
group by c.name;

/*select name
from customers c join invoices i
on c.customerid = i.customerid
where name = 'Johnson, Ajith';*/

-- 20. List all customers, even if they don't have any orders.  Show customerid, name and count of orders (invoices). 
select c.customerid, name, count(invoiceid) 
from customers c left join invoices i
on c.customerid = i.customerid
group by customerid, name
order by count(invoiceid);
