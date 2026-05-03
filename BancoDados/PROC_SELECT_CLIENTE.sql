USE corporativo
GO

CREATE OR ALTER PROCEDURE PROC_SELECT_CLIENTE
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