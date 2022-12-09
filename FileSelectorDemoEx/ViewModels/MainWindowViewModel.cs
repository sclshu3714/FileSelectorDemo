using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSelectorDemo.ViewModels
{
   public class MainWindowViewModel:CodeBase.NotifyObject
    {
        #region ViewModels

        private ViewModels.FileListViewModel _FileListViewModelInstance;
        public ViewModels.FileListViewModel FileListViewModelInstance
        {
            get { return _FileListViewModelInstance; }
            set
            {
                if (value != _FileListViewModelInstance)
                {
                    _FileListViewModelInstance = value;
                    OnPropertyChanged("FileListViewModelInstance");
                }
            }
        }

        private NavigationViewModel _NavigationViewModelInstance;
        public NavigationViewModel NavigationViewModelInstance
        {
            get { return _NavigationViewModelInstance; }
            set
            {
                if (value != _NavigationViewModelInstance)
                {
                    _NavigationViewModelInstance = value;
                    OnPropertyChanged("NavigationViewModelInstance");
                }
            }
        }

        private BreadCrumbViewModel _BreadCrumbViewModelInstance;
        public BreadCrumbViewModel BreadCrumbViewModelInstance
        {
            get { return _BreadCrumbViewModelInstance; }
            set
            {
                if (value != _BreadCrumbViewModelInstance)
                {
                    _BreadCrumbViewModelInstance = value;
                    OnPropertyChanged("BreadCrumbViewModelInstance");
                }
            }
        }

        #endregion
    }
}
