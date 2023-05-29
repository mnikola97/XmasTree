using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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

namespace XmasTree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int rowCount;
        private string header;
        private string footer;
        private int lastRowStars;
        public MainWindow()
        {
            InitializeComponent();
            this.tbXmasTree.IsReadOnly = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            header = this.txtBoxHeader.Text;
            footer = this.txtBoxFooter.Text;
            try
            {
                rowCount = Int32.Parse(this.txtBoxRow.Text);
                lastRowStars = (rowCount-1) * 2 - 1;
                if (header == "") this.tbXmasTree.Text = "\n";
                else this.tbXmasTree.Text = "\n" + header +"\n" ;
                string stars;
                string spaces;
                string empty= new String(' ', (lastRowStars - 1) / 2);
                for (int i = 1; i < rowCount; i++)
                {
                    if (i == 1)
                    {                  
                        stars = empty+"*"+empty;

                    }
                    else if (i == rowCount - 1)
                    {
                        stars = new String('*', lastRowStars);
                        stars += "\n";
                        this.tbXmasTree.Text += stars;
                        break;
                    }
                    else
                    {
                        stars = "*";
                        spaces = new String(' ', ((i - 1) * 2) - 1);
                        stars += spaces + "*";
                        stars = empty + stars + empty;
                    }
                    stars += "\n";
                    this.tbXmasTree.Text += stars;
                    empty = empty.Substring(1);
                }
                empty = new String(' ', (lastRowStars - 1) / 2);
                this.tbXmasTree.Text += empty+"*"+ empty;
                if (footer == "") this.tbXmasTree.Text += "\n";
                else this.tbXmasTree.Text += "\n" + footer + "\n";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
