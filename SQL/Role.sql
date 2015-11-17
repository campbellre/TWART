USE TWART;

CREATE PROCEDURE NewRole (
    IN title varchar(50)
  )
BEGIN
    INSERT INTO role(Role_Title)
      VALUES (title);
END;

CREATE PROCEDURE ListRole (
  )
BEGIN
    SELECT r.Role_id, r.role_Title
      FROM role as r;
END;

CREATE PROCEDURE SearchRole (
    IN rid int(11),
    IN title VARCHAR(50)
  )
BEGIN
  SELECT r.Role_ID,r.Role_Title
  FROM role as r
    WHERE (r.Role_ID = rid OR rid IS NULL)
  AND (r.Role_Title = title OR title IS NULL);
END;


