using ppe_foods.Views;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ppe_foods
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Dashboard View { get; set; }

        public static void ViewRouting(bool flag, Control content = null)
        {
            if (flag == true)
            {
                View.PnlContent.Children.Add(content);
            }
            else
            {
                View.PnlContent.Children.Clear();
            }
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            View = new Dashboard();
            View.Show();
            ViewRouting(true, new About());
        }
    }
}
