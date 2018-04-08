  IF EXISTS(SELECT 1 FROM information_schema.tables 
  WHERE table_name = '
__EFMigrationsHistory' AND table_schema = DATABASE()) 
BEGIN

CREATE TABLE `AspNetRoles` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ConcurrencyStamp` varchar(500) NULL,
    `Name` varchar(180) NULL,
    `NormalizedName` varchar(180) NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `AspNetUsers` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `AccessFailedCount` int NOT NULL,
    `Apellido` varchar(180) NULL,
    `ConcurrencyStamp` varchar(500) NULL,
    `Email` varchar(180) NULL,
    `EmailConfirmed` bit NOT NULL,
    `LockoutEnabled` bit NOT NULL,
    `LockoutEnd` timestamp NULL,
    `Nombre` varchar(180) NULL,
    `NormalizedEmail` varchar(180) NULL,
    `NormalizedUserName` varchar(180) NULL,
    `PasswordHash` varchar(500) NULL,
    `PhoneNumber` varchar(180) NULL,
    `PhoneNumberConfirmed` bit NOT NULL,
    `SecurityStamp` varchar(500) NULL,
    `TwoFactorEnabled` bit NOT NULL,
    `UserName` varchar(180) NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `AspNetRoleClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ClaimType` varchar(180) NULL,
    `ClaimValue` varchar(180) NULL,
    `RoleId` int NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AspNetUserClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ClaimType` varchar(180) NULL,
    `ClaimValue` varchar(180) NULL,
    `UserId` int NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AspNetUserLogins` (
    `LoginProvider` varchar(180) NOT NULL,
    `ProviderKey` varchar(180) NOT NULL,
    `ProviderDisplayName` varchar(250) NULL,
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
    `LoginProvider` varchar(180) NOT NULL,
    `Name` varchar(180) NOT NULL,
    `Value` varchar(500) NULL,
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