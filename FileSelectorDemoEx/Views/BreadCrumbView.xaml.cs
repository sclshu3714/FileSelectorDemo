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
            }
        }

        /// <summary>
        /// 编辑模式结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEndEditPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.OriginalSource is TextBox txtBox && txtBox.TemplatedParent is CheckBox checkBox && 
                checkBox.Template.LoadContent() is Border border && border.Name == "border" && border.FindName("bcvItemsControl") is ItemsControl control && control.FindName("toggleBtnFolder") is ToggleButton toggle)
            {
                toggle.IsChecked = false;
                this.UpdateLayout();
            }
        }
    }
}
