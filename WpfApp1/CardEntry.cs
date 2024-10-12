using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using Pravoslavni_Crkveni_Kalendar.Properties;


namespace WpfApp1
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CardEntry : Grid
    {
        private DateTime _date;
        private TextBlock _holidayTitle;
        private TextBlock _holidayDescriptionTitle;
        private TextBox _holidayDescription;
        private Calendar _holidayCalendar;
        private XmlLanguage _language;
        
         public CardEntry(MainWindow mainWindow, DateTime date, XmlLanguage language, string holidayTitleText, string holidayDescriptionText)
        {
            if (DateTime.Now.Month < date.Month || DateTime.Now.Month == date.Month && DateTime.Now.Day <= date.Day )
            {
                ColumnDefinitions.Add(new ColumnDefinition { });
                ColumnDefinitions.Add(new ColumnDefinition { });
                RowDefinitions.Add(new RowDefinition { });
                TextBlock holidayDescriptionTitle = new TextBlock();
                TextBlock holidayTitle = new TextBlock();
                TextBox holidayDescription = new TextBox();
                Calendar holidayCalendar = new Calendar();
                Date = date;
                holidayCalendar.Focusable = false;
                holidayCalendar.GotFocus += HolidayCalendar_GotFocus;
                holidayTitle.FontWeight = FontWeights.Bold;
                holidayTitle.HorizontalAlignment = HorizontalAlignment.Center;
                holidayTitle.VerticalAlignment = VerticalAlignment.Top;
                holidayTitle.FontSize = 18;
                holidayTitle.Text = holidayTitleText;
                holidayDescriptionTitle.Text = strings.DescriptionTitle;
                HolidayTitle = holidayTitle;
                holidayCalendar.SelectedDate = date;
                holidayCalendar.DisplayDate = date;
                holidayCalendar.DisplayDateEnd = date;
                holidayCalendar.DisplayDateStart = date;
                holidayCalendar.VerticalAlignment = VerticalAlignment.Top;
                holidayCalendar.HorizontalAlignment = HorizontalAlignment.Center;
                holidayCalendar.Height = 166;
                holidayCalendar.Margin = new Thickness(0, 26, 0, 0);
                holidayDescriptionTitle.FontWeight = FontWeights.Bold;
                holidayDescriptionTitle.HorizontalAlignment = HorizontalAlignment.Center;
                holidayDescriptionTitle.VerticalAlignment = VerticalAlignment.Top;
                holidayDescriptionTitle.FontSize = 18;
                HolidayDescriptionTitle = holidayDescriptionTitle;
                HolidayCalendar = holidayCalendar;
                holidayDescription.Text = holidayDescriptionText;
                holidayDescription.IsReadOnly = true;
                holidayDescription.HorizontalAlignment = HorizontalAlignment.Center;
                holidayDescription.Margin = new Thickness(15, 30, 40, 30);
                holidayDescription.VerticalAlignment = VerticalAlignment.Top;
                holidayDescription.Height = 152;
                holidayDescription.MinWidth = 250;
                holidayDescription.TextWrapping = TextWrapping.Wrap;
                holidayDescription.FontSize = 14;
                HolidayDescription = holidayDescription;
                Language = language;
                Width = 751;
                VerticalAlignment = VerticalAlignment.Top;
                HorizontalAlignment = HorizontalAlignment.Center;
                Brush bg = new SolidColorBrush(Color.FromRgb(241, 241, 241));
                Brush opacityMask = new SolidColorBrush(Color.FromRgb(218, 218, 218));
                opacityMask.Opacity = 0.88;
                Background = bg;
                OpacityMask = opacityMask;
                SetColumn(HolidayTitle, 0);
                Children.Add(HolidayTitle);
                SetColumn(HolidayCalendar, 0);
                Children.Add(HolidayCalendar);
                SetColumn(HolidayDescriptionTitle, 1);
                Children.Add(HolidayDescriptionTitle);
                SetColumn(HolidayDescription, 1);
                Children.Add(HolidayDescription);
                Margin = new Thickness(0, 125, 0, 0);
                mainWindow.mainCanvas.Children.Add(this);
            }

        }

        private void HolidayCalendar_GotFocus(object sender, RoutedEventArgs e)
        {
            Window mainWindow = Application.Current.MainWindow;
            mainWindow.Focus();
            mainWindow.Activate();

        }

        public Calendar HolidayCalendar
        {
            set { _holidayCalendar = value; }
            get { return _holidayCalendar; }
        }

        public TextBlock HolidayTitle
        {
            set { _holidayTitle = value; }
            get { return _holidayTitle; }
        }

        public TextBox HolidayDescription
        {
            set { _holidayDescription = value; }
            get { return _holidayDescription; }
        }

        public XmlLanguage Language
        {
            set 
            {
                _language = value;
                HolidayCalendar.Language = value; 
                HolidayDescription.Language = value;
                HolidayDescriptionTitle.Language = value;
                HolidayTitle.Language = value;
            }
            get { return _language; }
        }

        public TextBlock HolidayDescriptionTitle
        {
            set { _holidayDescriptionTitle = value; }
            get { return _holidayDescriptionTitle; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

    }
}
