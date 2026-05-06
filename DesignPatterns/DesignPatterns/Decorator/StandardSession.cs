namespace DesignPatterns.DesignPatterns.Decorator
{
    namespace DesignPatterns.DesignPatterns.Decorator
    {
        public class StandardSession : ISessionWrapper
        {
            private readonly ISession _session;
            public StandardSession(ISession session) => _session = session;

            public void Set(string key, string value) => _session.SetString(key, value);
            public string Get(string key) => _session.GetString(key);
        }
    }
}
