using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RAK.Actions;

namespace RAK.Actions
{

    class Connect : IAction
    {
        public int Id { get => 1;
            set { }
        }
        public string Name { get => "Połączenie";
            set { }
        }
        public string Description { get; set; }
        public List<string> Dominants {
            get
            {
                return new List<string>()
                {
                    "polacz", "jak polaczyc"
                };
            }
            set { }
        }
        public void Execute(object argument)
        {
            String strHostName = string.Empty;
            // Getting Ip address of local machine...
            // First get the host name of local machine.
            strHostName = Dns.GetHostName();
            // Then using host name, get the IP address list..
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            MainWindow._current.AddMessage("Spróbuj połączyć się używając tych adresów:", false);

            for (int i = 0; i < addr.Length; i++)
            {
                MainWindow._current.AddMessage(addr[i].ToString(), false, false);

                Console.WriteLine("Adres {0}: {1} ", i, addr[i].ToString());
            }
        }
    }
}
