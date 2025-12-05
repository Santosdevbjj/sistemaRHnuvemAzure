-- ============================================================
-- Seeds completos para o Sistema de RH
-- Compatível com Azure SQL Database
-- ============================================================

/* ============================================================
1. Seeds básicos: Departamentos e Cargos
============================================================ */

-- Departamentos
INSERT INTO Departamento (Nome, Sigla) VALUES
('Recursos Humanos', 'RH'),
('Financeiro', 'FIN'),
('Tecnologia da Informação', 'TI'),
('Operações', 'OPS'),
('Jurídico', 'JUR'),
('Comercial', 'COM');

-- Cargos
INSERT INTO Cargo (Nome, Descricao, EhChefia) VALUES
('Analista de RH', 'Responsável pelo cadastro e gestão de funcionários', 0),
('Assistente Financeiro', 'Auxílio nos processos financeiros', 0),
('Desenvolvedor Backend', 'Desenvolvimento de APIs e serviços', 0),
('Gerente de TI', 'Gestão da equipe de TI', 1),
('Coordenador de Operações', 'Coordenação das operações', 1),
('Estagiário', 'Apoio às áreas', 0);

-- Índices recomendados (caso não existam)
-- CREATE INDEX IX_Funcionario_Departamento ON Funcionario(IdDepartamento);
-- CREATE INDEX IX_Funcionario_Cargo ON Funcionario(IdCargo);


/* ============================================================
2. Seeds: Jornada de Trabalho (operacionais e chefia)
============================================================ */

-- Jornadas operacionais (intervalo 15min)
INSERT INTO JornadaTrabalho (Nome, HoraEntrada, HoraSaida, DuracaoIntervaloMin, PermiteHorarioNoturno) VALUES
('07:00 às 13:15', '07:00', '13:15', 15, 0),
('08:00 às 14:15', '08:00', '14:15', 15, 0),
('09:00 às 15:15', '09:00', '15:15', 15, 0),
('12:00 às 18:15', '12:00', '18:15', 15, 0),
('13:00 às 19:15', '13:00', '19:15', 15, 0),
('14:00 às 20:15', '14:00', '20:15', 15, 0),
('20:00 às 02:00', '20:00', '02:00', 15, 1),
('21:00 às 03:00', '21:00', '03:00', 15, 1),
('23:00 às 05:00', '23:00', '05:00', 15, 1),
('00:00 às 06:00', '00:00', '06:00', 15, 1);

-- Jornadas chefia (intervalo 60min)
INSERT INTO JornadaTrabalho (Nome, HoraEntrada, HoraSaida, DuracaoIntervaloMin, PermiteHorarioNoturno) VALUES
('07:00 às 16:00 (Chefia)', '07:00', '16:00', 60, 0),
('08:00 às 17:00 (Chefia)', '08:00', '17:00', 60, 0),
('09:00 às 18:00 (Chefia)', '09:00', '18:00', 60, 0),
('10:00 às 19:00 (Chefia)', '10:00', '19:00', 60, 0),
('17:00 às 01:00 (Chefia)', '17:00', '01:00', 60, 1),
('18:00 às 02:00 (Chefia)', '18:00', '02:00', 60, 1),
('19:00 às 03:00 (Chefia)', '19:00', '03:00', 60, 1),
('23:00 às 07:00 (Chefia)', '23:00', '07:00', 60, 1),
('00:00 às 08:00 (Chefia)', '00:00', '08:00', 60, 1);


/* ============================================================
3. Seeds: Benefícios
============================================================ */

INSERT INTO Beneficio (Nome, Tipo, Valor) VALUES
('Vale Transporte', 'VT', 200.00),
('Vale Refeição', 'VR', 600.00),
('Plano de Saúde', 'SAUDE', 350.00),
('Auxílio Creche', 'AUX', 300.00),
('Seguro de Vida', 'SEGURO', 50.00);


/* ============================================================
4. Seeds: Funcionários + Endereços
Observação: ajuste IdCargo e IdDepartamento conforme os IDs gerados
============================================================ */

