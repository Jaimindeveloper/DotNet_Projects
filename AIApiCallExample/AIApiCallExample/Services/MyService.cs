using AIApiCallExample.Models;
using Microsoft.Extensions.Options;
using System.Runtime;

namespace AIApiCallExample.Services
{
    public class MyService
    {
        private readonly string _apiKey;

        public MyService(IOptions<UserSettings> options)
        {
            _apiKey = options.Value.ApiKey;
        }

        public string GetApiKey()
        {
            return _apiKey;
        }
    }
}
