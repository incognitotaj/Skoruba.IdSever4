
using IdentityModel.Client;
using System.Text.Json;


// discover endpoints from metadata
var client = new HttpClient();

var disco = await client.GetDiscoveryDocumentAsync("https://localhost:44310");
if (disco.IsError)
{
    Console.WriteLine(disco.Error);
    return;
}

// request token
var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
{
    Address = disco.TokenEndpoint,
    ClientId = "datum.store",
    ClientSecret = "datum.store.secret",
    Scope = "catalog.read"
});


if (tokenResponse.IsError)
{
    Console.WriteLine(tokenResponse.Error);
    Console.WriteLine(tokenResponse.ErrorDescription);
    return;
}

Console.WriteLine("TOKEN");
Console.WriteLine(tokenResponse.Json);
Console.WriteLine("\n\n");

// call api
var apiClient = new HttpClient();
apiClient.SetBearerToken(tokenResponse.AccessToken);

var response = await apiClient.GetAsync("https://localhost:44353/weatherforecast");
if (!response.IsSuccessStatusCode)
{
    Console.WriteLine(response.StatusCode);
}
else
{
    var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
    Console.WriteLine(JsonSerializer.Serialize(doc, new JsonSerializerOptions { WriteIndented = true }));
}

Console.ReadLine();