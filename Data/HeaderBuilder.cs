using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace FLURLPOC.Data
{
    public class HeaderBuilder
    {
        public static HeaderDTO BuildHeader()
        {
            HeaderDTO headerDTO = Builder<HeaderDTO>.CreateNew()
                    .With(c => c.Accept = "*/*")
                    .With(c => c.AcceptEncoding = "gzip, deflate")
                    .With(c => c.CacheControl = "no-cache")
                    .With(c => c.Connection = "keep-alive")
                    .With(c => c.ContentType = "application/json; charset=utf-8")
                    .With(c => c.User_Agent = "csharp-console-app")
                .Build();

            return headerDTO;
        }

    }
}
