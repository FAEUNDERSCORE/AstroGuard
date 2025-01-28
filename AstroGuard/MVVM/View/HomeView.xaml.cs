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
using AstroGuard.MVVM.ViewModel;

namespace AstroGuard.MVVM.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();    
            Loaded += OnLoaded;
        }
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var viewModel = (HomeViewModel)DataContext;
            foreach (var patch in viewModel.PatchNotes)
            {
                var border = new Border
                {
                    Margin = new Thickness(5),
                    Padding = new Thickness(10),
                    CornerRadius = new CornerRadius(10),
                    Background = new LinearGradientBrush(
                        new GradientStopCollection
                        {
                            new GradientStop(Color.FromRgb(50, 42, 38), 0),
                            new GradientStop(Color.FromRgb(25, 19, 8), 1)
                        },
                        new Point(0, 0),
                        new Point(1, 1)),
                    Child = new StackPanel
                    {
                        Children =
                        {
                            new TextBlock { Text = patch.Title, FontWeight = FontWeights.Bold, FontSize = 16 },
                            new TextBlock { Text = patch.Version, FontStyle = FontStyles.Italic },
                            new TextBlock { Text = patch.Date.ToString("yyyy-MM-dd"), FontStyle = FontStyles.Italic },
                            new TextBlock { Text = patch.Description, TextWrapping = TextWrapping.Wrap, Margin = new Thickness(0, 5, 0, 0) }
                        }
                    }
                };

                Updates.Children.Add(border);
            }
        }
    }
}
