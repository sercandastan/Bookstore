using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace Bookstore.Controllers.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisApiController : ControllerBase
    {
        private readonly IDatabase _redisDb;

        public RedisApiController(IConnectionMultiplexer redis)
        {
            _redisDb = redis.GetDatabase();
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> GetValue(string key)
        {
            var value = await _redisDb.StringGetAsync(key);
            if (value.IsNullOrEmpty)
                return NotFound($"Anahtar '{key}' bulunamadı.");

            return Ok(value.ToString());
        }

        [HttpPost]
        public async Task<IActionResult> SetValue([FromBody] RedisEntry entry)
        {
            await _redisDb.StringSetAsync(entry.Key, entry.Value);
            return Ok($"Anahtar '{entry.Key}' başarıyla kaydedildi.");
        }

        [HttpDelete("{key}")]
        public async Task<IActionResult> DeleteValue(string key)
        {
            var result = await _redisDb.KeyDeleteAsync(key);
            if (!result)
                return NotFound($"Anahtar '{key}' bulunamadı veya silinemedi.");

            return Ok($"Anahtar '{key}' silindi.");
        }
    }

    public class RedisEntry
    {
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}