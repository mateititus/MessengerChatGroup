namespace MessengerChatApp
{
    public interface IChatServer
    {
        void RegisterUser(IUser user);

        void UnregisterUser(IUser user);

        void RegisterObserver(IObserver observer);

        void UnregisterObserver(IObserver observer);

        void SendMessage(string sender, string message);
    }
}
