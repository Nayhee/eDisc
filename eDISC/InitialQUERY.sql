USE MASTER
GO

IF NOT EXISTS (
    SELECT [name]
    FROM sys.databases
    WHERE [name] = N'TennesseeDiscsAPI'
)
CREATE DATABASE TennesseeDiscsAPI
GO

USE eDISC
GO

DROP TABLE IF EXISTS Tag;
DROP TABLE IF EXISTS Disc;
DROP TABLE IF EXISTS DiscTag;
DROP TABLE IF EXISTS Brand;
DROP TABLE IF EXISTS Users;

DROP TABLE IF EXISTS DiscType;
DROP TABLE IF EXISTS UserType;
DROP TABLE IF EXISTS CartDisc;
DROP TABLE IF EXISTS Cart;
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS Payment;

CREATE TABLE DiscType (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(55) NOT NULL,

)

CREATE TABLE UserType (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(55) NOT NULL,

)

CREATE TABLE CartDisc (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	cartId INTEGER NOT NULL,
	discId INTEGER NOT NULL,
	userId INTEGER NOT NULL,
	CONSTRAINT FK_CartDisc_Cart FOREIGN KEY (cartId) REFERENCES Cart(Id),
	CONSTRAINT FK_CartDisc_Users FOREIGN KEY (userId) REFERENCES Users(Id),
	CONSTRAINT FK_CartDisc_Disc FOREIGN KEY (discId) REFERENCES Disc(Id),


)

CREATE TABLE Cart (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	userId INTEGER NOT NULL,
	dateCreated DateTime NOT NULL,
	CONSTRAINT FK_Cart_Users FOREIGN KEY (userId) REFERENCES Users(Id),
)

CREATE TABLE Orders (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	userId INTEGER NOT NULL,
	cartId INTEGER NOT NULL,
	orderDate DATETIME NOT NULL,
	Total DECIMAL NOT NULL,
	shippingAddress VARCHAR(155) NOT NULL,
	shippingCity VARCHAR(155) NOT NULL,
	shippingState VARCHAR(155) NOT NULL,
	shippingZip INTEGER NOT NULL
)

CREATE TABLE Payment (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	orderId INTEGER NOT NULL,
	userId INTEGER NOT NULL,
	Amount DECIMAL NOT NULL,
	paymentDate DATETIME NOT NULL,
	CONSTRAINT FK_Payment_Orders FOREIGN KEY (orderId) REFERENCES Orders(Id),
	CONSTRAINT FK_Payment_Users FOREIGN KEY (userId) REFERENCES Users(Id),

)

CREATE TABLE Tag (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(55) NOT NULL
);

CREATE TABLE Disc (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(55) NOT NULL,
	brandId INTEGER NOT NULL,
	Condition VARCHAR(55) NOT NULL,
	Speed INTEGER NOT NULL,
	Glide INTEGER NOT NULL,
	Turn INTEGER NOT NULL,
	Fade INTEGER NOT NULL,
	Plastic VARCHAR(55) NOT NULL,
	Price INTEGER NOT NULL,
	imageUrl VARCHAR(55),
	Description VARCHAR(255),
	Weight INTEGER NOT NULL,
	discTypeId INTEGER NOT NULL,
	CONSTRAINT FK_Disc_DiscType FOREIGN KEY (discTypeId) REFERENCES DiscType(Id),
	CONSTRAINT FK_Disc_Brand FOREIGN KEY (brandId) REFERENCES Brand(Id),
);

CREATE TABLE DiscTag (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	discId INTEGER NOT NULL,
	tagId INTEGER NOT NULL,
	CONSTRAINT FK_DiscTags_Disc FOREIGN KEY (discId) REFERENCES Disc(Id),
	CONSTRAINT FK_DiscTags_Tag FOREIGN KEY (tagId) REFERENCES Tag(Id)
);


CREATE TABLE Brand (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(55) NOT NULL
);

CREATE TABLE Users (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(55) NOT NULL,
	Email VARCHAR(255) NOT NULL,
	userTypeId INTEGER NOT NULL,
	CONSTRAINT UQ_Email UNIQUE(Email),
	CONSTRAINT FK_Users_UserType FOREIGN KEY (userTypeId) REFERENCES UserType(Id),
	
);




INSERT INTO [Users] ([Name], Email, userTypeId) VALUES ('Nathan Traczewski', 'nayhee@gmail.com', 1);
INSERT INTO [Users] ([Name], Email, userTypeId) VALUES ('Ryan Bogle', 'bogle@gmail.com', 2);
INSERT INTO [Users] ([Name], Email, userTypeId) VALUES ('Palmer Adams', 'palmer@gmail.com', 2);

INSERT INTO [DiscType] (Name) VALUES ('ForSale');
INSERT INTO [DiscType] (Name) VALUES ('NotForSale');

INSERT INTO [Brands] ([Name]) VALUES ('Innova');
INSERT INTO [Brands] ([Name]) VALUES ('Discmania');
INSERT INTO [Brands] ([Name]) VALUES ('Prodigy');
INSERT INTO [Brands] ([Name]) VALUES ('Discraft');
INSERT INTO [Brands] ([Name]) VALUES ('MVP');
INSERT INTO [Brands] ([Name]) VALUES ('Westside');

INSERT INTO [Tags] ([Name]) VALUES ('Putter');
INSERT INTO [Tags] ([Name]) VALUES ('Mid-Range');
INSERT INTO [Tags] ([Name]) VALUES ('Fairway Driver');
INSERT INTO [Tags] ([Name]) VALUES ('Distance Driver');
INSERT INTO [Tags] ([Name]) VALUES ('Overstable');
INSERT INTO [Tags] ([Name]) VALUES ('Understable');
INSERT INTO [Tags] ([Name]) VALUES ('Stable');

INSERT INTO [Discs] ([Name], BrandId, TypeId, Condition, Speed, Glide, Turn, Fade, Plastic, Price, Weight, ImageUrl) VALUES ('Pig', 1, 1, 'New', 4, 1, 0, 3, 'Champion', 25, 173, 'pig1.jpg');   
INSERT INTO [Discs] ([Name], BrandId, TypeId, Condition, Speed, Glide, Turn, Fade, Plastic, Price, Weight, ImageUrl) VALUES ('Teebird3', 1, 3, 'New', 8, 4, 0, 2, 'Champion', 25, 173, 'teebird1.jpg');   
INSERT INTO [Discs] ([Name], BrandId, TypeId, Condition, Speed, Glide, Turn, Fade, Plastic, Price, Weight, ImageUrl) VALUES ('Shryke', 1, 4, 'New', 13, 6, -2, 2, 'Star', 20, 173, 'shryke1.jpg');   

INSERT INTO [DiscTags] (DiscId, TagId) VALUES (1, 1);
INSERT INTO [DiscTags] (DiscId, TagId) VALUES (1, 5);
INSERT INTO [DiscTags] (DiscId, TagId) VALUES (2, 3);
INSERT INTO [DiscTags] (DiscId, TagId) VALUES (2, 7);
INSERT INTO [DiscTags] (DiscId, TagId) VALUES (3, 4);
INSERT INTO [DiscTags] (DiscId, TagId) VALUES (3, 6);
