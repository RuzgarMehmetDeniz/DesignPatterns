namespace DesignPatterns.DesignPatterns.Strategy
{
    public class OrderContext
    {
        private IOrderStrategy _strategy;

        public void SetStrategy(IOrderStrategy strategy)
        {
            _strategy = strategy;
        }

        public string Execute(decimal amount)
        {
            return _strategy.ProcessOrder(amount);
        }
    }
}
