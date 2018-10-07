using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportMVC5.Service
{
    public class HashidService : IHashIdsService
    {
        private HashidsNet.Hashids hash;

        public HashidService()
        {
            hash = new HashidsNet.Hashids("Some weird text", 2);
        }
        public int Decrypt(string hashedId)
        {
            return hash.Decode(hashedId).First();
        }

        public string Encrypt(int id)
        {
            return hash.Encode(id);
        }
    }
}