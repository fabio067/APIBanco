**Introdução**

Este repositório contém o código fonte de uma API RESTful que simula uma fila de atendimento em um banco. A API foi desenvolvida utilizando a linguagem C# e o framework ASP.NET Core, com o objetivo de demonstrar a implementação de uma fila de espera com prioridades e funcionalidades básicas de consulta e remoção de clientes.

**Tecnologias Utilizadas**

* **C#:** Linguagem de programação orientada a objetos utilizada para desenvolver a aplicação.
* **ASP.NET Core:** Framework web de código aberto da Microsoft para construir aplicações web modernas e escaláveis.
* **Visual Studio:** Ambiente de desenvolvimento integrado (IDE) utilizado para criar, depurar e testar o código.

**Estrutura do Projeto**

* **Controllers:** Contém a lógica de controle da API, definindo as rotas e as ações HTTP (GET, POST, DELETE).
* **Models:** Define as classes que representam os dados da aplicação, como o cliente e a fila.
* **BibliotecaDeClasses:** Contém a lógica de negócio da aplicação, como as operações de adicionar, remover e consultar clientes na fila.

**Funcionamento da API**

A API expõe as seguintes funcionalidades:

* **Adicionar Cliente:** Permite adicionar um novo cliente à fila, priorizando clientes com mais de 40 anos.
* **Remover Cliente:** Remove o primeiro cliente da fila e o adiciona à lista de clientes atendidos.
* **Consultar Fila:** Retorna a lista de clientes atualmente na fila.
* **Consultar Clientes Atendidos:** Retorna a lista de clientes que já foram atendidos, ordenados alfabeticamente pelo nome.

**Como Utilizar**

Para utilizar esta API, você pode utilizar um cliente HTTP como o Postman ou um navegador web para enviar requisições HTTP para as rotas definidas.

**Contribuições**

Contribuições são bem-vindas! Se você encontrar algum bug ou tiver alguma sugestão de melhoria, por favor, abra um issue ou faça um pull request.

**Próximos Passos**

* **Adicionar notificações:** Implementar um sistema de notificações para avisar os clientes quando estiverem próximos de serem atendidos.
* **Gerenciar filas múltiplas:** Permitir a criação e gerenciamento de múltiplas filas.
* **Implementar relatórios:** Gerar relatórios com estatísticas sobre a fila, como tempo médio de espera e número de clientes atendidos.

**Considerações Finais**

Este projeto serve como um ponto de partida para o desenvolvimento de sistemas mais complexos de gerenciamento de filas. As funcionalidades podem ser expandidas e personalizadas de acordo com as necessidades específicas de cada aplicação.

**Licença**

Este projeto está licenciado sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.

**Autores**

* **Fábio Roberto:** Desenvolvedor principal
