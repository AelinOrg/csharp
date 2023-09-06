## Fundamentos básicos

- É uma linguagem fortemente tipada, ou seja, é necessário declarar o tipo de cada variável antes do nome:

  ```csharp
  string mensagemDeBoasVindas = "Boas vindas ao Screen Sound"
  Console.WriteLine(mensagemDeBoasVindas);
  ```

- É necessário usar o `;` no final de cada linha
- Usa o padrão `CamelCase` para nomear variáveis, classes, métodos, etc.

## Para saber mais: documentação

A leitura da documentação oficial de uma linguagem de programação é crucial para que um desenvolvedor de software possa utilizá-la de forma eficiente e eficaz. No caso do C# essa documentação fornece uma ampla gama de informações, incluindo a sintaxe, as classes, as bibliotecas e as funcionalidades disponíveis na linguagem. Além disso, a documentação oficial do C# também fornece exemplos de código e soluções para problemas comuns de programação.

Alguns links úteis para a documentação oficial do C# incluem:

- [a documentação do .NET Framework](https://learn.microsoft.com/pt-br/dotnet/framework/)
- [a documentação do Visual Studio](https://learn.microsoft.com/pt-br/visualstudio/get-started/csharp/?view=vs-2022)
- [a documentação do C#](https://learn.microsoft.com/pt-br/dotnet/csharp/)

Ao ler a documentação oficial do C#, temos uma compreensão mais profunda da linguagem e de suas funcionalidades, o que facilita a escrita de códigos mais limpos, claros e seguros. A documentação também pode ajudar o desenvolvedor a economizar tempo, além de evitar a necessidade de pesquisar em fóruns ou outras fontes de informação não confiáveis.

## Isolando o código com funções

Para declarar uma função em C#, definimos o tipo de retorno da função (que pode ser `void`), o nome da função e os parâmetros de entrada da função. Por exemplo, a função abaixo retorna um número inteiro e recebe dois números inteiros como parâmetros de entrada:

```csharp
int Soma(int a, int b)
{
    return a + b;
}
```

Repare que o nome da função segue o padrão `PascalCase`, ou seja, a primeira letra de cada palavra é maiúscula.

## Variáveis do tipo texto

Quando trabalhamos com strings e desejamos exibir um texto como ele de fato é, sem que o compilador interprete caracteres especiais, podemos utilizar o recurso _verbatim literal_, usando `@` antes da string. Por exemplo:

```csharp
void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
}
```

Caso quissemos armazenar um texto em uma variável, poderíamos faze-lo e usar o recursos de interpolação de strings para exibir o valor. Por exemplo:

```csharp
string nome = "Screen Sound";
Console.WriteLine($"Bem vindo ao {nome}");

// ou ainda
Console.WriteLine("Bem vindo ao {0}", nome);
```

## Variáveis do tipo inteiro

Ao criamos uma espécime de formulário, podemos usar o tipo `int` para armazenar a idade do usuário, por exemplo. Para isso, usamos a seguinte sintaxe:

```csharp
Console.Write("Digite sua idade:");
int idade = int.Parse(Console.ReadLine()!);
```

Repare que usamos o método `Parse` para converter o texto digitado pelo usuário em um número inteiro, pois o método `ReadLine` retorna uma string ou `null` (porém foi usado o operador `!` para afirmar que o valor será definido). Além disso, usamos o método `Write` para exibir o texto sem quebra de linha.

## Estruturas de controle

Semelhante a diversas linguagens que dão suporte ao paradigma estruturado, podemos estruturas condicionais como `if` e `switch` para controlar o fluxo de execução do programa.

```csharp
// Exemplo de if
if (idade >= 18)
{
    Console.WriteLine("Você é maior de idade");
}
else
{
    Console.WriteLine("Você é menor de idade");
}

// Exemplo de switch
switch (idade)
{
    case 18:
        Console.WriteLine("Você tem 18 anos");
        break;
    case 19:
        Console.WriteLine("Você tem 19 anos");
        break;
    default:
        Console.WriteLine("Você tem uma idade diferente de 18 e 19 anos");
        break;
}
```

Repare que o `break`, o qual também pode ser utilizado com o `if`, é necessário para que o fluxo de execução não continue para o próximo `case`. Outro ponto importante é uso do `default`, que é executado quando nenhum dos `case` anteriores é verdadeiro. Se assemelha ao `else` do `if`.

O `switch`, diferente do `if`, possui uma limitação: só é possível comparar valores de tipos primitivos e que sejam iguais. Por exemplo, não é possível comparar se um número é maior que outro usando o `switch`.

## Variáveis do tipo lista

Para armazenar uma lista de valores, podemos usar o tipo `List<T>`, onde `T` é o tipo dos valores que serão armazenados. Por exemplo, para armazenar uma lista de números inteiros, podemos usar o seguinte código:

```csharp
List<int> numeros = new List<int>();
numeros.Add(1);
```

Note que o método `Add` é usado para adicionar um valor à lista. Para exibir os valores da lista, podemos usar o seguinte código:

```csharp
foreach (int numero in numeros)
{
    Console.WriteLine(numero);
}

// ou

for (int i = 0; i < numeros.Count; i++)
{
    Console.WriteLine(numeros[i]);
}
```

Para inicializar uma lista com valores, podemos usar a seguinte sintaxe:

```csharp
List<int> numeros = new List<int>() { 1, 2, 3 };
```

## Variáveis do tipo dicionário

Para armazenar um conjunto de valores, onde cada valor possui uma chave, podemos usar o tipo `Dictionary<TKey, TValue>`, onde `TKey` é o tipo da chave e `TValue` é o tipo do valor. Por exemplo, para armazenar um dicionário de bandas e suas respectivas notas, onde a chave é o nome da banda e o valor é a nota da banda, podemos usar o seguinte código:

```csharp
Dictionary<string, List<int>> bandas = new Dictionary<string, List<int>>();

bandas.Add("AC/DC", new List<int>() { 10, 9, 8 });
bandas.Add("Metallica", new List<int>());

bandas["Metallica"].Add(10);
```

Repare que, para adicionar um valor ao dicionário, usamos o método `Add`, que recebe a chave e o valor. Utilizamos duas sintaxes diferentes para adicionar valores em `bandas`. Na segunda, usamos o operador `[]` para acessar o valor de uma banda e, em seguida, usamos o método `Add` para adicionar uma nota à banda.

Por ser fortemente tipada, precisamos definir a estrutura do dicionário antes de usá-lo.

### Listando valores

Caso quissemos listar todas as bandas e suas respectivas notas, poderíamos usar o seguinte código:

```csharp
// Banda e nota
foreach (KeyValuePair<string, List<int>> banda in bandas)
{
    Console.WriteLine($"Banda: {banda.Key}");
    Console.WriteLine($"Notas: {string.Join(", ", banda.Value)}");
}

// Apenas banda
foreach (string banda in bandas.Keys)
{
    Console.WriteLine($"Banda: {banda}");
}
```

### Verificando se uma chave existe

Para verificar se uma chave existe em um dicionário, podemos usar o método `ContainsKey`. Por exemplo:

```csharp
void VerificarSeBandaExiste(string nomeBanda)
{
    if (bandas.ContainsKey(nomeBanda))
    {
        Console.WriteLine($"A banda {nomeBanda} existe");
    }
    else
    {
        Console.WriteLine($"A banda {nomeBanda} não existe");
    }
}
```

## Utilidades e curiosidades

### Thread.Sleep

Em alguns momentos, podemos querer que o programa espere um tempo antes de continuar a execução. Para isso, podemos usar o método `Sleep` da classe `Thread`. Por exemplo, para esperar 1 segundo, podemos usar o seguinte código:

```csharp
Thread.Sleep(1000);
```

### Console.Clear

Para limpar o console, podemos usar o método `Clear` da classe `Console`. Por exemplo:

```csharp
Console.Clear();
```

### \n

Para quebrar uma linha, podemos usar o caractere `\n`. Por exemplo:

```csharp
Console.WriteLine("Olá\nMundo");
```

### ReadKey

Para ler uma tecla pressionada pelo usuário, podemos usar o método `ReadKey` da classe `Console`. Por exemplo:

```csharp
Console.ReadKey();
```

Ao chamar esse método, o programa irá esperar que o usuário pressione uma tecla antes de continuar a execução.

### Aspas simples vs aspas duplas

No C#, aspas simples são usadas para representar um caractere, enquanto aspas duplas são usadas para representar uma string. Por exemplo:

```csharp
char letra = 'a';
string palavra = "palavra";
```

Caso não respeitemos essa regra, o compilador irá gerar um erro.

### String.PadLeft

Suponha que você queira exibir um número inteiro com 3 dígitos, porém o número tem apenas 1 dígito. Para isso, podemos usar o método `PadLeft` da classe `String`. Por exemplo:

```csharp
int numero = 1;
Console.WriteLine(numero.ToString().PadLeft(3, '0')); // 001
```

Outro exemplo seria gerar uma string, de asteriscos, com base em uma string qualquer. Por exemplo:

```csharp
string texto = "Screen Sound";
string asteriscos = texto.PadLeft(texto.Length, '*');

Console.WriteLine(asteriscos);  // ************
Console.WriteLine(texto);       // Screen Sound
Console.WriteLine(asteriscos);  // ************
```

### List<int>.Average

Suponha que você queira calcular a média de uma lista de números inteiros. Para isso, podemos usar o método `Average` da classe `List<int>`. Por exemplo:

```csharp
List<int> numeros = new List<int>() { 1, 2, 3 };
Console.WriteLine(numeros.Average()); // 2
```
