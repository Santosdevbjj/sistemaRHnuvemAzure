-- DDL completo para todas as tabelas do sistema de Recursos Humanos
-- Compatível com Azure SQL Database

CREATE TABLE Departamento (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(120) NOT NULL,
    Sigla VARCHAR(20) NULL
);

CREATE TABLE Cargo (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(120) NOT NULL,
    Descricao VARCHAR(255) NULL,
    EhChefia BIT NOT NULL DEFAULT 0
);

CREATE TABLE Funcionario (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NomeCompleto VARCHAR(200) NOT NULL,
    CPF CHAR(11) NOT NULL UNIQUE,
    RG VARCHAR(20) NULL,
    DataNascimento DATE NULL,
    Email VARCHAR(200) NULL,
    Telefone VARCHAR(20) NULL,
    DataAdmissao DATE NOT NULL,
    DataDemissao DATE NULL,
    SalarioBase DECIMAL(12,2) NOT NULL,
    IdCargo INT NOT NULL,
    IdDepartamento INT NOT NULL,
    Situacao VARCHAR(20) NOT NULL DEFAULT 'ATIVO',
    CONSTRAINT FK_Funcionario_Cargo FOREIGN KEY (IdCargo) REFERENCES Cargo(Id),
    CONSTRAINT FK_Funcionario_Departamento FOREIGN KEY (IdDepartamento) REFERENCES Departamento(Id)
);

CREATE TABLE EnderecoFuncionario (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdFuncionario INT NOT NULL,
    Tipo VARCHAR(30) NOT NULL,
    Logradouro VARCHAR(200) NOT NULL,
    Numero VARCHAR(20) NULL,
    Complemento VARCHAR(200) NULL,
    Bairro VARCHAR(120) NULL,
    Cidade VARCHAR(120) NULL,
    Estado CHAR(2) NULL,
    CEP CHAR(8) NULL,
    CONSTRAINT FK_Endereco_Funcionario FOREIGN KEY (IdFuncionario) REFERENCES Funcionario(Id) ON DELETE CASCADE
);

CREATE TABLE JornadaTrabalho (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    HoraEntrada TIME NOT NULL,
    HoraSaida TIME NOT NULL,
    DuracaoIntervaloMin INT NOT NULL,
    PermiteHorarioNoturno BIT NOT NULL DEFAULT 0
);

CREATE TABLE EscalaTrabalho (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdFuncionario INT NOT NULL,
    IdJornada INT NOT NULL,
    DiaSemana TINYINT NOT NULL,
    CONSTRAINT FK_Escala_Funcionario FOREIGN KEY (IdFuncionario) REFERENCES Funcionario(Id) ON DELETE CASCADE,
    CONSTRAINT FK_Escala_Jornada FOREIGN KEY (IdJornada) REFERENCES JornadaTrabalho(Id),
    CONSTRAINT UQ_Escala UNIQUE(IdFuncionario, DiaSemana)
);

CREATE TABLE RegistroPonto (
    Id BIGINT IDENTITY(1,1) PRIMARY KEY,
    IdFuncionario INT NOT NULL,
    DataHora DATETIME2 NOT NULL,
    Tipo VARCHAR(20) NOT NULL,
    Origem VARCHAR(50) NOT NULL DEFAULT 'SISTEMA',
    CONSTRAINT FK_Ponto_Funcionario FOREIGN KEY (IdFuncionario) REFERENCES Funcionario(Id) ON DELETE CASCADE
);

CREATE TABLE Beneficio (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(120) NOT NULL,
    Tipo VARCHAR(50) NULL,
    Valor DECIMAL(10,2) NULL
);

CREATE TABLE FuncionarioBeneficio (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdFuncionario INT NOT NULL,
    IdBeneficio INT NOT NULL,
    Ativo BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_FuncBen_Func FOREIGN KEY (IdFuncionario) REFERENCES Funcionario(Id) ON DELETE CASCADE,
    CONSTRAINT FK_FuncBen_Ben FOREIGN KEY (IdBeneficio) REFERENCES Beneficio(Id),
    CONSTRAINT UQ_FuncBen UNIQUE(IdFuncionario, IdBeneficio)
);

CREATE TABLE FolhaPagamento (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdFuncionario INT NOT NULL,
    Competencia CHAR(7) NOT NULL,
    SalarioBase DECIMAL(12,2) NOT NULL,
    HorasExtras DECIMAL(10,2) NOT NULL DEFAULT 0,
    AdicionalNoturno DECIMAL(10,2) NOT NULL DEFAULT 0,
    Descontos DECIMAL(10,2) NOT NULL DEFAULT 0,
    SalarioLiquido AS (SalarioBase + HorasExtras + AdicionalNoturno - Descontos),
    CONSTRAINT FK_Folha_Funcionario FOREIGN KEY (IdFuncionario) REFERENCES Funcionario(Id)
);

CREATE TABLE Ferias (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdFuncionario INT NOT NULL,
    PeriodoAquisitivoInicio DATE NOT NULL,
    PeriodoAquisitivoFim DATE NOT NULL,
    PeriodoGozoInicio DATE NULL,
    PeriodoGozoFim DATE NULL,
    Coeficiente DECIMAL(5,2) NOT NULL DEFAULT 1.00,
    CONSTRAINT FK_Ferias_Funcionario FOREIGN KEY (IdFuncionario) REFERENCES Funcionario(Id)
);

CREATE TABLE UsuarioSistema (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdFuncionario INT NULL,
    Username VARCHAR(100) NOT NULL UNIQUE,
    HashSenha VARCHAR(250) NOT NULL,
    PerfilAcesso VARCHAR(30) NOT NULL,
    UltimoAcesso DATETIME2 NULL,
    CONSTRAINT FK_Usuario_Funcionario FOREIGN KEY (IdFuncionario) REFERENCES Funcionario(Id)
);

CREATE TABLE OcorrenciasFuncionario (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdFuncionario INT NOT NULL,
    Tipo VARCHAR(50) NOT NULL,
    DataOcorrencia DATE NOT NULL,
    Descricao VARCHAR(255),
    CONSTRAINT FK_Oco_Func FOREIGN KEY (IdFuncionario) REFERENCES Funcionario(Id)
);
