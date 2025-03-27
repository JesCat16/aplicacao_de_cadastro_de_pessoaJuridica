CREATE TABLE CadastroLead (
	Id int IDENTITY(1,1) PRIMARY KEY,
	cnpj varchar(255) NOT NULL,
	razao_social varchar(255) NOT NULL,
	cep varchar(255) NOT NULL,
	endereço varchar(255) NOT NULL,
	numero int NOT NULL,
	complemento varchar(255) NULL,
	bairro varchar(255) NOT NULL,
	cidade varchar(255) NOT NULL,
	estado varchar(255) NOT NULL
);