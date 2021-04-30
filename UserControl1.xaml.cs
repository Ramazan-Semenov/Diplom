using System;
using System.Windows;
using System.Windows.Controls;

namespace WindowsFormsApp4
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public static int id;
        public UserControl1()
        {
            InitializeComponent();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            id = Convert.ToInt32(((CheckBox)e.Source).Tag);
        }
    }
}
