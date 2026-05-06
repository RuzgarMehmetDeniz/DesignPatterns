namespace DesignPatterns.DesignPatterns.Decorator
{
    public interface ISessionWrapper
    {
        // Temel Session işlemlerini soyutlaştırıyoruz
        void Set(string key, string value);
        string Get(string key);
    }
}