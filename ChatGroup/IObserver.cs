namespace MessengerChatApp
{
    public interface IObserver
    {
        void ReceiveMessage(string personName, string reciever, string message);

        int getId { get; }

        string getName { get; }

        bool getOffline { get; }

    }
}