using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace QuanLyDonHang
{
    public class Utilities
    {
        private DependencyObject FindParent<T>(DependencyObject child)where T : DependencyObject
        {
            if (child == null) return null;
            var parent = VisualTreeHelper.GetParent(child);
            return parent as T ?? FindParent<T>(parent);
        }

        public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public static DependencyObject FindChildControl<T>(DependencyObject control)
        {
            DependencyObject child = null;
            int childNumber = VisualTreeHelper.GetChildrenCount(control);
            for (int i = 0; i < childNumber; i++)
            {
                child = VisualTreeHelper.GetChild(control, i);
                if (child != null && child is T)
                {
                     break;
                }
                else
                {
                    DependencyObject childRecur = FindChildControl<T>(child);
                    if (childRecur != null)
                    {
                        child = childRecur;
                        break;
                    }
                        

                }
            }
            return child;
        }

        public static void SelectCombobox(ComboBox combobox, string item)
        {
            for (int i = 0; i < combobox.Items.Count; i++)
            {
                if (combobox.Items[i].ToString().Equals(item))
                {
                    combobox.SelectedIndex = i;
                    break;
                }
            }
        }
    }
}
