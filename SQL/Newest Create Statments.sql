CREATE DATABASE IF NOT EXISTS `TWART`;

USE `TWART`;

CREATE TABLE IF NOT EXISTS Role
(
Role_ID INT(11) NOT NULL AUTO_INCREMENT,
Role_Title varchar(50) NOT NULL, 
PRIMARY KEY (Role_ID)
);

CREATE TABLE IF NOT EXISTS Goods
(
Goods_ID INT(11) NOT NULL AUTO_INCREMENT,
Item_Name varchar(40) NOT NULL, 
PRIMARY KEY (Goods_ID)
);

CREATE TABLE IF NOT EXISTS Transportation
(
Transportation_ID INT(11) NOT NULL AUTO_INCREMENT,
Transportation_Type varchar(15) NOT NULL, 
PRIMARY KEY (Transportation_ID)
);

CREATE TABLE IF NOT EXISTS Addressing
(
Address_ID INT(11) NOT NULL AUTO_INCREMENT, 
Address_Line1 varchar(60) NOT NULL,
Address_Line2 varchar(60) DEFAULT NULL,
Address_Line3 varchar(60) DEFAULT NULL,
Address_Line4 varchar(60) DEFAULT NULL,
Address_Line5 varchar(60) DEFAULT NULL,
State varchar(25) DEFAULT NULL,
County varchar(25) DEFAULT NULL,
Country varchar(25) NOT NULL,
Postal_Code varchar(10) NOT NULL,
PRIMARY KEY (Address_ID) 
);

CREATE TABLE IF NOT EXISTS Contact
(
Contact_ID INT(11) NOT NULL AUTO_INCREMENT,
Forename varchar(50) DEFAULT NULL,
Surname varchar(50) NOT NULL,
Position varchar(50) DEFAULT NULL,
Tel_Number varchar(21) DEFAULT NULL,
PRIMARY KEY (Contact_ID)
);

CREATE TABLE IF NOT EXISTS Account_Type
(
Account_Type_ID INT(11) NOT NULL AUTO_INCREMENT,
Account_Name varchar(30) NOT NULL,
Benefit varchar(255) DEFAULT NULL,
Cost decimal(13,4) NOT NULL,
PRIMARY KEY (Account_Type_ID) 
);

CREATE TABLE IF NOT EXISTS Depot
(
Depot_ID INT(11) NOT NULL AUTO_INCREMENT, 
Depot_Name varchar(50) NOT NULL,
Size int DEFAULT NULL,
NumVehicles int NOT NULL, 
Address_ID INT(11) NOT NULL,
Depot_Manager INT(11) DEFAULT NULL, 
PRIMARY KEY (Depot_ID), 
FOREIGN KEY (Address_ID) REFERENCES Addressing(Address_ID)  
);

CREATE TABLE IF NOT EXISTS Department
(
Department_ID INT(11) NOT NULL AUTO_INCREMENT,
Department_Title varchar(50) NOT NULL, 
Address_ID INT(11) NOT NULL,
Department_Head INT(11) DEFAULT NULL,
PRIMARY KEY (Department_ID), 
FOREIGN KEY (Address_ID) REFERENCES Addressing(Address_ID)
);

CREATE TABLE IF NOT EXISTS Package_Specification
(
Specification_ID INT(11) NOT NULL AUTO_INCREMENT,
Desired_Delivery_Date DATETIME NOT NULL,
Weight int DEFAULT NULL,
Dimension_Height int DEFAULT NULL,
Dimension_Width int DEFAULT NULL, 
Dimension_Length int DEFAULT NULL,
Handling_requirements varchar(255) DEFAULT NULL, 
Transportation_ID INT(11) NOT NULL,
PRIMARY KEY (Specification_ID),
FOREIGN KEY (Transportation_ID) REFERENCES Transportation(Transportation_ID) 
);

CREATE TABLE IF NOT EXISTS Package
(
Package_ID INT(11) NOT NULL AUTO_INCREMENT, 
Specification_ID INT(11) NOT NULL, 
Goods_ID INT(11) NOT NULL, 
PRIMARY KEY (Package_ID), 
FOREIGN KEY (Specification_ID) REFERENCES Package_Specification(Specification_ID), 
FOREIGN KEY (Goods_ID) REFERENCES Goods(Goods_ID) 
);


