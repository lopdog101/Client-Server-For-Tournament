using System;

namespace ApplicationClient
{
    //keep information about client
    class UserData
    {
        private string _name;
        private int _port;

        public UserData(string name)
        {
            _name = name;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public void SetPort(string port)
        {
            _port = Convert.ToInt32(port);
        }

        public string GetName()
        {
            return _name;
        }

        public int GetPort()
        {
            return _port;
        }
    }
}
