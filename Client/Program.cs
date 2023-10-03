using API_Projeto1.Models;
using Newtonsoft.Json;
using System;

    const string BaseUrl = "https://localhost:7228/api/Multiplica";

    Console.WriteLine("Digite um número");
    int numero = Convert.ToInt32(Console.ReadLine());              

    //GET//
    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri(BaseUrl);

        var response = client.GetStringAsync($"?numero={numero}");
        string result = response.Result.ToString();
        Console.WriteLine($"Resultado GET: {result}");
    }

    //POST//
    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri(BaseUrl);

        string json = JsonConvert.SerializeObject(new { num = $"{numero}" });
        var body = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        var response = await client.PostAsync("", body);
        var result = await response.Content.ReadAsStringAsync();

        //Post  Numero num = JsonConvert.DeserializeObject<PostNumero>(result); //ERRO
        
        string num = JsonConvert.DeserializeObject<string>(result); //Fiz dessa forma pois como ele trazia apenas uma string para desserializar, não estava conseguindo traduzi-la para um objeto.

        Console.WriteLine($"Resultado POST: {num}");

    }

Console.WriteLine("\nPressione qualquer tecla para fechar");
Console.ReadLine();