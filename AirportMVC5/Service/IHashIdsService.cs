using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportMVC5.Service
{
    interface IHashIdsService
    {
        string Encrypt(int id);
        int Decrypt(string hashedId);
    }
}
