USE twart;

CREATE PROCEDURE NewDepartment (
    IN title varchar(50),
    IN address varchar(50),
    IN head DATE
  )
BEGIN
    INSERT INTO department ( Department_Title, Address_ID, Department_Head)
      VALUES (title,address,head);
END;

CREATE PROCEDURE ListDepartment (
  )
BEGIN
    SELECT d.Department_ID, d.department_title, d.Address_ID, d.Department_Head
      FROM department as d ;
END;

CREATE PROCEDURE SearchDepartment (
    IN did int(11),
    IN title VARCHAR(50),
    IN address int(11),
    IN head int(11)
  )
BEGIN
  SELECT d.Department_ID,d.Department_Title,d.Address_ID,d.Department_Head
  FROM department as d
    WHERE (d.Department_ID = did OR did IS NULL)
  AND (d.Department_Title = title OR title IS NULL)
  AND (d.Address_ID = address OR address IS NULL )
  AND (d.Department_Head = head OR head IS NULL);
END;

