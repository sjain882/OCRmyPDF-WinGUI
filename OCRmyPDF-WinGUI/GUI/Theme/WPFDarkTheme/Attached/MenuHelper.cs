using System.Windows;

namespace FramePFX.Themes.Attached
{
    public static class MenuHelper
    {
        public static readonly DependencyProperty UseStretchedContentProperty = 
            DependencyProperty.RegisterAttached(
                "UseStretchedContent", 
                typeof(bool), 
                typeof(MenuHelper), 
                new PropertyMetadata(false));

        public static void SetUseStretchedContent(DependencyObject element, bool value) => element.SetValue(UseStretchedContentProperty, value);

        public static bool GetUseStretchedContent(DependencyObject element) => (bool)element.GetValue(UseStretchedContentProperty);
    }
}