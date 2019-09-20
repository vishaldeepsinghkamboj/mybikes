using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

namespace Mybikes.Bus
{
    public class FileHandler : IFileHandler
    {

        private static String xmlFilePathA = @"../../Data/Allbikes.xml";
        private static String LoginFilePath = @"../../Data/login.txt";

        public void WriteToXmlFileBike(List<Bike> Bikelist)
        {
            XmlWriter writer1 = XmlWriter.Create(xmlFilePathA); //  All bike  
            XmlSerializer serializer1 = new XmlSerializer(typeof(List<Bike>));
            serializer1.Serialize(writer1, Bikelist);
            writer1.Close();

        }
        public List<Bike> ReadFromXmlFileA()
        {
            List<Bike> tempbikelist = new List<Bike>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Bike>));
            StreamReader reader = new StreamReader(xmlFilePathA);
            tempbikelist = (List<Bike>)xmlSerializer.Deserialize(reader);
            reader.Close();
            return tempbikelist;
        }


        public List<Loginpage> ReadFromLoginfile()

        {
            List<Loginpage> temploginlist = new List<Loginpage>();
            StreamReader reader = new StreamReader(LoginFilePath);

            String line = null;
            line = reader.ReadLine();

            while (line != null)
            {
                Loginpage login = new Loginpage();
                String[] tokens = line.Split('|');
                login.Username = tokens[0];
                login.Password = tokens[1];
                temploginlist.Add(login);
                line = reader.ReadLine();
            }
            reader.Close();
            return temploginlist;
        }

    }
}
