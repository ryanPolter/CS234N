DELIMITER // 
CREATE PROCEDURE usp_ProductCreate (out prodId int, in prodCode_p varchar(10), in description_p varchar(50), in unitPrice_p decimal, in onHandQuantity_p int)
BEGIN
	Insert into products (ProductCode, Description, UnitPrice, OnHandQuantity, concurrencyid)
    Values (prodCode_p, description_p, unitPrice_p, onHandQuantity_p, 1);
    Select LAST_INSERT_ID() into prodId;
    
END //
DELIMITER ; 

DELIMITER // 
CREATE PROCEDURE usp_ProductDelete (in prodId int, in conCurrId int)
BEGIN
	Delete from products where productID = prodId and ConcurrencyID = conCurrId;
END //
DELIMITER ; 

DELIMITER // 
CREATE PROCEDURE usp_ProductSelect (in prodId int)
BEGIN
	Select * from products where productID=prodId;
END //
DELIMITER ;

DELIMITER // 
CREATE PROCEDURE usp_ProductsSelectAll ()
BEGIN
	Select * from products order by ProductID;
END //
DELIMITER ;

DELIMITER // 
CREATE PROCEDURE usp_ProductUpdate (in prodId int, in prodCode varchar(10), in conCurrId int)
BEGIN
	Update products
    Set productCode = prodCode, concurrencyid = (concurrencyid + 1)
    Where productID = prodId and concurrencyid = conCurrId;
END //
DELIMITER ;

DELIMITER // 
CREATE PROCEDURE usp_StateDelete (in code varchar(2), in conCurrId int)
BEGIN
	Delete from states where statecode = code and ConcurrencyID = conCurrId;
END //
DELIMITER ; 

DELIMITER // 
CREATE PROCEDURE usp_StateCreate (in code varchar(2), in name varchar(20))
BEGIN
	Insert into states (statecode, statename) values (code, name);
END //
DELIMITER ;

DELIMITER // 
CREATE PROCEDURE usp_StateSelect (in code varchar(2))
BEGIN
	Select * from states where statecode=code;
END //
DELIMITER ;

DELIMITER // 
CREATE PROCEDURE usp_StateSelectAll ()
BEGIN
	Select * from states order by statename;
END //
DELIMITER ;

DELIMITER // 
CREATE PROCEDURE usp_StateUpdate (in code varchar(2), in name varchar(20), in conCurrId int)
BEGIN
	Update states
    Set statename = name, concurrencyid = (concurrencyid + 1)
    Where statecode = code and concurrencyid = conCurrId;
END //
DELIMITER ;



DELIMITER // 
CREATE PROCEDURE usp_CustomerCreate (out custId int, in name_p varchar(100), in address_p varchar(50), in city_p varchar(20), in state_p varchar(2), in zipcode_p varchar(15))
BEGIN
	Insert into customers (name, address, city, state, zipcode, concurrencyid)
    Values (name_p, address_p, city_p, state_p, zipcode_p, 1);
    Select LAST_INSERT_ID() into custId;
    
END //
DELIMITER ; 

DELIMITER // 
CREATE PROCEDURE usp_CustomerDelete (in custId int, in conCurrId int)
BEGIN
	Delete from customers where customerID = custId and ConcurrencyID = conCurrId;
END //
DELIMITER ; 

DELIMITER // 
CREATE PROCEDURE usp_CustomerSelect (in custId int)
BEGIN
	Select * from customers where customerID=custId;
END //
DELIMITER ;

DELIMITER // 
CREATE PROCEDURE usp_CustomersSelectAll ()
BEGIN
	Select * from customers order by name;
END //
DELIMITER ;

DELIMITER // 
CREATE PROCEDURE usp_CustomerUpdate (in custId int, in name_p varchar(20), in conCurrId int)
BEGIN
	Update customers
    Set name = name, concurrencyid = (concurrencyid + 1)
    Where customerID = custId and concurrencyid = conCurrId;
END //
DELIMITER ;