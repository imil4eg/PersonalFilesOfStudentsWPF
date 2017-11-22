CREATE TABLE [dbo].[Students] (
    [StudentID]    INT            IDENTITY (1, 1) NOT NULL,
    [LastName]     NVARCHAR (50)  NOT NULL,
    [FirstName]    NVARCHAR (50)  NOT NULL,
    [MiddleName]   NVARCHAR (50)  NULL,
    [Birth Date]   DATE           NULL,
    [Registration] NVARCHAR (150) NULL,
    [Course]       INT            NOT NULL,
    [Group]        INT            NOT NULL,
    [Faculty]      INT            NOT NULL,
    [Gender]       NVARCHAR (7)  NULL,
    [INN]          INT            NOT NULL,
    [SNILS]        INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([StudentID] ASC)
);

