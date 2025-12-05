Feature: Cadastro de Funcionário
  As a analista de RH
  I want to cadastrar um novo funcionário
  So that eu possa gerenciar seu contrato e jornada

  Scenario: Cadastrar funcionário válido
    Given um funcionário com nome "Maria Silva" e CPF "12345678901"
    When eu envio a requisição de cadastro
    Then o sistema responde com 201 Created
    And publica um evento "funcionarios.created"
