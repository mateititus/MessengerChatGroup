using System;
using System.Collections.Generic;
using System.Linq;

namespace MessengerChatApp
{
    public class ChatServer : IChatServer
    {
        private List<IUser> _users = new List<IUser>();

        private List<IObserver> _observers = new List<IObserver>();

        public void RegisterUser(IUser user)
        {
            
            if (!_users.Contains(user) && _users.Count + _observers.Count < 10)
            {
                _users.ForEach(x => x.ReceiveMessage("App", x.getName, $"User {user.getName} is online"));

                _observers.ForEach(x => x.ReceiveMessage("App", x.getName, $"User {user.getName} is online"));

                _users.Add(user);
            }
            else
            {
                user.ReceiveMessage("App", user.getName, "Error");
            }

        }

        public void RegisterObserver(IObserver observer)
        {
            
            if (!_observers.Contains(observer) && _observers.Count < 2 && _users.Count + _observers.Count < 2)
            {
                _users.ForEach(x => x.ReceiveMessage("App", x.getName, $"Observer {observer.getName} is online"));

                _observers.ForEach(x => x.ReceiveMessage("App", x.getName, $"Observer {observer.getName} is online"));

                _observers.Add(observer);
            }
            else
            {
                observer.ReceiveMessage("Server", observer.getName, "Error");
            }

        }

        public void UnregisterUser(IUser user)
        {
            
            if (_users.Contains(user))
            {
                _users.Remove(user);

                _users.ForEach(x => x.ReceiveMessage(x.getName, x.getName, $"User {user.getName} is offline"));

                _observers.ForEach(x => x.ReceiveMessage(x.getName, x.getName, $"User {user.getName} is offline"));
            }
        }

        public void UnregisterObserver(IObserver observer)
        {
            
            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);

                _observers.ForEach(x => x.ReceiveMessage(x.getName, x.getName, $"User {observer.getName} is offline"));

                _users.ForEach(x => x.ReceiveMessage(x.getName, x.getName, $"User {observer.getName} is offline"));
            }
        }

        public void SendMessage(string sender, string message)
        {
            
            if(_users.Exists(x => x.getName == sender)){ 

            _users.ForEach(x => {if(x.getName != sender) x.ReceiveMessage(sender, x.getName, message); });

            _observers.ForEach(x => { if (x.getName != sender) x.ReceiveMessage(sender, x.getName, message); });
            }
          
        }
    }
}
