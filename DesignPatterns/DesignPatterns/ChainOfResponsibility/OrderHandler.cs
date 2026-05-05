namespace DesignPatterns.DesignPatterns.ChainOfResponsibility
{
    public abstract class OrderHandler
    {
        protected OrderHandler NextHandler;

        public void SetNextHandler(OrderHandler nextHandler)
        {
            NextHandler = nextHandler;
        }

        public abstract void Handle(Entites.CustomerProcess process);
    }
}