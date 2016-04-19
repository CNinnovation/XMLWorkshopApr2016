using Microsoft.Win32;
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
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace WPFValidatingReader
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

        private XmlDocument _doc;
        private readonly List<string> _schemaFiles = new List<string>();
        private void OnLoadXml(object sender, RoutedEventArgs e)
        {
            try
            {
                var dlg = new OpenFileDialog();
                if (dlg.ShowDialog() == true)
                {
                    _doc = new XmlDocument();
                   
                    _doc.Load(dlg.FileName);

                    Xml = XElement.Parse(_doc.OuterXml).ToString();
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }

        }

        private void OnLoadXsd(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_doc == null)
                {
                    MessageBox.Show("Load an XML File first");
                    return;
                }
                var dlg = new OpenFileDialog();
                if (dlg.ShowDialog() == true)
                {
                    _schemaFiles.Add(dlg.FileName);
                    Xsd = XElement.Load(dlg.FileName).ToString();
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        private void OnValidate(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var schemaFile in _schemaFiles)
                {
                    _doc.Schemas.Add(null, schemaFile);
                }

                _doc.Validate(ValidationEventHandler);
                MessageBox.Show("Validation completed");
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        public string Xml
        {
            get { return (string)GetValue(XmlProperty); }
            set { SetValue(XmlProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Xml.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XmlProperty =
            DependencyProperty.Register("Xml", typeof(string), typeof(MainWindow), new PropertyMetadata(string.Empty));

        public string Xsd
        {
            get { return (string)GetValue(XsdProperty); }
            set { SetValue(XsdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Xsd.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XsdProperty =
            DependencyProperty.Register("Xsd", typeof(string), typeof(MainWindow), new PropertyMetadata(string.Empty));


        public string Error
        {
            get { return (string)GetValue(ErrorProperty); }
            set { SetValue(ErrorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Error.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorProperty =
            DependencyProperty.Register("Error", typeof(string), typeof(MainWindow), new PropertyMetadata(string.Empty));


        private void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Error = $"Valdiating Error {e.Message}";
                    break;
                case XmlSeverityType.Warning:
                    Error = $"Valdiating Warning {e.Message}";
                    break;
            }

        }

    }
}
