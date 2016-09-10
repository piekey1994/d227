using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateClientService
{
    class MessageObject
    {
        public String ip;
        public String message;
        public String port;
        public MessageObject(String ip, String port, String message)
        {
            this.ip = ip;
            this.port = port;
            this.message = message;
        }
    }
}
