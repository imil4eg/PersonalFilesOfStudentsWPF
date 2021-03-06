﻿CREATE TABLE [dbo].[Students] (
    [StudentID]          INT            IDENTITY (28, 1) NOT NULL,
    [LastName]           NVARCHAR (50)  NOT NULL,
    [FirstName]          NVARCHAR (50)  NOT NULL,
    [MiddleName]         NVARCHAR (50)  NULL,
    [Birth Date]         DATE           NULL,
    [Registration]       NVARCHAR (150) NULL,
    [Course]             INT            NOT NULL,
    [Group]              INT            NOT NULL,
    [Faculty]            INT            NOT NULL,
    [Gender]             NVARCHAR (10)  NULL,
    [INN]                BIGINT         NOT NULL,
    [SNILS]              BIGINT         NOT NULL,
    [PassportNumber]     BIGINT         NOT NULL,
    [PassportSeries]     BIGINT         NOT NULL,
    [PassportIssuedBy]   NVARCHAR (MAX) NOT NULL,
    [PassportIssuedDate] DATE           NOT NULL,
    [InsuranceNumber]    BIGINT         NOT NULL,
    [InsuranceCompany]   NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([StudentID] ASC)
);

