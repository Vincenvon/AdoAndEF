USE [Test]
GO

/****** Объект: Table [dbo].[People] Дата скрипта: 03.02.2017 1:06:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[People] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (MAX) NOT NULL,
    [LastName]  NVARCHAR (MAX) NOT NULL,
    [Age]       INT            NOT NULL,
    [Sex]       NVARCHAR (MAX) NOT NULL
);


