using PersistenceCape.EmailConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface IEmailRepository
    {
        void SendEmail(Message message);
    }
}
