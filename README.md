# OCCCIO_PrizeDrawSystem
Started by Niagara College, OCCCIO Prize Draw system allows the hosting college to go paperless when it comes to the prize draw abilities.

Development Setup:
Once SQL server or SQL Express are setup properly (ensure authentication via SQL authentication is enabled)

In MS SQL Server Management Studio (or whatever SQL Query input tool you like to use), run DbCreation.sql on a Database. My suggestion is to avoid Master and create a database specifically for this tool.

Ensure 'COMMIT' is uncommented when running so SQL Server will actually commit the changes described.

Under Visual Studio 2017, there are two files you must edit to ensure the DB connections are set up properly. 
PrizeDraw > appsettings.json
and 
PrizeDrawTool > appsettings.json

For Development, ensure your ConnectionString are setup to your system. the basic style are:
Server=[server];Database=[databaseName];User ID=[userID];Password=[password];

Next, you need to generate a password for the Admin user, this is done using the PrizeDrawTool C# program.

PrizeDrawTool was written with command line arugments abilities, you may compile it to run on a command line or run it directly within Visual Studios.

To change the arguments and run within Visual Studios
	1.	Select the PrizeDrawTool Project
	2.	Secondary click it to access the properties window
	3.	Locate the Debug tab.
	4.	Alter the Applications Arguments to "p [path]".

The program will create a csv file at [path] with the password for the users in the system missing a password.


Known issues:
The Prize draw app will only start drawing ballots if the number of ballots is greater than to number of prizes available. This means if you have 2 attendees as your test input data, the max number of prizes per entry is 1. If you ahve 3 attendees, the max is 2.

The 'Draw Prize' function in the display screens, do not use the Generate Winner button in the Manager Prize screen unless it is intended for testing. On the Display screen, when the 'Winner' title is available, press Enter to have the system draw a winner from the pool.

