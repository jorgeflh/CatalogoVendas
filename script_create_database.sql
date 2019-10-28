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

GO 

SET IDENTITY_INSERT CatalogoVendas.dbo.tb_Usuario ON

INSERT INTO CatalogoVendas.dbo.tb_Usuario(IdUsuario, Nome, CPF, RG, Telefone, DesLogin, Senha)
VALUES (1, 'Tony Stark', '53850503003', '170480173', '16985530102', 'ironman', '123456');
INSERT INTO CatalogoVendas.dbo.tb_Usuario(IdUsuario, Nome, CPF, RG, Telefone, DesLogin, Senha)
VALUES (2, 'Steve Rogers', '08524230045', '234452304', '1637372222', 'capitainamerica', '123456');
INSERT INTO CatalogoVendas.dbo.tb_Usuario(IdUsuario, Nome, CPF, RG, Telefone, DesLogin, Senha)
VALUES (3, 'Bruce Banner', '31271956055', '136565724', '1645340000', 'hulk', '123456');

SET IDENTITY_INSERT CatalogoVendas.dbo.tb_Usuario OFF

GO

SET IDENTITY_INSERT CatalogoVendas.dbo.tb_Empresa ON

INSERT INTO CatalogoVendas.dbo.tb_Empresa(IdEmpresa, IdUsuarioCadastro, RazaoSocial, CNPJ, Endereco, Telefone)
VALUES (1, 1, 'Stark Industries', '57823849000182', 'First Avenue, 999', '1133442233');
INSERT INTO CatalogoVendas.dbo.tb_Empresa(IdEmpresa, IdUsuarioCadastro, RazaoSocial, CNPJ, Endereco, Telefone)
VALUES (2, 2, 'Shield', '56444754000195', 'Unespecified Place', '11923224499');
INSERT INTO CatalogoVendas.dbo.tb_Empresa(IdEmpresa, IdUsuarioCadastro, RazaoSocial, CNPJ, Endereco, Telefone)
VALUES (3, 3, 'ACME', '56444754000195', 'Second Av, 888', '1588881111');

SET IDENTITY_INSERT CatalogoVendas.dbo.tb_Empresa OFF

GO

SET IDENTITY_INSERT CatalogoVendas.dbo.Tb_SegmentoEmpresa ON

INSERT INTO CatalogoVendas.dbo.tb_SegmentoEmpresa (IdSegmento, IdEmpresa, DesSegmento, Ativo)
VALUES (1, 2, 'Secret Services', 1)
INSERT INTO CatalogoVendas.dbo.tb_SegmentoEmpresa (IdSegmento, IdEmpresa, DesSegmento, Ativo)
VALUES (2, 1, 'Scientific Machines Industry', 1)
INSERT INTO CatalogoVendas.dbo.tb_SegmentoEmpresa (IdSegmento, IdEmpresa, DesSegmento, Ativo)
VALUES (3, 3, 'Industry', 1)

SET IDENTITY_INSERT CatalogoVendas.dbo.Tb_SegmentoEmpresa OFF

GO

SET IDENTITY_INSERT CatalogoVendas.dbo.Tb_Vendas ON

INSERT INTO CatalogoVendas.dbo.tb_Vendas (IdVenda, IdEmpresa, IdUsuarioCadastro, DataVenda, ValorVenda, EmitidoNF)
VALUES (1, 1, 3, '28-10-2019', '100.00', 1);
INSERT INTO CatalogoVendas.dbo.tb_Vendas (IdVenda, IdEmpresa, IdUsuarioCadastro, DataVenda, ValorVenda, EmitidoNF)
VALUES (2, 2, 2, '28-10-2019', '59.00', 1);
INSERT INTO CatalogoVendas.dbo.tb_Vendas (IdVenda, IdEmpresa, IdUsuarioCadastro, DataVenda, ValorVenda, EmitidoNF)
VALUES (3, 3, 3, '28-10-2019', '33.00', 1);
INSERT INTO CatalogoVendas.dbo.tb_Vendas (IdVenda, IdEmpresa, IdUsuarioCadastro, DataVenda, ValorVenda, EmitidoNF)
VALUES (4, 1, 2, '28-10-2019', '599.00', 1);

SET IDENTITY_INSERT CatalogoVendas.dbo.Tb_Vendas OFF
