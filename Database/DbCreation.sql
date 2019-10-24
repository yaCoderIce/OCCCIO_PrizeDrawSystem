-- 2019-02-28
-- Brett Didemus, Niagara College
-- Prize Draw Database Creation Script

BEGIN TRANSACTION

DROP TABLE Scans;
DROP TABLE Winners;
DROP TABLE Prizes;
DROP TABLE UserRoles;
DROP TABLE [Roles];
DROP TABLE [Users];
DROP TABLE Attendees;
DROP TABLE Vendors;

CREATE TABLE Vendors (
	Id INT IDENTITY PRIMARY KEY,
	Name VARCHAR(100) NOT NULL,
	Logo VARBINARY(MAX)); 

CREATE TABLE Attendees (
	Id INT PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
	Email VARCHAR(100),
	MobilePhone VARCHAR(50),
	Address1 VARCHAR(100),
	Address2 VARCHAR(100),
	City VARCHAR(25),
	Province CHAR(2),
	PostalCode CHAR(6),
	JobTitle VARCHAR(100),
	Company VARCHAR(100),
	IsCheckedIn BIT DEFAULT 0 NOT NULL,
	CheckedInTime DATETIME DEFAULT NULL);
	
CREATE TABLE Users (
	Id INT IDENTITY PRIMARY KEY,
	UserName VARCHAR(25) NOT NULL UNIQUE,
	PasswordHash VARCHAR(255) DEFAULT NULL,
	VendorId INT DEFAULT NULL,
	CONSTRAINT fk_users_vendors_vendorid FOREIGN KEY(VendorId) REFERENCES Vendors(Id));

CREATE TABLE Roles (
	Id INT IDENTITY PRIMARY KEY,
	Name VARCHAR(20) NOT NULL);

CREATE TABLE UserRoles (
	UserId INT,
	RoleId INT,
	CONSTRAINT pk_userroles_userid_roleid PRIMARY KEY(UserId, RoleId));

CREATE TABLE Prizes (
	Id INT IDENTITY PRIMARY KEY,
	Name VARCHAR(100) NOT NULL,
	Value MONEY,
	Image VARBINARY(MAX),
	VendorId INT,
	NumberAvailable INT NOT NULL DEFAULT 1,
	CONSTRAINT fk_prize_vendors_vendorid FOREIGN KEY(VendorId) REFERENCES Vendors(Id));
	
CREATE TABLE Scans (
	AttendeeId INT,
	VendorId INT, -- ScannedBy
	CONSTRAINT pk_prizewinners_attendeeid_vendorId PRIMARY KEY(AttendeeId, VendorId),
	CONSTRAINT fk_prizewinners_attendees_anttendeeid FOREIGN KEY(AttendeeId) REFERENCES Attendees(Id),
	CONSTRAINT fk_prizewinners_vendors_vendorid FOREIGN KEY(VendorId) REFERENCES Vendors(Id));
	
CREATE TABLE Winners (
	PrizeId INT,
	AttendeeId INT,
	CONSTRAINT pk_winners_prizeid_attendeeid PRIMARY KEY(PrizeId, AttendeeId),
	CONSTRAINT fk_prizewinners_prizes_prizeid FOREIGN KEY(PrizeId) REFERENCES Prizes(Id),
	CONSTRAINT fk_prizewinners_attendee_attendeeid FOREIGN KEY(Attendeeid) REFERENCES Attendees(Id));

INSERT INTO Roles VALUES ('Admin'), ('Vendor'), ('Staff');
INSERT INTO Users (UserName) VALUES ('admin'), ('staff')

INSERT INTO UserRoles (UserId, RoleId) VALUES (1, 1);

--COMMIT
--ROLLBACK