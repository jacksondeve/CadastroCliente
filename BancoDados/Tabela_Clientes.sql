use corporativo

create table clientes (
IdCliente INT IDENTITY(1,1) PRIMARY KEY,
Documento varchar(15),
Nome varchar(100),
Sexo varchar(1),
Email varchar(250),
Telefone varchar(15),
UF varchar(20)

)