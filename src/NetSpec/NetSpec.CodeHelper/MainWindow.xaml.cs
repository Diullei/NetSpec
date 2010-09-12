using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NetSpec.CodeHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtSpecification_TextChanged(object sender, TextChangedEventArgs e)
        {
            var myFlowDoc = new FlowDocument();
            var textSpecification = new TextRange(txtSpecification.Document.ContentStart, txtSpecification.Document.ContentEnd).Text;

            var code = CodeBuilder.Builder(textSpecification, "NetSpecTestClass");
            myFlowDoc.Blocks.Add(new Paragraph(new Run(code)));

            txtCode.Document = myFlowDoc;
        }
    }
}
