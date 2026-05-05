namespace DesignPatterns.DesignPatterns.ChainOfResponsibility
{
    public class RegionalManagerHandler : OrderHandler
    {
        public override void Handle(Entites.CustomerProcess process)
        {
            if (process.Amount <= 10000)
            {
                process.EmployeeName = "Bölge Müdürü - Deniz Bey";
                process.Description = "Kritik eşikteki işlem Bölge Müdürü tarafından sisteme mühürlendi.";
            }
            else
            {
                throw new System.Exception("İşlem tutarı Bölge Müdürü yetkisini aşıyor (10.000 TL+). Genel Merkez onayı gerekli!");
            }
        }
    }
}