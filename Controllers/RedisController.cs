using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace ManagedIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        ConnectionMultiplexer _redisConnection;
        IDatabase _redis;
        public RedisController()
        {
            var options = new ConfigurationOptions();
            options.EndPoints.Add("wizmanagedidentity.redis.cache.windows.net:6380");
            options.ConnectRetry = 2;
            options.ConnectTimeout = 10000;
            options.Ssl = true;

            _redisConnection = ConnectionMultiplexer.Connect(options);

            _redis = _redisConnection.GetDatabase();
        }


        [HttpGet("{key}")]
        public async Task<string> Get(string key)
        {
            if (!_redis.KeyExists(key)) return "chave não existe";

            var value = await _redis.StringGetAsync(key);

            return value;
        }

        [HttpPost("{key}/{value}")]
        public async Task<string> Post(string key, string value)
        {
            if (_redis.KeyExists(key)) return "chave já existe";

            await _redis.StringSetAsync(key, value, TimeSpan.FromMinutes(5));

            return "Chave e valor adicionados com sucesso.";
        }

        [HttpDelete("{key}")]
        public string Delete(string key)
        {
            if (!_redis.KeyExists(key)) return "chave não existe";

            _redis.KeyDelete(key);

            return "chave excluída com sucesso";
        }
    }
}
