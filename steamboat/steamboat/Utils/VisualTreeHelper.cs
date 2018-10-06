using System.Windows;
using System.Windows.Media;

namespace steamboat.Utils
{
    public static class VisualTreeHelpers
    {
        public static T FindParent<T>(DependencyObject dependencyObject) where T : FrameworkElement
        {
            var parent = VisualTreeHelper.GetParent(dependencyObject);
            while (parent != null)
            {
                if (parent is T result)
                {
                    return result;
                }

                parent = VisualTreeHelper.GetParent(parent);
            }

            return null;
        }
    }
}