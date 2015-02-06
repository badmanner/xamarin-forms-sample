using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SharedApp.Views
{
    class TaskCell : ViewCell
    {
        public TaskCell()
        {
            var text = new Label
            {
                YAlign = TextAlignment.Center
            };

            text.SetBinding(Label.TextProperty, "taskText");

            

            var layout = new StackLayout
            {
                Padding = new Thickness(20, 0, 0, 0),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { text }
            };
            View = layout;
        }
    }
}
