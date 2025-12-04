-- Script básico para crear la base de datos ShopSmart orientada a una heladería.
CREATE DATABASE ShopSmartDB;
GO
USE ShopSmartDB;
GO

CREATE TABLE Clientes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Documento NVARCHAR(50) NOT NULL,
    Nombre NVARCHAR(150) NOT NULL,
    Telefono NVARCHAR(50) NULL,
    Correo NVARCHAR(150) NULL,
    Direccion NVARCHAR(200) NULL,
    Activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE Proveedores (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(150) NOT NULL,
    Telefono NVARCHAR(50) NULL,
    Correo NVARCHAR(150) NULL,
    Direccion NVARCHAR(200) NULL,
    Activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE Productos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Codigo NVARCHAR(50) NOT NULL,
    Nombre NVARCHAR(150) NOT NULL,
    Descripcion NVARCHAR(250) NULL,
    Precio DECIMAL(18,2) NOT NULL,
    StockActual INT NOT NULL DEFAULT 0,
    StockMinimo INT NOT NULL DEFAULT 0,
    Activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE Ventas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME NOT NULL,
    ClienteId INT NOT NULL REFERENCES Clientes(Id),
    Total DECIMAL(18,2) NOT NULL
);

CREATE TABLE DetalleVenta (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    VentaId INT NOT NULL REFERENCES Ventas(Id),
    ProductoId INT NOT NULL REFERENCES Productos(Id),
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(18,2) NOT NULL,
    Subtotal DECIMAL(18,2) NOT NULL
);

-- Usuarios para autenticación básica
CREATE TABLE Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario NVARCHAR(50) NOT NULL,
    Contrasena NVARCHAR(50) NOT NULL,
    Rol NVARCHAR(50) NOT NULL
);

INSERT INTO Usuarios (NombreUsuario, Contrasena, Rol) VALUES ('admin', 'admin', 'Administrador');

-- TODO: vistas para reporte de ventas diarias, productos con stock bajo y productos más vendidos.
