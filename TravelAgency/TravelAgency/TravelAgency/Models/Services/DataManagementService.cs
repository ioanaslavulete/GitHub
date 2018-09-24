using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using TravelAgency.Models;

namespace TravelAgency.Services
{
	public sealed class DataManagementService
	{
		private static DataManagementService instance = null;
		private static readonly object padlock = new object();

		private const string fileName = "mainrepository.bin";

		private IFormatter formatter = new BinaryFormatter();

		DataManagementService()
		{
			LoadData();
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

			Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
			formatter.Serialize(stream, MainRepository);
			stream.Close();
		}

		private void LoadData()
		{
			try
			{
				Stream readStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
				MainRepository = (MainRepository)formatter.Deserialize(readStream);
			}
			catch
			{
				MainRepository = new MainRepository();
			}
		}
	}
}
