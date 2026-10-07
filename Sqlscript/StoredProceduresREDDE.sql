--Read All Employees
ALTER PROC [DBO].[Get_Companies]
AS
BEGIN
	SELECT Id, RNC, Name, CommercialName, Category, PaymentScheme, State, EconomicActivity, GubernamentalBranch
	FROM DBO.Companies
END

exec [DBO].[Get_Companies]

--Get by Id
ALTER PROC [DBO].[Get_Company_Id] (@Id int)
AS
BEGIN
	SELECT Id, RNC, Name, CommercialName, Category, PaymentScheme, State, EconomicActivity, GubernamentalBranch
	FROM DBO.Companies WHERE Id = @Id
END

--Create
CREATE PROC [dbo].[Create_Company]
(
    @RNC VARCHAR(20),
    @Name VARCHAR(150),
    @CommercialName VARCHAR(150),
    @Category VARCHAR(100),
    @PaymentScheme VARCHAR(100),
    @State VARCHAR(50),
    @EconomicActivity VARCHAR(150),
    @GubernamentalBranch VARCHAR(150)
)
AS
BEGIN
    INSERT INTO Companies
    ( RNC, Name, CommercialName, Category, PaymentScheme, State, EconomicActivity, GubernamentalBranch )
    VALUES
    ( @RNC, @Name, @CommercialName, @Category, @PaymentScheme, @State, @EconomicActivity, @GubernamentalBranch )
END

--update
CREATE PROC [dbo].[Update_Company]
    @Id INT,
    @RNC VARCHAR(20),
    @Name VARCHAR(150),
    @CommercialName VARCHAR(150),
    @Category VARCHAR(100),
    @PaymentScheme VARCHAR(100),
    @State VARCHAR(50),
    @EconomicActivity VARCHAR(150),
    @GubernamentalBranch VARCHAR(150)
AS
BEGIN
    UPDATE Companies
    SET
        RNC = @RNC,
        Name = @Name,
        CommercialName = @CommercialName,
        Category = @Category,
        PaymentScheme = @PaymentScheme,
        State = @State,
        EconomicActivity = @EconomicActivity,
        GubernamentalBranch = @GubernamentalBranch
    WHERE Id = @Id
END

--Delete
CREATE PROC [dbo].[Delete_Company]
    @Id INT
AS
BEGIN
    DELETE FROM Companies
    WHERE Id = @Id
END
