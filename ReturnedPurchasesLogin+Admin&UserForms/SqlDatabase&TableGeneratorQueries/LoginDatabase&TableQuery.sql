CREATE DATABASE Login_Example

USE Login_Example
GO

CREATE TABLE Login (
	userName VARCHAR(20),
	userPassword VARCHAR(20),
	userRole VARCHAR(20)
)

INSERT INTO Login (userName, userPassword, userRole) 
VALUES ('Admin', 'admin123', 'admin'),
	   ('User', 'user123', 'user')