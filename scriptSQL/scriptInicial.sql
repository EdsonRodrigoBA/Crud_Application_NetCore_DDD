CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Produtos` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `nome` varchar(250) CHARACTER SET utf8mb4 NOT NULL,
    `descricao` varchar(500) CHARACTER SET utf8mb4 NOT NULL,
    `ativo` tinyint(1) NOT NULL,
    `valor` numeric(65,30) NOT NULL,
    `estoque` int NOT NULL,
    `dataCadastro` datetime(6) NOT NULL,
    CONSTRAINT `PK_Produtos` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230830222818_InicialMigration', '7.0.10');

COMMIT;

