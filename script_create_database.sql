IF DB_ID('CatalogoVendas') IS NULL
	CREATE DATABASE CatalogoVendas;

GO

CREATE TABLE CatalogoVendas.dbo.tb_Usuario (
	IdUsuario INT PRIMARY KEY IDENTITY (1,1),
	Nome VARCHAR(60) NOT NULL,
	CPF VARCHAR(11) NOT NULL,
	RG VARCHAR(14) NOT NULL,
	Telefone VARCHAR(13) NOT NULL,
	DesLogin VARCHAR(100) NOT NULL,
	Senha VARCHAR(30) NOT NULL
);

GO

CREATE TABLE CatalogoVendas.dbo.tb_Empresa (
	IdEmpresa INT PRIMARY KEY IDENTITY (1,1),
	IdUsuarioCadastro INT NOT NULL,
	RazaoSocial VARCHAR(255) NOT NULL,
	CNPJ VARCHAR(14) NOT NULL,
	Endereco VARCHAR(255) NOT NULL,
	Telefone VARCHAR(13) NOT NULL,
	FOREIGN KEY (IdUsuarioCadastro) REFERENCES tb_Usuario (IdUsuario)
);

GO

CREATE TABLE CatalogoVendas.dbo.tb_SegmentoEmpresa (
	IdSegmento INT PRIMARY KEY IDENTITY (1,1),
	IdEmpresa INT NOT NULL,
	DesSegmento VARCHAR(255),
	Ativo BIT
	FOREIGN KEY (IdEmpresa) REFERENCES tb_Empresa (IdEmpresa) 
);

GO

CREATE TABLE CatalogoVendas.dbo.tb_Vendas (
	IdVenda INT PRIMARY KEY IDENTITY (1,1),
	IdEmpresa INT NOT NULL,
	IdUsuarioCadastro INT NOT NULL,
	ValorVenda DECIMAL(18,2) NOT NULL,
	DataVenda DATETIME,
	EmitidoNF BIT,
	FOREIGN KEY (IdEmpresa) REFERENCES tb_Empresa (IdEmpresa),
	FOREIGN KEY (IdUsuarioCadastro) REFERENCES tb_Usuario (IdUsuario)
);
