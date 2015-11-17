
CREATE TABLE User
(
    UID int PRIMARY KEY NOT NULL AUTO_INCREMENT,
    Username varchar(50) NOT NULL,
    PWD varchar(100) NOT NULL,
    AccessLevel varchar(10) NOT NULL
);
CREATE UNIQUE INDEX User_UID_uindex ON User (UID);
CREATE UNIQUE INDEX User_Username_uindex ON User (Username)