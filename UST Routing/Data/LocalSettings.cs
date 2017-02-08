using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace UST_Routing.Data
{
	[Serializable]
	public class LocalSettings
	{
		private static LocalSettings i;
		public static LocalSettings I => i ?? (i = LoadFromBinaryStream());
		public static DirectoryInfo DataStorageDirectory =
			new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\USTRoutingApps\UserConfig\" +
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name);

		public static FileInfo DataStorageFile = new FileInfo(DataStorageDirectory.FullName + @"\LocalSettings.bin");

		private LocalSettings() { }

		private string lastUsername;
		public string LastUsername
		{
			get { return I.lastUsername; }
			set
			{
				I.lastUsername = value;
				SaveToBinaryStream();
			}
		}

		public void SaveToBinaryStream()
		{
			IFormatter formatter = new BinaryFormatter();
			if (!DataStorageDirectory.Exists) DataStorageDirectory.Create();
			Stream stream = new FileStream(DataStorageFile.FullName, FileMode.Create, FileAccess.Write, FileShare.None);
			formatter.Serialize(stream, this);
			stream.Close();
		}
		private static LocalSettings LoadFromBinaryStream()
		{
			if (!DataStorageFile.Exists)
				return new LocalSettings();
			try
			{
				IFormatter formatter = new BinaryFormatter();
				Stream stream = new FileStream(DataStorageFile.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
				var obj = (LocalSettings)formatter.Deserialize(stream);
				stream.Close();
				return obj;
			}
			catch
			{
				return new LocalSettings();
			}
		}
	}
}
