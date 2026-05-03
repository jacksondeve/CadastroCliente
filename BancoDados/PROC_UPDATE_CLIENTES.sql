use corporativo

go

CREATE OR ALTER PROCEDURE PROC_UPDATE_CLIENTES(
	@IdCliente int,
	@Documento varchar(15),
	@Nome varchar(100),
	@Sexo varchar(1),
	@Email varchar(200),
	@Telefone varchar(15),
	@UF CHAR(2)


)

AS

BEGIN
    UPDATE clientes 
    SET 
        Documento = @Documento, 
        Nome = @Nome, 
        Sexo = @Sexo,  
        Email = @Email, 
        Telefone = @Telefone,  
        UF = @UF 
    WHERE IdCliente = @IdCliente
END