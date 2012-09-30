USE master

GO

IF EXISTS(SELECT * FROM sysdatabases WHERE name='MyLoginDb')
   DROP DATABASE MyLoginDb

GO

CREATE DATABASE MyLoginDb

GO

USE MyLoginDb

GO

CREATE TABLE MyUsers
(
  UserName VARCHAR(80) NOT NULL PRIMARY KEY,
  UserPassword VARCHAR(80) NOT NULL
)

GO

INSERT INTO MyUsers VALUES('First', '(User1)')
INSERT INTO MyUsers VALUES('Second', '(User2)')
INSERT INTO MyUsers VALUES('Third', '(User3)')
INSERT INTO MyUsers VALUES('Fourth', '(User4)')