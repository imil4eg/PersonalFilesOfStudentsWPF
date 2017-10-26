CREATE TABLE [dbo].[RecordBook] (
    [id]     INT NOT NULL,
    [Subject]       NVARCHAR (100) NOT NULL,
    [DateOfPassing] DATE       NULL,
    [Mark]          INT            NULL,
    [Teacher]       NVARCHAR (100) NULL,
    [StudentID] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([id] ASC), 
    CONSTRAINT [FK_RecordBook_ToStudent] FOREIGN KEY ([StudentID]) REFERENCES [Students]([StudentID])
);

