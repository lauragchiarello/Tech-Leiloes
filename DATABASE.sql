
/* ============================================================
   CRIAÇÃO DO BANCO
============================================================ */

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'LeilaoDB')
BEGIN
    CREATE DATABASE LeilaoDB;
END
GO

USE LeilaoDB;
GO

/* ============================================================
   TABELA CATEGORIA
============================================================ */

CREATE TABLE CATEGORIA (
    CATEGORIAID INT IDENTITY(1,1) PRIMARY KEY,
    DESCRICAOCATEGORIA VARCHAR(150) NOT NULL,
    DATACRIACAO DATETIME NOT NULL DEFAULT GETDATE(),
    DATAATUALIZACAO DATETIME NULL
);



CREATE INDEX IX_CATEGORIA_DESCRICAO ON CATEGORIA(DESCRICAOCATEGORIA);

/* ============================================================
   TABELA CIDADE
============================================================ */

CREATE TABLE CIDADE (
    CIDADEID INT IDENTITY(1,1) PRIMARY KEY,
    NOMECIDADE VARCHAR(150) NOT NULL,
    ESTADO CHAR(2)
);

CREATE INDEX IX_CIDADE_NOME ON CIDADE(NOMECIDADE);

/* ============================================================
   TABELA LEILOEIRO
============================================================ */

CREATE TABLE LEILOEIRO (
    LEILOEIROID INT IDENTITY(1,1) PRIMARY KEY,
    NOME VARCHAR(150) NOT NULL,
    EMAIL VARCHAR(150),
    TELEFONE VARCHAR(20),
    WEBSITE VARCHAR(200),
    CADASTROJUNTACOMERCIAL VARCHAR(200)
);

/* ============================================================
   TABELA STATUS
============================================================ */

CREATE TABLE STATUSLEILAO (
    STATUSID INT IDENTITY(1,1) PRIMARY KEY,
    NOME VARCHAR(100) NOT NULL UNIQUE
);

/* ============================================================
   TABELA USUARIO
============================================================ */

CREATE TABLE USUARIO (
    USUARIOID INT IDENTITY(1,1) PRIMARY KEY,
    NOME VARCHAR(150) NOT NULL,
    EMAIL VARCHAR(150) NOT NULL UNIQUE,
    TELEFONE VARCHAR(20),
    DATANASCIMENTO DATETIME NOT NULL,
    PROFISSAO VARCHAR(100),
    DATACRIACAO DATETIME NOT NULL DEFAULT GETDATE()
);

/* ============================================================
   TABELA COR
============================================================ */

CREATE TABLE COR(
    CORID INT IDENTITY(1,1) PRIMARY KEY,
    CORCATEGORIA VARCHAR(10),
    CORCATEGORIACONTRASTE VARCHAR(10),
    CATEGORIAID INT NOT NULL,
       
    CONSTRAINT FK_CATEGORIA
        FOREIGN KEY (CATEGORIAID) REFERENCES CATEGORIA(CATEGORIAID)
);
/* ============================================================
   TABELA LEILAO
============================================================ */

CREATE TABLE LEILAO (
    LEILAOID INT IDENTITY(1,1) PRIMARY KEY,
    LEILOEIROID INT NOT NULL,
    EDITAL VARCHAR(500),
    DATAPRIMEIRAPRACA DATETIME,
    DATASEGUNDAPRACA DATETIME,
    PRECOPRIMEIRAPRACA VARCHAR(100),
    PRECOSEGUNDAPRACA VARCHAR(100),
    DESCONTO DECIMAL(5,2),
    DATAINCLUSAO DATETIME NOT NULL,
    DATACRIACAO DATETIME DEFAULT GETDATE(),

    CONSTRAINT FK_LEILAO_LEILOEIRO 
        FOREIGN KEY (LEILOEIROID) REFERENCES LEILOEIRO(LEILOEIROID),

    CONSTRAINT CK_LEILAO_DESCONTO 
        CHECK (DESCONTO >= 0 AND DESCONTO <= 100)
);

CREATE INDEX IX_LEILAO_LEILOEIRO ON LEILAO(LEILOEIROID);

/* ============================================================
   TABELA IMOVEL
============================================================ */

