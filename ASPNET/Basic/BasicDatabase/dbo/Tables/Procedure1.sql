CREATE PROCEDURE [dbo].[Procedure1]
	@param1 int = 0,
	@param2 int
AS
	Select [Id], [Name], [Email], [Title], [PostDate], [PostIp], [Content], [Password], [ReadCount], [Encoding], [Homepage], [ModifyDate], [ModifyIp] From Basics
RETURN 0
