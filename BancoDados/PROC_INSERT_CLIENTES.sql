use corporativo

go

create or alter procedure PROC_INSERT_CLIENTES(
	@Documento varchar(15),
	@Nome varchar(100),
	@Sexo varchar(1),
	@Email varchar(200),
	@Telefone varchar(15),
	@UF CHAR(15)


)

as

begin
	 INSERT INTO clientes ( Documento, Nome, Sexo, email, telefone, UF) 
	VALUES(@Documento,@Nome,@Sexo,@Email,@Telefone,@UF)
end