IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221222061757_migracioninicial')
BEGIN
    CREATE TABLE [Species] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Species] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221222061757_migracioninicial')
BEGIN
    CREATE TABLE [Pets] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Age] int NULL,
        [Weight] decimal(18,2) NULL,
        [SpeciesId] int NOT NULL,
        CONSTRAINT [PK_Pets] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Pets_Species_SpeciesId] FOREIGN KEY ([SpeciesId]) REFERENCES [Species] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221222061757_migracioninicial')
BEGIN
    CREATE INDEX [IX_Pets_SpeciesId] ON [Pets] ([SpeciesId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221222061757_migracioninicial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221222061757_migracioninicial', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221222064133_migracionbreed')
BEGIN
    ALTER TABLE [Pets] ADD [BreedId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221222064133_migracionbreed')
BEGIN
    CREATE TABLE [Breeds] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Breeds] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221222064133_migracionbreed')
BEGIN
    CREATE INDEX [IX_Pets_BreedId] ON [Pets] ([BreedId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221222064133_migracionbreed')
BEGIN
    ALTER TABLE [Pets] ADD CONSTRAINT [FK_Pets_Breeds_BreedId] FOREIGN KEY ([BreedId]) REFERENCES [Breeds] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221222064133_migracionbreed')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221222064133_migracionbreed', N'7.0.1');
END;
GO

COMMIT;
GO

