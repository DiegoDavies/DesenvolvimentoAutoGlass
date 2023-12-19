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

CREATE TABLE [Fornecedor] (
    [Codigo] int NOT NULL IDENTITY,
    [Descricao] nvarchar(max) NOT NULL,
    [CNPJ] nvarchar(max) NULL,
    [DataInclusao] datetime2 NOT NULL,
    [Situacao] bit NOT NULL,
    CONSTRAINT [PK_Fornecedor] PRIMARY KEY ([Codigo])
);
GO

CREATE TABLE [Produto] (
    [Codigo] int NOT NULL IDENTITY,
    [Descricao] nvarchar(max) NOT NULL,
    [DataFabricacao] datetime2 NOT NULL,
    [DataValidade] datetime2 NOT NULL,
    [DataInclusao] datetime2 NOT NULL,
    [Situacao] bit NOT NULL,
    [CodigoFornecedor] int NOT NULL,
    CONSTRAINT [PK_Produto] PRIMARY KEY ([Codigo]),
    CONSTRAINT [FK_Produto_Fornecedor_CodigoFornecedor] FOREIGN KEY ([CodigoFornecedor]) REFERENCES [Fornecedor] ([Codigo]) ON DELETE NO ACTION
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Codigo', N'CNPJ', N'DataInclusao', N'Descricao', N'Situacao') AND [object_id] = OBJECT_ID(N'[Fornecedor]'))
    SET IDENTITY_INSERT [Fornecedor] ON;
INSERT INTO [Fornecedor] ([Codigo], [CNPJ], [DataInclusao], [Descricao], [Situacao])
VALUES (1, N'12775524000133', '2023-12-17T19:50:21.0182088-03:00', N'Fornecedor 1', CAST(1 AS bit)),
(2, N'09809005000134', '2023-12-17T14:50:21.0200282-03:00', N'Fornecedor 2', CAST(1 AS bit)),
(3, N'40575582000159', '2023-12-16T19:50:21.0200466-03:00', N'Fornecedor 3', CAST(1 AS bit)),
(4, N'27283103000162', '2023-12-10T19:50:21.0200488-03:00', N'Fornecedor 4', CAST(1 AS bit));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Codigo', N'CNPJ', N'DataInclusao', N'Descricao', N'Situacao') AND [object_id] = OBJECT_ID(N'[Fornecedor]'))
    SET IDENTITY_INSERT [Fornecedor] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Codigo', N'CodigoFornecedor', N'DataFabricacao', N'DataInclusao', N'DataValidade', N'Descricao', N'Situacao') AND [object_id] = OBJECT_ID(N'[Produto]'))
    SET IDENTITY_INSERT [Produto] ON;
INSERT INTO [Produto] ([Codigo], [CodigoFornecedor], [DataFabricacao], [DataInclusao], [DataValidade], [Descricao], [Situacao])
VALUES (1, 1, '2023-10-20T20:40:10.0000000', '2023-12-17T19:50:21.0301894-03:00', '2024-10-20T00:00:00.0000000', N'Arroz', CAST(1 AS bit));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Codigo', N'CodigoFornecedor', N'DataFabricacao', N'DataInclusao', N'DataValidade', N'Descricao', N'Situacao') AND [object_id] = OBJECT_ID(N'[Produto]'))
    SET IDENTITY_INSERT [Produto] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Codigo', N'CodigoFornecedor', N'DataFabricacao', N'DataInclusao', N'DataValidade', N'Descricao', N'Situacao') AND [object_id] = OBJECT_ID(N'[Produto]'))
    SET IDENTITY_INSERT [Produto] ON;
INSERT INTO [Produto] ([Codigo], [CodigoFornecedor], [DataFabricacao], [DataInclusao], [DataValidade], [Descricao], [Situacao])
VALUES (2, 2, '2023-11-15T07:40:10.0000000', '2023-12-17T19:50:21.0302568-03:00', '2024-01-20T00:00:00.0000000', N'Coca Cola', CAST(1 AS bit));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Codigo', N'CodigoFornecedor', N'DataFabricacao', N'DataInclusao', N'DataValidade', N'Descricao', N'Situacao') AND [object_id] = OBJECT_ID(N'[Produto]'))
    SET IDENTITY_INSERT [Produto] OFF;
GO

CREATE INDEX [IX_Produto_CodigoFornecedor] ON [Produto] ([CodigoFornecedor]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231217225021_Initial', N'5.0.17');
GO

COMMIT;
GO

