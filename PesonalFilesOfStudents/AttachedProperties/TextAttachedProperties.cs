using System.Windows;
using System.Windows.Controls;

namespace PesonalFilesOfStudents
{
    /// <summary>
    /// Focuses (keyboard focus) this element on load
    /// </summary>
    public class IsFocusedProperty : BaseAttachedProperty<IsFocusedProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // If we don't have a control, return
            var control = new Control();
            if (!(sender is Control))
                return;

            // Focus this control once loaded
            control.Loaded += (s, se) => control.Focus();
        }
    }
}
