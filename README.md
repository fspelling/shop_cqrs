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
- **Redis** (configurado como base de leitura)  
- **Mediator**  
- **Arquitetura Event-Driven**  

---

## 📂 Estrutura do Projeto  

- Commands -> Implementações dos comandos (Write model).
- Queries -> Implementações das consultas (Read model).
- Events -> Modelos de eventos e seus manipuladores.
- Infrastructure -> Configuração e integração com tecnologias, incluindo Redis.
- ReadModel -> Base de leitura otimizada com Redis.

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
