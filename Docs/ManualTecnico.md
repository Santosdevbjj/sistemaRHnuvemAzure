**Manual Técnico do Sistema de Recursos Humanos**

•  **Visão Geral**
Este manual técnico descreve em detalhes a arquitetura, tecnologias utilizadas e instruções de execução do Sistema de Recursos Humanos (RH) desenvolvido em .NET 10 / C# 14 com arquitetura de microsserviços.  
O sistema foi projetado para rodar em Azure App Service for Containers, Azure Container Apps ou AKS (Kubernetes), utilizando Azure SQL Database e Azure Table Storage.

---

• **Arquitetura**

- **API Gateway (YARP)**  
  - Ponto único de entrada.  
  - Valida JWT e roteia requisições para os serviços.  

- **Serviços independentes (Minimal API RESTful)**  
  - Auth Service → Usuários, perfis, JWT e refresh tokens.  
  - Funcionarios Service → CRUD de funcionários, endereços, cargos, departamentos.  
  - JornadaEscala Service → Jornadas, escalas, registro de ponto.  
  - Folha Service → Cálculo de folha (salário, adicional noturno, horas extras, INSS, IRRF).  
  - Beneficios Service → Gestão de benefícios e vínculos.  
  - Logs Service → Persistência em Azure Table Storage.  
  - Notifications Service → Consome eventos e envia notificações (email/push).  

- **Mensageria (RabbitMQ)**  
  - Comunicação assíncrona entre serviços.  
  - Eventos: FuncionarioAtualizado, FolhaGerada, NotificacaoCriada.  

---

📂 **Estrutura de Pastas**

<img width="870" height="1593" alt="Screenshot_20251205-054855" src="https://github.com/user-attachments/assets/58c08f83-926a-4ddb-8454-e7992b00c84c" />


---



**Tecnologias Utilizadas**

- ASP.NET Core 10 (Minimal API)  
- C# 14  
- Entity Framework Core 10  
- Azure SQL Database  
- Azure Table Storage  
- RabbitMQ  
- Docker / Docker Compose  
- JWT Authentication  
- xUnit + FluentAssertions (TDD)  
- SpecFlow (BDD)  
- Moq (Mocks)  

---

• **Testes**

- TDD: Testes unitários com xUnit e FluentAssertions.  
- BDD: Testes de comportamento com SpecFlow (Gherkin).  
- Moq: Mock de repositórios e mensageria.  

---

• **Execução Local**

1. Clonar o repositório:
   `bash
   git clone https://github.com/Santosdevbjj/sistemaRHnuvemAzure.git
   cd sistemaRHnuvemAzure
   `

2. Subir os containers:
   `bash
   docker-compose up --build
   `

3. Acessar o API Gateway:
   `
   http://localhost:5000
   `

---

• **Implantação no Azure**

- Azure App Service for Containers → Deploy direto dos Dockerfiles.  
- Azure Container Apps → Escalabilidade automática.  
- AKS (Kubernetes) → Orquestração avançada.  
- Azure SQL Database → Persistência relacional por serviço.  
- Azure Table Storage → Logs imutáveis.  

---

•  **Segurança**

- Autenticação via JWT emitido pelo Auth Service.  
- Validação no API Gateway e em cada serviço.  
- Perfis de acesso: Admin, RH, Gestor, Colaborador.  

---

• **Requisitos de Hardware e Software**

- **Hardware mínimo:**  
  - CPU: 2 cores  
  - RAM: 4 GB  
  - Disco: 20 GB  

- **Software:**  
  - Docker Desktop  
  - .NET 10 SDK  
  - Azure CLI  
  - RabbitMQ (container via docker-compose)  

---

• **Conclusão:**

Este manual técnico garante que desenvolvedores e administradores possam compreender, executar e manter o sistema de RH em ambientes locais e na nuvem Azure.
`


---




