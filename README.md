Prova de Conceito: CQRS com Event Sourcing
Este repositório contém uma Prova de Conceito (PoC) que demonstra como estruturar, de forma simplificada, um projeto utilizando as arquiteturas CQRS (Command Query Responsibility Segregation) e Event Sourcing, integrando tecnologias modernas para suportar uma aplicação baseada em eventos.

📋 Objetivo
Apresentar um exemplo prático e acessível para desenvolvedores interessados em explorar as vantagens do CQRS e Event Sourcing, como:

Separação clara entre comandos e consultas.
Escalabilidade e alta performance.
Controle completo do histórico de mudanças por meio de eventos.
🛠️ Tecnologias Utilizadas
C#
CQRS
Event Sourcing
Redis (configurado como base de leitura)
Mediator
Arquitetura Event-Driven
📂 Estrutura do Projeto
/Commands: Implementações dos comandos (Write model).
/Queries: Implementações das consultas (Read model).
/Events: Modelos de eventos e seus manipuladores.
/Infrastructure: Configuração e integração com tecnologias, incluindo Redis.
/ReadModel: Estrutura da base de leitura, otimizada com Redis.
🚀 Como Executar
Clone o repositório

bash
Copiar código
git clone https://github.com/seu-usuario/nome-do-repositorio.git  
cd nome-do-repositorio  
Configure os serviços necessários:

Certifique-se de ter o Redis instalado e rodando.
Atualize as configurações no appsettings.json (se necessário).
Execute o projeto:
No terminal ou na IDE, rode o projeto com o comando:

bash
Copiar código
dotnet run  
Testar:
Utilize ferramentas como Postman ou Swagger (caso habilitado) para enviar comandos e realizar consultas.

🌟 Recursos Demonstrados
Como implementar a separação entre Write e Read models.
Persistência de eventos no modelo de escrita.
Uso do Redis como base de leitura para consultas rápidas e escaláveis.
Comunicação eficiente com o padrão Mediator.
📌 Próximos Passos
Adicionar exemplos de integração com filas (ex.: RabbitMQ).
Implementar mais casos de uso no modelo de evento.
Melhorar a documentação com fluxogramas de arquitetura.
📫 Contribuições
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests.

📄 Licença
Este projeto está licenciado sob a licença MIT. Consulte o arquivo LICENSE para mais detalhes.
