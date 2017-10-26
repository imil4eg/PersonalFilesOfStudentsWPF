CREATE TABLE [dbo].[Book] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [name]          NVARCHAR (150) NOT NULL,
    [author]        NVARCHAR (150) NOT NULL,
    [ReadingBookID] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Book_ToReadingBook] FOREIGN KEY ([ReadingBookID]) REFERENCES [dbo].[ReadingBook] ([id])
);

