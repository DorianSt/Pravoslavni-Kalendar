using System.Linq;
using System.Windows.Controls;
using System.Windows;

namespace WpfApp1
{

    public class CustomCanvas : Canvas
    {
        /// <summary>
        /// Override of the original OnVisualChildrenChanged function, to allow the parentGrid to be expanded by 250 each time a new CardEntry gets created and add 250 top margin, in order to make it visible.
        /// 
        /// </summary>
        /// <param name="visualAdded"></param>
        /// <param name="visualRemoved"></param>
        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            Grid parentGrid = (Grid)Parent;
            if (visualAdded != null && visualAdded.GetType() == typeof(CardEntry) )
            {
                CardEntry cE = (CardEntry)visualAdded;
                CustomCanvas mainCanvas = parentGrid.Children[0] as CustomCanvas;
                // Make sure that all CardEntries except first one trigger parentGrid to be increased by 250 and allow new created CardEntry to be 250 pixels below last one.
                if (mainCanvas.Children.OfType<CardEntry>().Count() > 1 && cE.HolidayTitle != null)
                {
                    parentGrid.Height += 250;
                    int lastCardEntryIndex = mainCanvas.Children.OfType<CardEntry>().Count() -2; 
                    double previousCardEntryTop = mainCanvas.Children.OfType<CardEntry>().ElementAt(lastCardEntryIndex).Margin.Top;
                    cE.Margin = new Thickness(0, previousCardEntryTop + 250, 0, 0);
                }
            }
        }
    }
}
