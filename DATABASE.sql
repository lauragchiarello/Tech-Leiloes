CREATE DATABASE TechLeiloes;
GO

USE TechLeiloes;
GO


-- TABELA: Usuarios

CREATE TABLE Usuarios (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    telefone VARCHAR(11) NOT NULL,
    data_nascimento DATE NOT NULL,
    profissao VARCHAR(50),
    data_criacaoConta DATETIME DEFAULT GETDATE(),
    nivel_experiencia VARCHAR(20) CHECK (nivel_experiencia IN ('Iniciante', 'Intermedi�rio', 'Avan�ado'))
);



-- TABELA: Leiloeiro

CREATE TABLE Leiloeiro (
    id_leiloeiro INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    telefone VARCHAR(11) NOT NULL,
    website VARCHAR(100),
    cadastro_juntacomercial VARCHAR(100)
);



-- TABELA: Categoria

CREATE TABLE Categoria (
    id_categoria INT IDENTITY(1,1) PRIMARY KEY,
    tipo VARCHAR(50) NOT NULL
);


-- TABELA: Estado

CREATE TABLE Estado (
    id_estado INT IDENTITY(1,1) PRIMARY KEY,
    sigla CHAR(2) NOT NULL,
    nome_estado VARCHAR(50) NOT NULL
);



-- TABELA: Status

CREATE TABLE Status (
    id_status INT IDENTITY(1,1) PRIMARY KEY,
    status VARCHAR(20) CHECK (status IN ('Vendido','Cancelado','Suspenso'))
);


-- TABELA: Imovel

CREATE TABLE Imovel (
    id_imovel INT IDENTITY(1,1) PRIMARY KEY,
    id_leiloeiro INT NOT NULL,
    id_categoria INT NOT NULL,
    id_estado INT NOT NULL,
    endereco VARCHAR(255),
    cidade VARCHAR(100),
    cep VARCHAR(10),
    edital VARCHAR(255),
    descricao VARCHAR(500),
    data_primeiraPraca DATE,
    valor_primeiraPraca DECIMAL(18,2),
    data_segundaPraca DATE,
    valor_segundaPraca DECIMAL(18,2),
    id_status INT,
    desconto DECIMAL(5,2),
    criado_em DATETIME DEFAULT GETDATE(),
    website_leiloeiro VARCHAR(200),
    FOREIGN KEY (id_leiloeiro) REFERENCES Leiloeiro(id_leiloeiro),
    FOREIGN KEY (id_categoria) REFERENCES Categoria(id_categoria),
    FOREIGN KEY (id_estado) REFERENCES Estado(id_estado),
    FOREIGN KEY (id_status) REFERENCES Status(id_status)
);



-- TABELA: Foto

CREATE TABLE Foto (
    id_foto INT IDENTITY(1,1) PRIMARY KEY,
    id_imovel INT NOT NULL,
    caminho_imagem VARCHAR(500) NOT NULL,
    FOREIGN KEY (id_imovel) REFERENCES Imovel(id_imovel)
);
GO


-- TABELA: Favoritos (N:N entre Usuario e Imovel)

CREATE TABLE Favoritos (
    id_favorito INT IDENTITY(1,1) PRIMARY KEY,
    id_usuario INT NOT NULL,
    id_imovel INT NOT NULL,
    criado_em DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_usuario) REFERENCES Usuarios(id_usuario),
    FOREIGN KEY (id_imovel) REFERENCES Imovel(id_imovel)
);



-- TABELA: HistoricoLeilao

CREATE TABLE HistoricoLeilao (
    id_historico INT IDENTITY(1,1) PRIMARY KEY,
    id_imovel INT NOT NULL,
    id_status INT NOT NULL,
    data_evento DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_imovel) REFERENCES Imovel(id_imovel),
    FOREIGN KEY (id_status) REFERENCES Status(id_status)
);



-- TABELA: Sincronizacao_site_leiloeiro

CREATE TABLE Sincronizacao_site_leiloeiro (
    id_sinc INT IDENTITY(1,1) PRIMARY KEY,
    id_leiloeiro INT NOT NULL,
    total_leiloes INT,
    novos_leiloes INT,
    leiloes_removidos INT,
    horario_inicio DATETIME,
    horario_termino DATETIME,
    sucesso BIT,
    FOREIGN KEY (id_leiloeiro) REFERENCES Leiloeiro(id_leiloeiro)
);

