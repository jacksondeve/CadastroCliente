use corporativo

go


CREATE OR ALTER PROCEDURE PROC_GETCLIENTES_CLIENTES(

	@IdCliente INT
)

AS

BEGIN
	
SELECT 
        IdCliente,
        Documento, 
        Nome, 
        Sexo, 
        Email, 
        Telefone, 
        UF 
    FROM clientes
END 
