using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;

namespace ToDoTask.Behaviors
{
    public class FocusBehavior : Behavior<TextBox>
    {
        public static readonly DependencyProperty IsFocusedProperty =
            DependencyProperty.Register("IsFocused", typeof(bool), typeof(FocusBehavior), new PropertyMetadata(false));

        public bool IsFocused
        {
            get { return (bool)GetValue(IsFocusedProperty); }
            set { SetValue(IsFocusedProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.GotFocus += OnGotFocus;
            AssociatedObject.LostFocus += OnLostFocus;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.GotFocus -= OnGotFocus;
            AssociatedObject.LostFocus -= OnLostFocus;
        }

        private void OnGotFocus(object sender, RoutedEventArgs e)
        {
            IsFocused = true;
        }

        private void OnLostFocus(object sender, RoutedEventArgs e)
        {
            IsFocused = false;
        }
    }
}