using System.IO;
using System.Xml.Serialization;
using TravelAgency.Models;

namespace TravelAgency.Services
{
    public sealed class DataManagementService
    {
        private static DataManagementService instance = null;
        private static readonly object padlock = new object();

        private const string fileName = "mainrepository.xml";

        DataManagementService()
        {
            MainRepository = LoadData();
        }

        public MainRepository MainRepository
        {
            get; set;
        }

        public static DataManagementService Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DataManagementService();
                    }
                    return instance;
                }
            }
        }

        public void SaveData()
        {
            if (File.Exists(fileName))
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                File.Delete(fileName);
            }

            XmlSerializer serializer = new XmlSerializer(MainRepository.GetType());
            TextWriter writer = new StreamWriter(fileName);
            serializer.Serialize(writer, MainRepository);
            writer.Close();
        }

        private MainRepository LoadData()
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(MainRepository));
                FileStream read = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                return (MainRepository)xs.Deserialize(read);
            }
            catch
            {
                return new MainRepository();
            }
        }
    }
}
