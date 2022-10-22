CREATE SCHEMA SoftBookShop;

USE SoftBookShop;

CREATE TABLE IF NOT EXISTS Categorias (

ID_Categoria INT AUTO_INCREMENT,
Descripcion VARCHAR(50) NOT NULL,
Estado BIT NOT NULL,

CONSTRAINT PK_CATEGORIAS PRIMARY KEY (ID_Categoria)
);

CREATE TABLE IF NOT EXISTS Productos (

ID_Producto INT AUTO_INCREMENT,
Descripcion VARCHAR(80) NOT NULL,
ID_Categoria INT NOT NULL,
Imagen VARCHAR(200),
Stock INT NOT NULL,
Precio DOUBLE(8,2) NOT NULL,
Estado BIT NOT NULL,

CONSTRAINT PK_PRODUCTOS PRIMARY KEY (ID_Producto)
);

CREATE TABLE IF NOT EXISTS MetodoPago (

ID_MetodoPago INT AUTO_INCREMENT,
Descripcion VARCHAR(80),
Estado BIT NOT NULL,

CONSTRAINT PK_METODOPAGO PRIMARY KEY (ID_MetodoPago)
);

CREATE TABLE IF NOT EXISTS Ventas (

ID_Venta INT AUTO_INCREMENT,
ID_MetodoPago INT NOT NULL,
Fecha TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
Total DOUBLE(8,2) NOT NULL,

CONSTRAINT PK_VENTAS PRIMARY KEY (ID_Venta)
);

CREATE TABLE IF NOT EXISTS DetalleVenta (

ID_DetalleVenta INT AUTO_INCREMENT,
ID_Venta INT NOT NULL,
ID_Producto INT NOT NULL,
PrecioUnitario DOUBLE (8,2) NOT NULL,
Cantidad INT NOT NULL,

CONSTRAINT PK_DETALLE_VENTA PRIMARY KEY (ID_DetalleVenta)
);

ALTER TABLE Productos ADD CONSTRAINT FK_PRODUCTOS_CATEGORIAS FOREIGN KEY (ID_Categoria) REFERENCES Categorias (ID_Categoria);
ALTER TABLE Ventas ADD CONSTRAINT FK_VENTAS_METODOPAGO FOREIGN KEY (ID_MetodoPago) REFERENCES MetodoPago (ID_MetodoPago);
ALTER TABLE DetalleVenta ADD CONSTRAINT FK_DETALLE_VENTA_VENTAS FOREIGN KEY (ID_Venta) REFERENCES Ventas (ID_Venta);
ALTER TABLE DetalleVenta ADD CONSTRAINT FK_DETALLE_VENTA_PRODUCTOS FOREIGN KEY (ID_Producto) REFERENCES Productos (ID_Producto);