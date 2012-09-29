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
using WpfApplicationTest.Test.Calculator;

namespace WpfApplicationTest
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

		private void button1_Click(object sender, RoutedEventArgs e)
		{
			using (var proxy = new CalculatorClient())
			{
				int result1 = proxy.Add(1, 2);
				double result2 = proxy.Add(1.0, 2.0);
				labelUsualResult.Content = string.Format("int: {0}, double: {1}", result1, result2);
			}
		}

		private void button2_Click(object sender, RoutedEventArgs e)
		{
			using (var proxy1 = new SimplCalculatorClient())
			{
				var result1 = proxy1.Add(1, 2);
				labelSimpleCalculatorResult.Content = string.Format("adding: {0}", result1);
			}
		}

		private void button3_Click(object sender, RoutedEventArgs e)
		{
			using (var proxy2 = new ScientificCalculatorClient())
			{
				var result2 = proxy2.Add(3, 4);
				var result3 = proxy2.Multiply(5, 6);
				labelScientificCalculatorResult.Content = string.Format("adding: {0}, multiplying: {1}", result2, result3);
			}
		}
	}
}
