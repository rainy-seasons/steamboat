using System.Windows;
using System.Windows.Media;

namespace Steamboat.Utils
{
    public static class VisualTreeHelpers
    {
        public static T FindParent<T>(DependencyObject dependencyObject) where T : FrameworkElement
        {
            var parent = VisualTreeHelper.GetParent(dependencyObject);
            while (parent != null)
            {
                if (parent is T)
                {
                    return (T)parent;
                }

                parent = VisualTreeHelper.GetParent(parent);
            }

            return null;
        }
    }
}