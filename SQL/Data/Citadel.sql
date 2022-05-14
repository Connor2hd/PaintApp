/* Script to load in all the Games Workshop paints */

/* Manufacturer */

delete from Manufacturer
delete from Paint
delete from PaintGroup

DECLARE @CitadelPaintId as uniqueidentifier;
SET @CitadelPaintId = NEWID();

INSERT INTO Paint.dbo.Manufacturer (ManufacturerId, ManufacturerName, ManufacturerDescription, LogoImageURL)
VALUES (@CitadelPaintId, 'Citadel', 'Child company of Games Workshop', 'Not Yet Implemented')

/* PaintGroup */

DECLARE @LayerId as uniqueidentifier;
SET @LayerId = NEWID();

INSERT INTO Paint.dbo.PaintGroup (PaintGroupId, ManufacturerId, PaintGroupName, PaintGroupDescription)
VALUES (@LayerId, @CitadelPaintId, 'Layer', 'Layer paints have a lighter pigment count than base paints, meaning they can be applied in multiple layers to help bring out extra detail on your miniatures. They’re particularly great for edge highlighting.')

DECLARE @AirId as uniqueidentifier;
SET @AirId = NEWID();

INSERT INTO Paint.dbo.PaintGroup (PaintGroupId, ManufacturerId, PaintGroupName, PaintGroupDescription)
VALUES (@AirId, @CitadelPaintId, 'Air', 'Air paints pair seamlessly with the rest of the Citadel Colour range, featuring a thinner formulation that makes them work perfectly with your airbrush.')

DECLARE @BaseId as uniqueidentifier;
SET @BaseId = NEWID();

INSERT INTO Paint.dbo.PaintGroup (PaintGroupId, ManufacturerId, PaintGroupName, PaintGroupDescription)
VALUES (@BaseId, @CitadelPaintId, 'Base', 'Base paints are the foundation of the Classic Method of painting. The high pigment count of these paints means they provide excellent coverage, giving you a base of rich colour to paint over.')

DECLARE @ContrastId as uniqueidentifier;
SET @ContrastId = NEWID();

INSERT INTO Paint.dbo.PaintGroup (PaintGroupId, ManufacturerId, PaintGroupName, PaintGroupDescription)
VALUES (@ContrastId, @CitadelPaintId, 'Contrast', 'Contrast is a revolutionary paint that makes beautiful painting simple and fast. Each Contrast paint, when applied over a light Contrast undercoat, gives you a vivid base and realistic shading all in a single application.')

DECLARE @DryId as uniqueidentifier;
SET @DryId = NEWID();

INSERT INTO Paint.dbo.PaintGroup (PaintGroupId, ManufacturerId, PaintGroupName, PaintGroupDescription)
VALUES (@DryId, @CitadelPaintId, 'Dry', 'Dry paints are formulated to be perfect for drybrushing, with a thicker texture than normal paint designed to catch on the raised edges of your mode. This useful technique makes highlighting and capturing detail simple.')

DECLARE @TechnicalId as uniqueidentifier;
SET @TechnicalId = NEWID();

INSERT INTO Paint.dbo.PaintGroup (PaintGroupId, ManufacturerId, PaintGroupName, PaintGroupDescription)
VALUES (@TechnicalId, @CitadelPaintId, 'Technical', 'Technical paints let you add all sorts of special effects to your models. Churned earth, grisly gore, rust and corrosion or spectral glows – each makes for an eye-catching way to finish your miniatures.')

DECLARE @ShadeId as uniqueidentifier;
SET @ShadeId = NEWID();

INSERT INTO Paint.dbo.PaintGroup (PaintGroupId, ManufacturerId, PaintGroupName, PaintGroupDescription)
VALUES (@ShadeId, @CitadelPaintId, 'Shade', 'Shade paints make adding realistic shadows and lowlights to your models easy. They are designed to run into the recesses of your miniatures, providing excellent results with minimal effort.')

DECLARE @SprayId as uniqueidentifier;
SET @SprayId = NEWID();

