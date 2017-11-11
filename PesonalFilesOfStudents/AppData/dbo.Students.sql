CREATE TABLE [dbo].[Students] (
    [StudentID]     INT            IDENTITY (1, 1) NOT NULL,
    [LastName]      NVARCHAR (50)  NOT NULL,
    [FirstName]     NVARCHAR (50)  NOT NULL,
    [MiddleName]    NVARCHAR (50)  NOT NULL,
    [Birth Date]    DATE           NOT NULL,
    [Registration]  NVARCHAR (150) NOT NULL,
    [Course]        INT            NOT NULL,
    [Group]         INT            NOT NULL,
    [Faculty]       INT NOT NULL,
    [Gender]        NVARCHAR (10)  NOT NULL,
    [RecordBookID]  INT            NOT NULL,
    [ReadingBookID] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([StudentID] ASC)
);

