> **Aba de planejamento do projeto** <br>
> Este documento será voltado para documentar o planejamento para a realização do projeto **TaskMate**. <br>
> Basicamente servindo como um guia de desenvolvimento para o projeto, também documentando o processo de desenvolvimento do mesmo

# 1.	Criação dos Projeto no Visual Studio

1. **Criação do projeto de *Aplicativo de Console* `TaskMate` no Visual Studio**
1. **Adicionar o projeto `TaskMate.Core` ao projeto `TaskMate`** 
1. **Adicionar o projeto `TaskMate.Infrastructure` ao projeto `TaskMate`** 
1. **Adicionar o projeto `TaskMate.Console` ao projeto `TaskMate`** 

# 2.	Estruturação do projeto `TaskMate.Core`

> Trata-se do projeto que irá definir a essência de uma tarefa, como seus atributos, principais características e métodos. Basicamente, será o local onde armazenaremos a essência dos principais objetos do projeto, ou seja, as tarefas

**Esse projeto conterá** :
- Uma classe abstrata chamada `BaseTask`, contendo os principais atributos base de uma classe, juntamente com seus métodos, incluindo método `GetDetails()`
- As classes `DeadLineTask` e `RecurringTask`, que são classes especializadas da classe `BaseTask`  
- Criar a interface `IRepositiry<T>`, que implementa os principais métodos de uma interface, como `Add` e `GetById`

# 2.	Estruturação do projeto `TaskMate.Infrastructure`

> Trata-se do projeto onde serão armazenadas as implementações do projeto, como interfaces, eventos que devem ocorrer. Basciamente será o projeto que armazena boa parte dos principais métodos do projeto, como salvar os dados e emitir eventos

**Esse projeto conterá** :
- 