CREATE TABLE IMOVEL (
    IMOVELID INT IDENTITY(1,1) PRIMARY KEY,
    CIDADEID INT NOT NULL,
    CATEGORIAID INT NOT NULL,
    LEILAOID INT NOT NULL,
    SITUACAO VARCHAR(500) NOT NULL,
    ENDERECO VARCHAR(500) NOT NULL,
    CEP VARCHAR(20) NOT NULL,
    DESCRICAO VARCHAR(MAX)NOT NULL,
    AREATOTAL DECIMAL(10,2),
    MATRICULA VARCHAR(100),


    CONSTRAINT FK_LEILAO
        FOREIGN KEY (LEILAOID) REFERENCES LEILAO(LEILAOID),
    CONSTRAINT FK_IMOVEL_CIDADE 
        FOREIGN KEY (CIDADEID) REFERENCES CIDADE(CIDADEID),
    CONSTRAINT FK_CATEGORIA_IMOVEL
        FOREIGN KEY (CATEGORIAID) REFERENCES CATEGORIA(CATEGORIAID)
);

CREATE INDEX IX_IMOVEL_CIDADE ON IMOVEL(CIDADEID);

/* ============================================================
   TABELA HISTORICO
============================================================ */

CREATE TABLE HISTORICO (
    HISTORICOID INT IDENTITY(1,1) PRIMARY KEY,
    LEILAOID INT NOT NULL,
    STATUSID INT NOT NULL,
    DATAHISTORICO DATETIME NOT NULL DEFAULT GETDATE(),
    SUCESSO BIT,
    TOTALLEILOES INT,

    CONSTRAINT FK_STATUS_LEILAO
        FOREIGN KEY (STATUSID) REFERENCES STATUSLEILAO (STATUSID),
    CONSTRAINT FK_HISTORICO_LEILAO 
        FOREIGN KEY (LEILAOID) REFERENCES LEILAO(LEILAOID)
);

CREATE INDEX IX_HISTORICO_LEILAO ON HISTORICO(LEILAOID);

/* ============================================================
   TABELA SINCRONIZACAO
============================================================ */

CREATE TABLE SINCRONIZACAO (
    SINCRONIZACAOID INT IDENTITY(1,1) PRIMARY KEY,
    LEILOEIROID INT NOT NULL,
    DATAINICIOATUALIZACAO DATETIME NOT NULL DEFAULT GETDATE(),
    DATATERMINOATUALIZACAO DATETIME NOT NULL DEFAULT GETDATE(),
    DATAATUALIZACAO DATETIME NOT NULL DEFAULT GETDATE(),
    SUCESSO BIT,

     CONSTRAINT FK_SINCRONIZACAO_LEILOEIRO
        FOREIGN KEY (LEILOEIROID) REFERENCES LEILOEIRO(LEILOEIROID),

);

/* ============================================================
   TABELA FOTO
============================================================ */

CREATE TABLE FOTO (
    FOTOID INT IDENTITY(1,1) PRIMARY KEY,
    IMOVELID INT NOT NULL,
    CAMINHOIMAGEM VARCHAR(300) NOT NULL,

    CONSTRAINT FK_FOTO_IMOVEL 
        FOREIGN KEY (IMOVELID) REFERENCES IMOVEL(IMOVELID)
);

CREATE INDEX IX_FOTO_IMOVEL ON FOTO(IMOVELID);

/* ============================================================
   TABELA FAVORITOS
============================================================ */

CREATE TABLE FAVORITOS (
    FAVORITOSID INT IDENTITY(1,1) PRIMARY KEY,
    LEILAOID INT NOT NULL,
    USUARIOID INT NOT NULL,
    DATAFAVORITO DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_FAVORITOS_USUARIO 
        FOREIGN KEY (USUARIOID) REFERENCES USUARIO(USUARIOID),

    CONSTRAINT FK_FAVORITOS_LEILAO 
        FOREIGN KEY (LEILAOID) REFERENCES LEILAO(LEILAOID),

    CONSTRAINT UQ_FAVORITO UNIQUE (USUARIOID, LEILAOID)
);

CREATE INDEX IX_FAVORITOS_USUARIO ON FAVORITOS(USUARIOID);



/* ============================================================
   TABELAS DE CONTROLE
============================================================ */

CREATE TABLE NOVOSLEILOES (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    LEILAOID INT,
    DATAREGISTRO DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE LEILOESREMOVIDOS (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    LEILAOID INT,
    DATAREGISTRO DATETIME NOT NULL DEFAULT GETDATE()
);


-- comandos git -- 
git status
git add .
git commit -m 'Criação da Service e Models#
>> Inclui interfaces vazias para serviços de Imóvel, Leilão, Leiloeiro e Usuário. Cria a classe ResultadoExecucao<T> para padronizar retornos. Adiciona dependências Dapper e SqlClient ao projeto.
 git config --global user.email "laura_chiarello@live.com"
 git config --global user.name "Laura Chiarello"
 git status
git log
> git push origin master
