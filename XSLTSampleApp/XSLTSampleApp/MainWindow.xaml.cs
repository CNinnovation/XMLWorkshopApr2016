using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace XSLTSampleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void OnTransform(object sender, RoutedEventArgs e)
        {
            var transform = new XslCompiledTransform(enableDebug: true);
            var dlg = new OpenFileDialog();
            dlg.Title = "Select Stylesheet";
            if (dlg.ShowDialog() == true)
            {
                transform.Load(dlg.FileName);

                var dlg2 = new OpenFileDialog();
                dlg2.Title = "Select XML File";
                if (dlg2.ShowDialog() == true)
                {
                    var sb = new StringBuilder();
                    XmlWriter resultsXml = XmlWriter.Create(sb);
                    transform.Transform(dlg2.FileName, resultsXml);

                    Result = XElement.Parse(sb.ToString()).ToString();
                }
            }
        }

        public string Result
        {
            get { return (string)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Result.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ResultProperty =
            DependencyProperty.Register("Result", typeof(string), typeof(MainWindow), new PropertyMetadata(string.Empty));


    }
}
