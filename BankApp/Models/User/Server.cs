namespace BankApp.MVVM
{
    public interface IServer
    {
        event EventHandler<int> OnMoneyReceived;
    }
}