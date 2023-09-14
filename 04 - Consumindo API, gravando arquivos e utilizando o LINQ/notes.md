## Realizando uma requisição
Para essa tarefa, utilizaremos a biblioteca `HttpCLient`.

```csharp
using (HttpClient client = new HttpClient())
{
    string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
    Console.WriteLine(resposta);
}
```

Note que, o `client` instanciado, é um objeto que será destruído após o bloco `using` ser executado. Desta forma, podemos realizar nossos testes dentro desse contexto.

Fora usado o método `GetStringAsync` para realizar a requisição. Esse método retorna uma `Task<string>`, que é uma promessa de que, em algum momento, teremos uma string. Para isso, usamos o `await` para aguardar o retorno da requisição.

## Try Catch
Partindo do código anterior, caso a requisição falhe, o programa irá quebrar. Para evitar isso, podemos usar um `try catch` para tratar o erro.

```csharp
using (HttpClient client = new HttpClient())
{
	try
	{
		string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
		Console.WriteLine(resposta);
	}
	catch (Exception e)
	{
		Console.WriteLine(e.Message);
	}
}
```
Quando lidamos com requisições, é indispensável o uso de `try catch`. Apesar disso, também podemos usá-los para tratar erros de lógica, como por exemplo, um erro de divisão por zero.

```csharp
try
{
	int c = 1 / 0;
}
catch (Exception e)
{
	Console.WriteLine(e.Message);
}
```