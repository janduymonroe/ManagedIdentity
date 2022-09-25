using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Mvc;

namespace ManagedIdentity.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KeyVaultController : ControllerBase
{
    private readonly SecretClient _secretClient;

    public KeyVaultController(SecretClient secretClient)
    {
        _secretClient = new SecretClient("https://wizmikv.vault.azure.net/secrets/Hoje/a15bd58616e54bd796af716b4fa8062a");
    }


    [HttpGet]
    public async Task<string> Get()
    {
        var keyValueSecret = await _secretClient.GetSecretAsync(secretName);

        return keyValueSecret.Value.ToString();
    }

    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    [HttpPost]
    public void Post(string name, string value)
    {
        var secret = new KeyVaultSecret(name, value);
        _secretClient.SetSecret(secret);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
