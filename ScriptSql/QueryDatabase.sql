create database XYZBoutique
go

use XYZBoutique
go

CREATE TABLE Correlativo
(
idCorrelativo int identity(1,1) primary key,
numeroDoc varchar(7),
nombreTabla varchar(50),
estado bit default(1),
fechaRegistro datetime default(getdate()),
)
go

insert into Correlativo(numeroDoc,nombreTabla)
values(0,'Pedido')

CREATE TABLE Rol(
idRol int identity(1,1) primary key,
nombre varchar(50),
estado bit default(1),
fechaRegistro datetime default(getdate()),
)
go

insert into Rol(nombre)
values('Encargado'),('Vendedor'),('Delivery'),('Repartidor')
go

CREATE TABLE Usuario(
idUsuario int identity(1,1) primary key,
codigoTrabajador varchar(15),
nombreCompleto varchar(200),
correo varchar(200),
telefono varchar(9),
puesto varchar(200),
idRol int foreign key references Rol(idRol),
clave varchar(20),
estado bit default(1),
fechaRegistro datetime default(getdate())
)
go

insert into Usuario(codigoTrabajador, nombreCompleto, correo, telefono, puesto, idRol, clave)
values
    ('JPEREZ', 'Juan Pérez', 'juan.perez@email.com', '123456789', 'Gerente General', 1, 'juan123'),
    ('MGOMEZ', 'María Gómez', 'maria.gomez@email.com', '987654321', 'Vendedor Senior', 2, 'maria123'),
    ('CRODRIGUEZ', 'Carlos Rodríguez', 'carlos.rodriguez@email.com', '456789012', 'Encargado de Delivery', 3, 'carlos123'),
    ('AMARTINEZ', 'Ana Martínez', 'ana.martinez@email.com', '654321098', 'Repartidor Principal', 4, 'ana123');
GO

insert into Usuario(codigoTrabajador, nombreCompleto, correo, telefono, puesto, idRol, clave)
values
    ('LFLORES', 'Luis Flores', 'luis.flores@email.com', '111223344', 'Analista de Ventas', 2, 'luis123'),
    ('PPEREZ', 'Patricia Pérez', 'patricia.perez@email.com', '999888777', 'Asistente de Ventas', 2, 'patricia123'),
    ('EGONZALEZ', 'Eduardo González', 'eduardo.gonzalez@email.com', '444555666', 'Vendedor Junior', 2, 'eduardo123'),
    ('RGOMEZ', 'Roberto Gómez', 'roberto.gomez@email.com', '333222111', 'Repartidor Asociado', 4, 'roberto123');
GO

--SELECT *,CONVERT(varchar, DECRYPTBYPASSPHRASE('clave', clave)) AS ContraseñaDesencriptada FROM Usuario

CREATE TABLE Tipo
(
idTipo int identity(1,1) primary key,
nombre varchar(50),
estado bit default(1),
fechaRegistro datetime default(getdate()),
)
go

insert into Tipo (nombre)
values('Accesorios'),('Artículos para el Hogar'),('Calzado')
go

CREATE TABLE UnidadMedida
(
idUnidadMedida int identity(1,1) primary key,
nombre varchar(20),
abreviatura varchar(5),
estado bit default(1),
fechaRegistro datetime default(getdate()),
)
go

insert UnidadMedida (nombre,abreviatura)
values('Unidad','UN'),('Pares','PR')
go


CREATE TABLE Producto
(
idProducto int identity(1,1) primary key,
nombre varchar(255),
sku varchar(50),
idTipo int foreign key references Tipo(idTipo),
etiquetas varchar(500),
precio decimal(18,2),
idUnidadMedida int foreign key references UnidadMedida(idUnidadMedida),
stock int,
estado bit default(1),
fechaRegistro datetime default(getdate())
)
go

insert into Producto (nombre,sku,idTipo,etiquetas,precio,idUnidadMedida,stock)
values('Almohada Cebra Viscodream', 'ALM-CEB-VIS',2,'Algodon;Verde;Mediano;Vintage;',99.90,1,20),
	  ('Sabana Microfibra Benetton', 'SAB-MIC-BEN',2,'Otoño/Invierno;Grande;Seda;Moderno;',199.90,1,15),
	  ('Zapatillas Hombre adidas Breaknet 2.0', 'ZAP-HOM-ADI-BRE',3,'Casual/Invierno;Informal;Piel sintética;Negro;',299.90,2,30),
	  ('Zapatillas Deportivas Mujer Nike', 'ZAP-DEP-MUJ-NIK',3,'Casual;Informal;Cuero;Azul;',259.90,2,55)
go

CREATE TABLE EstadoPedido(
idEstadoPedido int identity(1,1) primary key,
nombre varchar(15),
fechaRegistro datetime default(getdate()),
estado bit default(1)
)
go

insert into EstadoPedido(nombre)
values('Por atender'),('En proceso'),('En delivery'),('Recibido')
go

CREATE TABLE Pedido
(
	idPedido int identity (1,1) primary key,
	nroPedido varchar(7),
	fechaPedido datetime,
	fechaRecepcion datetime,
	fechaDespacho datetime,
	fechaEntrega datetime,
	idUsuarioSolicitante int foreign key references Usuario(idUsuario),
	repartidor varchar(100),
	idEstadoPedido int foreign key references EstadoPedido(idEstadoPedido) default(1),
	estado bit default(1),
	fechaRegistro datetime default(getdate())
)
go

CREATE TABLE DetallePedido
(
	idDetallePedido int identity (1,1) primary key,
	idPedido int foreign key references Pedido(idPedido),
	idProducto int foreign key references Producto(idProducto),
	cantidad int,
	precio decimal(18,2),
	total decimal(18,2),
	estado bit default(1),
	fechaRegistro datetime default(getdate())
)
go


