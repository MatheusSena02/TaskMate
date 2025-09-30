> **Aba de planejamento do projeto** <br>
> Este documento ser� voltado para documentar o planejamento para a realiza��o do projeto **TaskMate**. <br>
> Basicamente servindo como um guia de desenvolvimento para o projeto, tamb�m documentando o processo de desenvolvimento do mesmo

# 1.	Cria��o dos Projeto no Visual Studio

1. **Cria��o do projeto de *Aplicativo de Console* `TaskMate` no Visual Studio**
1. **Adicionar o projeto `TaskMate.Core` ao projeto `TaskMate`** 
1. **Adicionar o projeto `TaskMate.Infrastructure` ao projeto `TaskMate`** 
1. **Adicionar o projeto `TaskMate.Console` ao projeto `TaskMate`** 

# 2.	Estrutura��o do projeto `TaskMate.Core`

> Trata-se do projeto que ir� definir a ess�ncia de uma tarefa, como seus atributos, principais caracter�sticas e m�todos. Basicamente, ser� o local onde armazenaremos a ess�ncia dos principais objetos do projeto, ou seja, as tarefas

**Esse projeto conter�** :
- Uma classe abstrata chamada `BaseTask`, contendo os principais atributos base de uma classe, juntamente com seus m�todos, incluindo m�todo `GetDetails()`
- As classes `DeadLineTask` e `RecurringTask`, que s�o classes especializadas da classe `BaseTask`  
- Criar a interface `IRepositiry<T>`, que implementa os principais m�todos de uma interface, como `Add` e `GetById`

# 2.	Estrutura��o do projeto `TaskMate.Infrastructure`

> Trata-se do projeto onde ser�o armazenadas as implementa��es do projeto, como interfaces, eventos que devem ocorrer. Basciamente ser� o projeto que armazena boa parte dos principais m�todos do projeto, como salvar os dados e emitir eventos

**Esse projeto conter�** :
- 