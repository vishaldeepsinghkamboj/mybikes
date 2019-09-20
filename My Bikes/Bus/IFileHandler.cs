using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mybikes.Bus
{
    interface IFileHandler
    {
        void WriteToXmlFileBike(List<Bike> Bikelist);
        List<Bike> ReadFromXmlFileA();
        List<Loginpage> ReadFromLoginfile();
    }
}
