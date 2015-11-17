USE twart;

CREATE PROCEDURE NewAddress (
    IN line1 varchar(60),
    IN line2 varchar(60),
    IN line3 varchar(60),
    IN line4 varchar(60),
    IN line5 varchar(60),
    IN pstate varchar(25),
    IN pcounty varchar(25),
    IN pcountry varchar(50),
    IN postalCode varchar(10)
  )
BEGIN
    INSERT INTO addressing (Address_Line1, Address_Line2, Address_Line3, Address_Line4, Address_Line5, State, County, Country, Postal_Code)
      VALUES (line1,line2,line3,line4,line5,pstate,pcounty,pcountry,postalCode);
END;

CREATE PROCEDURE ListAddress (
  )
BEGIN
    SELECT a.Address_ID,a.Address_Line1,a.Address_Line2,a.Address_Line3,a.Address_Line4,a.Address_Line5,
            a.State,a.County,a.Country,a.Postal_Code
      from addressing as a;
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
  SELECT a.Address_ID,a.Address_Line1,a.Address_Line2,a.Address_Line3,a.Address_Line4,a.Address_Line5,
            a.State,a.County,a.Country,a.Postal_Code
  FROM addressing as a
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

