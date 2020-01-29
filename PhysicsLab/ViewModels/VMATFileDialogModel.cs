using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using PhysicsLab.CommonClasses;
using PhysicsLab.Models;

namespace PhysicsLab.ViewModels
{
	public class VMATFileDialogModel : ViewModelBase
	{
        private FileFolderInfo selectedTreeViewItem;
        public FileFolderInfo SelectedTreeViewItem
        {
            get
            {
                return selectedTreeViewItem;
            }

            set
            {
                selectedTreeViewItem = value;
                if (value != null)
                {
                    if (value.IsDirectory || value.IsDrive)
                    {
                        value.FileFolders = new ObservableCollection<FileFolderInfo>();
                        GetDirectoryData(new DirectoryInfo(value.Path), ref value);
                        GetFileInfo(new DirectoryInfo(value.Path), ref value);
                    }
                }
                OnPropertyChanged("SelectedTreeViewItem");
            }
        }

        private FileFolderInfo selectedFileItem;
        public FileFolderInfo SelectedFileItem
        {
            get
            {
                return selectedFileItem;
            }

            set
            {
                selectedFileItem = value;
                OnPropertyChanged("SelectedFileItem");
            }
        }

        private string avoidedFilePaths;
        public string AvoidedFilePaths
        {
            get
            {
                return avoidedFilePaths == null || avoidedFilePaths == "" ? "," : avoidedFilePaths;
            }

            set
            {
                avoidedFilePaths = value;
                OnPropertyChanged("AvoidedFilePaths");
            }
        }

        private ObservableCollection<FileFolderInfo> selectedFileItemList;
        public ObservableCollection<FileFolderInfo> SelectedFileItemList
        {
            get
            {
                return selectedFileItemList;
            }

            set
            {
                selectedFileItemList = value;
                OnPropertyChanged("SelectedFileItemList");
            }
        }

        private ObservableCollection<FileFolderInfo> tempSelectedFileItemList;
        public ObservableCollection<FileFolderInfo> TempSelectedFileItemList
        {
            get
            {
                return tempSelectedFileItemList;
            }

            set
            {
                tempSelectedFileItemList = value;
                OnPropertyChanged("TempSelectedFileItemList");
            }
        }

        private List<string> filterList;
        public List<string> FilterList
        {
            get
            {
                return filterList == null ? new List<string>() : filterList;
            }
            set
            {
                filterList = value;
                OnPropertyChanged("FilterList");
            }
        }

        private string selectedFilter;
        public string SelectedFilter
        {
            get
            {
                return selectedFilter == null ? "" : selectedFilter;
            }
            set
            {
                selectedFilter = value;
                if (SelectedTreeViewItem != null)
                {
                    if (SelectedTreeViewItem.IsDirectory || SelectedTreeViewItem.IsDrive)
                    {
                        FileFolderInfo obj = SelectedTreeViewItem;
                        SelectedTreeViewItem.FileFolders = new ObservableCollection<FileFolderInfo>();
                        GetDirectoryData(new DirectoryInfo(SelectedTreeViewItem.Path), ref obj);
                        GetFileInfo(new DirectoryInfo(SelectedTreeViewItem.Path), ref obj);
                    }
                }
                OnPropertyChanged("SelectedFilter");
            }
        }

        private bool isOk;
        public bool IsOk
        {
            get
            {
                return isOk;
            }

            set
            {
                isOk = value;
                if (value)
                {
                    if (TempSelectedFileItemList.Count > 0)
                    {
                        SelectedFileItemList = TempSelectedFileItemList;
                    }
                    else
                    {
                        SelectedFileItemList = new ObservableCollection<FileFolderInfo>();
                        SelectedFileItemList.Add(SelectedFileItem);
                    }
                    OnPropertyChanged("IsOk");
                }
            }
        }

        private ObservableCollection<FileFolderInfo> drives;
        public ObservableCollection<FileFolderInfo> Drives
        {
            get
            {
                return drives;
            }

            set
            {
                drives = value;
                OnPropertyChanged("Drives");
            }
        }

        private bool multiSelect;
        public bool MultiSelect
        {
            get
            {
                return multiSelect;
            }

            set
            {
                multiSelect = value;
                OnPropertyChanged("MultiSelect");
            }
        }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        private static VMATFileDialogModel instance;
        public static VMATFileDialogModel Instance
        {
            get { return instance ?? (instance = new VMATFileDialogModel()); }
        }

        public VMATFileDialogModel()
        {
        }

        public void LoadTreeData()
        {
            Drives = new ObservableCollection<FileFolderInfo>();
            foreach (DriveInfo info in DriveInfo.GetDrives())
            {
                if (!AvoidedFilePaths.Split(',').Contains(info.RootDirectory.FullName))
                {
                    if (info.IsReady)
                    {
                        FileFolderInfo harddriveinfo = new FileFolderInfo();
                        harddriveinfo.FileFolders = new ObservableCollection<FileFolderInfo>();
                        GetDirectoryData(info.RootDirectory, ref harddriveinfo);
                        GetFileInfo(info.RootDirectory, ref harddriveinfo);
                        harddriveinfo.IsDrive = true;
                        harddriveinfo.Name = info.Name;
                        harddriveinfo.Path = info.RootDirectory.FullName;
                        Drives.Add(harddriveinfo);
                    }
                }
            }
        }

        public void GetDirectoryData(DirectoryInfo DirectoryInfo, ref FileFolderInfo folder)
        {
            foreach (DirectoryInfo directoryinfo in DirectoryInfo.GetDirectories("*.*", SearchOption.TopDirectoryOnly).Where(s => !AvoidedFilePaths.Contains(s.FullName)))
            {
                if ((directoryinfo.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    folder.FileFolders.Add(new FileFolderInfo
                    {
                        Name = directoryinfo.Name,
                        Path = directoryinfo.FullName,
                        IsDirectory = true,
                        DateModified = directoryinfo.LastWriteTime
                        //Files= GetFileInfo(directoryinfo),
                        //Folders=GetDirectoryData(directoryinfo)
                    });
                }
            }
        }

        public void GetFileInfo(DirectoryInfo DirectoryInfo, ref FileFolderInfo items)
        {
            if (!SelectedFilter.Contains("*.*"))
            {
                foreach (FileInfo directoryinfo in DirectoryInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly).Where(s => SelectedFilter.Split('|')[1].Contains(s.Extension.ToLower())).Where(s => !AvoidedFilePaths.Contains(s.FullName)))
                {
                    if ((directoryinfo.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden && directoryinfo.Extension != "")
                    {
                        items.FileFolders.Add(new FileFolderInfo
                        {
                            Name = directoryinfo.Name,
                            Path = directoryinfo.FullName,
                            DateModified = directoryinfo.LastWriteTime,
                            IsFile = true
                        });
                    }
                }
            }
            else
            {
                foreach (FileInfo directoryinfo in DirectoryInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly).Where(s => !AvoidedFilePaths.Contains(s.FullName)))
                {
                    if ((directoryinfo.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden && directoryinfo.Extension != "")
                    {
                        items.FileFolders.Add(new FileFolderInfo
                        {
                            Name = directoryinfo.Name,
                            Path = directoryinfo.FullName,
                            DateModified = directoryinfo.LastWriteTime,
                            IsFile = true
                        });
                    }
                }
            }
        }
    }
}