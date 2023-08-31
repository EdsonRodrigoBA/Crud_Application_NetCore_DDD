CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "Produtos" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Produtos" PRIMARY KEY,
    "nome" varchar(250) NOT NULL,
    "descricao" varchar(500) NOT NULL,
    "ativo" INTEGER NOT NULL,
    "valor" numeric(18,2 NOT NULL,
    "estoque" INTEGER NOT NULL,
    "dataCadastro" TEXT NOT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230831132140_InicialMigrationSqlLite', '7.0.10');

COMMIT;