INSERT INTO Paint.dbo.PaintGroup (PaintGroupId, ManufacturerId, PaintGroupName, PaintGroupDescription)
VALUES (@SprayId, @CitadelPaintId, 'Spray', 'Sprays make undercoating a model simple. Each acts as a primer that prepares your model for painting, as well as providing a strong foundation to build on.')


/* Paint */

/* Layers */

INSERT INTO Paint.dbo.Paint (GroupId, PaintName, PaintSize, StockImageURL, MSRP) 
VALUES 
(@LayerId, 'White Scar', 12, 'Citadel/Layer/WhiteScar.svg', 5.40),
(@LayerId, 'Ulthuan Grey', 12, 'Citadel/Layer/UlthuanGrey.svg', 5.40),
(@LayerId, 'DornYellow', 12, 'Citadel/Layer/DornYellow.svg', 5.40),
(@LayerId, 'Phalanx Yellow', 12, 'Citadel/Layer/PhalanxYellow.svg', 5.40),
(@LayerId, 'Flash Gitz Yellow', 12, 'Citadel/Layer/FlashGitzYellow.svg', 5.40),
(@LayerId, 'Yriel Yellow', 12, 'Citadel/Layer/YrielYellow.svg', 5.40),
(@LayerId, 'Lugganath Orange', 12, 'Citadel/Layer/LugganathOrange.svg', 5.40),
(@LayerId, 'Fire Dragon Bright', 12, 'Citadel/Layer/FireDragonBright.svg', 5.40),
(@LayerId, 'Troll Slayer Orange', 12, 'Citadel/Layer/TrollSlayerOrange.svg', 5.40),
(@LayerId, 'Squig Orange', 12, 'Citadel/Layer/SquigOrange.svg', 5.40),
(@LayerId, 'Wild Rider Red', 12, 'Citadel/Layer/WildRiderRed.svg', 5.40),
(@LayerId, 'Evil Sunz Scarlet', 12, 'Citadel/Layer/EvilSunzScarlet.svg', 5.40),
(@LayerId, 'Wazdakka Red', 12, 'Citadel/Layer/WazdakkaRed.svg', 5.40),
(@LayerId, 'Word Bearers Red', 12, 'Citadel/Layer/WordBearersRed.svg', 5.40),
(@LayerId, 'Fulgrim Pink', 12, 'Citadel/Layer/FulgrimPink.svg', 5.40),
(@LayerId, 'Emperors Children', 12, 'Citadel/Layer/EmperorsChildren.svg', 5.40),
(@LayerId, 'Pink Horror', 12, 'Citadel/Layer/PinkHorror.svg', 5.40),
(@LayerId, 'Slaanesh Grey', 12, 'Citadel/Layer/SlaaneshGrey.svg', 5.40),
(@LayerId, 'Warpfiend Grey', 12, 'Citadel/Layer/WarpfiendGrey.svg', 5.40),
(@LayerId, 'Dechala Lilac', 12, 'Citadel/Layer/DechalaLilac.svg', 5.40),
(@LayerId, 'Kakophoni Purple', 12, 'Citadel/Layer/KakophoniPurple.svg', 5.40),
(@LayerId, 'Genestealer Purple', 12, 'Citadel/Layer/GenestealerPurple.svg', 5.40),
(@LayerId, 'Xereus Purple', 12, 'Citadel/Layer/XereusPurple.svg', 5.40),
(@LayerId, 'Blue Horror', 12, 'Citadel/Layer/BlueHorror.svg', 5.40),
(@LayerId, 'Hoeth Blue', 12, 'Citadel/Layer/HoethBlue.svg', 5.40),
(@LayerId, 'Lothern Blue', 12, 'Citadel/Layer/LothernBlue.svg', 5.40),
(@LayerId, 'Calgar Blue', 12, 'Citadel/Layer/CalgarBlue.svg', 5.40),
(@LayerId, 'Teclis Blue', 12, 'Citadel/Layer/TeclisBlue.svg', 5.40),
(@LayerId, 'Alaitoc Blue', 12, 'Citadel/Layer/AlaitocBlue.svg', 5.40),
(@LayerId, 'Altdorf Guard Blue', 12, 'Citadel/Layer/AltdorfGuardBlue.svg', 5.40),
(@LayerId, 'Baharroth Blue', 12, 'Citadel/Layer/BaharrothBlue.svg', 5.40),
(@LayerId, 'Temple Guard Blue', 12, 'Citadel/Layer/TempleGuardBlue.svg', 5.40),
(@LayerId, 'Ahriman Blue', 12, 'Citadel/Layer/AhrimanBlue.svg', 5.40),
(@LayerId, 'Sotek Green', 12, 'Citadel/Layer/SotekGreen.svg', 5.40),
(@LayerId, 'Gauss Blaster Green', 12, 'Citadel/Layer/GaussBlasterGreen.svg', 5.40),
(@LayerId, 'Sybarite Green', 12, 'Citadel/Layer/SybariteGreen.svg', 5.40),
(@LayerId, 'Kabalite Green', 12, 'Citadel/Layer/KabaliteGreen.svg', 5.40),
(@LayerId, 'Nurgling Green', 12, 'Citadel/Layer/NurglingGreen.svg', 5.40),
(@LayerId, 'Elysian Green', 12, 'Citadel/Layer/ElysianGreen.svg', 5.40),
(@LayerId, 'Ogryn Camo', 12, 'Citadel/Layer/OgrynCamo.svg', 5.40),
(@LayerId, 'Straken Green', 12, 'Citadel/Layer/StrakenGreen.svg', 5.40),
(@LayerId, 'Loren Forest', 12, 'Citadel/Layer/LorenForest.svg', 5.40),
(@LayerId, 'Sons of Horus Green', 12, 'Citadel/Layer/SonsofHorusGreen.svg', 5.40),
(@LayerId, 'Vulkan Green', 12, 'Citadel/Layer/VulkanGreen.svg', 5.40),
(@LayerId, 'Skarsnik Green', 12, 'Citadel/Layer/SkarsnikGreen.svg', 5.40),
(@LayerId, 'Warboss Green', 12, 'Citadel/Layer/WarbossGreen.svg', 5.40),
(@LayerId, 'Warpstone Glow', 12, 'Citadel/Layer/WarpstoneGlow.svg', 5.40),
(@LayerId, 'Screaming Skull', 12, 'Citadel/Layer/ScreamingSkull.svg', 5.40),
(@LayerId, 'Ushabti Bone', 12, 'Citadel/Layer/UshabtiBone.svg', 5.40),
(@LayerId, 'Krieg Khaki', 12, 'Citadel/Layer/KriegKhaki.svg', 5.40),
(@LayerId, 'Karak Stone', 12, 'Citadel/Layer/KarakStone.svg', 5.40),
(@LayerId, 'Baneblade Brown', 12, 'Citadel/Layer/BanebladeBrown.svg', 5.40),
(@LayerId, 'Gorthor Brown', 12, 'Citadel/Layer/GorthorBrown.svg', 5.40),
(@LayerId, 'Zamesi Desert', 12, 'Citadel/Layer/ZamesiDesert.svg', 5.40),
(@LayerId, 'Tallarn Sand', 12, 'Citadel/Layer/TallarnSand.svg', 5.40),
(@LayerId, 'Deathclaw Brown', 12, 'Citadel/Layer/DeathclawBrown.svg', 5.40),
(@LayerId, 'Balor Brown', 12, 'Citadel/Layer/BalorBrown.svg', 5.40),
(@LayerId, 'Tau Light Ochre', 12, 'Citadel/Layer/TauLightOchre.svg', 5.40),
(@LayerId, 'Skrag Brown', 12, 'Citadel/Layer/SkragBrown.svg', 5.40),
(@LayerId, 'Tuskgor Fur', 12, 'Citadel/Layer/TuskgorFur.svg', 5.40),
(@LayerId, 'Doombull Brown', 12, 'Citadel/Layer/DoombullBrown.svg', 5.40),
(@LayerId, 'Pallid Wych Flesh', 12, 'Citadel/Layer/PallidWychFlesh.svg', 5.40),
(@LayerId, 'Deepkin Flesh', 12, 'Citadel/Layer/DeepkinFlesh.svg', 5.40),
(@LayerId, 'Flayed One Flesh', 12, 'Citadel/Layer/FlayedOneFlesh.svg', 5.40),
(@LayerId, 'Ungor Flesh', 12, 'Citadel/Layer/UngorFlesh.svg', 5.40),
(@LayerId, 'Kislev Flesh', 12, 'Citadel/Layer/KislevFlesh.svg', 5.40),
(@LayerId, 'Bestigor Flesh', 12, 'Citadel/Layer/BestigorFlesh.svg', 5.40),
(@LayerId, 'Cadian Fleshtone', 12, 'Citadel/Layer/CadianFleshtone.svg', 5.40),
(@LayerId, 'Knight-Questor Flesh', 12, 'Citadel/Layer/KnightQuestorFlesh.svg', 5.40),
(@LayerId, 'Bloodreaver Flesh', 12, 'Citadel/Layer/BloodreaverFlesh.svg', 5.40),
(@LayerId, 'Fenrisian Grey', 12, 'Citadel/Layer/FenrisianGrey.svg', 5.40),
(@LayerId, 'Russ Grey', 12, 'Citadel/Layer/RussGrey.svg', 5.40),
(@LayerId, 'Thunderhawk Blue', 12, 'Citadel/Layer/ThunderhawkBlue.svg', 5.40),
(@LayerId, 'Dark Reaper', 12, 'Citadel/Layer/DarkReaper.svg', 5.40),
(@LayerId, 'Administratum Grey', 12, 'Citadel/Layer/AdministratumGrey.svg', 5.40),
(@LayerId, 'Dawnstone', 12, 'Citadel/Layer/Dawnstone.svg', 5.40),
(@LayerId, 'Stormvermin Fur', 12, 'Citadel/Layer/StormverminFur.svg', 5.40),
(@LayerId, 'Eshin Grey', 12, 'Citadel/Layer/EshinGrey.svg', 5.40),
(@LayerId, 'Skavenblight Dinge', 12, 'Citadel/Layer/SkavenblightDinge.svg', 5.40),
(@LayerId, 'Stormhost Silver', 12, 'Citadel/Layer/StormhostSilver.svg', 5.40),
(@LayerId, 'Runefang Steel', 12, 'Citadel/Layer/RunefangSteel.svg', 5.40),
(@LayerId, 'Ironbreaker', 12, 'Citadel/Layer/Ironbreaker.svg', 5.40),
(@LayerId, 'Liberator Gold', 12, 'Citadel/Layer/LiberatorGold.svg', 5.40),
(@LayerId, 'Auric Armour Gold', 12, 'Citadel/Layer/AuricArmourGold.svg', 5.40),
(@LayerId, 'Gehennas Gold', 12, 'Citadel/Layer/GehennasGold.svg', 5.40),
(@LayerId, 'Fulgurite Copper', 12, 'Citadel/Layer/FulguriteCopper.svg', 5.40),
(@LayerId, 'Hashut Copper', 12, 'Citadel/Layer/HashutCopper.svg', 5.40),
(@LayerId, 'Skullcrusher Brass', 12, 'Citadel/Layer/SkullcrusherBrass.svg', 5.40),
(@LayerId, 'Brass Scorpion', 12, 'Citadel/Layer/BrassScorpion.svg', 5.40),
(@LayerId, 'Sycorax Bronze', 12, 'Citadel/Layer/SycoraxBronze.svg', 5.40),
(@LayerId, 'Castellax Bronze', 12, 'Citadel/Layer/CastellaxBronze.svg', 5.40),
(@LayerId, 'Canoptek Alloy', 12, 'Citadel/Layer/CanoptekAlloy.svg', 5.40),