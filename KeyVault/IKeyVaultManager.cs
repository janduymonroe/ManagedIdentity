namespace ManagedIdentity.KeyVault
{
    public interface IKeyVaultManager
    {
        Task<string> GetSecret(string secretName);
    }
}
