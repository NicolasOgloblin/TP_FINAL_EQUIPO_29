CREATE DATABASE ECOMMERCE
GO

USE ECOMMERCE
GO

BEGIN TRY
DROP TABLE ROLES
END TRY BEGIN CATCH END CATCH
CREATE TABLE ROLES (
ID SMALLINT IDENTITY(1,1) NOT NULL,
NOMBRE VARCHAR(60) NOT NULL,
CONSTRAINT PK_ROLES PRIMARY KEY (ID)
)
GO

BEGIN TRY
DROP TABLE USUARIOS 
END TRY BEGIN CATCH END CATCH
CREATE TABLE USUARIOS (
ID BIGINT IDENTITY(1,1) NOT NULL,
NOMBRE VARCHAR(70) NOT NULL,
APELLIDO VARCHAR(70) NOT NULL,
DNI VARCHAR(10) UNIQUE NOT NULL,
EMAIL VARCHAR(150) UNIQUE NOT NULL,
CONTRASENIA VARCHAR(30) NOT NULL,
ROLID SMALLINT NOT NULL,
PROVINCIA VARCHAR(80) NOT NULL,
LOCALIDAD VARCHAR(80) NOT NULL,
CALLE VARCHAR(80) NOT NULL,
ALTURA VARCHAR(20) NOT NULL,
TELEFONO VARCHAR(15) NOT NULL,
FECHA_REGISTRO DATETIME NOT NULL
CONSTRAINT PK_USUARIOS PRIMARY KEY CLUSTERED (ID),
CONSTRAINT FK_USUARIOS_ROLES FOREIGN KEY (ROLID) REFERENCES ROLES(ID)
)
GO

BEGIN TRY
DROP TABLE CATEGORIAS
END TRY BEGIN CATCH END CATCH
CREATE TABLE CATEGORIAS (
ID INT IDENTITY(1,1) NOT NULL,
NOMBRE VARCHAR(70),
DESCRIPCION VARCHAR(300)
CONSTRAINT PK_CATEGORIAS PRIMARY KEY (ID)
)
GO

BEGIN TRY
DROP TABLE MARCAS
END TRY BEGIN CATCH END CATCH
CREATE TABLE MARCAS (
ID INT IDENTITY(1,1) NOT NULL,
NOMBRE VARCHAR(70),
DESCRIPCION VARCHAR(300)
CONSTRAINT PK_MARCAS PRIMARY KEY (ID)
)
GO

BEGIN TRY
DROP TABLE ARTICULOS
END TRY BEGIN CATCH END CATCH
CREATE TABLE ARTICULOS (
ID BIGINT IDENTITY(1,1) NOT NULL,
NOMBRE VARCHAR(100) NOT NULL,
DESCRIPCION VARCHAR(250) NULL,
CATEGORIAID INT NOT NULL,
MARCAID INT NOT NULL,
FECHA_AGREGADO DATETIME NOT NULL,
CONSTRAINT PK_ARTICULOS PRIMARY KEY CLUSTERED (ID),
CONSTRAINT FK_ARTICULOS_CATEGORIAS FOREIGN KEY (CATEGORIAID) REFERENCES CATEGORIAS(ID),
CONSTRAINT FK_ARTICULOS_MARCAS FOREIGN KEY (MARCAID) REFERENCES MARCAS(ID)
)
GO

BEGIN TRY
DROP TABLE ARTICULOS_DETALLE
END TRY BEGIN CATCH END CATCH
CREATE TABLE ARTICULOS_DETALLE (
ARTICULOID BIGINT NOT NULL,
PRECIO DECIMAL(10,2) NOT NULL,
STOCK INT NOT NULL,
CONSTRAINT FK_ARTICULOS_DETALLE FOREIGN KEY (ARTICULOID) REFERENCES ARTICULOS(ID)
)
GO

BEGIN TRY
DROP TABLE IMAGENES
END TRY BEGIN CATCH END CATCH
CREATE TABLE IMAGENES(
ARTICULOID BIGINT NOT NULL,
IMAGEN VARCHAR(MAX) NULL,
CONSTRAINT FK_IMAGENES_ARTICULO FOREIGN KEY (ARTICULOID) REFERENCES ARTICULOS(ID)
) 
GO

BEGIN TRY
DROP TABLE PEDIDO
END TRY BEGIN CATCH END CATCH
CREATE TABLE PEDIDO (
ID BIGINT IDENTITY(1,1) NOT NULL,
USUARIOID BIGINT NOT NULL,
FECHA_PEDIDO DATETIME NOT NULL,
MONTO_TOTAL DECIMAL(10, 2) NOT NULL,
ESTADO BIT NOT NULL,
CONSTRAINT PK_PEDIDO PRIMARY KEY CLUSTERED (ID),
CONSTRAINT FK_PEDIDO_USUARIO FOREIGN KEY (USUARIOID) REFERENCES USUARIOS(ID)
)
GO

BEGIN TRY
DROP TABLE PEDIDO_DETALLE
END TRY BEGIN CATCH END CATCH
CREATE TABLE PEDIDO_DETALLE (
PEDIDOID BIGINT NOT NULL,
ARTICULOID BIGINT NOT NULL,
CANTIDAD INT NOT NULL,
PRECIO_UNITARIO DECIMAL(10, 2) NOT NULL,
CONSTRAINT FK_PEDIDO_DETALLE FOREIGN KEY (PEDIDOID) REFERENCES PEDIDO(ID),
CONSTRAINT FK_PEDIDO_DETALLE_USUARIO FOREIGN KEY (ARTICULOID) REFERENCES ARTICULOS(ID)
)
GO

BEGIN TRY
DROP TABLE METODO_PAGO
END TRY BEGIN CATCH END CATCH
CREATE TABLE METODO_PAGO(
ID SMALLINT IDENTITY(1,1)NOT NULL,
NOMBRE VARCHAR(30),
CONSTRAINT PK_METODO_PAGO PRIMARY KEY (ID) 
)
GO

BEGIN TRY
DROP TABLE VENTAS
END TRY BEGIN CATCH END CATCH
CREATE TABLE VENTAS (
ID BIGINT IDENTITY(1,1) NOT NULL,
PEDIDOID BIGINT NOT NULL,
FECHA_VENTA DATETIME NOT NULL,
METODOPAGOID SMALLINT NOT NULL,
CONSTRAINT FK_VENTAS_PEDIDO FOREIGN KEY (PEDIDOID) REFERENCES PEDIDO(ID),
CONSTRAINT FK_VENTAS_METODO_PAGO FOREIGN KEY (METODOPAGOID) REFERENCES METODO_PAGO(ID)
)
GO


