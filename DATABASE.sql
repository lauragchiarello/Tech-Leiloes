CREATE DATABASE TechLeiloes;
GO

USE TechLeiloes;
GO


-- TABELA: Usuario

CREATE TABLE Usuario (
    usuarioId INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    telefone VARCHAR(15) NOT NULL,
    data_nascimento DATE NOT NULL,
    profissao VARCHAR(50) NOT NULL,
    data_criacaoConta DATETIME DEFAULT GETDATE(),
    dataatualizacao datetime DEFAULT GETDATE(),
    nivel_experiencia VARCHAR(20) CHECK (nivel_experiencia IN ('Iniciante', 'Intermediário', 'Profissional'))
);

-- TABELA: Leiloeiro

CREATE TABLE Leiloeiro (
    leiloeiroId INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    telefone VARCHAR(12) NOT NULL,
    website VARCHAR(300) NOT NULL,
    ativo BIT,
    dataatualizacao datetime DEFAULT GETDATE()
);

-- TABELA: Categoria

CREATE TABLE Categoria (
    categoriaId INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(50) NOT NULL,
    foto VARCHAR(300),
    cor VARCHAR(26),
    dataatualizacao datetime DEFAULT GETDATE()
);

-- TABELA: Estado

CREATE TABLE Estado (
    estadoId INT IDENTITY(1,1) PRIMARY KEY,
    sigla CHAR(2) NOT NULL,
    nome_estado VARCHAR(50) NOT NULL,
    dataatualizacao datetime DEFAULT GETDATE()
);


-- TABELA: Status

CREATE TABLE Status (
    statusId INT IDENTITY(1,1) PRIMARY KEY,
    tipo_status VARCHAR(20) CHECK (tipo_status IN ('Vendido','Cancelado','Suspenso'))
);

-- TABELA: Imovel

CREATE TABLE Imovel (
    imovelId INT IDENTITY(1,1) PRIMARY KEY,
    leiloeiroId INT NOT NULL,
    categoriaId INT NOT NULL,
    estadoId INT NOT NULL,
    ativo BIT,
    endereco VARCHAR(255),
    cidade VARCHAR(100),
    cep VARCHAR(10),
    edital VARCHAR(255),
    descricao VARCHAR(1000),
    data_primeiraPraca DATE ,
    valor_primeiraPraca DECIMAL(18,2),
    data_segundaPraca DATE,
    valor_segundaPraca DECIMAL(18,2),
    statusId INT,
    desconto INT,
    matricula varchar(max) not null,
    criado_em DATETIME DEFAULT GETDATE(),
    website_leiloeiro VARCHAR(200),
    FOREIGN KEY (id_leiloeiro) REFERENCES Leiloeiro(id_leiloeiro),
    FOREIGN KEY (id_categoria) REFERENCES Categoria(id_categoria),
    FOREIGN KEY (id_estado) REFERENCES Estado(id_estado),
    FOREIGN KEY (id_status) REFERENCES Status(id_status)
);

-- TABELA: Foto

CREATE TABLE Foto (
    fotoId INT IDENTITY(1,1) PRIMARY KEY,
    imovelId INT NOT NULL,
    caminho_imagem VARCHAR(500) NOT NULL,
    FOREIGN KEY (id_imovel) REFERENCES Imovel(id_imovel)
);
GO

-- TABELA: Favoritos (N:N entre Usuario e Imovel)

CREATE TABLE Favoritos (
    favoritoId INT IDENTITY(1,1) PRIMARY KEY,
    usuarioId INT NOT NULL,
    imovelId INT NOT NULL,
    criado_em DATETIME DEFAULT GETDATE(),
    ATIVO BIT,
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    FOREIGN KEY (id_imovel) REFERENCES Imovel(id_imovel)
);

-- TABELA: HistoricoLeilao

CREATE TABLE HistoricoLeilao (
    historicoId INT IDENTITY(1,1) PRIMARY KEY,
    imovelId INT NOT NULL,
    statusId INT NOT NULL,
    data_evento DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_imovel) REFERENCES Imovel(id_imovel),
    FOREIGN KEY (id_status) REFERENCES Status(id_status)
);

-- TABELA: Sincronizacao_site_leiloeiro

CREATE TABLE Sincronizacao_site_leiloeiro (
    sincId INT IDENTITY(1,1) PRIMARY KEY,
    leiloeiroId INT NOT NULL,
    --total_leiloes INT, -- count
    novos_leiloes INT,
    leiloes_removidos INT,
    horario_inicio DATETIME,
    horario_termino DATETIME,
    sucesso BIT,
    FOREIGN KEY (id_leiloeiro) REFERENCES Leiloeiro(id_leiloeiro)
);

-- tipos de consultas sql:
--GET 
--1) trazer a lista de USUARIO
SELECT * FROM USUARIO

--2) trazer a lista de LEILOEIROS
SELECT * FROM Leiloeiro

--3) trazer a lista de Categoria
SELECT * FROM Categoria

--4)trazer a lista de Estado
SELECT * FROM Estado

--5) TRAZER A LISTA DE STATUS
SELECT * FROM STATUS

--6) TRAZER A LISTA DE IMOVEL
SELECT * FROM IMOVEL

--7)TRAZER A LISTA DE FOTO
SELECT * FROM FOTO

--8)TRAZER A LISTA DE FAVORITOS
SELECT * FROM FAVORITOS






