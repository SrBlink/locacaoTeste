

CREATE TABLE Cliente (
	Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	Nome varchar(255) NOT NULL,
	DataNascimento date NOT NULL,
	Cpf varchar(11) NOT NULL,
	Cnh varchar(50) NOT NULL,
	Logradouro varchar(200) NOT NULL,
	Numero  varchar(10) NOT NULL,
	Bairro varchar(60) NOT NULL,
	Cidade varchar(60) NOT NULL
);