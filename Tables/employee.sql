CREATE TABLE [dbo].[employee] (
    [Id]        INT        IDENTITY (1, 1) NOT NULL,
    [firstname] NCHAR (30) NULL,
    [middlename] NCHAR (30) NULL,
    [lastname]  CHAR (30)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

