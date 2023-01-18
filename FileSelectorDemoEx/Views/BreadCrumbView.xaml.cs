using FileSelectorDemo.Models;
using FileSelectorDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileSelectorDemo.Views
{
    /// <summary>
    /// BreadCrumbView.xaml 的交互逻辑
    /// </summary>
    public partial class BreadCrumbView : UserControl
    {
        public BreadCrumbView()
        {
            InitializeComponent();
            Loaded +=new RoutedEventHandler(BreadCrumbView_Loaded);
        }

        private void BreadCrumbView_Loaded(object sender, RoutedEventArgs e)
        {
            // this.DataContext = new ViewModels.BreadCrumbViewModel(AttachedDataContext);
        }

        /// <summary>
        /// 当前FileList的DataContext对象
        /// </summary>
        public object AttachedDataContext
        {
            get { return GetValue(AttachedDataContextProperty); }
            set { SetValue(AttachedDataContextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AttachedDataContextProperty =
            DependencyProperty.Register("AttachedDataContext", typeof(object), typeof(BreadCrumbView), new PropertyMetadata(null));

        /// <summary>
        /// 进入编辑模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEditPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Border border && border.Name == "outer" && 
                border.TemplatedParent is ItemsControl control && control.FindName("toggleBtnFolder") is ToggleButton toggle) {
                toggle.IsChecked = true;
                if (control.TemplatedParent is CheckBox checkBox && checkBox.Template.FindName("currentdirectory", checkBox) is TextBox txtBox)
                {
                    if(txtBox.Text != null)
                    txtBox.Select(txtBox.Text.Length, 0);
                }
            }
        }

        /// <summary>
        /// 编辑模式结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEndEditPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && e.OriginalSource is TextBox txtBox && txtBox.TemplatedParent is CheckBox checkBox && checkBox.Template.FindName("toggleBtnFolder", checkBox) is ToggleButton toggle)
            {
                toggle.IsChecked = false;
                System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(txtBox.Text);// System.IO.Directory.GetParent(directory);
                FileListViewModel fileListViewModel = AttachedDataContext as FileListViewModel;
                if ((directoryInfo.Name == "此电脑" || directoryInfo.Name == "我的电脑") ||
                    fileListViewModel.CurrentModel.CurrentDirectory.Equals(txtBox.Text))
                {
                    return;
                }

                Models.FileListItemModel tempModel = new Models.FileListItemModel()
                {
                    Name = directoryInfo.Name,
                    CreateTime = directoryInfo.CreationTime.ToString(),
                    Size = " ",
                    CurrentType = Defines.CurrentType.文件夹,
                    CurrentDirectory = directoryInfo.FullName,
                    Icon = Utils.DirectoryUtil.GetDefaultFolderIcon(),
                    FileExtension = ".",
                    ParentDirectory = directoryInfo.Parent.FullName
                };
                fileListViewModel.OpenCurrentDirectory.Execute(tempModel);
            }
        }


        private void OnTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is TextBox txtBox && txtBox.TemplatedParent is CheckBox checkBox && checkBox.Template.FindName("toggleBtnFolder", checkBox) is ToggleButton toggle)
            {
                toggle.IsChecked = false;
                System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(txtBox.Text);// System.IO.Directory.GetParent(directory);
                FileListViewModel fileListViewModel = AttachedDataContext as FileListViewModel;
                if ((directoryInfo.Name == "此电脑" || directoryInfo.Name == "我的电脑") ||
                    fileListViewModel.CurrentModel.CurrentDirectory.Equals(txtBox.Text))
                {
                    return;
                }

                Models.FileListItemModel tempModel = new Models.FileListItemModel()
                {
                    Name = directoryInfo.Name,
                    CreateTime = directoryInfo.CreationTime.ToString(),
                    Size = " ",
                    CurrentType = Defines.CurrentType.文件夹,
                    CurrentDirectory = directoryInfo.FullName,
                    Icon = Utils.DirectoryUtil.GetDefaultFolderIcon(),
                    FileExtension = ".",
                    ParentDirectory = directoryInfo.Parent.FullName
                };
                fileListViewModel.OpenCurrentDirectory.Execute(tempModel);
            }
        }
    }
}