-- Funcionários (exemplos)
INSERT INTO Funcionario
(NomeCompleto, CPF, RG, DataNascimento, Email, Telefone, DataAdmissao, DataDemissao, SalarioBase, IdCargo, IdDepartamento, Situacao)
VALUES
('Ana Silva', '12345678901', 'MG-12.345.678', '1990-05-12', 'ana.silva@empresa.com', '(31)99999-0001', '2022-01-10', NULL, 4500.00, 1, 1, 'ATIVO'),
('Bruno Costa', '23456789012', 'MG-23.456.789', '1988-03-22', 'bruno.costa@empresa.com', '(31)99999-0002', '2021-06-15', NULL, 5200.00, 3, 3, 'ATIVO'),
('Carla Menezes', '34567890123', 'MG-34.567.890', '1995-11-30', 'carla.menezes@empresa.com', '(31)99999-0003', '2023-02-01', NULL, 9800.00, 4, 3, 'ATIVO'),
('Diego Ramos', '45678901234', 'MG-45.678.901', '1992-08-05', 'diego.ramos@empresa.com', '(31)99999-0004', '2020-09-01', NULL, 3200.00, 2, 2, 'ATIVO'),
('Elisa Pereira', '56789012345', 'MG-56.789.012', '1986-12-18', 'elisa.pereira@empresa.com', '(31)99999-0005', '2019-04-23', NULL, 1500.00, 6, 4, 'ATIVO');

-- Endereços dos funcionários
INSERT INTO EnderecoFuncionario (IdFuncionario, Tipo, Logradouro, Numero, Complemento, Bairro, Cidade, Estado, CEP) VALUES
(1, 'Residencial', 'Rua A', '100', NULL, 'Centro', 'Belo Horizonte', 'MG', '30140000'),
(2, 'Residencial', 'Av. Brasil', '230', 'Ap 402', 'Savassi', 'Belo Horizonte', 'MG', '30180000'),
(3, 'Residencial', 'Rua das Flores', '55', NULL, 'Funcionários', 'Belo Horizonte', 'MG', '30120000'),
(4, 'Residencial', 'Rua XV', '12', 'Casa', 'Nova Lima', 'Nova Lima', 'MG', '34000000'),
(5, 'Residencial', 'Av. Alameda', '77', NULL, 'Ipiranga', 'Belo Horizonte', 'MG', '31160000');


/* ============================================================
5. Seeds: Escalas de Trabalho
Associação de funcionários às jornadas por dia da semana
DiaSemana: 1=Segunda ... 7=Domingo
============================================================ */

-- Assumindo que as jornadas inseridas geraram IDs de 1..19
-- Escala para Ana Silva (FuncionarioId=1) na jornada '08:00 às 14:15' (JornadaId=2)
INSERT INTO EscalaTrabalho (IdFuncionario, IdJornada, DiaSemana) VALUES
(1, 2, 1),
(1, 2, 2),
(1, 2, 3),
(1, 2, 4),
(1, 2, 5);

-- Escala para Bruno Costa (FuncionarioId=2) na jornada '09:00 às 18:00 (Chefia)' (JornadaId=13)
INSERT INTO EscalaTrabalho (IdFuncionario, IdJornada, DiaSemana) VALUES
(2, 13, 1),
(2, 13, 2),
(2, 13, 3),
(2, 13, 4),
(2, 13, 5);

-- Escala para Carla Menezes (FuncionarioId=3) na jornada '23:00 às 07:00 (Chefia)' (JornadaId=18)
INSERT INTO EscalaTrabalho (IdFuncionario, IdJornada, DiaSemana) VALUES
(3, 18, 1),
(3, 18, 2),
(3, 18, 3),
(3, 18, 4),
(3, 18, 5);

-- Escala para Diego Ramos (FuncionarioId=4) na jornada '12:00 às 18:15' (JornadaId=4)
INSERT INTO EscalaTrabalho (IdFuncionario, IdJornada, DiaSemana) VALUES
(4, 4, 1),
(4, 4, 2),
(4, 4, 3),
(4, 4, 4),
(4, 4, 5);

-- Escala para Elisa Pereira (FuncionarioId=5) na jornada '20:00 às 02:00' (JornadaId=7)
INSERT INTO EscalaTrabalho (IdFuncionario, IdJornada, DiaSemana) VALUES
(5, 7, 1),
(5, 7, 2),
(5, 7, 3),
(5, 7, 4),
(5, 7, 5);


/* ============================================================
6. Seeds: Registros de Ponto (exemplos)
============================================================ */

