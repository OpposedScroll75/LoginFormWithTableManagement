USE Nortwind_III1
GO

CREATE TABLE Returned_Purchases(
	ID INT IDENTITY(1, 1),
	Purchase_Tag VARCHAR(6) NOT NULL,
	Purchase_Name VARCHAR(50) NOT NULL,
	Purchase_Category VARCHAR(20) NOT NULL,
	Return_Cause VARCHAR(60) NOT NULL,
	PRIMARY KEY(ID)
)