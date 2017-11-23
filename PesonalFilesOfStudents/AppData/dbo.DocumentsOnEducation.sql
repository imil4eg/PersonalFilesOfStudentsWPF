CREATE TABLE [dbo].[DocumentsOnEducation] (
    [Id]        INT            IDENTITY (27, 1) NOT NULL,
    [StudentID] INT            NOT NULL,
    [File]      NVARCHAR (MAX) NOT NULL,
    [DateOfEnd] DATE       NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DocumentsOnEducation_ToStudents] FOREIGN KEY ([StudentID]) REFERENCES [dbo].[Students] ([StudentID])
);

