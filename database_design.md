# Database Design
	This document will go into detail about our classes for our websites system.
	
## User
* Display Name - Unique string that shows up on the leaderboards (String)
* First Name - Users first name (String)
* Last Name - Users last name (String)
* Age - Data for verifaction (Int)
* Password - Password for the user to log in (String)
* Role - User or Admin (String)
* ProfilePicture - Uploaded profile photo of users choosing (String)
## Game
* Name - The Name of the game (String)
* ReleaseDate - Year it came out (DateField)
* GameArt - Stores the URL to the specific games artwork (String)
* Genre - What genre the game will be under (ManyToManyForeignKey->Genre)
* GameBio - A description of each individual game (String)

## GameDatas
* Data - Float value for a piece of user data  (Float)
* Game_Id - The ID of the game that the data belongs to (ForeignKey -> Game)
* User_Id - The owner/uploader of this data  (ForeignKey -> User)
*Category_Id - The ID of what category the data belongs under (ForeignKey -> Categories)

## Genre
* GenreName - Descriptors of the genre (Action, RPG, Shooter, etc)

## Categories
* CategoryName - Name of a stats category for a specific game (String)
* Game_Id - Foreign key to which game each category belongs to (ForeignKey - Game)


## Interconnection between tables

The image below shows how the tables are connected within the database. For Game and Genre, this is a many to many relationship. 

![alt tag](https://github.com/SenecaCollegeBTSProjects/Group_16/blob/master/BTS530/images/DataBaseDesign.png)
