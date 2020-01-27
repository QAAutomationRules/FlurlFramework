using FakerDotNet;
using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLURLPOC.Data
{
    public class UserBuilder
    {
        public static UserDTO BuildUser()
        {
            UserDTO userDTO = Builder<UserDTO>.CreateNew()
                    .With(c => c.Login = "KTJ-Demo")
                    .With(c => c.Id = 53450794L)
                    .With(c => c.NodeId = "MDQ6VXNlcjUzNDUwNzk0")
                    .With(c => c.AvatarUrl = new Uri("https://avatars2.githubusercontent.com/u/53450794?v=4"))
                    .With(c => c.GravatarId = "" )
                    .With(c => c.Url = new Uri("https://api.github.com/users/KTJ-Demo"))
                .Build();

            return userDTO;
        }
    }
}
