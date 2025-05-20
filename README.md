# Adventure Boy: Heroes & Monsters API
This is the API for the web application Adventure Boy, for which the front-end respository can be found [here](https://github.com/emmanuelalesna/adventure-boy-front). That respository also contains more information about the project on a high-level.
## Overview
This is the API we developed for Adventure Boy. It follows RESTful API practices, and is built with .NET, ASP.NET Core, and Entity Framework connected to a SQL Server database.

We based the design on the Data Acess Object pattern. The controllers handle initial endpoint hits, converting incoming data into a friendly format for the rest of the API. This data is then passed to the services, which check for conformity to our business logic (checking that IDs aren't negative, making sure that no required data is missing, etc.). The DAO layer directly communicates to the database, using Entity Framework in a code-first approach to minimize SQL programming.

There are a number of entities that represent the player, enemies, and various items. Most importantly, accounts and players have a one-to-one relationship. Items, enemies, and everything else exist independently and are pulled from the database when the level needs to be populated.

The API allows for basic CRUD operations on accounts and the various items and other supporting objects necessary to make a functional level.
