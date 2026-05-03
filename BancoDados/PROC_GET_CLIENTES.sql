use corporativo

go

create OR alter procedure PROC_GET_CLIENTE(

@IdCliente int

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
    
    FROM clientes WHERE IdCliente = @IdCliente

END