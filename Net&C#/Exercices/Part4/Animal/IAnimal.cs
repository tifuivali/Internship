using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
   
    public interface IAnimal
    {
        string Name { get; set; }

        void Serialize(TextWriter fileName);

        IAnimal Deserialize(ReadAheadStreamReader Filename);
    }

}
