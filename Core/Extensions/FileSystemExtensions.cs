using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Core.Extensions
{
	public static class FileSystemExtensions
	{
		public static string GetFileNameWithoutExtention(this FileInfo i)
		{
			return i.Name.Substring(0, i.Name.LastIndexOf('.'));
		}

		public static ReadOnlyCollection<string> FormatLabels =
			new ReadOnlyCollection<string>(new List<string>
			{
				"Bytes",
				"Kb",
				"Mb",
				"Gb",
				"Tb"
			});

		private const int stepSize = 1024;
		public static string GetFormattedFileLength(this FileInfo i)
		{
			var length = (double)i.Length;
			var label = FormatLabels.First();
			for (var x = 0; x < FormatLabels.Count - 1; x++)
			{
				label = FormatLabels[x];
				if (length < stepSize) break;
				length = length / stepSize;
			}
			return $"{length.Round(2)} {label}";
		}

		public static string GetFormattedSize(this long i)
		{
			var length = (double)i;
			var label = FormatLabels.First();
			for (var x = 0; x < FormatLabels.Count - 1; x++)
			{
				label = FormatLabels[x];
				if (length < stepSize) break;
				length = length / stepSize;
			}
			return $"{length.Round(2)} {label}";
		}

		public static bool IsAccessible(this DirectoryInfo i)
		{
			try
			{
				var readAllow = false;
				var readDeny = false;
				var accessControlList = i.GetAccessControl();
				var accessRules = accessControlList?.GetAccessRules(true, true, typeof(SecurityIdentifier));
				if (accessRules == null)
					return false;

				foreach (FileSystemAccessRule rule in accessRules)
				{
					if ((FileSystemRights.Read & rule.FileSystemRights) != FileSystemRights.Read) continue;

					if (rule.AccessControlType == AccessControlType.Allow)
						readAllow = true;
					else if (rule.AccessControlType == AccessControlType.Deny)
						readDeny = true;
				}

				return readAllow && !readDeny;
			}
			catch
			{
				return false;
			}

		}

		public static bool IsAccessible(this FileInfo i)
		{
			try
			{
				var readAllow = false;
				var readDeny = false;
				var accessControlList = i.GetAccessControl();
				var accessRules = accessControlList?.GetAccessRules(true, true, typeof(SecurityIdentifier));
				if (accessRules == null)
					return false;

				foreach (FileSystemAccessRule rule in accessRules)
				{
					if ((FileSystemRights.Read & rule.FileSystemRights) != FileSystemRights.Read) continue;

					if (rule.AccessControlType == AccessControlType.Allow)
						readAllow = true;
					else if (rule.AccessControlType == AccessControlType.Deny)
						readDeny = true;
				}

				return readAllow && !readDeny;
			}
			catch
			{
				return false;
			}
		}
		public static bool IsAccessible(this FileSystemInfo i)
		{
			var file = i as FileInfo;
			if (file != null)
				return file.IsAccessible();

			var directory = i as DirectoryInfo;
			if (directory != null)
				return directory.IsAccessible();

			return false;
		}

		public static void CreateIfNotExists(this DirectoryInfo i)
		{
			if (!i.Exists)
				i.Create();
		}

		public static IEnumerable<FileInfo> EnumerateAccessibleFiles(this DirectoryInfo i)
		{
			return i.EnumerateFiles().Where(n => n.IsAccessible() && !n.Attributes.HasFlag(FileAttributes.ReparsePoint));
		}
		public static IEnumerable<FileInfo> EnumerateAccessibleFiles(this DirectoryInfo i, string searchPattern, SearchOption searchOption)
		{
			return i.EnumerateFiles(searchPattern, searchOption).Where(n => n.IsAccessible() && !n.Attributes.HasFlag(FileAttributes.ReparsePoint));
		}

		public static IEnumerable<DirectoryInfo> EnumerateAccessibleDirectories(this DirectoryInfo i)
		{
			return i.EnumerateDirectories().Where(n => n.IsAccessible() && !n.Attributes.HasFlag(FileAttributes.ReparsePoint));
		}

		public static IEnumerable<FileSystemInfo> EnumerateAccessibleFSIs(this DirectoryInfo i)
		{
			return i.EnumerateFileSystemInfos().Where(n => n.IsAccessible() && !n.Attributes.HasFlag(FileAttributes.ReparsePoint));
		}
		public enum DirectoryFetchMode
		{
			Throw,
			Suppress,
			Create
		}

		public static DirectoryInfo GetSubDirectory(this DirectoryInfo i, string name, DirectoryFetchMode fetchMode = DirectoryFetchMode.Suppress)
		{
			var expectedPath = new DirectoryInfo(i.FullName + $@"\{name}");
			if (!i.Exists)
			{
				if (fetchMode != DirectoryFetchMode.Suppress)
					throw new DirectoryNotFoundException($"SubDirectory {i.FullName} does not exist.");
				return expectedPath;
			}

			if (expectedPath.Exists)
				return expectedPath;

			if (fetchMode == DirectoryFetchMode.Create)
			{
				return i.CreateSubdirectory(name);
			}
			if (fetchMode == DirectoryFetchMode.Suppress)
				return expectedPath;

			throw new DirectoryNotFoundException($"SubDirectory {name} was not found in {i.FullName}.");
		}

		public static FileInfo GetFilePath(this DirectoryInfo i, string name)
		{
			return new FileInfo(i.FullName + name);
		}

		public static FileInfo MoveTo(this FileInfo i, DirectoryInfo target)
		{
			var path = $@"{target.FullName}\{i.Name}";
			i.MoveTo(path);
			return new FileInfo(path);
		}

		public static FileInfo MoveToSafe(this FileInfo i, DirectoryInfo target)
		{
			try
			{
				var path = $@"{target.FullName}\{i.Name}";
				i.MoveTo(path);
				return new FileInfo(path);
			}
			catch
			{
				var secondaryTarget = target.CreateSubdirectory($"{DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss-tt")}");
				var path = $@"{secondaryTarget.FullName}\{i.Name}";
				i.MoveTo(path);
				return new FileInfo(path);
			}
		}
	}
}