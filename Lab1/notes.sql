use mmabooks;

/* Week 1 Lectures
 SIMPLE SELECT STATEMENTS 
 */
 
select * from states;

select productcode
from products;

select customerid
from customers;

/* CONDITIONAL SELECT STATEMENTS ('WHERE' CLAUSE) */

/*This is only customer 1*/
select name
from customers
where customerid = 1;

/*Everyone BUT customer 1*/
select name
from customers
where customerid != 1;

/*Select customer that have "ch" anywhere in their name*/
select name
from customers
where name like '%ch%';

/*Select customer that have "ch" start in their name*/







select name
from customers
where name like 'ch%';

/*Select customer that have "ch" end in their name*/
select name
from customers
where name like '%ch';

/*Select customers with a range that is from c -> m*/
select name 
from customers
where name > 'c' and name < 'm';

/*Select customers where customerid is 1, 4, 9, and 12*/
select name 
from customers
where customerid in (1, 4, 9, 12);

/*Select customers whose id is 1 to 12*/
select name 
from customers
where customerid between 1 and 12;

/*Select the customers and order by name (Ascending by default)*/
select *
from customers
order by name;

/*Select the customers and order by name (descending)*/
select *
from customers
order by name desc;

/*Select the customers and order by state and city)*/
select *
from customers
order by state, city;

/*Select the customers ids and names and order by state and city)*/
select customerid, name
from customers
order by state, city;

/*CALCULATIONS*/

/*Selecting an invoice id, its product total, its salestax, its shipping, and add it up and display it as "Calculatedtotal"*/
select invoiceid, producttotal, salestax, shipping,
		producttotal + salestax + shipping AS CalculatedTotal
from invoices;

/*Selecting invoices using integrated functions (month) */
select invoiceid, invoicedate, month(invoicedate) as monthNumber, monthname(invoicedate) as month
from invoices;

/*Select invoices where producttotal, salestax, and shipping are greater than 200, order by ascending Calculated total*/
select *, producttotal + salestax + shipping AS CalculatedTotal
from invoices
where producttotal + salestax + shipping > 200
order by CalculatedTotal;

/* Week 2 Lectures
   Join statements
*/

select invoiceid, invoicedate, customers.customerid, name
from invoices inner join customers on
	invoices.customerid = customers.customerid;

-- Same as ^^ just using aliases
select invoiceid, invoicedate, c.customerid, name
from invoices i inner join customers c on
	i.customerid = c.customerid;
    