CREATE TABLE [dbo].[Parent] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [StudentID]  INT           NULL,
    [LastName]   NVARCHAR (50) NULL,
    [FirstName]  NVARCHAR (50) NULL,
    [MiddleName] NVARCHAR (50) NULL,
    [Phone]      INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Parent_ToStudents] FOREIGN KEY ([StudentID]) REFERENCES [dbo].[Students] ([StudentID])
);

