using Microsoft.Win32;
using SwabianWPFChallenge.Domain;
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
using Point = SwabianWPFChallenge.Domain.Point;

namespace SwabianWPFChallenge
{
    public partial class MainWindow : Window
    {
        private IDataSource dataSource;
        private FittingModelEnum fittingModel = FittingModelEnum.Linear;
        private List<OxyPlot.DataPoint> points;

        public MainWindow()
        {
            InitializeComponent();
            InitCurveFittingComboBox();
            points = new List<OxyPlot.DataPoint>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var fileSelector = new OpenFileDialog();
            fileSelector.ShowDialog();
            dataSource = new FileDataReader(fileSelector.FileName);
            DrawFittedCurve();
        }

        private void InitCurveFittingComboBox()
        {
            
        }

        private void DrawFittedCurve()
        {
            var curveFitting = new CurveFitting(dataSource, fittingModel);
            points.Clear();
            points.AddRange(curveFitting.GetPoints.Select(p => new OxyPlot.DataPoint(p.X, p.Y)).ToList());
        }
    }
}
