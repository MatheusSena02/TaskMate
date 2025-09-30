> **Olá! Seja bem-vindo(a) ao projeto TaskMate!**
>
> Vamos construir juntos um gerenciador de tarefas, mas com um objetivo principal: transformar os conceitos teóricos da **Programação Orientada a Objetos (POO)** em código que você pode ver e executar. Cada fase deste projeto foi desenhada para introduzir um pilar da POO de forma clara e prática.
>
> Esqueça a complexidade por enquanto. Nosso foco é construir uma base sólida, entendendo *por que* escrevemos o código de uma certa maneira. Este documento é seu guia, e vamos evoluir passo a passo.

---

## 1. Visão Geral: O Que Vamos Construir?

O **TaskMate** será uma aplicação de console que permitirá:

* Criar diferentes tipos de tarefas: tarefas simples, tarefas com prazo e tarefas recorrentes.
* Adicionar subtarefas a uma tarefa principal.
* Marcar tarefas como concluídas.
* Listar e visualizar os detalhes das tarefas.
* Receber uma notificação no console quando uma tarefa for concluída.

---

## 2. A Arquitetura Focada em Aprendizado

Manteremos uma arquitetura simples e organizada para que você possa focar nos conceitos.

| Projeto                 | Analogia                                   | Descrição Didática                                                                                                                                                                                                            |
| :---------------------- | :----------------------------------------- | :---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **`TaskMate.Core`** | 🧠 **O Cérebro (Modelos e Regras)** | Aqui definimos a "essência" das nossas coisas. O que é uma `Tarefa`? Quais são suas regras? É aqui que os conceitos de POO como Encapsulamento, Herança e Polimorfismo ganham vida. Também definimos os "contratos" (`interfaces`) do nosso sistema. |
| **`TaskMate.Infrastructure`** | 🛠️ **A Caixa de Ferramentas (Implementações)** | Aqui damos vida aos contratos definidos no Core. Por exemplo, como vamos *realmente* salvar os dados (em memória, por enquanto) ou como vamos *realmente* enviar uma notificação (escrevendo no console).                             |
| **`TaskMate.Console`** | 🖥️ **A Interface com o Usuário (O "Rosto")** | É a camada que conversa com o usuário. Ela não tem lógica de negócio; seu único trabalho é coletar informações do usuário, passar para o "cérebro" (Core) processar e depois exibir o resultado.                            |

---

## 3. Nossa Jornada de Implementação (Foco em POO)

### Fase 1: Encapsulamento - A Anatomia de um Objeto

Nesta fase, o foco é total em criar um objeto coeso e que protege seus próprios dados.

#### O que vamos fazer?

