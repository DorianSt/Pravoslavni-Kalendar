using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using Pravoslavni_Crkveni_Kalendar.Properties;
using System.Reflection;
using System.Net;
using System.IO;
using System.Text;
using Pravoslavni_Crkveni_Kalendar;
using static Pravoslavni_Crkveni_Kalendar.Properties.strings;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string Serbocroatian = "sr-Latn-RS";
        private const string German = "de-DE";
        private string currentLanguage;
        private string appVersion = Convert.ToString(Assembly.GetEntryAssembly().GetName().Version);
        private string browserPath = CurrentBrowserGetter.GetBrowserPath();
        private const string Url = "https://doriannebojsa.com";
        public MainWindow()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Serbocroatian);
            CheckAndUpdateVersion();
            InitializeComponent();
            currentLanguage = Thread.CurrentThread.CurrentUICulture.Name;
            langDE.MouseDown += LangDE_Click;
            langYU.MouseDown += LangYU_Click;
            this.Focusable = true;
            langDE.ToolTip = strings.ToolTipGerman;
            langYU.ToolTip = strings.ToolTipSerboCroatian;
            langTitle.Text = strings.LanguageTitle;
            langTitle.Margin = new Thickness(12, 0, 0, 0);
            Title = strings.ApplicationTitle;
            aboutButton.Content = strings.AboutButton;
            buyButton.Content= strings.BuyButton;
            CreateCardEntries();



        }
        /// <summary>Occurs when german flag gets clicked, that makes sure the cultureinfo gets changed and all the buttons have the right dimensions to fit the new text based on language.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LangDE_Click(object sender, MouseButtonEventArgs e)
        {
            if (Thread.CurrentThread.CurrentUICulture != CultureInfo.GetCultureInfo(German))
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(German);
                currentLanguage = German;
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
        /// <summary>Occurs when yugoslav flag gets clicked, that makes sure the cultureinfo gets changed and all the buttons have the right dimensions to fit the new text based on language.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LangYU_Click(object sender, MouseButtonEventArgs e)
        {
            if (Thread.CurrentThread.CurrentUICulture != CultureInfo.GetCultureInfo(Serbocroatian))
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Serbocroatian);
                currentLanguage = Serbocroatian;
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

        /// <summary>Creates all calendar entries and assigns their respective dates and description strings to them.</summary>
        private void CreateCardEntries()
        {
            new CardEntry(this, new DateTime(DateTime.Now.Year, 01, 02), XmlLanguage.GetLanguage(currentLanguage), "Sveti Ignjatije", strings.SvetiIgnjatijeDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 01, 02), XmlLanguage.GetLanguage(currentLanguage), "Sveti Ignjatije", strings.SvetiIgnjatijeDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 01, 09), XmlLanguage.GetLanguage(currentLanguage), "Sveti Stefan", strings.SvetiStefanDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 01, 16), XmlLanguage.GetLanguage(currentLanguage), "Sveti Vasilije Veliki", strings.SvetiVasilijeVelikiDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 01, 20), XmlLanguage.GetLanguage(currentLanguage), "Sveti Jovan", strings.SvetiJovanDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 01, 27), XmlLanguage.GetLanguage(currentLanguage), "Sveti Sava", strings.SvetogSaveDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 01, 29), XmlLanguage.GetLanguage(currentLanguage), "Sveti Apostol Petar", strings.SvetiApostolPetarDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 02, 12), XmlLanguage.GetLanguage(currentLanguage), "Sveta Tri jerarha", strings.SvetiTriJerarhaDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 02, 14), XmlLanguage.GetLanguage(currentLanguage), "Sveti Trifun", strings.SvetiTrifunDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 03, 22), XmlLanguage.GetLanguage(currentLanguage), "Svetih 40 mučenika", strings.Svetih40mucenikaDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 04, 07), XmlLanguage.GetLanguage(currentLanguage), "Blagovesti", strings.BlagovestiDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 04, 08), XmlLanguage.GetLanguage(currentLanguage), "Lazareva subota", strings.LazarevaSubotaDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 05, 06), XmlLanguage.GetLanguage(currentLanguage), "Sveti Georgije", strings.SvetiGeorgijeDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 05, 08), XmlLanguage.GetLanguage(currentLanguage), "Sveti Marko", strings.SvetiMarkoDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 05, 12), XmlLanguage.GetLanguage(currentLanguage), "Sveti Vasilije", strings.SvetiVasilijeDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 06, 28), XmlLanguage.GetLanguage(currentLanguage), "Sveti Knez Lazar", strings.SvetiKnezLazarDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 07, 07), XmlLanguage.GetLanguage(currentLanguage), "Rođenje Svetog Jovana Krstitelja", strings.KrstiteljaDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 07, 12), XmlLanguage.GetLanguage(currentLanguage), "Sveti apostoli Petar i Pavle", strings.PavlovdanDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 07, 30), XmlLanguage.GetLanguage(currentLanguage), "Sveta velikomučenica Marina", strings.MarinaDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 08, 02), XmlLanguage.GetLanguage(currentLanguage), "Sveti Ilija", strings.SvetiIlijaDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 08, 04), XmlLanguage.GetLanguage(currentLanguage), "Sveta Marija Magdalena", strings.SvetaMarijaDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 08, 08), XmlLanguage.GetLanguage(currentLanguage), "Sveta mučenica Paraskeva", strings.SvetaParaskevaDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 08, 09), XmlLanguage.GetLanguage(currentLanguage), "Sveti Pantelejmon", strings.SvetiPanteljmonDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 08, 19), XmlLanguage.GetLanguage(currentLanguage), "Preobraženje Gospodnje", strings.PreobrazenjeDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 08, 28), XmlLanguage.GetLanguage(currentLanguage), "Uspenje presvete Bogorodice", strings.BogorodiceDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 09, 11), XmlLanguage.GetLanguage(currentLanguage), "Usekovanje glave Sv. Jovana Krstitelja", strings.UsekovanjeDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 09, 21), XmlLanguage.GetLanguage(currentLanguage), "Rođenje presvete Bogorodice", strings.RodjenjeDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 09, 27), XmlLanguage.GetLanguage(currentLanguage), "Krstovdan", strings.KrstovdanDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 10, 12), XmlLanguage.GetLanguage(currentLanguage), "Sveti Kirijak", strings.SvetiKirijakDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 10, 14), XmlLanguage.GetLanguage(currentLanguage), "Presvete Bogorodice", strings.PresveteBogorodiceDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 10, 19), XmlLanguage.GetLanguage(currentLanguage), "Sveti apostol Toma", strings.SvetiTomaDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 10, 20), XmlLanguage.GetLanguage(currentLanguage), "Srđevdan", strings.SrdevdanDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 10, 27), XmlLanguage.GetLanguage(currentLanguage), "Sveta Petka", strings.SvetaPetkaDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 10, 31), XmlLanguage.GetLanguage(currentLanguage), "Sveti Luka", strings.SvetiLukaDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 11, 08), XmlLanguage.GetLanguage(currentLanguage), "Sveti Dimitrije", strings.SvetiDimitrijeDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 11, 16), XmlLanguage.GetLanguage(currentLanguage), "Sveti Georgije - Đurđic", strings.DurdicDesc);
            new CardEntry(this,new DateTime(DateTime.Now.Year, 11, 21), XmlLanguage.GetLanguage(currentLanguage), "Sveti Arhangel", strings.SvetiArandjelDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 11, 22), XmlLanguage.GetLanguage(currentLanguage), "Sveti Nektarije", strings.SvetiNektarijeDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 11, 24), XmlLanguage.GetLanguage(currentLanguage), "Sveti Stefan Dečanski", strings.SvetiStefanDecanskiDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 12, 04), XmlLanguage.GetLanguage(currentLanguage), "Vavedenje presvete Bogorodice", strings.VavedenjeDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 12, 09), XmlLanguage.GetLanguage(currentLanguage), "Sveti Alimpije Stolpnik", strings.SvetiAlimpijeDesc);
            new CardEntry(this, new DateTime(DateTime.Now.Year, 12, 19), XmlLanguage.GetLanguage(currentLanguage), "Sveti Nikola", strings.SvetiNikolaDesc);
        }
        /// <summary>When language was changed, based on the name of the holiday, gets specific description string.</summary>
        private void UpdateHolidayText()
        {
            for (int i=0; i < mainCanvas.Children.OfType<CardEntry>().Count()  ; i++)
            {
                mainCanvas.Children.OfType<CardEntry>().ElementAt(i).HolidayDescriptionTitle.Text = strings.DescriptionTitle;
                mainCanvas.Children.OfType<CardEntry>().ElementAt(i).Language = XmlLanguage.GetLanguage(currentLanguage);
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
        /// <summary>Shows about me text of the application.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Made by Dorian Nebojsa Stanojevic 2023 - doriannebojsa.com | Version {appVersion}", strings.AboutButton );
        }
        /// <summary>Opens the website in the users default web brwoser.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buyButton_Click(object sender, RoutedEventArgs e)
        {
            switch (currentLanguage)
            {
                case "sr-Latn-RS":
                    Process.Start(new ProcessStartInfo(browserPath)
                    {
                        UseShellExecute = true,
                        Arguments = "https://uslavigospodu.shop/sr/produkt/ikona/?pismo=lat/"
                    });
                    break;
                case "de-DE":
                    Process.Start(new ProcessStartInfo(browserPath)
                    {
                        UseShellExecute = true,
                        Arguments = "https://uslavigospodu.shop/produkt/ikone/"
                    });
                    break;

            }
            
        }
        /// <summary>Checks if there's a newer version and updates if wished by user.</summary>
        private void CheckAndUpdateVersion()
        {
            string appCurrentVersion = GetCurrentAppVersion();
            if (appVersion != appCurrentVersion)
            {
                MessageBoxResult result = MessageBox.Show(NewVersionText, NewVersionCaption, MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    WebClient client = new WebClient();
                    string downloadFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\";
                    string destFile = Path.Combine(downloadFolder, "program" + appCurrentVersion + ".msi");
                    client.DownloadFile(Url + "/version/program" + appCurrentVersion + ".msi", destFile);
                    Process.Start(new ProcessStartInfo(destFile)
                    {
                        UseShellExecute = true,
                    });
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>Gets the version number of the newest version.</summary>
        /// <returns></returns>
        private string GetCurrentAppVersion()
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://doriannebojsa.com/version/");
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        string html = streamReader.ReadToEnd();
                        return html.Substring(html.LastIndexOf("<a") + 16, 7);
                    }
                }
            } 
            catch (Exception ex)
            {
                if (!Debugger.IsAttached)
                {
                    string wholePath = AppContext.BaseDirectory;
                    var directory = wholePath.Remove(wholePath.LastIndexOf('\\')) + "\\error_log" + "_"  + DateTime.Now.ToString("dd.MM.yyyy");
                    using (FileStream fileStream = File.Create(directory))
                    {
                        char[] exceptionText = ex.InnerException.ToString().ToCharArray();
                        fileStream.Write(Encoding.UTF8.GetBytes(exceptionText), 0, exceptionText.Length);
                    }
                }
                return appVersion;
            }
        }
    }


}
