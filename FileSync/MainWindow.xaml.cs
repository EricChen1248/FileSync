using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;

namespace FileSync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var path = "E:/";

            var dir = new DirectoryInfo(path);


            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            var files = dir.GetFiles("*", new EnumerationOptions {
                IgnoreInaccessible = true,
                RecurseSubdirectories = true,
            });
            watch.Stop();

            var watch2 = new System.Diagnostics.Stopwatch();

            var dd = new DirectoryItem(dir);
            watch2.Start();
            dd.GetChildren(recurse: true);
            watch2.Stop();

            Console.WriteLine(watch.ElapsedMilliseconds);
            Console.WriteLine(watch2.ElapsedMilliseconds);

        }

    }


}
