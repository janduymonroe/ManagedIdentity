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
    }


    [HttpGet]
    public async Task<string> Get()
    {
        return null;
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
