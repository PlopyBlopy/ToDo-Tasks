using System.Windows.Media;
using System.Windows;

namespace TDT.Helpers
{
    public static class FindVisualChildHlp
    {
        public static T FindVisualChild<T>(DependencyObject depObj, string name) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    var child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T && ((FrameworkElement)child).Name == name)
                    {
                        return (T)child;
                    }

                    var childItem = FindVisualChild<T>(child, name);
                    if (childItem != null)
                    {
                        return childItem;
                    }
                }
            }
            return null;
        }
    }
}