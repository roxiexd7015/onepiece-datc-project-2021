/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF NOT EXISTS (SELECT * FROM VoteType WHERE Id=1) BEGIN
    INSERT INTO VoteType(Id, [Name], [Value]) 
    VALUES(1, 'UpVote', 1);
END;

IF NOT EXISTS (SELECT * FROM VoteType WHERE Id=2) BEGIN
    INSERT INTO VoteType(Id, [Name], [Value]) 
    VALUES(2, 'DownVote', -1);
END;

IF NOT EXISTS (SELECT * FROM VoteType WHERE Id=69) BEGIN
    INSERT INTO VoteType(Id, [Name], [Value]) 
    VALUES(69, 'SupremeVote', 100);
END;