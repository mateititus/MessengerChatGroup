namespace MessengerChatApp
{
    public interface IUser
    {
        void SendMessage(string personName, string message);

        void ReceiveMessage(string personName, string reciever, string message);

        int getId { get; }

        string getName { get; }

        bool getOffline { get; }
    }
}
