/* Script to insert stock/base data into the Paint App Database */

/* Manufacturers */

DECLARE @GamesWorkshopId as uniqueidentifier;
SET @GamesWorkshopId = NEWID();

INSERT INTO Paint.dbo.Manufacturer (ManufacturerId, ManufacturerName, ManufacturerDescription, LogoImageURL)
VALUES (@GamesWorkshopId, 'Games Workshop', 'Creator of the Warhammer universe', 'Not Yet Implemented')

/* PaintGroup */

DECLARE @CitadelId as uniqueidentifier;
SET @CitadelId = NEWID();

INSERT INTO Paint.dbo.PaintGroup (PaintGroupId, ManufacturerId, PaintGroupName, PaintGroupDescription)
VALUES (@CitadelId, @GamesWorkshopId, 'Citadel', 'An acrylic paint line designed for use with Games Workshop products.')

/* Paint */

Declare @PaintId as uniqueidentifier;
SET @PaintId = NEWID();

INSERT INTO Paint.dbo.Paint (PaintId, GroupId, PaintName, PaintSize, StockImageURL, MSRP) 
VALUES (@PaintId, @CitadelId, 'Calgar Blue', 17, 'Not Yet Implemented', 5.40)

INSERT INTO Paint.dbo.Paint (GroupId, PaintName, PaintSize, StockImageURL, MSRP) 
VALUES (@CitadelId, 'Yriel Yellow', 17, 'Not Yet Implemented', 5.40)

INSERT INTO Paint.dbo.Paint (GroupId, PaintName, PaintSize, StockImageURL, MSRP) 
VALUES (@CitadelId, 'Word Bearers Red', 17, 'Not Yet Implemented', 5.40)

/* User */

DECLARE @UserId as uniqueidentifier;
SET @UserId = NEWID();

INSERT INTO Paint.dbo.[User] (UserId, Username, [Password]) /* SHA256 */
VALUES (@UserId, 'Connor', '04f8996da763b7a969b1028ee3007569eaf3a635486ddab211d512c85b9df8fb') 

/* UserPaint */

INSERT INTO Paint.dbo.UserPaint (UserId, PaintId)
VALUES (@UserId, @PaintId)