-- Scripts completos para criação das tabelas no Azure SQL Database

-- Schema
CREATE SCHEMA hr;

-- Departamentos
CREATE TABLE hr.Departamentos (
    DepartamentoId INT IDENTITY(1,1) PRIMARY KEY,
    NomeDepartamento VARCHAR(100) NOT NULL,
    Descricao VARCHAR(255)
);

-- Cargos
CREATE TABLE hr.Cargos (
    CargoId INT IDENTITY(1,1) PRIMARY KEY,
    NomeCargo VARCHAR(100) NOT NULL,
    Descricao VARCHAR(255),
    IsChefia BIT NOT NULL DEFAULT 0
);

-- Horários de Jornada
CREATE TABLE hr.HorariosJornada (
    HorarioId INT IDENTITY(1,1) PRIMARY KEY,
    HoraEntrada TIME NOT NULL,
    HoraSaida TIME NOT NULL,
    IntervaloMinutos INT NOT NULL
);

-- Funcionários
CREATE TABLE hr.Funcionarios (
    FuncionarioId INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(150) NOT NULL,
    CPF CHAR(11) NOT NULL UNIQUE,
    DataNascimento DATE NOT NULL,
    Email VARCHAR(200) UNIQUE,
    Telefone VARCHAR(20),
    DataAdmissao DATE NOT NULL,
    CargoId INT NOT NULL,
    HorarioId INT NOT NULL,
    CONSTRAINT FK_Func_Cargo FOREIGN KEY (CargoId) REFERENCES hr.Cargos(CargoId),
    CONSTRAINT FK_Func_Horario FOREIGN KEY (HorarioId) REFERENCES hr.HorariosJornada(HorarioId)
);

-- Endereços
CREATE TABLE hr.EnderecoFuncionario (
    EnderecoId INT IDENTITY(1,1) PRIMARY KEY,
    FuncionarioId INT NOT NULL,
    Logradouro VARCHAR(200) NOT NULL,
    Numero VARCHAR(20),
    Bairro VARCHAR(120),
    Cidade VARCHAR(120),
    Estado CHAR(2),
    CEP CHAR(8),
    CONSTRAINT FK_Endereco_Func FOREIGN KEY (FuncionarioId) REFERENCES hr.Funcionarios(FuncionarioId)
);

-- Escalas
CREATE TABLE hr.EscalaTrabalho (
    EscalaId INT IDENTITY(1,1) PRIMARY KEY,
    FuncionarioId INT NOT NULL,
    HorarioId INT NOT NULL,
    DiaSemana TINYINT NOT NULL,
    CONSTRAINT FK_Escala_Func FOREIGN KEY (FuncionarioId) REFERENCES hr.Funcionarios(FuncionarioId),
    CONSTRAINT FK_Escala_Horario FOREIGN KEY (HorarioId) REFERENCES hr.HorariosJornada(HorarioId),
    CONSTRAINT UQ_Escala UNIQUE(FuncionarioId, DiaSemana)
);

-- Registro de Ponto
CREATE TABLE hr.RegistroPonto (
    PontoId BIGINT IDENTITY(1,1) PRIMARY KEY,
    FuncionarioId INT NOT NULL,
    DataHora DATETIME2 NOT NULL,
    Tipo VARCHAR(20) NOT NULL,
    Origem VARCHAR(50) NOT NULL DEFAULT 'SISTEMA',
    CONSTRAINT FK_Ponto_Func FOREIGN KEY (FuncionarioId) REFERENCES hr.Funcionarios(FuncionarioId)
);
