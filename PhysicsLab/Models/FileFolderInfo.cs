using System;
using System.Collections.ObjectModel;
using PhysicsLab.CommonClasses;

namespace PhysicsLab.Models
{
	public class FileFolderInfo : ViewModelBase
	{
        private string path;
        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
                OnPropertyChanged("Path");
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private bool isFile;
        public bool IsFile
        {
            get
            {
                return isFile;
            }

            set
            {
                isFile = value;
                OnPropertyChanged("IsFile");
            }
        }

        private bool isDirectory;
        public bool IsDirectory
        {
            get
            {
                return isDirectory;
            }

            set
            {
                isDirectory = value;
                OnPropertyChanged("IsDirectory");
            }
        }

        private bool isDrive;
        public bool IsDrive
        {
            get
            {
                return isDrive;
            }

            set
            {
                isDrive = value;
                OnPropertyChanged("IsDrive");
            }
        }

        private DateTime dateModified;
        public DateTime DateModified
        {
            get
            {
                return dateModified;
            }

            set
            {
                dateModified = value;
                OnPropertyChanged("DateModified");
            }
        }

        private ObservableCollection<FileFolderInfo> fileFolders;
        public ObservableCollection<FileFolderInfo> FileFolders
        {
            get
            {
                return fileFolders;
            }

            set
            {
                fileFolders = value;
                OnPropertyChanged("FileFolders");
            }
        }
    }

	public class HardDriveInfo : ViewModelBase
	{
		private string path;
		public string Path
		{
			get
			{
				return path;
			}

			set
			{
				path = value;
				OnPropertyChanged("Path");
			}
		}

		private string name;
		public string Name
		{
			get
			{
				return name;
			}

			set
			{
				name = value;
				OnPropertyChanged("Name");
			}
		}

		private bool isFile;
		public bool IsFile
		{
			get
			{
				return isFile;
			}

			set
			{
				isFile = value;
				OnPropertyChanged("IsFile");
			}
		}

		private bool isDirectory;
		public bool IsDirectory
		{
			get
			{
				return isDirectory;
			}

			set
			{
				isDirectory = value;
				OnPropertyChanged("IsDirectory");
			}
		}

		private bool isDrive;
		public bool IsDrive
		{
			get
			{
				return isDrive;
			}

			set
			{
				isDrive = value;
				OnPropertyChanged("IsDrive");
			}
		}

		private ObservableCollection<FileFolderInfo> fileFolders;
		public ObservableCollection<FileFolderInfo> FileFolders
		{
			get
			{
				return fileFolders;
			}

			set
			{
				fileFolders = value;
				OnPropertyChanged("FileFolders");
			}
		}
	}
}