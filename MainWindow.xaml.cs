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

namespace second_lesson2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
       
        }

        public void SetUpGame()
        {
            List<string> listEmoji = new List<string>()
            {
                "🦓", "🦓",
                "🐗", "🐗",
                "🐅", "🐅",
                "🐒", "🐒",
                "🐊", "🐊",
                "🐥", "🐥",
                "🐙", "🐙",
                "🕊", "🕊",
            };
            Random random = new Random();

            foreach(TextBlock cellBlock in mainGrid.Children.OfType<TextBlock>())
            {
                int index = random.Next(listEmoji.Count);

                string randomEmoji = listEmoji[index];

                cellBlock.Text = randomEmoji;

                listEmoji.RemoveAt(index);

            }
        }
    }
}