1.  **Criar a classe `TaskItem` no projeto `TaskMate.Core`.**
    * **Recurso:** `class`
    * **Descrição:** A palavra-chave `class` é o modelo fundamental para criar objetos em C#. Ela agrupa dados (campos) e comportamentos (métodos) em uma única unidade.
    * **Documentação:** [Classes (Guia de Programação C#) - Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/classes)

2.  **Usar campos privados (`_title`) e propriedades públicas (`Title`).**
    * **Recursos:** Campos (Fields) e Propriedades (Properties)
    * **Descrição:** Um **campo** (`_title`) é uma variável declarada diretamente na classe, geralmente privada para proteger o dado. Uma **propriedade** (`Title`) fornece uma maneira controlada de acessar esse campo, usando os acessadores `get` e `set`. Usar `{ get; private set; }` significa que o valor só pode ser lido de fora da classe, mas só pode ser alterado por código *dentro* da própria classe.
    * **Documentação:**
        * [Campos (Guia de Programação C#) - Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/fields)
        * [Propriedades (Guia de Programação C#) - Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/csharp/properties)

3.  **Implementar um construtor.**
    * **Recurso:** Construtores (Constructors)
    * **Descrição:** Um construtor é um método especial chamado no momento em que um objeto é criado (`new TaskItem(...)`). Sua principal função é inicializar o estado do objeto e garantir que ele seja criado em um estado válido (por exemplo, exigindo um título).
    * **Documentação:** [Construtores (Guia de Programação C#) - Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/constructors)

4.  **Criar métodos públicos como `MarkAsComplete()` e `UpdateDescription()`.**
    * **Recurso:** Métodos (Methods)
    * **Descrição:** Métodos são blocos de código que contêm uma série de instruções. Eles definem os comportamentos e as ações que um objeto pode executar.
    * **Documentação:** [Métodos (Guia de Programação C#) - Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/methods)

#### Por que é importante?
Você aprenderá o pilar do **Encapsulamento**. Um objeto não deve ser um "saco de dados" que qualquer um pode alterar. Ele deve ser uma entidade inteligente que gerencia seu próprio estado e garante sua consistência.

### Fase 2: Abstração e Composição - Construindo com Contratos e Blocos

Agora que temos um objeto, vamos definir como ele será armazenado e como ele pode ser "composto" por outros objetos.

#### O que vamos fazer?

1.  **Adicionar uma lista privada `List<string> _subtasks` em `TaskItem`.**
    * **Recurso:** `System.Collections.Generic.List<T>` (Composição)
    * **Descrição:** Isso demonstra **Composição**, o princípio de que um objeto pode ser "composto por" outros. Em vez de uma `TaskItem` *ser* uma lista, ela *tem uma* lista de subtarefas. `List<T>` é uma classe genérica poderosa para gerenciar coleções de objetos.
    * **Documentação:** [Classe List<T> - Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/api/system.collections.generic.list-1)

2.  **No `TaskMate.Core`, criar a interface `IRepository<T>`.**
    * **Recursos:** `interface`, Genéricos (`<T>`)
    * **Descrição:** Uma **interface** é um contrato. Ela define um conjunto de métodos e propriedades que uma classe *deve* implementar, mas não diz *como*. Isso é **Abstração**. O uso de **Genéricos** (`<T>`) torna a interface reutilizável para qualquer tipo de dado (`IRepository<TaskItem>`, `IRepository<User>`, etc.).
    * **Documentação:**
        * [Interfaces (Guia de Programação C#) - Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/csharp/language-reference/keywords/interface)
        * [Introdução aos Genéricos - Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/generics/introduction-to-generics)

3.  **No `TaskMate.Infrastructure`, criar `InMemoryRepository<T>` que implementa `IRepository<T>`.**
    * **Recurso:** Implementação de Interface
    * **Descrição:** Aqui criamos uma classe *concreta* que "assina o contrato" da interface. A classe `InMemoryRepository` promete fornecer uma implementação real para os métodos `Add`, `GetById`, etc., definidos em `IRepository`.
    * **Documentação:** Veja o exemplo de implementação na documentação de Interfaces linkada acima.

#### Por que é importante?
Você verá que a **Composição** nos permite construir objetos complexos a partir de objetos mais simples. E a **Abstração** nos permite escrever código flexível, que depende de "contratos" e não de "implementações concretas".

### Fase 3: Herança e Polimorfismo - Criando Variações de Tarefas
Esta é a fase onde a POO realmente brilha.

#### O que vamos fazer?

1.  **Renomear `TaskItem` para `BaseTask` e torná-la `abstract`.**
    * **Recurso:** `abstract`
    * **Descrição:** Uma classe **abstrata** serve como um modelo base que não pode ser instanciado diretamente. Ela foi feita para ser herdada por outras classes mais específicas.
    * **Documentação:** [Classes Abstratas e Seladas e Membros de Classe (Guia de C#) - Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members)

2.  **Criar um método `virtual GetDetails()` na `BaseTask`.**
    * **Recurso:** `virtual`
    * **Descrição:** A palavra-chave `virtual` em um método de uma classe base permite que classes derivadas (filhas) forneçam sua própria implementação para esse método usando `override`.
    * **Documentação:** [virtual (Referência de C#) - Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/csharp/language-reference/keywords/virtual)

3.  **Criar `DeadlineTask` e `RecurringTask` que herdam de `BaseTask`.**
    * **Recurso:** Herança
    * **Descrição:** **Herança** é um pilar da POO que permite que uma classe (filha) adquira os campos e métodos de outra classe (pai). Isso promove a reutilização de código e cria uma hierarquia do tipo "é-um" (uma `DeadlineTask` *é um tipo de* `BaseTask`). A sintaxe em C# é `: BaseTask`.
    * **Documentação:** [Herança (Guia de C#) - Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/csharp/fundamentals/object-oriented/inheritance)

4.  **Sobrescrever (`override`) o método `GetDetails()` em cada classe filha.**
    * **Recurso:** `override`
    * **Descrição:** A palavra-chave `override` é usada para estender ou modificar a implementação de um método `virtual` (ou `abstract`) herdado. É aqui que o **Polimorfismo** acontece: o mesmo chamado de método (`GetDetails()`) se comporta de maneiras diferentes dependendo do tipo real do objeto.
    * **Documentação:**
        * [override (Referência de C#) - Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/csharp/language-reference/keywords/override)
        * [Polimorfismo (Guia de C#) - Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/csharp/fundamentals/object-oriented/polymorphism)

#### Por que é importante?
A **Herança** permite reutilizar código. O **Polimorfismo** (que significa "muitas formas") é a mágica que nos permitirá tratar diferentes tipos de tarefa de forma uniforme, e o C# saberá qual é a versão correta do método a ser executada em tempo de execução.

### Fase 4: Orquestração - O Serviço e as Notificações
Agora vamos criar um "maestro" para gerenciar nossas tarefas.

#### O que vamos fazer?

1.  **No `TaskMate.Core`, criar `TaskService` que recebe `IRepository` no construtor.**
    * **Recurso:** Injeção de Dependência (Princípio)
    * **Descrição:** Em vez de o `TaskService` criar sua própria instância de `InMemoryRepository`, ele *recebe* uma dependência do tipo `IRepository`. Isso torna o serviço mais flexível e testável, pois ele não depende de uma implementação concreta, mas sim de um contrato (a interface).
    * **Documentação:** [Injeção de dependência no .NET - Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/core/extensions/dependency-injection) (Este é um tópico avançado, mas o conceito manual é aplicado aqui).

2.  **Criar o evento `TaskCompleted` usando `delegate` e `event`.**
    * **Recursos:** `delegate`, `event`
    * **Descrição:** Um **delegate** é um tipo que representa referências a métodos com uma assinatura específica (como um "ponteiro de função seguro"). A palavra-chave **event** é um mecanismo que usa delegates para permitir que uma classe envie notificações (eventos) para outras classes que se inscreveram para ouvi-los. É a implementação do padrão de projeto *Observer*.
    * **Documentação:**
        * [Delegados (Guia de Programação C#) - Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/delegates/)
        * [Eventos (Guia de Programação C#) - Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/events/)

3.  **Criar a interface `INotificationChannel`.**
    * **Recurso:** `interface` (Abstração novamente)
    * **Descrição:** Novamente, usamos uma interface para definir um contrato para um "canal de notificação", sem nos prendermos a como essa notificação será enviada (console, email, SMS, etc.).

4.  **No `TaskMate.Infrastructure`, criar `ConsoleNotificationChannel`.**
    * **Recurso:** Implementação de Interface
    * **Descrição:** Uma implementação concreta que satisfaz o contrato `INotificationChannel`, simplesmente escrevendo a mensagem no console.
    
5.  **O `TaskService` usará a interface de notificação e disparará o evento.**

### Fase 5: Dando Vida - A Aplicação de Console
A etapa final, onde conectamos tudo.

#### O que vamos fazer?

1.  **No projeto `TaskMate.Console`, criar um menu simples para o usuário.**
    * **Recurso:** Classe `System.Console`
    * **Descrição:** Esta classe é a porta de entrada para interagir com o console (a janela de texto). Usaremos métodos como `Console.WriteLine()` para exibir texto e `Console.ReadLine()` para capturar a entrada do usuário.
    * **Documentação:** [Classe Console - Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/api/system.console)

2.  **Permitir que o usuário escolha que tipo de tarefa quer criar.**
3.  **Usar o `TaskService` para realizar todas as operações.**
4.  **Ao listar as tarefas, chamar o método `GetDetails()` de cada uma para ver o polimorfismo em ação.**
5.  **Configurar o "ouvinte" do evento para que a notificação apareça na tela.**

#### Por que é importante?
É o momento de ver todos os conceitos de POO que aplicamos funcionando juntos para resolver um problema real.

---

> ### Dica de Mentor
>
> O objetivo aqui é a clareza. Se em algum momento um conceito não parecer claro, pare e revise. A beleza da POO está em como esses pilares se conectam para criar um código mais organizado, reutilizável e fácil de manter.
>


## 4. Telas e Cenários

**Tela Principal (Menu)**

Ao iniciar a aplicação, o usuário recebe uma saudação e um menu de opções claras e numeradas. Este será o ponto central da navegação.

```bash
Tela Principal (Menu Final)
========================================
    🚀 BEM-VINDO(A) AO TASKMATE 🚀
========================================

O que você gostaria de fazer?

  [1] Listar Todas as Tarefas
  [2] Ver Detalhes de uma Tarefa
  [3] Criar Nova Tarefa
  [4] Editar uma Tarefa
  [5] Excluir uma Tarefa
  [6] Gerenciar Subtarefas
  [7] Ver Histórico de Notificações
  
  [0] Sair

Digite a sua opção: _
```

**Cenário 1: Criando uma Nova Tarefa (com Prazo)**

Aqui, o usuário escolhe a opção 1. O sistema então precisa saber qual tipo de tarefa criar, levando a um segundo menu.

```bash
>> Opção selecionada: [1] Criar Nova Tarefa

Qual tipo de tarefa você deseja criar?
  [1] Tarefa Simples
  [2] Tarefa com Prazo
  [3] Tarefa Recorrente

Digite a sua opção: 2

>> Criando uma nova Tarefa com Prazo...

Digite o título da tarefa: Comprar ingressos para o cinema
Digite a descrição (opcional): Comprar para o filme novo do Christopher Nolan.
Digite a data de vencimento (dd/mm/aaaa): 29/09/2025

✅ Tarefa com prazo "Comprar ingressos para o cinema" criada com sucesso!

Pressione ENTER para voltar ao menu...
```

Conceitos em ação:

Herança: O sistema sabe que precisa pedir um DueDate (prazo) porque está instanciando um objeto da classe DeadlineTask, que herda de BaseTask mas adiciona essa propriedade específica.

**Cenário 2: Listando as Tarefas (Polimorfismo em Ação!)**

Esta é a tela mais importante para visualizar a "mágica" da POO. O usuário escolhe a opção 2 e o sistema exibe todas as tarefas, independentemente do seu tipo.

```bash
>> Opção selecionada: [2] Listar Todas as Tarefas

========================================
          SUA LISTA DE TAREFAS
========================================

[ID: 1] [✅] Limpar o quarto
    - (Recorrência: Semanal)

[ID: 2] [⬜] Entregar relatório do projeto
    - Descrição: Finalizar a seção de resultados e enviar para a equipe.
    - (Prazo: 26/09/2025)
    - Subtarefas:
      - [✅] Coletar dados da API
      - [⬜] Gerar gráficos

[ID: 3] [⬜] Comprar ingressos para o cinema
    - Descrição: Comprar para o filme novo do Christopher Nolan.
    - (Prazo: 29/09/2025)

========================================

Pressione ENTER para voltar ao menu...
```

Conceitos em ação:

Polimorfismo: O código que renderiza esta lista simplesmente faz um loop em uma List<BaseTask> e chama o método GetDetails() para cada item. Ele não precisa saber se o item é uma DeadlineTask ou RecurringTask. O C# em tempo de execução invoca a versão correta (override) do método, exibindo o prazo para uma e a recorrência para outra.

Composição: A Tarefa de ID 2 mostra como uma tarefa tem-uma lista de subtarefas, exibindo-as de forma aninhada.

Encapsulamento: O estado de cada tarefa (título, se está completa [✅]/[⬜]) é controlado internamente pelo objeto. A interface apenas pede para o objeto se "descrever".

**Cenário 3: Marcando uma Tarefa como Concluída (Eventos em Ação!)**
O usuário escolhe a opção 3 e informa o ID da tarefa que finalizou.

```bash
>> Opção selecionada: [3] Marcar Tarefa como Concluída

Digite o ID da tarefa que deseja marcar como concluída: 3

✅ Tarefa "Comprar ingressos para o cinema" marcada como concluída!

[NOTIFICAÇÃO]: A tarefa 'Comprar ingressos para o cinema' foi concluída! 🎉

Pressione ENTER para voltar ao menu...
```

Conceitos em ação:

Abstração e Eventos: Quando o TaskService marca a tarefa como concluída, ele dispara o evento TaskCompleted. A interface de console não sabe nada sobre o sistema de notificação. Ela apenas "ouve" o evento. O ConsoleNotificationChannel, que é uma implementação da abstração INotificationChannel, é quem recebe a notificação e imprime a mensagem [NOTIFICAÇÃO]: ... na tela. Isso demonstra um sistema desacoplado.


**Cenário 4: Adicionando uma Subtarefa**

O usuário escolhe a opção 4 para detalhar uma tarefa existente.

```bash
>> Opção selecionada: [4] Adicionar Subtarefa a uma Tarefa

Digite o ID da tarefa principal: 3

Digite a descrição da nova subtarefa: Comprar pipoca e refrigerante

✅ Subtarefa "Comprar pipoca e refrigerante" adicionada à tarefa "Comprar ingressos para o cinema"!

Pressione ENTER para voltar ao menu...
```

Conceitos em ação:

Encapsulamento e Composição: A lógica de adicionar uma subtarefa é gerenciada pelo objeto TaskItem através de um método público (ex: AddSubtask). A interface do console não manipula a lista de subtarefas diretamente; ela pede para o objeto principal fazer isso, respeitando o encapsulamento.


**Cenário 5: Ver Detalhes de uma Tarefa Específica**

Esta tela permite que o usuário foque em uma única tarefa, vendo todas as suas informações de forma clara.

>> Opção selecionada: [2] Ver Detalhes de uma Tarefa

```bash
Digite o ID da tarefa para ver os detalhes: 2

-------------------------------------------------
            DETALHES DA TAREFA #2
-------------------------------------------------
  Título:         Entregar relatório do projeto
  Status:         Pendente [⬜]
  Tipo:           Tarefa com Prazo
  Prazo Final:    26/09/2025
  
  Descrição:
    Finalizar a seção de resultados e enviar para a equipe.

  Subtarefas:
    1. [✅] Coletar dados da API
    2. [⬜] Gerar gráficos
-------------------------------------------------

Pressione ENTER para voltar ao menu...
```

Conceitos em ação:

Encapsulamento: A tela está acessando as propriedades públicas (Title, Description, DueDate, IsComplete) do objeto Task para exibir seu estado completo. A lógica de como esses dados são armazenados está protegida dentro do objeto.

**Cenário 6: Editando a Descrição de uma Tarefa**

Esta funcionalidade corresponde diretamente ao método UpdateDescription() que planejamos na Fase 1.

```bash
>> Opção selecionada: [4] Editar uma Tarefa

Digite o ID da tarefa que deseja editar: 2

Título da Tarefa: Entregar relatório do projeto
Descrição Atual: Finalizar a seção de resultados e enviar para a equipe.

Digite a nova descrição (deixe em branco para não alterar):
Finalizar a seção de resultados, gerar os gráficos e enviar para a equipe por e-mail.

✅ Descrição da tarefa #2 atualizada com sucesso!

Pressione ENTER para voltar ao menu...
```

Conceitos em ação:

Métodos Públicos como Comportamento: A interface não altera a variável de descrição diretamente. Ela invoca o método UpdateDescription() do objeto, que é a maneira "oficial" e segura de alterar seu estado interno. Isso é encapsulamento em sua forma mais pura.

**Cenário 7: Excluindo uma Tarefa:**

Uma funcionalidade essencial em qualquer sistema de gerenciamento. Inclui um passo de confirmação para evitar exclusões acidentais.

```bash
>> Opção selecionada: [5] Excluir uma Tarefa

Digite o ID da tarefa que deseja excluir: 1

Você tem certeza que deseja excluir a tarefa "Limpar o quarto"? (S/N): S

✅ Tarefa #1 "Limpar o quarto" foi excluída com sucesso.

Pressione ENTER para voltar ao menu...
```

Conceitos em ação:

Abstração (Repositório): A interface simplesmente chama um método como taskService.DeleteTask(1). O serviço, por sua vez, usa a abstração IRepository para executar a exclusão. A interface não sabe se a tarefa está sendo removida de uma lista em memória, de um banco de dados ou de um arquivo de texto.

**Cenário 8: Gerenciamento de Subtarefas (Menu Dedicado)**

Esta tela aprofunda o conceito de Composição, mostrando um objeto (Tarefa) gerenciando sua coleção interna de outros itens (Subtarefas).

```bash
>> Opção selecionada: [6] Gerenciar Subtarefas

Digite o ID da tarefa principal: 2

Gerenciando subtarefas de: "Entregar relatório do projeto"
  1. [✅] Coletar dados da API
  2. [⬜] Gerar gráficos

O que você deseja fazer?
  [1] Adicionar nova subtarefa
  [2] Marcar subtarefa como concluída/pendente
  [3] Remover subtarefa
  [0] Voltar ao menu principal

Digite a sua opção: 2

Digite o número da subtarefa que deseja alterar: 2

✅ Subtarefa "Gerar gráficos" marcada como concluída!

Pressione ENTER para continuar...
```

// A tela é atualizada //

```bash
Gerenciando subtarefas de: "Entregar relatório do projeto"
  1. [✅] Coletar dados da API
  2. [✅] Gerar gráficos
...
```

Conceitos em ação:

Composição e Encapsulamento: A classe Task principal expõe métodos para manipular sua lista interna de subtarefas (AddSubtask, ToggleSubtaskStatus, RemoveSubtask). A interface do console utiliza esses métodos, tratando a tarefa como um "gerente" de suas próprias partes, sem acessar a lista _subtasks diretamente.

**Cenário 9: Tratamento de Erro (ID Inválido)**

Uma boa interface deve lidar com entradas inesperadas do usuário de forma graciosa.

```bash
>> Opção selecionada: [2] Ver Detalhes de uma Tarefa

Digite o ID da tarefa para ver os detalhes: 99

❌ Erro: Tarefa com ID '99' não foi encontrada.
Por favor, verifique o ID e tente novamente.

Pressione ENTER para voltar ao menu...
```

Importância Didática:

Isso ensina sobre a importância da validação e do feedback ao usuário, que são partes essenciais da construção de software robusto. O serviço ou repositório seria responsável por informar à camada de UI que o objeto solicitado não existe.

**COMPLEXIDADE ADICIONAL

**Cenário 10: Visualizando o Histórico de Notificações**

O usuário escolhe a opção 7. O sistema consulta o INotificationRepository e exibe todos os logs salvos, do mais recente para o mais antigo.

```bash
>> Opção selecionada: [7] Ver Histórico de Notificações

=========================================================
            HISTÓRICO DE NOTIFICAÇÕES 📋
=========================================================

[26/09/2025 01:03:15] A tarefa 'Entregar relatório do projeto' foi concluída! 🎉
---------------------------------------------------------
[25/09/2025 23:51:30] A tarefa 'Comprar ingressos para o cinema' foi concluída! 🎉
---------------------------------------------------------
[25/09/2025 22:15:05] A tarefa 'Limpar o quarto' foi concluída! 🎉
---------------------------------------------------------

Pressione ENTER para voltar ao menu...
```

**Cenário 11: Histórico de Notificações Vazio:**

É importante tratar o caso em que nenhuma tarefa foi concluída ainda, para que o usuário não veja uma tela em branco.

```bash
>> Opção selecionada: [7] Ver Histórico de Notificações

=========================================================
            HISTÓRICO DE NOTIFICAÇÕES 📋
=========================================================

           Nenhuma notificação registrada ainda.
          Conclua uma tarefa para ver o histórico!

=========================================================

Pressione ENTER para voltar ao menu...
```

A adição deste recurso enriquece significativamente o projeto, não apenas em funcionalidade, mas principalmente em valor didático, mostrando uma aplicação mais avançada e realista do sistema de eventos e da separação de responsabilidades.

## 4. Próximos Passos (Após a Base Sólida)

Quando você estiver confortável com esses pilares, podemos evoluir o projeto:

* **Testes Unitários:** Usando frameworks como **xUnit**, **NUnit** ou **MSTest**.
* **Programação Assíncrona (`async`/`await`):** Essencial para aplicações que não devem travar enquanto esperam por operações lentas.
* **Injeção de Dependência (DI):** Usar um contêiner de DI do próprio .NET (`Microsoft.Extensions.DependencyInjection`).
* **Persistência Real:** Usar o **Entity Framework Core**, um ORM (Mapeador Objeto-Relacional) para interagir com bancos de dados.
