using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Pravoslavni_Crkveni_Kalendar.Properties;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const string Serbocroatian = "sr-Latn-RS";
        public const string German = "de-DE";
        public MainWindow()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Serbocroatian);
            langDE.MouseDown += LangDE_MouseDown;
            langYU.MouseDown += LangYU_MouseDown;
            langDE.ToolTip = strings.ToolTipGerman;
            langYU.ToolTip = strings.ToolTipSerboCroatian;
            langTitle.Text = strings.LanguageTitle;
            langTitle.Margin = new Thickness(12, 0, 0, 0);
            Title = strings.ApplicationTitle;
            aboutButton.Content = strings.AboutButton;
            buyButton.Content= strings.BuyButton;
            CreateCardEntries();

        }
        /// <summary>
        /// Occurs when German flag gets clicked, that makes sure the cultureinfo gets changed and all the buttons have the right dimensions to fit the new text based on language.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LangDE_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Thread.CurrentThread.CurrentUICulture != CultureInfo.GetCultureInfo(German))
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(German);
                langTitle.Text = strings.LanguageTitle;
                langDE.ToolTip = strings.ToolTipGerman;
                langYU.ToolTip = strings.ToolTipSerboCroatian;
                Title = strings.ApplicationTitle;
                aboutButton.Content = strings.AboutButton;
                aboutButton.Width = 125;
                buyButton.Content = strings.BuyButton;
                buyButton.Width = 165;
                buyButton.Margin = new Thickness(50, 0, 0, 0);
                UpdateHolidayText();
            }
        }
        /// <summary>
        /// Occurs when Yugoslav flag gets clicked, that makes sure the cultureinfo gets changed and all the buttons have the right dimensions to fit the new text based on language.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LangYU_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Thread.CurrentThread.CurrentUICulture != CultureInfo.GetCultureInfo(Serbocroatian))
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Serbocroatian);
                langTitle.Text = strings.LanguageTitle;
                langDE.ToolTip = strings.ToolTipGerman;
                langYU.ToolTip = strings.ToolTipSerboCroatian;
                Title = strings.ApplicationTitle;
                aboutButton.Content = strings.AboutButton;
                aboutButton.Width = 86;
                buyButton.Content = strings.BuyButton;
                buyButton.Width = 152;
                buyButton.Margin = new Thickness(0, 0, 0, 0);
                UpdateHolidayText();
                langTitle.Margin = new Thickness(12, 0, 0, 0);
            }
        }

        /// <summary>
        /// Creates all calendar entries and assigns their respective dates and description strings to them.
        /// </summary>
        private void CreateCardEntries()
        {
            CardEntry cardEntry14 = new CardEntry(this, new DateTime(DateTime.Now.Year, 01, 02), XmlLanguage.GetLanguage(Serbocroatian), "Sveti Ignjatije", strings.SvetiIgnjatijeDesc);
            CardEntry cardEntry15 = new CardEntry(this, new DateTime(DateTime.Now.Year, 01, 09), XmlLanguage.GetLanguage(Serbocroatian), "Sveti Stefan", strings.SvetiStefanDesc);
            CardEntry cardEntry16 = new CardEntry(this, new DateTime(DateTime.Now.Year, 01, 16), XmlLanguage.GetLanguage(Serbocroatian), "Sveti Vasilije Veliki", strings.SvetiVasilijeVelikiDesc);
            CardEntry cardEntry11 = new CardEntry(this, new DateTime(DateTime.Now.Year, 01, 20), XmlLanguage.GetLanguage(Serbocroatian), "Sveti Jovan", strings.SvetiJovanDesc);
            CardEntry cardEntry1 = new CardEntry(this, new DateTime(DateTime.Now.Year, 01, 27), XmlLanguage.GetLanguage(Serbocroatian), "Sveti Sava", strings.SvetogSaveDesc);
            CardEntry cardEntry17 = new CardEntry(this, new DateTime(DateTime.Now.Year, 01, 29), XmlLanguage.GetLanguage(Serbocroatian), "Sveti Apostol Petar", strings.SvetiApostolPetarDesc);
            CardEntry cardEntry18 = new CardEntry(this, new DateTime(DateTime.Now.Year, 02, 12), XmlLanguage.GetLanguage(Serbocroatian), "Sveta Tri jerarha", strings.SvetiTriJerarhaDesc);
            CardEntry cardEntry19 = new CardEntry(this, new DateTime(DateTime.Now.Year, 02, 14), XmlLanguage.GetLanguage(Serbocroatian), "Sveti Trifun", strings.SvetiTrifunDesc);
            CardEntry cardEntry20 = new CardEntry(this, new DateTime(DateTime.Now.Year, 03, 22), XmlLanguage.GetLanguage(Serbocroatian), "Svetih 40 mučenika", strings.Svetih40mucenikaDesc);
            CardEntry cardEntry21 = new CardEntry(this, new DateTime(DateTime.Now.Year, 04, 07), XmlLanguage.GetLanguage(Serbocroatian), "Blagovesti", strings.BlagovestiDesc);
            CardEntry cardEntry22 = new CardEntry(this, new DateTime(DateTime.Now.Year, 04, 08), XmlLanguage.GetLanguage(Serbocroatian), "Lazareva subota", strings.LazarevaSubotaDesc);
            CardEntry cardEntry9 = new CardEntry(this, new DateTime(DateTime.Now.Year, 05, 06), XmlLanguage.GetLanguage(Serbocroatian), "Sveti Georgije", strings.SvetiGeorgijeDesc);
            CardEntry cardEntr24 = new CardEntry(this, new DateTime(DateTime.Now.Year, 05, 08), XmlLanguage.GetLanguage(Serbocroatian), "Sveti Marko", strings.SvetiMarkoDesc);
            CardEntry cardEntry6 = new CardEntry(this, new DateTime(DateTime.Now.Year, 05, 12), XmlLanguage.GetLanguage(Serbocroatian), "Sveti Vasilije", strings.SvetiVasilijeDesc);
            CardEntry cardEntry25 = new CardEntry(this, new DateTime(DateTime.Now.Year, 06, 28), XmlLanguage.GetLanguage(Serbocroatian), "Sveti Knez Lazar", strings.SvetiKnezLazarDesc);
            CardEntry cardEntry26 = new CardEntry(this, new DateTime(DateTime.Now.Year, 07, 07), XmlLanguage.GetLanguage(Serbocroatian), "Rođenje Svetog Jovana Krstitelja", strings.KrstiteljaDesc);
            CardEntry cardEntry8 = new CardEntry(this, new DateTime(DateTime.Now.Year, 07, 12), XmlLanguage.GetLanguage(Serbocroatian), "Sveti apostoli Petar i Pavle", strings.PavlovdanDesc);
            CardEntry cardEntry27 = new CardEntry(this, new DateTime(DateTime.Now.Year, 07, 30), XmlLanguage.GetLanguage(Serbocroatian), "Sveta velikomučenica Marina", strings.MarinaDesc);
            CardEntry cardEntry4 = new CardEntry(this, new DateTime(DateTime.Now.Year, 08, 02), XmlLanguage.GetLanguage(Serbocroatian), "Sveti Ilija", strings.SvetiIlijaDesc);
            CardEntry cardEntry28 = new CardEntry(this, new DateTime(DateTime.Now.Year, 08, 04), XmlLanguage.GetLanguage(Serbocroatian), "Sveta Marija Magdalena", strings.SvetaMarijaDesc);
            CardEntry cardEntry29 = new CardEntry(this, new DateTime(DateTime.Now.Year, 08, 08), XmlLanguage.GetLanguage(Serbocroatian), "Sveta mučenica Paraskeva", strings.SvetaParaskevaDesc);
            CardEntry cardEntry30 = new CardEntry(this, new DateTime(DateTime.Now.Year, 08, 09), XmlLanguage.GetLanguage(Serbocroatian), "Sveti Pantelejmon", strings.SvetiPanteljmonDesc);
            CardEntry cardEntry31 = new CardEntry(this, new DateTime(DateTime.Now.Year, 08, 19), XmlLanguage.GetLanguage(Serbocroatian), "Preobraženje Gospodnje", strings.PreobrazenjeDesc);
            CardEntry cardEntry32 = new CardEntry(this, new DateTime(DateTime.Now.Year, 08, 28), XmlLanguage.GetLanguage(Serbocroatian), "Uspenje presvete Bogorodice", strings.BogorodiceDesc);
            CardEntry cardEntry33 = new CardEntry(this, new DateTime(DateTime.Now.Year, 09, 11), XmlLanguage.GetLanguage(Serbocroatian), "Usekovanje glave Sv. Jovana Krstitelja", strings.UsekovanjeDesc);
            CardEntry cardEntry34 = new CardEntry(this, new DateTime(DateTime.Now.Year, 09, 21), XmlLanguage.GetLanguage(Serbocroatian), "Rođenje presvete Bogorodice", strings.RodjenjeDesc);
            CardEntry cardEntry35 = new CardEntry(this, new DateTime(DateTime.Now.Year, 09, 27), XmlLanguage.GetLanguage(Serbocroatian), "Krstovdan", strings.KrstovdanDesc);
            CardEntry cardEntry36 = new CardEntry(this, new DateTime(DateTime.Now.Year, 10, 12), XmlLanguage.GetLanguage(Serbocroatian), "Sveti Kirijak", strings.SvetiKirijakDesc);
            CardEntry cardEntry5 = new CardEntry(this, new DateTime(DateTime.Now.Year, 10, 14), XmlLanguage.GetLanguage(Serbocroatian), "Presvete Bogorodice", strings.PresveteBogorodiceDesc);
            CardEntry cardEntry37 = new CardEntry(this, new DateTime(DateTime.Now.Year, 10, 19), XmlLanguage.GetLanguage(Serbocroatian), "Sveti apostol Toma", strings.SvetiTomaDesc);
            CardEntry cardEntry38 = new CardEntry(this, new DateTime(DateTime.Now.Year, 10, 20), XmlLanguage.GetLanguage(Serbocroatian), "Srđevdan", strings.SrdevdanDesc);
            CardEntry cardEntry2 = new CardEntry(this, new DateTime(DateTime.Now.Year, 10, 27), XmlLanguage.GetLanguage(Serbocroatian), "Sveta Petka", strings.SvetaPetkaDesc);
            CardEntry cardEntry10 = new CardEntry(this, new DateTime(DateTime.Now.Year, 10, 31), XmlLanguage.GetLanguage(Serbocroatian), "Sveti Luka", strings.SvetiLukaDesc);
            CardEntry cardEntry12 = new CardEntry(this, new DateTime(DateTime.Now.Year, 11, 08), XmlLanguage.GetLanguage(Serbocroatian), "Sveti Dimitrije", strings.SvetiDimitrijeDesc);
            CardEntry cardEntry39 = new CardEntry(this, new DateTime(DateTime.Now.Year, 11, 16), XmlLanguage.GetLanguage(Serbocroatian), "Sveti Georgije - Đurđic", strings.DurdicDesc);
            CardEntry cardEntry3 = new CardEntry(this,new DateTime(DateTime.Now.Year, 11, 21), XmlLanguage.GetLanguage(Serbocroatian), "Sveti Arhangel", strings.SvetiArandjelDesc);
            CardEntry cardEntry13 = new CardEntry(this, new DateTime(DateTime.Now.Year, 11, 22), XmlLanguage.GetLanguage(Serbocroatian), "Sveti Nektarije", strings.SvetiNektarijeDesc);
            CardEntry cardEntry40 = new CardEntry(this, new DateTime(DateTime.Now.Year, 11, 24), XmlLanguage.GetLanguage(Serbocroatian), "Sveti Stefan Dečanski", strings.SvetiStefanDecanskiDesc);
            CardEntry cardEntry41 = new CardEntry(this, new DateTime(DateTime.Now.Year, 12, 04), XmlLanguage.GetLanguage(Serbocroatian), "Vavedenje presvete Bogorodice", strings.VavedenjeDesc);
            CardEntry cardEntry42 = new CardEntry(this, new DateTime(DateTime.Now.Year, 12, 09), XmlLanguage.GetLanguage(Serbocroatian), "Sveti Alimpije Stolpnik", strings.SvetiAlimpijeDesc);
            CardEntry cardEntry7 = new CardEntry(this, new DateTime(DateTime.Now.Year, 12, 19), XmlLanguage.GetLanguage(Serbocroatian), "Sveti Nikola", strings.SvetiNikolaDesc);
        }
        /// <summary>
        /// Based on the name of the holiday, gets specific description string.
        /// </summary>
        private void UpdateHolidayText()
        {
            for (int i=0; i < mainCanvas.Children.OfType<CardEntry>().Count()  ; i++)
            {
                mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescriptionTitle.Text = strings.DescriptionTitle;
                mainCanvas.Children.OfType<CardEntry>().ElementAt(i).Language = XmlLanguage.GetLanguage(Thread.CurrentThread.CurrentUICulture.Name);
                switch (mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayTitle.Text)
                {
                    case "Sveta Petka":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetaPetkaDesc;
                        break;
                    case "Dan Svetog Save":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetogSaveDesc;
                        break;
                    case "Sveti Arhangel":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetiArandjelDesc;
                        break;
                    case "Sveti Ilija":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetiIlijaDesc;
                        break;
                    case "Presvete Bogorodice":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.PresveteBogorodiceDesc;
                        break;
                    case "Sveti Nikola":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetiNikolaDesc;
                        break;
                    case "Sveti Vasilije":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetiVasilijeDesc;
                        break;
                    case "Sveti apostoli Petar i Pavle":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.PavlovdanDesc;
                        break;
                    case "Sveti Georgije":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetiGeorgijeDesc;
                        break;
                    case "Sveti Luka":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetiLukaDesc;
                        break;
                    case "Sveti Jovan":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetiJovanDesc;
                        break;
                    case "Sveti Dimitrije":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetiDimitrijeDesc;
                        break;
                    case "Sveti Nektarije":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetiNektarijeDesc;
                        break;
                    case "Sveti Stefan":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetiStefanDesc;
                        break;
                    case "Sveti Ignjatije":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetiIgnjatijeDesc;
                        break;
                    case "Sveti Vasilije Veliki":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetiVasilijeVelikiDesc;
                        break;
                    case "Sveti Apostol Petar":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetiApostolPetarDesc;
                        break;
                    case "Sveta Tri jerarha":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetiTriJerarhaDesc;
                        break;
                    case "Sveti Trifun":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetiTrifunDesc;
                        break;
                    case "Svetih 40 mučenika":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.Svetih40mucenikaDesc;
                        break;
                    case "Blagovesti":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.BlagovestiDesc;
                        break;
                    case "Lazareva Subota":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.LazarevaSubotaDesc;
                        break;
                    case "Sveti Marko":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetiMarkoDesc;
                        break;
                    case "Sveti Knez Lazar":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetiKnezLazarDesc;
                        break;
                    case "Rođenje Svetog Jovana Krstitelja":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.KrstiteljaDesc;
                        break;
                    case "Sveta velikomučenica Marina":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.KrstiteljaDesc;
                        break;
                    case "Sveta Marija Magdalena":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetaMarijaDesc;
                        break;
                    case "Sveta mučenica Paraskeva":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetaParaskevaDesc;
                        break;
                    case "Sveti Panteljmon":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetiPanteljmonDesc;
                        break;
                    case "Preobraženje Gospodnje":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.PreobrazenjeDesc;
                        break;
                    case "Uspenje presvete Bogorodice":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.BogorodiceDesc;
                        break;
                    case "Usekovanje glave Sv.Jovana Krstitelja":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.UsekovanjeDesc;
                        break;
                    case "Rođenje presvete Bogorodice":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.RodjenjeDesc;
                        break;
                    case "Krstovdan":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.KrstovdanDesc;
                        break;
                    case "Sveti Kirijak":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetiKirijakDesc;
                        break;
                    case "Sveti apostol Toma":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetiTomaDesc;
                        break;
                    case "Srđevdan":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SrdevdanDesc;
                        break;
                    case "Sveti Georgije - Đurđic":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.DurdicDesc;
                        break;
                    case "Sveti Stefan Dečanski":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetiStefanDecanskiDesc;
                        break;
                    case "Vavedenje presvete Bogorodice":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.VavedenjeDesc;
                        break;
                    case "Sveti Alimpije Stolpnik":
                        mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescription.Text = strings.SvetiAlimpijeDesc;
                        break;
                }
            }
        }
        /// <summary>
        /// Shows message box with text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Made by Dorian Nebojsa Stanojevic 2023 - doriannebojsa.com", strings.AboutButton );
        }
        /// <summary>
        /// Opens website in Microsoft Edge.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buyButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("msedge")
            {
                UseShellExecute = true,
                Arguments = "http://uslavigospodu.shop"
            });
        }
    }


}
