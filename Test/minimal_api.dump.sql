-- MySQL dump compatível com .NET 9 / EF Core 9
-- Host: localhost    Database: minimal_api
-- Server version: 8.1.0

-- Configurações iniciais
SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;
SET UNIQUE_CHECKS = 0;

-- ------------------------------------------------------
-- Tabela de histórico de migrações (__EFMigrationsHistory)
-- ------------------------------------------------------
DROP TABLE IF EXISTS `__EFMigrationsHistory`;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dados de migrações iniciais
INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
('20231114235912_AdministradorMigration','9.0.0'),
('20231115013756_SeedAdministrador','9.0.0'),
('20231115020944_VeiculosMigration','9.0.0');

-- ------------------------------------------------------
-- Tabela Administradores
-- ------------------------------------------------------
DROP TABLE IF EXISTS `Administradores`;
CREATE TABLE `Administradores` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Email` varchar(255) NOT NULL,
  `Senha` varchar(50) NOT NULL,
  `Perfil` varchar(10) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dados iniciais
INSERT INTO `Administradores` (`Id`, `Email`, `Senha`, `Perfil`) VALUES
(1, 'administrador@teste.com', '123456', 'Adm'),
(2, 'joao@teste.com', 'editor', 'Editor');

-- ------------------------------------------------------
-- Tabela Veiculos
-- ------------------------------------------------------
DROP TABLE IF EXISTS `Veiculos`;
CREATE TABLE `Veiculos` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(150) NOT NULL,
  `Marca` varchar(100) NOT NULL,
  `Ano` int NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dados iniciais
INSERT INTO `Veiculos` (`Id`, `Nome`, `Marca`, `Ano`) VALUES
(1, 'Fiesta 2.0', 'Ford', 2013),
(3, 'X6', 'BMW', 2022);

-- Restaurar checks
SET UNIQUE_CHECKS = 1;
SET FOREIGN_KEY_CHECKS = 1;