-- Entradas e saídas simuladas para Ana (FuncionarioId=1)
INSERT INTO RegistroPonto (IdFuncionario, DataHora, Tipo, Origem) VALUES
(1, '2025-12-01T08:00:00', 'Entrada', 'SISTEMA'),
(1, '2025-12-01T14:15:00', 'Saída', 'SISTEMA'),
(1, '2025-12-02T08:00:00', 'Entrada', 'SISTEMA'),
(1, '2025-12-02T14:15:00', 'Saída', 'SISTEMA');

-- Entradas e saídas simuladas para Bruno (FuncionarioId=2)
INSERT INTO RegistroPonto (IdFuncionario, DataHora, Tipo, Origem) VALUES
(2, '2025-12-01T09:00:00', 'Entrada', 'SISTEMA'),
(2, '2025-12-01T18:00:00', 'Saída', 'SISTEMA');


/* ============================================================
7. Seeds: Vínculos de Benefícios com Funcionários
============================================================ */

-- Vínculo de benefícios
INSERT INTO FuncionarioBeneficio (IdFuncionario, IdBeneficio, Ativo) VALUES
(1, 1, 1), -- Ana com VT
(1, 2, 1), -- Ana com VR
(2, 3, 1), -- Bruno com Plano de Saúde
(3, 5, 1), -- Carla com Seguro
(4, 1, 1), -- Diego com VT
(5, 2, 1); -- Elisa com VR


/* ============================================================
8. Seeds: Folha de Pagamento (exemplos)
============================================================ */

INSERT INTO FolhaPagamento
(IdFuncionario, Competencia, SalarioBase, HorasExtras, AdicionalNoturno, Descontos)
VALUES
(1, '2025-11', 4500.00, 120.00, 0.00, 300.00),
(2, '2025-11', 5200.00, 80.00, 0.00, 450.00),
(3, '2025-11', 9800.00, 60.00, 320.00, 900.00),
(4, '2025-11', 3200.00, 0.00, 0.00, 150.00),
(5, '2025-11', 1500.00, 0.00, 180.00, 100.00);


/* ============================================================
9. Seeds: Férias (exemplos)
============================================================ */

INSERT INTO Ferias
(IdFuncionario, PeriodoAquisitivoInicio, PeriodoAquisitivoFim, PeriodoGozoInicio, PeriodoGozoFim, Coeficiente)
VALUES
(1, '2024-01-10', '2024-12-31', '2025-01-05', '2025-01-25', 1.00),
(2, '2024-06-15', '2025-06-14', NULL, NULL, 1.00);


/* ============================================================
10. Seeds: Usuários do Sistema (Auth)
Senha deve ser armazenada como hash (ex.: BCrypt) — abaixo apenas placeholders
============================================================ */

INSERT INTO UsuarioSistema (IdFuncionario, Username, HashSenha, PerfilAcesso, UltimoAcesso) VALUES
(1, 'ana.silva', '$2a$12$PLACEHOLDER_HASH_ANA', 'RH', GETUTCDATE()),
(2, 'bruno.costa', '$2a$12$PLACEHOLDER_HASH_BRUNO', 'Gestor', GETUTCDATE()),
(3, 'carla.menezes', '$2a$12$PLACEHOLDER_HASH_CARLA', 'Admin', GETUTCDATE()),
(NULL, 'admin.sistema', '$2a$12$PLACEHOLDER_HASH_ADMIN', 'Admin', GETUTCDATE());


/* ============================================================
11. Seeds: Ocorrências de Funcionário (exemplos)
============================================================ */

INSERT INTO OcorrenciasFuncionario (IdFuncionario, Tipo, DataOcorrencia, Descricao) VALUES
(1, 'Advertencia', '2025-10-20', 'Atraso de 15 minutos'),
(2, 'Afastamento', '2025-09-12', 'Afastamento médico de 5 dias'),
(3, 'Justificativa', '2025-11-02', 'Saída antecipada com justificativa');


/* ============================================================
12. Observações
- Ajuste IDs conforme os registros realmente criados no seu ambiente.
- Em produção, substitua HashSenha por hashes reais gerados com BCrypt.Net.
- Para grandes volumes, prefira importar CSV (Docs/horarios_trabalho.csv) ou usar scripts de ETL.
============================================================ */
