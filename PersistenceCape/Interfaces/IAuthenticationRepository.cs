using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface IAuthenticationRepository
    {
        bool Authenticate(string email, string password);

        bool CloseSession(string token);
    }
}
