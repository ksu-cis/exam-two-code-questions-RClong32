using System;
using System.Collections.Generic;
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
using ExamTwoCodeQuestions.Data;
namespace ExamTwoQuestions.PointOfSale
{
    /// <summary>
    /// Interaction logic for CustomizeCobblerControl.xaml
    /// </summary>
    public partial class CustomizeCobblerControl : UserControl
    {
        public CustomizeCobblerControl()
        {
            InitializeComponent();
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            FruitFilling a;
            a = FruitFilling.Cherry;
            if (DataContext is Cobbler)
            {
                Cobbler b = (Cobbler)DataContext;
                b.Fruit = a;
            }
        }

        private void Pink_Click(object sender, RoutedEventArgs e)
        {
            FruitFilling a;
            a = FruitFilling.Peach;
            if (DataContext is Cobbler)
            {
                Cobbler b = (Cobbler)DataContext;
                b.Fruit = a;
            }
        }

        private void Blue_Click(object sender, RoutedEventArgs e)
        {
            FruitFilling a;
            a = FruitFilling.Blueberry;
            if (DataContext is Cobbler)
            {
                Cobbler b = (Cobbler)DataContext;
                b.Fruit = a;
            }
        }


    }
}
