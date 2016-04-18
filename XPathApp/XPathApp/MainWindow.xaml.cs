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
using System.Xml.XPath;

namespace XPathApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private XmlDocument _doc;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void OnLoadXml(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                _doc = new XmlDocument();
                _doc.Load(dlg.FileName);
                XmlContent = _doc.OuterXml;
            }
        }

        public string XmlContent
        {
            get { return (string)GetValue(XmlContentProperty); }
            set { SetValue(XmlContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XmlContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XmlContentProperty =
            DependencyProperty.Register("XmlContent", typeof(string), typeof(MainWindow), new PropertyMetadata(string.Empty));

        public string XPathExpression
        {
            get { return (string)GetValue(XPathExpressionProperty); }
            set { SetValue(XPathExpressionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XPathExpression.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XPathExpressionProperty =
            DependencyProperty.Register("XPathExpression", typeof(string), typeof(MainWindow), new PropertyMetadata(string.Empty));


        public string Result
        {
            get { return (string)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ResultNode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ResultProperty =
            DependencyProperty.Register(nameof(Result), typeof(string), typeof(MainWindow), new PropertyMetadata(string.Empty));




        private void OnXPath(object sender, RoutedEventArgs e)
        {
            try
            {
                ErrorInformation = string.Empty;
                if (Multiple == false)
                {
                    //XmlNode node = _doc.SelectSingleNode(XPathExpression);
                    //Result = node.OuterXml;
                    XPathNavigator navigator = _doc.CreateNavigator();
                    navigator = navigator.SelectSingleNode(XPathExpression);
                    Result = navigator.OuterXml;
                }
                else
                {
                    //XmlNodeList nodeList = _doc.SelectNodes(XPathExpression);
                    //Result = string.Join(Environment.NewLine, nodeList.Cast<XmlNode>().Select(n => n.OuterXml));
                    XPathNavigator navigator = _doc.CreateNavigator();
                    XPathNodeIterator iterator = navigator.Select(XPathExpression);
                    List<string> results = new List<string>();
                    foreach (XPathNavigator item in iterator)
                    {
                        results.Add(item.OuterXml);
                    }
                    Result = string.Join(Environment.NewLine, results);
                }
            }
            catch (Exception ex)
            {
                ErrorInformation = ex.Message;
            }
        }

        public string ErrorInformation
        {
            get { return (string)GetValue(ErrorInformationProperty); }
            set { SetValue(ErrorInformationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorInformation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorInformationProperty =
            DependencyProperty.Register("ErrorInformation", typeof(string), typeof(MainWindow), new PropertyMetadata(string.Empty));


        public bool? Multiple
        {
            get { return (bool?)GetValue(MultipleProperty); }
            set { SetValue(MultipleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Multiple.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MultipleProperty =
            DependencyProperty.Register("Multiple", typeof(bool?), typeof(MainWindow), new PropertyMetadata(false));

        private void OnXPathEvaluate(object sender, RoutedEventArgs e)
        {
            try
            {
                XPathNavigator navigator = _doc.CreateNavigator();
                Result = navigator.Evaluate(XPathExpression).ToString();
            }
            catch (Exception ex)
            {
                ErrorInformation = ex.Message;
            }
        }
    }
}
