IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Reports] (
    [Id] int NOT NULL IDENTITY,
    [ReportType] int NOT NULL,
    [ReporterUserID] int NOT NULL,
    [CreationDate] datetime2 NOT NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Reports] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Role] int NOT NULL,
    [RegisterDate] datetime2 NOT NULL,
    [BornDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Locations] (
    [Id] int NOT NULL IDENTITY,
    [ReportId] int NOT NULL,
    [Longitud] nvarchar(max) NULL,
    [Latitude] nvarchar(max) NULL,
    CONSTRAINT [PK_Locations] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Locations_Reports_ReportId] FOREIGN KEY ([ReportId]) REFERENCES [Reports] ([Id]) ON DELETE CASCADE
);

GO

CREATE UNIQUE INDEX [IX_Locations_ReportId] ON [Locations] ([ReportId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211005195333_FirstMigration', N'3.1.19');

GO

