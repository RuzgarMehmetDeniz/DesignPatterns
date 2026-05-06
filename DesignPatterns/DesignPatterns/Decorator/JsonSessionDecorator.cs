using Newtonsoft.Json;

namespace DesignPatterns.DesignPatterns.Decorator
{
    public class JsonSessionDecorator : ISessionWrapper
    {
        private readonly ISessionWrapper _innerSession;

        public JsonSessionDecorator(ISessionWrapper innerSession)
        {
            _innerSession = innerSession;
        }

        public void Set(string key, string value) => _innerSession.Set(key, value);
        public string Get(string key) => _innerSession.Get(key);

        public void SetObject(string key, object value)
        {
            var json = JsonConvert.SerializeObject(value);
            _innerSession.Set(key, json);
        }

        public T GetObject<T>(string key)
        {
            var json = _innerSession.Get(key);
            return json == null ? default : JsonConvert.DeserializeObject<T>(json);
        }
    }
}