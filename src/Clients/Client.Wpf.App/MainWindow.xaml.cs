using IdentityModel.OidcClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client.Wpf.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OidcClient _oidcClient = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var options = new OidcClientOptions
            {
                Authority = "https://localhost:44310",
                ClientId = "wpf.client",
                Scope = "openid",
                RedirectUri = "https://localhost/wpf-app",
                Browser = new WebBrowserWpf()
            };

            _oidcClient = new OidcClient(options);

            LoginResult loginResult;
            try
            {
                loginResult = await _oidcClient.LoginAsync();
            }
            catch (Exception)
            {
                return;
            }

            if (loginResult.IsError)
            {

            }
            else
            {
                
            }
        }
    }
}
