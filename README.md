# Prova de Conceito: CQRS com Event Sourcing  

Este repositório apresenta uma Prova de Conceito (PoC) que demonstra como estruturar um projeto utilizando as arquiteturas **CQRS (Command Query Responsibility Segregation)** e **Event Sourcing**, integrando tecnologias modernas para suportar uma aplicação baseada em eventos.  

---

## 📋 Objetivo  

Explorar as vantagens do CQRS e Event Sourcing, como:  

- Separação clara entre **comandos** e **consultas**.  
- Escalabilidade e alta performance.  
- Controle completo do histórico de mudanças por meio de eventos.  

---

## 🛠️ Tecnologias Utilizadas  

- **C#**  
- **CQRS**  
- **Event Sourcing**
- **Entity Framework Core - Sql Server**  
- **Redis**
- **Fluent Validation**
- **Mediator**  
- **Event-Driven**  

---

## 📂 Estrutura do Projeto  

- API -> Camada responsável por expor os endpoints da aplicação, permitindo a comunicação com clientes externos.
- Application -> Contém a lógica de aplicação, incluindo validações, orquestração de comandos e consultas (CQRS).
- Service -> Responsável por implementar as regras de negócio e realizar a interação com os repositórios e outras integrações.
- Bus -> Implementação do barramento de mensagens para comunicação assíncrona entre eventos e comandos.
- Data -> Gerencia a persistência de dados, incluindo repositórios e o mapeamento das entidades no banco de dados.
- Cache -> Configuração e manipulação de cache para otimizar consultas e reduzir a carga no banco de dados principal (ex.: Redis).
- Domain -> Representa o núcleo da aplicação, contendo as entidades, eventos, interfaces e regras de domínio.
- Domain.Core -> Fornece abstrações e funcionalidades compartilhadas, como classes base, interfaces genéricas e contratos.

---

## 🚀 Como Executar  

### 1. Clone o Repositório  

```bash
git clone https://github.com/seu-usuario/nome-do-repositorio.git  
cd nome-do-repositorio
```

### 2. Configure os Serviços Necessários

- Certifique-se de ter o Redis instalado e rodando.
- Atualize as configurações no arquivo **appsettings.json**, se necessário.

### 3. Execute o Projeto

No terminal ou na sua IDE de preferência, rode o projeto com o comando:

```bash
dotnet run  
```

### 4. Testar

- Utilize ferramentas como Postman ou Swagger (se habilitado) para enviar comandos e realizar consultas.

---

### 🌟 Recursos Demonstrados

- Implementação da separação entre Write e Read models.
- Persistência de eventos no modelo de escrita.
- Uso do Redis como base de leitura para consultas rápidas e escaláveis.
- Comunicação eficiente utilizando o padrão Mediator.

---

### 📌 Próximos Passos

- Adicionar exemplos de integração com filas (ex.: RabbitMQ).
- Implementar mais casos de uso no modelo de evento.
- Melhorar a documentação com fluxogramas de arquitetura.

---

### 📫 Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests.

---

### 📄 Licença

Este projeto está licenciado sob a licença MIT. Consulte o arquivo LICENSE para mais detalhes.
