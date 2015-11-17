USE `15ac3d04`;
CREATE FUNCTION Login (
    uname varchar(50),
    upass varchar(50)
  )
    RETURNS INT
BEGIN
    SET @p = '';
    SELECT PWD INTO @p FROM 15ac3d04.user_account where Username = uname;

    IF upass = @p THEN RETURN 1;
    ELSE RETURN 0;
    END IF;

END;

CREATE PROCEDURE 15ac3d04.LoggingIn(
  IN UsersName varchar(50),
    IN UserPass varchar(100)
)
  BEGIN
    SELECT Login(UsersName,UserPass) AS Login, u.AccessLevel
      FROM user_account AS u
      WHERE u.Username = UsersName;
  END;