USE MASTER
GO

IF NOT EXISTS (
    SELECT [name]
    FROM sys.databases
    WHERE [name] = N'eDISC'
)
CREATE DATABASE eDISC
GO

USE eDISC
GO

DROP TABLE IF EXISTS Tags;
DROP TABLE IF EXISTS Discs;
DROP TABLE IF EXISTS DiscTags;
DROP TABLE IF EXISTS Brands;
DROP TABLE IF EXISTS Users;
DROP TABLE IF EXISTS SoldDiscs;


CREATE TABLE Tags (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(55) NOT NULL
);

CREATE TABLE Discs (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(55) NOT NULL,
	BrandId INTEGER NOT NULL,
	TypeId INTEGER NOT NULL,
	Condition VARCHAR(55) NOT NULL,
	Speed INTEGER NOT NULL,
	Glide INTEGER NOT NULL,
	Turn INTEGER NOT NULL,
	Fade INTEGER NOT NULL,
	Plastic VARCHAR(55) NOT NULL,
	Price INTEGER NOT NULL,
	Weight INTEGER NOT NULL,
	ImageUrl VARCHAR(55)
);

CREATE TABLE DiscTags (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	DiscId INTEGER NOT NULL,
	TagId INTEGER NOT NULL,
	CONSTRAINT FK_DiscTags_Discs FOREIGN KEY (DiscId) REFERENCES Discs(Id),
	CONSTRAINT FK_DiscTags_Tags FOREIGN KEY (TagId) REFERENCES Tags(Id)
);


CREATE TABLE Brands (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(55) NOT NULL
);

CREATE TABLE Users (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(55) NOT NULL,
	Email VARCHAR(255) NOT NULL, 
	CONSTRAINT UQ_Email UNIQUE(Email)
);

CREATE TABLE SoldDiscs (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	UserId INTEGER NOT NULL,
	DiscId INTEGER NOT NULL,
	CONSTRAINT FK_SoldDiscs_Users FOREIGN KEY (UserId) REFERENCES Users(Id),
	CONSTRAINT FK_SoldDiscs_Discs FOREIGN KEY (DiscId) REFERENCES Discs(Id)
);



INSERT INTO [Users] ([Name], Email) VALUES ('Nathan Traczewski', 'nayhee@gmail.com');
INSERT INTO [Users] ([Name], Email) VALUES ('Ryan Bogle', 'bogle@gmail.com');
INSERT INTO [Users] ([Name], Email) VALUES ('Palmer Adams', 'palmer@gmail.com');

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
