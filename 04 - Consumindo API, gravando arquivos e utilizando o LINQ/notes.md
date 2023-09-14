## Realizando uma requisi��o
Para essa tarefa, utilizaremos a biblioteca `HttpCLient`.

```csharp
using (HttpClient client = new HttpClient())
{
    string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
    Console.WriteLine(resposta);
}
```

Note que, o `client` instanciado, � um objeto que ser� destru�do ap�s o bloco `using` ser executado. Desta forma, podemos realizar nossos testes dentro desse contexto.

Fora usado o m�todo `GetStringAsync` para realizar a requisi��o. Esse m�todo retorna uma `Task<string>`, que � uma promessa de que, em algum momento, teremos uma string. Para isso, usamos o `await` para aguardar o retorno da requisi��o.

## Try Catch
Partindo do c�digo anterior, caso a requisi��o falhe, o programa ir� quebrar. Para evitar isso, podemos usar um `try catch` para tratar o erro.

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
Quando lidamos com requisi��es, � indispens�vel o uso de `try catch`. Apesar disso, tamb�m podemos us�-los para tratar erros de l�gica, como por exemplo, um erro de divis�o por zero.

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