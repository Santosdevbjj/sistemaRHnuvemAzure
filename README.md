### Sistema de RH em Nuvem com Azure (Arquitetura de Microsserviços)

**Resumo:**

Este projeto apresenta um Sistema de Recursos Humanos corporativo, desenvolvido com arquitetura de microsserviços e implantado na nuvem Microsoft Azure, simulando cenários reais de ambientes empresariais de médio e grande porte.

O projeto demonstra competências em engenharia de software, cloud computing e DevOps, incluindo:

Modelagem de domínios com Domain-Driven Design (DDD)

Arquitetura distribuída com microsserviços independentes

Deploy automatizado em Azure Kubernetes Service (AKS)

Pipelines de CI/CD, testes automatizados e governança em cloud

Comunicação assíncrona com mensageria e preocupação com segurança e observabilidade


Mais do que um sistema funcional, este projeto foi concebido como um case técnico de arquitetura cloud nativa, evidenciando capacidade de tomada de decisão arquitetural, visão de escalabilidade, manutenibilidade e alinhamento com práticas corporativas modernas.

Este repositório integra meu portfólio técnico, com foco em sistemas críticos, governança de dados e soluções cloud escaláveis.




![DotNet_Developer](https://github.com/user-attachments/assets/455a5e1c-e39f-4a1f-a116-78afd895ad45)


**Formação .NET Developer**


---

# Sistema de RH em Nuvem com Azure (Arquitetura de Microsserviços)

## Visão Geral
Este projeto apresenta a concepção e implementação de um **Sistema de Recursos Humanos corporativo**, desenvolvido com **arquitetura de microsserviços**, voltado para ambientes empresariais que demandam **escala, segurança, alta disponibilidade e governança**.

A solução foi projetada para rodar integralmente em **Microsoft Azure**, utilizando **Kubernetes (AKS)**, automação de **CI/CD**, mensageria assíncrona e práticas modernas de **engenharia de software e DevOps**.

Mais do que um sistema funcional, este projeto foi criado como um **case técnico de arquitetura cloud nativa**, simulando cenários reais encontrados em grandes organizações.

---

## Problema que o Projeto se Propõe a Resolver
Em ambientes corporativos tradicionais, sistemas de RH costumam apresentar:
- Forte acoplamento entre módulos;
- Dificuldade de escalar partes específicas do sistema;
- Baixa automação de deploy e testes;
- Riscos elevados em mudanças e atualizações.

Este projeto busca resolver esses problemas ao aplicar uma **arquitetura distribuída**, permitindo:
- Evolução independente dos módulos de RH;
- Maior confiabilidade em ambientes críticos;
- Padronização de deploy e governança em nuvem;
- Redução de riscos operacionais.

---

## Objetivo do Projeto
O principal objetivo deste projeto é **demonstrar, na prática**, minha capacidade de:

- Projetar arquiteturas corporativas baseadas em **microsserviços**;
- Aplicar conceitos de **DDD (Domain-Driven Design)**;
- Implementar pipelines de **CI/CD** e deploy automatizado em Kubernetes;
- Trabalhar com mensageria, segurança e segregação de responsabilidades;
- Pensar arquitetura com foco em **negócio, escalabilidade e manutenção**.

Este repositório faz parte do meu **portfólio técnico**, com foco em **cloud computing, engenharia de software e governança de sistemas críticos**.

---

## Arquitetura da Solução (Visão Macro)
A solução é composta pelos seguintes elementos principais:

- Microsserviços independentes por domínio de negócio (Auth, Funcionários, Jornada, Folha, Benefícios, Logs, Notificações);
- API Gateway como ponto único de entrada;
- Comunicação assíncrona via mensageria;
- Shared Kernel para componentes reutilizáveis;
- Infraestrutura provisionada e gerenciada na Azure;
- Deploy automatizado em **Azure Kubernetes Service (AKS)**.

*(Diagramas e detalhes técnicos completos estão descritos nas seções abaixo.)*


---

## Decisões Técnicas

Este projeto foi estruturado com foco em **ambientes corporativos reais**, considerando requisitos comuns de sistemas de RH: escalabilidade, segurança, manutenibilidade, observabilidade e automação de deploy.

A seguir, explico as principais decisões técnicas adotadas e os motivos por trás de cada uma.

### Arquitetura em Microsserviços

Optei por uma arquitetura baseada em microsserviços para permitir:
- Escalabilidade independente por domínio funcional (Funcionários, Folha, Benefícios, Autenticação, etc.)
- Isolamento de responsabilidades
- Evolução incremental do sistema sem impacto global

Cada microsserviço representa um **bounded context**, seguindo princípios de Domain-Driven Design (DDD).

**Trade-off:**  
Essa abordagem aumenta a complexidade operacional em comparação a um monólito, mas reflete melhor cenários corporativos de médio e grande porte.

---

### Domain-Driven Design (DDD)

O DDD foi adotado para:
- Centralizar regras de negócio no domínio
- Evitar lógica espalhada em controllers ou infraestrutura
- Facilitar testes e manutenção

As camadas foram organizadas em:
- Domain
- Application
- Infrastructure
- API

**Trade-off:**  
Maior esforço inicial de modelagem, compensado por maior clareza e longevidade do código.

---

### .NET como plataforma principal

A plataforma .NET foi escolhida devido a:
- Forte suporte a aplicações corporativas
- Excelente integração com o ecossistema Azure
- Performance e maturidade para sistemas críticos
- Suporte robusto a testes automatizados



---

### Comunicação assíncrona com RabbitMQ

Utilizei mensageria para:
- Reduzir acoplamento entre serviços
- Permitir processamento assíncrono de eventos
- Aumentar resiliência do sistema

Eventos são utilizados, por exemplo, para notificações, auditoria e integração entre domínios.

**Trade-off:**  
A introdução de mensageria exige maior controle operacional, mas melhora a robustez do sistema.

---

### API Gateway

Um API Gateway foi adotado para:
- Centralizar o acesso aos microsserviços
- Facilitar controle de rotas, segurança e versionamento
- Simular padrões comuns em arquiteturas cloud corporativas

---

### Containerização com Docker

Todos os serviços foram containerizados para:
- Garantir consistência entre ambientes
- Facilitar deploy em Kubernetes
- Padronizar execução local e em cloud

---

### Kubernetes (AKS) como orquestrador

O Azure Kubernetes Service (AKS) foi escolhido para:
- Orquestração de containers
- Escalabilidade automática
- Alta disponibilidade
- Alinhamento com práticas modernas de Cloud Native

**Trade-off:**  
Kubernetes adiciona complexidade operacional, mas é amplamente utilizado em ambientes corporativos e foi escolhido propositalmente para demonstrar domínio desse cenário.

---

### CI/CD automatizado

Pipelines de CI/CD foram implementados para:
- Build automático das imagens Docker
- Execução de testes
- Deploy contínuo no AKS
- Gerenciamento seguro de segredos

Isso garante:
- Reprodutibilidade
- Redução de erros manuais
- Entregas consistentes

---

### Testes automatizados

O projeto inclui:
- Testes unitários
- Testes de integração
- Testes BDD

O objetivo foi demonstrar preocupação com:
- Qualidade de código
- Manutenibilidade
- Confiabilidade do sistema

---

### Segurança e gestão de segredos

Segredos e configurações sensíveis foram tratados considerando boas práticas de segurança em cloud, evitando hardcoding e simulando integrações seguras típicas de ambientes corporativos.

---

### Observabilidade e logging

Foi adotada uma abordagem de logging centralizado para:
- Facilitar diagnóstico de falhas
- Monitorar comportamento dos serviços
- Apoiar manutenção e evolução do sistema

  


---

• **Diagrama UML do Sistema de RH**

<img width="1080" height="729" alt="UML_Principais_componente" src="https://github.com/user-attachments/assets/af3a432e-0380-4769-81f2-5d78137f10e2" />




--- 


**Visão geral da solução**

- **Objetivo:** plataforma modular de RH, escalável e segura, com serviços independentes integrados via HTTP (API Gateway) e mensageria (RabbitMQ), persistência em bancos separados, observabilidade com logs e notificações, e segurança de segredos via Azure Key Vault.
  
- **Arquitetura:** microsserviços .NET, C#, separação em camadas (Api, Domain, Infrastructure), testes unitários e BDD, automação CI/CD em GitHub Actions, deploy em AKS.

- **Segurança:** .gitignore robusto, GitHub Secret Scanning, GitGuardian monitorando leaks, Key Vault como fonte única de segredos, pipelines que puxam segredos com identidade de serviço.

---

**Estrutura de pastas e arquivos no GitHub**



<img width="895" height="1670" alt="Screenshot_20251205-155134" src="https://github.com/user-attachments/assets/9d91e35d-c9c2-4b67-8de8-2067dbfff218" />
<img width="917" height="1630" alt="Screenshot_20251205-155237" src="https://github.com/user-attachments/assets/fac9a00f-2893-4d2a-aab4-eaa1b0d4ed20" />
<img width="900" height="1544" alt="Screenshot_20251205-155331" src="https://github.com/user-attachments/assets/076cf9c8-7f26-4bb0-adbf-e35404eb64ae" />
<img width="934" height="1548" alt="Screenshot_20251205-155506" src="https://github.com/user-attachments/assets/d393457b-c826-4907-bf84-541a44503bbf" />



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

- **Logs Service**
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

**Build**

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

- **Políticas e práticas:**
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

- **Solução:** SistemaRH.sln
- **Compose:** docker-compose.yml
- **Manifesto Kubernetes:** deployment.yaml
- **Pipelines:** .github/workflows/ci-cd.yml, aks-deploy.yml, aks-secrets-deploy.yml
- **Gateway:** gateway/src/ApiGateway/Program.cs, gateway/src/ApiGateway/appsettings.json
- **Shared Kernel:** shared/src/SharedKernel/SharedKernel.csproj
- **Auth:** services/auth-service/src/Auth.Api/Program.cs, services/auth-service/src/Auth.Infrastructure/Persistence/AuthDbContext.cs
- **Funcionários:** services/funcionarios-service/src/Funcionarios.Api/Program.cs, services/funcionarios-service/src/Funcionarios.Infrastructure/Persistence/FuncionariosDbContext.cs
- **Jornada/Escala:** services/jornadaescala-service/src/JornadaEscala.Api/Program.cs, .../Persistence/JornadaDbContext.cs
- **Folha:** services/folha-service/src/Folha.Domain/Services/CalculadoraFolha.cs
- **Logs:** services/logs-service/src/Logs.Infrastructure/Messaging/FuncionarioEventsConsumer.cs
- **Notificações:** services/notifications-service/src/Notifications.Api/Program.cs

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

