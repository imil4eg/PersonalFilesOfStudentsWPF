CREATE TABLE [dbo].[ReadingBook] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [TakedBooks] NVARCHAR (MAX) NULL,
    [StudentID]  INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_ReadingBook_ToStudents] FOREIGN KEY ([StudentID]) REFERENCES [dbo].[Students] ([StudentID])
);

