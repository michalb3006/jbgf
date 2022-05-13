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

namespace WpfGameXO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int[,] mat { get; set; } = new int[3, 3];
        public int counter { get; set; } = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button b = e.OriginalSource as Button;
            int row = (int)b.GetValue(Grid.RowProperty);
            int col = (int)b.GetValue(Grid.ColumnProperty);
            if (counter % 2 == 0)
            {
                b.Content = "O";
                tb_text.Text = "תורו של הX";
                mat[row, col] = 2;
            }
            else
            {
                b.Content = "X";
                tb_text.Text = "תורו של הO";
                mat[row, col] = 1;
            }
            counter++;
            b.IsEnabled = false;
            if (counter >= 5)
                if (CheckValid(row, col))
                    MessageBox.Show("נצחת");

        }
        public bool CheckValid(int row, int col)
        {
            int num = mat[row, col];

            if (mat[0, 0] == mat[0, 1])
                if (mat[0, 0] == mat[0, 2] && mat[0, 0] != 0)
                    return true;
            if (mat[0, 0] == mat[1, 0] && mat[0,0]!=0)
                if (mat[0, 0] == mat[2, 0])
                    return true;
            if (mat[2, 2] == mat[2, 1] && mat[2, 2] != 0)
                if (mat[2, 2] == mat[2, 0])
                    return true;
            if (mat[2, 2] == mat[1, 2] && mat[2, 2] != 0)
                if (mat[2, 2] == mat[0, 2])
                    return true;
            if (mat[2, 2] == mat[1, 1] && mat[2, 2] != 0)
                if (mat[2, 2] == mat[0, 0])
                    return true;
            if (mat[0, 2] == mat[1, 1] && mat[0, 2] != 0)
                if (mat[0, 2] == mat[2, 0])
                    return true;
            return false;
        }
    }
}
