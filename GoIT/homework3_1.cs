using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] _sUsers = { "admin", "moderator", "user" };
            String[] _sPasswords = { "admin", "moderator", "user" };
            String[] _sRoles = { "Admin", "Moderator", "User" };
            String _sLogin, _sPassword;
            int _iCount = 0;
            bool flag = false;
            while (true)
            {
                Console.Write("Login: ");
                _sLogin = Console.ReadLine();
                Console.Write("Password: ");
                _sPassword = Console.ReadLine();
                for (int i = 0; i < _sUsers.Length; ++i)
                {
                    if (_sLogin == _sUsers[i] && _sPassword == _sPasswords[i])
                    {
                        if (_sRoles[i] == "Admin")
                        {
                            Console.WriteLine("\nGreetings, admin. Here is the list of users:");
                            for (int j = 0; j < _sUsers.Length; ++j)
                            {
                                Console.WriteLine("Username - {0}, password - {1}, role - {2}", _sUsers[j], _sPasswords[j], _sRoles[j]);
                            }
                        }
                        else if (_sRoles[i] == "Moderator")
                        {
                            Console.WriteLine("\nNumber of all registered users : {0}", _sUsers.Length);
                        }
                        else
                        {
                            int cnt = 0;
                            for (int j = 0; j < _sUsers.Length; ++j)
                            {
                                if (_sRoles[j] == "User")
                                {
                                    cnt++;
                                    Console.WriteLine("Username - {0}", _sUsers[j]);
                                }
                            }
                            Console.WriteLine("Number of Users: {0}", cnt);
                        }
                        return;
                    }
                }
                _iCount++;
                if (_iCount < 3)
                    Console.WriteLine("Incorrect username or password, attempts left: {0}", 3 - _iCount);
                else
                {
                    Console.WriteLine("Sorry, you are out of attempts");
                    break;
                }
            }
        }
    }
}
