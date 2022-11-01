using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Mvc;

namespace ManagedIdentity.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KeyVaultController : ControllerBase
{
    private readonly SecretClient _secretClient;

    public KeyVaultController()
    {
        _secretClient = new SecretClient(new Uri("URI do key vault"), new DefaultAzureCredential());
    }


    [HttpGet]
    public async Task<string> Get(string key)
    {
        var keyValueSecret = await _secretClient.GetSecretAsync(key);

        return keyValueSecret.Value.Value;
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
