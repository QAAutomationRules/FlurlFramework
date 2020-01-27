using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FLURLPOC.Data
{
    public class HeaderDTO
    {
        public string Accept { get; set; }

        public string AcceptEncoding { get; set; }

        public string CacheControl { get; set; }

        public string Connection { get; set; }

        public string ContentType { get; set; }

        public string User_Agent { get; set; }

    }
}
