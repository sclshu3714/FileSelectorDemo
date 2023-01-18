using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FileSelectorDemo.Converters
{
    public class CollectionSelectedCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ObservableCollection<Models.FileListItemModel>)
            {
                var collection = value as ObservableCollection<Models.FileListItemModel>;
                if (null != collection && collection.Count > 0)
                {
                    int count = 0;
                    foreach (var item in collection)
                    {
                        if (item.IsSelected)
                        {
                            count++;
                        }
                    }
                    return count;
                }
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class CollectionSelectedSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ObservableCollection<Models.FileListItemModel>)
            {
                var collection = value as ObservableCollection<Models.FileListItemModel>;
                if (null != collection && collection.Count > 0)
                {
                    double size = 0;
                    foreach (var item in collection)
                    {
                        if (item.IsSelected)
                        {
                            FileInfo info = new FileInfo(item.CurrentDirectory);
                            size += info.Length;
                        }
                    }
                    if(size == 0) return "";
                    return $"   {Utils.DirectoryUtil.GetCurrentLengthWithUnit(size)}";
                }
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
