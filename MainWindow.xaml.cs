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
    using System.Windows.Threading;
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondsElapsed;
        int matchesFound = 0;

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += Timer_Tick;


            SetUpGame();
       
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;

            timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");

            if (matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
            }
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

            int counter = listEmoji.Count;
            foreach(TextBlock cellBlock in mainGrid.Children.OfType<TextBlock>())
            {
                int index = random.Next(listEmoji.Count);
                if (counter == 0)
                    break;
                string randomEmoji = listEmoji[index];
                cellBlock.Text = randomEmoji;
                cellBlock.Visibility = Visibility.Visible;
                listEmoji.RemoveAt(index);
                counter--;
            }
            tenthsOfSecondsElapsed = 0;
            timer.Start();
        }


        TextBlock lastTextBlockClicked;
        bool findingMatch = false;


        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock clickedTextBlock = sender as TextBlock;

            if (findingMatch == false)
            {
                clickedTextBlock.Visibility = Visibility.Hidden;
                findingMatch = true;
                lastTextBlockClicked = clickedTextBlock;
            }
            else if(clickedTextBlock.Text == lastTextBlockClicked.Text)
            {
                clickedTextBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
                matchesFound++;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }
        private void TimeTextBlock_MouseDown(object sender, EventArgs e)
        {
            if (matchesFound == 8)
            {
                SetUpGame();
            }
        }
    }
}
