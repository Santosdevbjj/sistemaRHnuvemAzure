### Construindo um Sistema de Cadastro de Funcionários e Hospedando na Nuvem Azure

![DotNet_Developer](https://github.com/user-attachments/assets/455a5e1c-e39f-4a1f-a116-78afd895ad45)


**Formação .NET Developer**


---




**Sistema de recursos humanos**

Este repositório consolida uma arquitetura de microsserviços para um Sistema de Recursos Humanos, cobrindo autenticação, cadastro de funcionários, jornada/escala, folha de pagamento, benefícios, logs e notificações, além de um API Gateway, um Shared Kernel, automações de CI/CD e implantação em AKS com integração segura ao Azure Key Vault.

**Este guia:** explica a estrutura de pastas, cada arquivo principal e sua funcionalidade, como compilar e testar com dotnet, como executar localmente, requisitos e tecnologias, e traz um esquema visual da árvore de diretórios.

---

**Visão geral da solução**

- **Objetivo:** plataforma modular de RH, escalável e segura, com serviços independentes integrados via HTTP (API Gateway) e mensageria (RabbitMQ), persistência em bancos separados, observabilidade com logs e notificações, e segurança de segredos via Azure Key Vault.
  
- **Arquitetura:** microsserviços .NET, separação em camadas (Api, Domain, Infrastructure), testes unitários e BDD, automação CI/CD em GitHub Actions, deploy em AKS.

- **Segurança:** .gitignore robusto, GitHub Secret Scanning, GitGuardian monitorando leaks, Key Vault como fonte única de segredos, pipelines que puxam segredos com identidade de serviço.

---

**Estrutura de pastas no GitHub**

**Esquema visual das pastas e arquivos**


sistemaRHnuvemAzure/
├─ services/
│  ├─ auth-service/
│  │  ├─ src/
│  │  │  ├─ Auth.Api/
│  │  │  │  ├─ Auth.Api.csproj
│  │  │  │  ├─ Endpoints/AuthEndpoints.cs
│  │  │  │  ├─ Program.cs
│  │  │  │  └─ appsettings.json
│  │  │  ├─ Auth.Domain/
│  │  │  │  ├─ Auth.Domain.csproj
│  │  │  │  └─ Entities/UsuarioSistema.cs
│  │  │  └─ Auth.Infrastructure/
│  │  │     ├─ Auth.Infrastructure.csproj
│  │  │     ├─ Persistence/AuthDbContext.cs
│  │  │     └─ Services/TokenService.cs
│  │  └─ tests/
│  │     └─ Auth.Tests/Auth.Tests.csproj
│  │  └─ Dockerfile
│  ├─ funcionarios-service/
│  │  ├─ src/
│  │  │  ├─ Funcionarios.Api/
│  │  │  │  ├─ Funcionarios.Api.csproj
│  │  │  │  ├─ Endpoints/FuncionarioEndpoints.cs
│  │  │  │  ├─ Program.cs
│  │  │  │  └─ appsettings.json
│  │  │  ├─ Funcionarios.Domain/
│  │  │  │  ├─ Funcionarios.Domain.csproj
│  │  │  │  └─ Entities/Funcionario.cs
│  │  │  └─ Funcionarios.Infrastructure/
│  │  │     ├─ Funcionarios.Infrastructure.csproj
│  │  │     └─ Persistence/FuncionariosDbContext.cs
│  │  └─ tests/
│  │     ├─ Funcionarios.UnitTests/Funcionarios.UnitTests.csproj
│  │     └─ Funcionarios.Bdd/
│  │        ├─ Funcionarios.Bdd.csproj
│  │        ├─ Features/CadastroFuncionario.feature
│  │        └─ Steps/CadastroFuncionarioSteps.cs
│  │  └─ Dockerfile
│  ├─ jornadaescala-service/
│  │  ├─ src/
│  │  │  ├─ JornadaEscala.Api/
│  │  │  │  ├─ JornadaEscala.Api.csproj
│  │  │  │  ├─ Endpoints/JornadaEndpoints.cs
│  │  │  │  ├─ Endpoints/EscalaEndpoints.cs
│  │  │  │  ├─ Endpoints/PontoEndpoints.cs
│  │  │  │  └─ Program.cs
│  │  │  ├─ JornadaEscala.Domain/
│  │  │  │  └─ JornadaEscala.Domain.csproj
│  │  │  └─ JornadaEscala.Infrastructure/
│  │  │     ├─ JornadaEscala.Infrastructure.csproj
│  │  │     ├─ Persistence/JornadaDbContext.cs
│  │  │     ├─ Seeds/JornadaSeeds.cs
│  │  │     ├─ Configurations/FuncionarioConfig.cs
│  │  │     ├─ Configurations/EnderecoFuncionarioConfig.cs
│  │  │     ├─ Configurations/JornadaTrabalhoConfig.cs
│  │  │     ├─ Configurations/EscalaTrabalhoConfig.cs
│  │  │     ├─ Configurations/RegistroPontoConfig.cs
│  │  │     ├─ Persistence/EntityConfigurations.cs
│  │  │     └─ Persistence/PersistenceServiceExtensions.cs
│  │  └─ tests/
│  │     └─ JornadaEscala.Tests/JornadaEscala.Tests.csproj
│  ├─ folha-service/
│  │  ├─ src/
│  │  │  ├─ Folha.Api/Folha.Api.csproj
│  │  │  ├─ Folha.Domain/
│  │  │  │  ├─ Folha.Domain.csproj
│  │  │  │  └─ Services/CalculadoraFolha.cs
│  │  │  └─ Folha.Infrastructure/Folha.Infrastructure.csproj
│  │  └─ tests/
│  │     ├─ Folha.Tests/Folha.Tests.csproj
│  │     └─ Folha.Tests/CalculadoraFolhaTests.cs
│  ├─ beneficios-service/
│  │  ├─ src/
│  │  │  ├─ Beneficios.Api/Beneficios.Api.csproj
│  │  │  ├─ Beneficios.Domain/Beneficios.Domain.csproj
│  │  │  └─ Beneficios.Infrastructure/Beneficios.Infrastructure.csproj
│  │  └─ tests/Beneficios.Tests/Beneficios.Tests.csproj
│  ├─ logs-service/
│  │  ├─ src/
│  │  │  ├─ Logs.Api/Logs.Api.csproj
│  │  │  ├─ Logs.Infrastructure/
│  │  │  │  ├─ Logs.Infrastructure.csproj
│  │  │  │  ├─ TableStorage/FuncionarioLogEntity.cs
│  │  │  │  └─ Messaging/FuncionarioEventsConsumer.cs
│  │  └─ tests/Logs.Tests/Logs.Tests.csproj
│  └─ notifications-service/
│     ├─ src/
│     │  └─ Notifications.Api/
│     │     ├─ Notifications.Api.csproj
│     │     ├─ Program.cs
│     │     ├─ Messaging/EventConsumers.cs
│     │     └─ Services/EmailSender.cs
│     └─ tests/Notifications.Tests/Notifications.Tests.csproj
├─ gateway/
│  ├─ src/ApiGateway/
│  │  ├─ ApiGateway.csproj
│  │  ├─ Program.cs
│  │  └─ appsettings.json
│  └─ Dockerfile
├─ shared/
│  └─ src/SharedKernel/
│     ├─ SharedKernel.csproj
│     ├─ Events/FuncionarioEvents.cs
│     ├─ Auth/JwtExtensions.cs
│     └─ Messaging/RabbitMqProducer.cs
├─ tests/
│  └─ JornadaEscala.Api.Tests/
│     ├─ JornadaEndpointsTests.cs
│     ├─ EscalaEndpointsTests.cs
│     └─ PontoEndpointsTests.cs
├─ Docs/
│  ├─ ManualTecnico.md
│  ├─ ManualLeigo.md
│  ├─ horarios_trabalho.csv
│  ├─ tabelassqlddl.sql
│  ├─ scriptscriacaotabelas.sql
│  └─ scripts_seeds.sql
├─ .github/workflows/
│  ├─ ci-cd.yml
│  ├─ aks-deploy.yml
│  └─ aks-secrets-deploy.yml
├─ deployment.yaml
├─ docker-compose.yml
├─ SistemaRH.sln
├─ .gitignore
└─ README.md (este arquivo)
`

---

**Funcionalidade de cada pasta e arquivo**

• **services**

- **Auth Service**
  - **src/Auth.Api/Program.cs:** ponto de entrada da API de autenticação.
  - **src/Auth.Api/Endpoints/AuthEndpoints.cs:** endpoints de login/refresh.
  - **src/Auth.Api/appsettings.json:** configurações básicas; segredos não ficam aqui.
  - **src/Auth.Domain/Entities/UsuarioSistema.cs:** entidade de usuário do sistema.
  - **src/Auth.Infrastructure/Persistence/AuthDbContext.cs:** contexto EF Core.
  - **src/Auth.Infrastructure/Services/TokenService.cs:** geração/validação de JWT.
  - **tests/Auth.Tests/Auth.Tests.csproj:** projeto de testes do serviço.

- **Funcionários Service**
  - **src/Funcionarios.Api/Program.cs:** entrada da API.
  - **src/Funcionarios.Api/Endpoints/FuncionarioEndpoints.cs:** endpoints CRUD e consultas.
  - src/Funcionarios.Api/appsettings.json: configs locais.
  - **src/Funcionarios.Domain/Entities/Funcionario.cs:** entidade funcionário.
  - **src/Funcionarios.Infrastructure/Persistence/FuncionariosDbContext.cs:** EF Core.
  - tests/Funcionarios.UnitTests/…: testes unitários de domínio e infraestrutura.
  - **tests/Funcionarios.Bdd/Features/CadastroFuncionario.feature:** especificações BDD.
  - **tests/Funcionarios.Bdd/Steps/CadastroFuncionarioSteps.cs:** passos BDD.

- **Jornada/Escala Service**
  - **src/JornadaEscala.Api/Program.cs:** entrada.
  - **src/JornadaEscala.Api/Endpoints/*.cs:** endpoints para jornada, escala e ponto.
  - **src/JornadaEscala.Domain/JornadaEscala.Domain.csproj:** regras de domínio.
  - **src/JornadaEscala.Infrastructure/Persistence/JornadaDbContext.cs:** EF Core.
  - **src/JornadaEscala.Infrastructure/Seeds/JornadaSeeds.cs:** dados iniciais.
  - **src/JornadaEscala.Infrastructure/Configurations/*.cs:** mapeamentos Fluent API.
  - **src/JornadaEscala.Infrastructure/Persistence/*.cs:** extensões de persistência.
  - **tests/JornadaEscala.Tests/JornadaEscala.Tests.csproj:** testes do serviço.

- **Folha Service**
  - **src/Folha.Api/Folha.Api.csproj:** API da folha.
  - **src/Folha.Domain/Services/CalculadoraFolha.cs:** regra de cálculo.
  - **src/Folha.Infrastructure/Folha.Infrastructure.csproj:** infraestrutura de dados.
  - **tests/Folha.Tests/CalculadoraFolhaTests.cs:** testes de cálculo.

- **Benefícios Service**
  - **src/Beneficios.Api/Beneficios.Api.csproj:** API de benefícios.
  - **src/Beneficios.Domain/Beneficios.Domain.csproj:** modelo e regras.
  - **src/Beneficios.Infrastructure/Beneficios.Infrastructure.csproj:** persistência.
  - **tests/Beneficios.Tests/Beneficios.Tests.csproj:** testes.

- Logs Service
  - **src/Logs.Api/Logs.Api.csproj:** API de logs/consulta.
  - **src/Logs.Infrastructure/TableStorage/FuncionarioLogEntity.cs:** entidade para Azure Table Storage.
  - **src/Logs.Infrastructure/Messaging/FuncionarioEventsConsumer.cs:** consumo de eventos de funcionário para logar.
  - **tests/Logs.Tests/Logs.Tests.csproj:** testes.

- **Notifications Service**
  - **src/Notifications.Api/Program.cs:** entrada da API de notificações.
  - **src/Notifications.Api/Messaging/EventConsumers.cs:** consumidores de eventos para envio de notificações.
  - **src/Notifications.Api/Services/EmailSender.cs:** serviço de e-mail.
  - **tests/Notifications.Tests/Notifications.Tests.csproj:** testes.

• **gateway**

- **src/ApiGateway/Program.cs:** API Gateway que roteia chamadas para serviços.
- **src/ApiGateway/appsettings.json:** configuração de roteamento.
- **Dockerfile:** imagem do gateway para container.

• **shared**

- **src/SharedKernel/SharedKernel.csproj:** biblioteca compartilhada.
- **Events/FuncionarioEvents.cs:** contratos/eventos de domínio para mensageria.
- **Auth/JwtExtensions.cs:** extensões utilitárias para JWT.
- **Messaging/RabbitMqProducer.cs:** produtor para RabbitMQ.

• **tests**

- **JornadaEscala.Api.Tests/*.cs:** testes de API em jornada/escala.

• **Docs**

- **ManualTecnico.md, ManualLeigo.md:** documentação técnica/usuário.
- **.sql e .csv:** artefatos de banco e dados de exemplo.

• **DevOps e Deploy**

- **.github/workflows/ci-cd.yml:** pipeline CI/CD geral (build, test, deploy).
- **.github/workflows/aks-deploy.yml:** deploy em AKS com ACR.
- **.github/workflows/aks-secrets-deploy.yml:** atualização de Kubernetes Secrets a partir do Key Vault.
- **deployment.yaml:** manifesto Kubernetes (Deployment + Service).
- **docker-compose.yml:** orquestração local de serviços.
- **SistemaRH.sln:** solution .NET com todos os projetos.
- **.gitignore:** regras para ignorar artefatos de build e segredos.

---

• **Projetos .csproj e papéis por camada**

- **Api (.Api.csproj):** expõe endpoints HTTP; configura DI, autenticação, Swagger; não contém lógica de negócio, apenas orquestra.
- **Domain (.Domain.csproj):** entidades, serviços de domínio, regras de negócio e invariantes; sem dependências de infraestrutura.
- **Infrastructure (.Infrastructure.csproj):** persistência (EF Core), integrações externas, mapeamentos, repositórios e mensageria.
- **Tests (.Tests.csproj, .UnitTests.csproj, .Bdd.csproj):** testes unitários, de integração e BDD, garantindo qualidade e regressão mínima.
- **SharedKernel (.csproj):** componentes cross-cutting, contratos de eventos e utilitários compartilhados.

---

• **Tecnologias utilizadas**

- **.NET:** Web APIs, EF Core, testes unitários e BDD.
- **Azure:** Key Vault (segredos), AKS (orquestração), ACR (imagens), Table Storage (logs), App Insights/Monitor (observabilidade, quando habilitado).
- **Mensageria:** RabbitMQ para eventos de domínio e integração entre serviços.
- **DevOps:** GitHub Actions (CI/CD), Docker, Kubernetes Manifests.
- **Qualidade:** GitGuardian/Secret Scanning, branch protections, testes automatizados.

---

• **Requisitos de hardware e software**

- **Hardware mínimo (dev):**
  - **CPU:** 4 cores
  - **Memória:** 8 GB RAM (recomendado 16 GB para rodar múltiplos serviços)
  - **Disco:** 20 GB livres

- **Software (dev):**
  - **Sistema operacional:** Windows 10/11, macOS, ou Linux
  - **SDK .NET:** 8.0 ou superior
  - **Docker Desktop:** versão recente com Kubernetes opcional
  - **kubectl:** para aplicar manifests e interagir com clusters
  - **Azure CLI:** para login e operações na nuvem
  - **Git:** controle de versão
  - **RabbitMQ:** local via Docker Compose (quando necessário)
  - **Editor:** Visual Studio 2022 ou VS Code

---

**Como compilar e rodar testes**

Build

- Build da solução completa:
  `bash
  dotnet build SistemaRH.sln --configuration Release
  `

- Build de um serviço específico (ex.: Funcionários Api):
  `bash
  dotnet build services/funcionarios-service/src/Funcionarios.Api/Funcionarios.Api.csproj --configuration Release
  `

**Testes**

- Rodar todos os testes da solução:
  `bash
  dotnet test SistemaRH.sln --configuration Release --no-build
  `

- Rodar testes de um projeto específico (ex.: Folha.Tests):
  `bash
  dotnet test services/folha-service/tests/Folha.Tests/Folha.Tests.csproj --configuration Release --no-build
  `

---

• **Como executar localmente**

• **Usando Docker Compose**

1. Build das imagens e subida dos serviços:
   `bash
   docker compose up --build
   `
**2. Configurar variáveis e segredos:**
   - .env: variáveis não sensíveis locais.
   - Segredos reais devem ser simulados via variáveis de ambiente ou Kubernetes Secrets em ambiente de dev. Evite colocar connection strings em arquivos versionados.

• **Executando um serviço via dotnet run**

- Exemplo (Funcionários Api):
  `bash
  dotnet run --project services/funcionarios-service/src/Funcionarios.Api/Funcionarios.Api.csproj
  `
- Use a URL local exibida no console para testar endpoints.

---

• **CI/CD e deploy**

- **Build e test automáticos:** .github/workflows/ci-cd.yml
- Deploy em AKS: .github/workflows/aks-deploy.yml
- Integração com Key Vault e atualização de **Kubernetes Secrets:** .github/workflows/aks-secrets-deploy.yml
- **Manifesto Kubernetes:** deployment.yaml injeta variáveis de ambiente via secretKeyRef dos Secrets criados no cluster.

---

• **Segurança: GitGuardian e vazamento de segredos**

**O que significa o alerta do GitGuardian**

- Mensagem: “ODBC Connection String exposed on GitHub”.
- Significado: foi detectada uma connection string (ODBC) exposta em algum commit do repositório. Connection strings podem conter host de banco, usuário e senha. Manter isso no Git é um risco de segurança grave, pois qualquer fork/clone ou histórico pode exibir o segredo.

**Como resolver detalhadamente**

**1. Revogar e rotacionar credenciais:**
   - Revogar a credencial exposta no banco ou provedor imediatamente.
   - Gerar uma nova credencial (usuário/senha ou token).
**2. Remover o segredo do código:**
   - Substituir no código por leitura segura via Azure Key Vault (em tempo de execução).
   - Manter apenas a referência ao Key Vault (por exemplo, KeyVault:Url) em appsettings.json.
**3. Limpar o histórico do Git:**
   - Usar git filter-repo ou BFG Repo-Cleaner para remover o arquivo/linha do histórico.
   - Exemplo com git filter-repo:
     `bash
     pip install git-filter-repo
     git filter-repo --replace-text replacements.txt
     `
     Onde replacements.txt mapeia o segredo para máscara:
     `
     senhaAntiga=REMOVED
     `
   - Forçar push:
     `bash
     git push origin --force
     `
   - Avisar colaboradores para re-clonar (histórico reescrito).
**4. Validar com GitGuardian:**
   - Confirmar que os novos commits e PRs não contêm segredos.
   - Fechar o incidente no painel após correção.
**5. Atualizar pipelines:**
   - Garantir que GitHub Secrets guardam credenciais do Service Principal (AZURE_CREDENTIALS).
   - Pipelines passam a puxar segredos do Key Vault, nunca do repositório.

• **Como evitar esse erro no futuro**

- Políticas e práticas:
  - Nunca commitar .env, appsettings.*.local.json, secrets.json, perfis de publicação.
  - Reforçar .gitignore (já configurado neste repo).
  - Usar Azure Key Vault e Managed Identity para acesso em produção.
  - Ativar GitHub Secret Scanning e GitGuardian para PRs e branches.
  - Code reviews com checklist de segurança.
- Automação:
  - Pipelines que criam/atualizam Kubernetes Secrets a partir do Key Vault (já incluído).
  - Rotação periódica de segredos no Key Vault.
- Treinamento:
  - Conscientização da equipe sobre riscos de expor segredos.
  - Documentar fluxo de configuração segura em Docs/ManualTecnico.md.

---

• **Boas práticas adicionais**

- Configurações por ambiente: segregar Dev/QA/Prod (Key Vaults separados, recursos por ambiente).
- Observabilidade: logs centralizados (Logs Service, Table Storage), alertas e métricas.
- Mensageria resiliente: garantir DLQs e políticas de retry no RabbitMQ.
- Proteção de branches: obrigar PR + revisão + testes passarem antes de merge.
- Versionamento de API: versionar endpoints no Gateway/serviços para evitar breaking changes.

---

• **Referência rápida de caminhos importantes**

- Solução: SistemaRH.sln
- Compose: docker-compose.yml
- Manifesto Kubernetes: deployment.yaml
- Pipelines: .github/workflows/ci-cd.yml, aks-deploy.yml, aks-secrets-deploy.yml
- Gateway: gateway/src/ApiGateway/Program.cs, gateway/src/ApiGateway/appsettings.json
- Shared Kernel: shared/src/SharedKernel/SharedKernel.csproj
- Auth: services/auth-service/src/Auth.Api/Program.cs, services/auth-service/src/Auth.Infrastructure/Persistence/AuthDbContext.cs
- Funcionários: services/funcionarios-service/src/Funcionarios.Api/Program.cs, services/funcionarios-service/src/Funcionarios.Infrastructure/Persistence/FuncionariosDbContext.cs
- Jornada/Escala: services/jornadaescala-service/src/JornadaEscala.Api/Program.cs, .../Persistence/JornadaDbContext.cs
- Folha: services/folha-service/src/Folha.Domain/Services/CalculadoraFolha.cs
- Logs: services/logs-service/src/Logs.Infrastructure/Messaging/FuncionarioEventsConsumer.cs
- Notificações: services/notifications-service/src/Notifications.Api/Program.cs

---

• **Passos finais para quem vai começar**

- Instalar pré-requisitos e clonar o repositório.
- dotnet build e dotnet test para validar.
- docker compose up --build para rodar localmente.
- Configurar Azure (Key Vault, ACR, AKS) e atualizar secrets no GitHub.
- Executar pipelines de CI/CD para publicar e implantar.

Se tiver dúvidas, abra uma issue no repositório ou consulte os manuais em Docs/.












---


**Autor:**
  Sergio Santos 


---

**Contato:**


[![Portfólio Sérgio Santos](https://img.shields.io/badge/Portfólio-Sérgio_Santos-111827?style=for-the-badge&logo=githubpages&logoColor=00eaff)](https://santosdevbjj.github.io/portfolio/)
[![LinkedIn Sérgio Santos](https://img.shields.io/badge/LinkedIn-Sérgio_Santos-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://linkedin.com/in/santossergioluiz) 

---

