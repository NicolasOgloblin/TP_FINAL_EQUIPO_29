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
USUARIO VARCHAR(30) UNIQUE NOT NULL,
EMAIL VARCHAR(150) UNIQUE NOT NULL,
CONTRASENIA VARCHAR(200) NOT NULL,
SALT VARCHAR(150) NOT NULL,
ROLID SMALLINT NOT NULL,
PROVINCIA VARCHAR(80) NULL,
LOCALIDAD VARCHAR(80) NULL,
CALLE VARCHAR(80) NULL,
ALTURA VARCHAR(20) NULL,
CODIGO_POSTAL VARCHAR(5) NULL,
TELEFONO VARCHAR(15) NOT NULL,
ESTADO BIT NOT NULL,
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
NOMBRE VARCHAR(70)
CONSTRAINT PK_CATEGORIAS PRIMARY KEY (ID)
)
GO

BEGIN TRY
DROP TABLE MARCAS
END TRY BEGIN CATCH END CATCH
CREATE TABLE MARCAS (
ID INT IDENTITY(1,1) NOT NULL,
NOMBRE VARCHAR(70)
CONSTRAINT PK_MARCAS PRIMARY KEY (ID)
)
GO

BEGIN TRY
DROP TABLE ARTICULOS
END TRY BEGIN CATCH END CATCH
CREATE TABLE ARTICULOS (
ID BIGINT IDENTITY(1,1) NOT NULL,
CODIGO_ARTICULO VARCHAR(50) UNIQUE NOT NULL,
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
NOMBRE VARCHAR(100) NOT NULL,
DESCRIPCION VARCHAR(250) NULL,
ALTO DECIMAL(10,2) NULL,
ANCHO DECIMAL(10,2) NULL,
COLOR VARCHAR(20) NULL,
MODELO VARCHAR(50) NULL,
ORIGEN VARCHAR(50) NULL,
PESO DECIMAL(10,2) NULL,
GARANTIA_ANIOS INT NULL,
GARANTIA_MESES INT NULL,
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
DROP TABLE ESTADO_PEDIDO
END TRY BEGIN CATCH END CATCH
CREATE TABLE ESTADO_PEDIDO(
ID SMALLINT IDENTITY(1,1) NOT NULL,
NOMBRE VARCHAR(40) NOT NULL
CONSTRAINT PK_ESTADO_PEDIDO PRIMARY KEY (ID)
) 
GO

BEGIN TRY
DROP TABLE METODO_PAGO
END TRY BEGIN CATCH END CATCH
CREATE TABLE METODO_PAGO(
ID SMALLINT IDENTITY(1,1) NOT NULL,
NOMBRE VARCHAR(30),
CONSTRAINT PK_METODO_PAGO PRIMARY KEY (ID) 
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
ESTADOPEDIDOID SMALLINT NULL,
METODOPAGOID SMALLINT NULL,
ENVIO BIT NULL
CONSTRAINT PK_PEDIDO PRIMARY KEY CLUSTERED (ID),
CONSTRAINT FK_PEDIDO_USUARIO FOREIGN KEY (USUARIOID) REFERENCES USUARIOS(ID),
CONSTRAINT FK_PEDIDO_ESTADO_PEDIDO FOREIGN KEY (ESTADOPEDIDOID) REFERENCES ESTADO_PEDIDO(ID)
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
)
GO

BEGIN TRY
DROP TABLE AUDITORIA_ARTICULOS
END TRY BEGIN CATCH END CATCH
CREATE TABLE AUDITORIA_ARTICULOS (
CODIGO_ARTICULO VARCHAR(50) NOT NULL,
NOMBRE VARCHAR(100) NOT NULL,
DESCRIPCION VARCHAR(250) NULL,
CATEGORIAID INT NOT NULL,
MARCAID INT NOT NULL,
FECHA_AGREGADO DATETIME NOT NULL,
CATEGORIANOMBRE VARCHAR(70) NOT NULL,
CATEGORIAMARCA VARCHAR(70) NOT NULL,
CONSTRAINT PK_AUDITORIA_ARTICULOS PRIMARY KEY (CODIGO_ARTICULO)
)
GO

BEGIN TRY
DROP TABLE RESERVA_STOCK
END TRY BEGIN CATCH END CATCH
CREATE TABLE RESERVA_STOCK (
USUARIOID BIGINT NOT NULL,
ARTICULOID BIGINT NOT NULL,
STOCK_RESERVADO INT NOT NULL
CONSTRAINT FK_RESERVA_USUARIO FOREIGN KEY (USUARIOID) REFERENCES USUARIOS(ID),
CONSTRAINT FK_RESERVA_ARTICULO FOREIGN KEY (ARTICULOID) REFERENCES ARTICULOS(ID)
)
GO

INSERT INTO ROLES
VALUES('ADMIN'),('CLIENTE')

INSERT INTO ESTADO_PEDIDO
VALUES('PENDIENTE'),('DESPACHADO'),('ENTREGADO')

INSERT INTO METODO_PAGO
VALUES('TRANSFERENCIA'),('EFECTIVO')
