  IF EXISTS(SELECT 1 FROM information_schema.tables 
  WHERE table_name = '
__EFMigrationsHistory' AND table_schema = DATABASE()) 
BEGIN
CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

END;

CREATE TABLE `AspNetRoles` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ConcurrencyStamp` text NULL,
    `Name` varchar(256) NULL,
    `NormalizedName` varchar(256) NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `AspNetUsers` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `AccessFailedCount` int NOT NULL,
    `Apellido` text NULL,
    `ConcurrencyStamp` text NULL,
    `Email` varchar(256) NULL,
    `EmailConfirmed` bit NOT NULL,
    `LockoutEnabled` bit NOT NULL,
    `LockoutEnd` timestamp NULL,
    `Nombre` text NULL,
    `NormalizedEmail` varchar(256) NULL,
    `NormalizedUserName` varchar(256) NULL,
    `PasswordHash` text NULL,
    `PhoneNumber` text NULL,
    `PhoneNumberConfirmed` bit NOT NULL,
    `SecurityStamp` text NULL,
    `TwoFactorEnabled` bit NOT NULL,
    `UserName` varchar(256) NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `AspNetRoleClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ClaimType` text NULL,
    `ClaimValue` text NULL,
    `RoleId` int NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AspNetUserClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ClaimType` text NULL,
    `ClaimValue` text NULL,
    `UserId` int NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AspNetUserLogins` (
    `LoginProvider` varchar(767) NOT NULL,
    `ProviderKey` varchar(767) NOT NULL,
    `ProviderDisplayName` text NULL,
    `UserId` int NOT NULL,
    PRIMARY KEY (`LoginProvider`, `ProviderKey`),
    CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AspNetUserRoles` (
    `UserId` int NOT NULL,
    `RoleId` int NOT NULL,
    PRIMARY KEY (`UserId`, `RoleId`),
    CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AspNetUserTokens` (
    `UserId` int NOT NULL,
    `LoginProvider` varchar(767) NOT NULL,
    `Name` varchar(767) NOT NULL,
    `Value` text NULL,
    PRIMARY KEY (`UserId`, `LoginProvider`, `Name`),
    CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);

CREATE INDEX `IX_AspNetRoleClaims_RoleId` ON AspNetRoleClaims (`RoleId`);

CREATE UNIQUE INDEX `RoleNameIndex` ON AspNetRoles (`NormalizedName`);

CREATE INDEX `IX_AspNetUserClaims_UserId` ON AspNetUserClaims (`UserId`);

CREATE INDEX `IX_AspNetUserLogins_UserId` ON AspNetUserLogins (`UserId`);

CREATE INDEX `IX_AspNetUserRoles_RoleId` ON AspNetUserRoles (`RoleId`);

CREATE INDEX `EmailIndex` ON AspNetUsers (`NormalizedEmail`);

CREATE UNIQUE INDEX `UserNameIndex` ON AspNetUsers (`NormalizedUserName`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180404201559_enteroFinal', '2.0.2-rtm-10011');

