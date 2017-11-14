using System;
using System.Windows;
using System.Windows.Controls;

namespace PesonalFilesOfStudents
{
    /// <summary>
    /// Match label width of all text entry controls inside this panel
    /// </summary>
    public class TextEntryWidthMatcherProperty : BaseAttachedProperty<TextEntryWidthMatcherProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Get the panel (grid typically)
            var panel = (sender as Panel);

            // Call SetWidths initially (this also helps design time to work)
            SetWidths(panel);

            // Wait for panel to load
            RoutedEventHandler onLoaded = null;
            onLoaded = (s, ee) =>
            {
                // Unhook
                panel.Loaded -= onLoaded;

                // Set widths
                SetWidths(panel);

                // Loop each child 
                foreach (var child in panel.Children)
                {
                    // Ignore any non-text entry controls
                    if(!(child is TextEntryControl))
                        continue;

                    var control = (TextEntryControl) child;

                    // Set it's margin to the given value
                    control.Label.SizeChanged += (ss, eee) =>
                    {
                        // Update widths
                        SetWidths(panel);
                    };
                }
            };

            // Hook into the Loaded event
            panel.Loaded += onLoaded;

        }

        /// <summary>
        /// Update all child text entry controls so their widths match the largest width of the group
        /// </summary>
        /// <param name="panel">The panel containing the next entry controls</param>
        private void SetWidths(Panel panel)
        {
            // Keep track of the maximum width
            var maxSize = 0d;

            // For each child
            foreach (var child in panel.Children)
            {
                // Ignore any non-text entry controls
                if (!(child is TextEntryControl))
                    continue;

                // Find if tthis value is lagrder than the other controls
                var control = (TextEntryControl)child;
                maxSize = Math.Max(maxSize,
                     control.Label.RenderSize.Width + control.Label.Margin.Left + control.Label.Margin.Right);
            }

            // Create a grid length covnerter
            var gridLength = (GridLength) new GridLengthConverter().ConvertFromString(maxSize.ToString());

            // For each child...
            foreach (var child in panel.Children)
            {
                // Ignore any non-text entry controls
                if (!(child is TextEntryControl))
                    continue;

                // Set each controls LabelWidth value to the max size
                var control = (TextEntryControl) child;
                control.LabelWidth = gridLength;
            }
        }
    }
}