CREATE TABLE IF NOT EXISTS Employee
(
Employee_ID INT(11) NOT NULL AUTO_INCREMENT, 
Forenames varchar(50) DEFAULT NULL,
Surname varchar(50) NOT NULL, 
DOB date NOT NULL,
Contact_Number Varchar(21) NULL, 
Start_Date date NOT NULL,
End_Date date DEFAULT NULL,
Department_ID INT(11) NOT NULL,
Depot_ID INT(11) DEFAULT NULL, 
Role_ID INT(11) NOT NULL,
PRIMARY KEY (Employee_ID),
CONSTRAINT FOREIGN KEY (Department_ID) REFERENCES Department(Department_ID),
CONSTRAINT FOREIGN KEY (Role_ID) REFERENCES Role(Role_ID),
CONSTRAINT FOREIGN KEY (Depot_ID) REFERENCES Depot(Depot_ID)
);

CREATE TABLE IF NOT EXISTS Customer
(
Client_ID INT(11) NOT NULL AUTO_INCREMENT, 
Company_Name varchar(50) NOT NULL, 
Address_ID INT(11) NOT NULL, 
PRIMARY KEY (Client_ID), 
FOREIGN KEY (Address_ID) REFERENCES Addressing(Address_ID) 
);

CREATE TABLE IF NOT EXISTS Banking
(
Banking_ID INT(11) NOT NULL AUTO_INCREMENT,
Address_ID INT(11) DEFAULT NULL,
Sort_Code varchar(8) NOT NULL,
Account_Number int NOT NULL,
Client_ID INT(11) NOT NULL,
PRIMARY KEY (Banking_ID), 
FOREIGN KEY (Address_ID) REFERENCES Addressing(Address_ID), 
FOREIGN KEY (Client_ID) REFERENCES Customer(Client_ID)
);

CREATE TABLE IF NOT EXISTS Account
(
Account_ID INT(11) NOT NULL AUTO_INCREMENT, 
Contact_ID INT(11) NOT NULL, 
Client_ID INT(11) NOT NULL, 
Account_Type_ID INT(11) NOT NULL,
Banking_ID INT(11) NOT NULL,
PRIMARY KEY (Account_ID), 
FOREIGN KEY (Client_ID) REFERENCES Customer(Client_ID), 
FOREIGN KEY (Contact_ID) REFERENCES Contact(Contact_ID),
FOREIGN KEY (Account_Type_ID) REFERENCES Account_Type(Account_Type_ID), 
FOREIGN KEY (Banking_ID) REFERENCES Banking(Banking_ID) 
);

CREATE TABLE IF NOT EXISTS Purchace
(
Order_ID INT(11) NOT NULL AUTO_INCREMENT, 
Order_Status varchar(255) DEFAULT NULL,
Date_Placed DATETIME NOT NULL,
Date_Received DATETIME DEFAULT NULL,
Date_Delivered DATETIME DEFAULT NULL,
Goods_ID INT(11) NOT NULL,
Destination_Address INT(11) NOT NULL,
Source_Address INT(11) NOT NULL,
Account_ID INT(11) NOT NULL,
PRIMARY KEY (Order_ID), 
FOREIGN KEY (Goods_ID) REFERENCES Goods (Goods_ID), 
FOREIGN KEY (Account_ID) REFERENCES Account(Account_ID),  
FOREIGN KEY (Source_Address) REFERENCES Addressing(Address_ID), 
FOREIGN KEY (Destination_Address) REFERENCES Addressing(Address_ID)  
);

CREATE TABLE IF NOT EXISTS Delays
(
Delay_ID INT(11) NOT NULL AUTO_INCREMENT,
Delay_Time1 DATETIME NOT NULL,
Delay_Time2 DATETIME DEFAULT NULL,
Reason varchar(255),
Order_ID INT(11) NOT NULL,
PRIMARY KEY (Delay_ID), 
FOREIGN KEY (Order_ID) REFERENCES Purchace(Order_ID)
);

CREATE TABLE IF NOT EXISTS Sale_Transaction
(
Sale_Transaction_ID INT(11) NOT NULL AUTO_INCREMENT,
Date_Of_Order DATETIME NOT NULL,
Order_ID INT(11) NOT NULL, 
Client_ID INT(11) NOT NULL,
Banking_ID INT(11) NOT NULL,
PRIMARY KEY (Sale_Transaction_ID), 
FOREIGN KEY (Client_ID) REFERENCES Customer(Client_ID),  
FOREIGN KEY (Order_ID) REFERENCES Purchace(Order_ID), 
FOREIGN KEY (Banking_ID) REFERENCES Banking(Banking_ID)
);

ALTER TABLE Department ADD FOREIGN KEY (Department_Head) REFERENCES Employee(Employee_ID);
ALTER TABLE Depot ADD FOREIGN KEY (Depot_Manager) REFERENCES Employee(Employee_ID);