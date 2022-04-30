using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinUIEx;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace HW_2
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : WindowEx
    {
        public MainWindow() {
            InitializeComponent();
#if DEBUG
            VarX1TextBox.Text = "0.5";
            VarX2TextBox.Text = "0.5";

            VarE1TextBox.Text = "1e-15";
            VarN2TextBox.Text = "15";
#endif
        }

        private void CalcButton1_Click(object sender, RoutedEventArgs e) {
            if (!double.TryParse(VarX1TextBox.Text, out double x)) {
                ErrorTip.Subtitle = "Unable to convert argument x to double"; ErrorTip.IsOpen = true;
                return;
            }

            if (!(0.0 < x && x <= 1.0)) {
                ErrorTip.Subtitle = "x doesn't meet condition 0 < x ≤ 1"; ErrorTip.IsOpen = true;
                return;
            }

            if (!double.TryParse(VarE1TextBox.Text, out double E))
            {
                ErrorTip.Subtitle = "Unable to convert argument E to double"; ErrorTip.IsOpen = true;
                return;
            }

            Result1TextBox.Text = Utils.Method1(x, E).ToString();
            ResultC1TextBox.Text = Utils.CalculateC(x).ToString();
        }

        private void CalcButton2_Click(object sender, RoutedEventArgs e) {
            if (!double.TryParse(VarX2TextBox.Text, out double x))
            {
                ErrorTip.Subtitle = "Unable to convert argument x to double"; ErrorTip.IsOpen = true;
                return;
            }

            if (!(0.0 < x && x <= 1.0))
            {
                ErrorTip.Subtitle = "x doesn't meet condition 0 < x ≤ 1"; ErrorTip.IsOpen = true;
                return;
            }

            if (!int.TryParse(VarN2TextBox.Text, out int N))
            {
                ErrorTip.Subtitle = "Unable to convert argument N to int"; ErrorTip.IsOpen = true;
                return;
            }

            double result = Utils.Method2(x, N);

            if (double.IsNaN(result) || double.IsInfinity(result)) {
                ErrorTip.Subtitle = "Calculation result is invalid"; ErrorTip.IsOpen = true;
                return;
            }

                Result2TextBox.Text = result.ToString();
            ResultC2TextBox.Text = Utils.CalculateC(x).ToString();
        }

        private void Var1TextBox_TextChanged(object sender, TextChangedEventArgs e) {
            if (ResultC1TextBox.Text != "") ResultC1TextBox.Text = "";
            if (Result1TextBox.Text != "") Result1TextBox.Text = "";
        }

        private void Var2TextBox_TextChanged(object sender, TextChangedEventArgs e) {
            if (ResultC2TextBox.Text != "") ResultC2TextBox.Text = "";
            if (Result2TextBox.Text != "") Result2TextBox.Text = "";
        }
    }
}