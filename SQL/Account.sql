USE twart;

CREATE PROCEDURE NewAccount (
    IN contactID int(11),
    IN clientID int(11),
    IN accountTypeID int(11),
    IN bankingID int(11)
  )
BEGIN
    INSERT INTO account (Contact_ID, Client_ID, Account_Type_ID, Banking_ID)
      VALUES (contactID, clientID, accountTypeID, bankingID);
END;

CREATE PROCEDURE ListAccount (
  )
BEGIN
    SELECT a.Account_ID, a.Contact_ID, a.Client_ID, a.Account_Type_ID, a.Banking_ID
    FROM account AS a;
END;

CREATE PROCEDURE SearchAccount (
    IN aid int(11),
    IN cid int(11),
    IN clid int(11),
    IN atid int(11),
    IN bid int(11)
  )
BEGIN
  SELECT a.Account_ID, a.Contact_ID, a.Client_ID, a.Account_Type_ID, a.Banking_ID
  FROM account as a
    WHERE (c.Client_ID = cid OR cid IS NULL)
  AND (c.Company_Name = companyName OR companyName IS NULL)
  AND (c.Address_ID = addressID OR addressID IS NULL );
END;

CREATE PROCEDURE SearchAddress (
    IN pid int(11),
    IN sid int(11),
    IN gid int(11)
  )
BEGIN
  SELECT c.Client_ID, c.Company_Name, c.Client_ID,
          a.Address_ID,a.Address_Line1,a.Address_Line2,a.Address_Line3,a.Address_Line4,a.Address_Line5,
          a.State,a.County,a.Country,a.Postal_Code
  FROM account as a
  INNER JOIN package as p
  ON a.Account_ID = p
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

