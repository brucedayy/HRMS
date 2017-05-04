using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace HRMS
{

    public class UIHelper
    {
        /// <summary>
        /// 在Visual里找到想要的元素
        /// childName可为空，不为空就按名字找
        /// </summary>
        public static T FindChild<T>(DependencyObject parent, string childName)
           where T : DependencyObject
        {
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                T childType = child as T;
                if (childType == null)
                {
                    // 住下查要找的元素
                    foundChild = FindChild<T>(child, childName);

                    // 如果找不到就反回
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // 看名字是不是一样
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        //如果名字一样返回
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // 找到相应的元素了就返回 
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }

        /// <summary>
        /// 得到指定元素的集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="depObj"></param>
        /// <returns></returns>
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj)
            where T : DependencyObject
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
    }


    public class FocusAdvancement
    {
        public static bool GetAdvancesByEnterKey(DependencyObject obj)
        {
            return (bool)obj.GetValue(AdvancesByEnterKeyProperty);
        }

        public static void SetAdvancesByEnterKey(DependencyObject obj, bool value)
        {
            obj.SetValue(AdvancesByEnterKeyProperty, value);
        }

        public static readonly DependencyProperty AdvancesByEnterKeyProperty =
            DependencyProperty.RegisterAttached("AdvancesByEnterKey", typeof(bool), typeof(FocusAdvancement),
            new UIPropertyMetadata(OnAdvancesByEnterKeyPropertyChanged));

        static void OnAdvancesByEnterKeyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as UIElement;
            if (element == null) return;

            if ((bool)e.NewValue) element.KeyDown += Keydown;
            else element.KeyDown -= Keydown;
        }

        static void Keydown(object sender, KeyEventArgs e)
        {
            if (!e.Key.Equals(Key.Enter)) return;

            var element = sender as UIElement;

            if (element != null) element.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        }

    }
}
