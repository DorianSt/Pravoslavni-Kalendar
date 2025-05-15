using Microsoft.Win32;

namespace Pravoslavni_Crkveni_Kalendar
{
    public static class CurrentBrowserGetter
    {
        public static string GetBrowserPath()
        {
            string browserPath;
            var regDefault = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.html\\UserChoice", false);
            var stringDefault = regDefault.GetValue("ProgId");
            using (RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(stringDefault + "\\shell\\open\\command", false))
            {
                browserPath = regKey.GetValue(null).ToString().ToLower().Replace("" + (char)34, "");

                if (!browserPath.EndsWith("exe") && regKey != null)
                {
                    browserPath = browserPath.Substring(0, browserPath.LastIndexOf(".exe") + 4);
                }
                regKey.Close();
            }
            return browserPath;
        }
    }
}
