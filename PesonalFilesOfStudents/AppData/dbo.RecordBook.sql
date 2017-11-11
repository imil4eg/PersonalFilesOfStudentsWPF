CREATE TABLE [dbo].[RecordBook] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Subject]       NVARCHAR (150) NULL,
    [DateOfPassing] DATE           NULL,
    [Mark]          INT            NULL,
    [Teacher]       NVARCHAR (150) NULL,
    [StudentID]     INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

