USE twart;

CREATE PROCEDURE NewCustomer (
    IN companyName varchar(60),
    IN addressID varchar(60)
  )
BEGIN
    INSERT INTO customer(Company_Name,Address_ID)
      VALUES (companyName,addressID);
END;

CREATE PROCEDURE ListCustomer (
  )
BEGIN
    SELECT c.Client_ID, c.Company_Name, c.Address_ID
    FROM customer AS c;
END;

CREATE PROCEDURE SearchCustomer (
    IN cid int(11),
    IN companyName VARCHAR(60),
    IN addressID VARCHAR(60),
  )
BEGIN
  SELECT c.Client_ID, c.Company_Name, c.Address_ID
  FROM customer as c
    WHERE (c.Client_ID = cid OR cid IS NULL)
  AND (c.Company_Name = companyName OR companyName IS NULL)
  AND (c.Address_ID = addressID OR addressID IS NULL );
END;

CREATE PROCEDURE SearchAddress (
    IN aid int(11),
    IN line1 VARCHAR(60),
    IN line2 VARCHAR(60),
    IN line3 VARCHAR(60),
    IN line4 VARCHAR(60),
    IN line5 VARCHAR(60),
    IN pstate VARCHAR(25),
    IN pcounty VARCHAR(25),
    IN pcountry VARCHAR(50),
    IN postalCode VARCHAR(10)
  )
BEGIN
  SELECT c.Client_ID, c.Company_Name, c.Client_ID,
          a.Address_ID,a.Address_Line1,a.Address_Line2,a.Address_Line3,a.Address_Line4,a.Address_Line5,
          a.State,a.County,a.Country,a.Postal_Code
  FROM customer as c
  INNER JOIN addressing as a
  ON c.Address_ID = a.Address_ID
  WHERE (a.Address_ID = aid OR aid IS NULL)
  AND (a.Address_Line1 = line1 OR line1 IS NULL)
  AND (a.Address_Line2 = line2 OR line2 IS NULL )
  AND (a.Address_Line3 = line3 OR line3 IS NULL)
  AND (a.Address_Line4 = line4 OR line4 IS NULL)
  AND (a.Address_Line5 = line5 OR line5 IS NULL)
  AND (a.State = pstate OR pstate IS NULL)
  AND (a.County = pcounty OR pcounty IS NULL)
  AND (a.Country = pcountry OR pcountry IS NULL)
  AND (a.Postal_Code = postalCode OR postalCode IS NULL);
END;

