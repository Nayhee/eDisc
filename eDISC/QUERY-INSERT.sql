INSERT INTO [Users] ([Name], Email, userTypeId) VALUES ('Nathan Traczewski', 'nayhee@gmail.com', 1);
INSERT INTO [Users] ([Name], Email, userTypeId) VALUES ('Ryan Bogle', 'bogle@gmail.com', 2);
INSERT INTO [Users] ([Name], Email, userTypeId) VALUES ('Palmer Adams', 'palmer@gmail.com', 2);

INSERT INTO [UserType] (Name) VALUES ('Admin');
INSERT INTO [UserType] (Name) VALUES ('User');

INSERT INTO [DiscType] (Name) VALUES ('ForSale');
INSERT INTO [DiscType] (Name) VALUES ('NotForSale');

INSERT INTO [Brand] ([Name]) VALUES ('Innova');
INSERT INTO [Brand] ([Name]) VALUES ('Discmania');
INSERT INTO [Brand] ([Name]) VALUES ('Prodigy');
INSERT INTO [Brand] ([Name]) VALUES ('Discraft');
INSERT INTO [Brand] ([Name]) VALUES ('MVP');
INSERT INTO [Brand] ([Name]) VALUES ('Westside');

INSERT INTO [Tag] ([Name]) VALUES ('Putter');
INSERT INTO [Tag] ([Name]) VALUES ('Mid-Range');
INSERT INTO [Tag] ([Name]) VALUES ('Fairway Driver');
INSERT INTO [Tag] ([Name]) VALUES ('Distance Driver');
INSERT INTO [Tag] ([Name]) VALUES ('Overstable');
INSERT INTO [Tag] ([Name]) VALUES ('Understable');
INSERT INTO [Tag] ([Name]) VALUES ('Stable');

INSERT INTO [Disc] ([Name], brandId, discTypeId, Condition, Speed, Glide, Turn, Fade, Plastic, Price, Weight, Description, imageUrl) VALUES ('Pig', 1, 1, 'New', 4, 1, 0, 3, 'Champion', 25, 173, 'The Pig is an overstable Putt & Approach disc. It is great for hyzer putting, sidearm approaches and backhand spikes. The Pig holds the line well, even in extreme wind conditions. The Pig features a Thumtrac® Rim for sure grips on sidearm throws and putts. It performs equally well for backhand or sidearm throws.', 'https://prochemicalanddye.net/media/extendware/ewimageopt/media/inline/d3/6/deluxe-disc-golf-dyeing-kit-16c.jpghttps://prochemicalanddye.net/media/extendware/ewimageopt/media/inline/d3/6/deluxe-disc-golf-dyeing-kit-16c.jpg');   
INSERT INTO [Disc] ([Name], brandId, discTypeId, Condition, Speed, Glide, Turn, Fade, Plastic, Price, Weight, Description, imageUrl) VALUES ('Teebird3', 1, 1, 'New', 8, 4, 0, 2, 'Champion', 25, 173, 'The TeeBird3 represents the evolution of the TeeBird. Many people have described a lot of discs as a "faster TeeBird", but this is the real deal. The flat flight plate promotes speed while reducing glide, effectively producing consistent, accurate flights. This is a point and shoot, target specific fairway driver.', 'https://prochemicalanddye.net/media/extendware/ewimageopt/media/inline/df/f/disc-golf-dyeing-kit-32b.jpg');   
INSERT INTO [Disc] ([Name], brandId, discTypeId, Condition, Speed, Glide, Turn, Fade, Plastic, Price, Weight, Description, imageUrl) VALUES ('Shryke', 1, 1, 'New', 13, 6, -2, 2, 'Star', 20, 173, 'The Shryke is an easy to throw, very long range driver for a wide variety of players. A mild high speed turn puts the Shryke in glide mode, which along with its high aerodynamic speed, give it incredible distance. The low speed fade is also mild, which makes it easy to keep on the fairway.', 'https://prochemicalanddye.net/media/extendware/ewimageopt/media/inline/2/7/beginners-disc-golf-dyeing-kit-98b.jpg');   

INSERT INTO [DiscTag] (DiscId, TagId) VALUES (1, 1);
INSERT INTO [DiscTag] (DiscId, TagId) VALUES (1, 5);
INSERT INTO [DiscTag] (DiscId, TagId) VALUES (2, 3);
INSERT INTO [DiscTag] (DiscId, TagId) VALUES (2, 7);
INSERT INTO [DiscTag] (DiscId, TagId) VALUES (3, 4);
INSERT INTO [DiscTag] (DiscId, TagId) VALUES (3, 6);