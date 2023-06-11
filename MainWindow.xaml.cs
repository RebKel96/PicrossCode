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

namespace Picross
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int randomnum = 0;
        int prevgame = 0;

        public MainWindow()
        {
            InitializeComponent();
            btnPlayAgain.Visibility = Visibility.Hidden;
            playGame();

        }

        private void gridInit() {
            for (int i = 0; i < 10; i++)
            { //initialize grid of buttons
                for (int j = 0; j < 10; j++)
                {

                    System.Windows.Controls.Button btn = new System.Windows.Controls.Button();

                    btn.Width = 60;

                    btn.Height = 60;

                    btn.Background = Brushes.White;

                    btn.Visibility = Visibility.Visible;

                    btn.VerticalAlignment = VerticalAlignment.Center;

                    btn.HorizontalAlignment = HorizontalAlignment.Center;

                    btn.PreviewMouseDown += new MouseButtonEventHandler(btn1_Click);

                    grdPuzzle.Children.Add(btn);

                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);

                }

            }

        }

        private void btn1_Click(object sender, MouseButtonEventArgs e) //action when clicking on one button
        {

            System.Windows.Controls.Button btn2 = (System.Windows.Controls.Button)sender;


            if (btn2.Background == Brushes.White && e.ChangedButton == MouseButton.Left)
            {
                btn2.Background = Brushes.Black;
                labelCheck();

            }
            else if (e.ChangedButton == MouseButton.Right)
            {
                btn2.Background = Brushes.Red;
                labelCheck();

            }
            else
            {
                btn2.Background = Brushes.White;
                labelCheck();
            }

        }

        public string rowValue(int r) { //finds the value of a row, converts it to a string to see if it matches one of the labels below
          
            int a = 0; //how many of the first chunk are there
            int b = 0; //how many of the second chunk are there
            int c = 0; //how many of the third chunk are there
            int twochunk = 0;
            int threechunk = 0;
            string result = "";

            foreach (System.Windows.Controls.Button myBtn in grdPuzzle.Children) {
                if (Grid.GetRow(myBtn) == r)
                {
                    if (myBtn.Background == Brushes.Black && b == 0 && twochunk == 0)
                    {
                        a++;
                    }
                    else if ((myBtn.Background == Brushes.White || myBtn.Background == Brushes.Red) && a > 0 && twochunk==0)
                    {
                        twochunk++;
                    }
                    else if (twochunk > 0 && myBtn.Background == Brushes.Black && threechunk == 0)
                    {
                        b++;
                    }
                    else if (threechunk == 0 && (myBtn.Background == Brushes.White || myBtn.Background == Brushes.Red) && a > 0 && b > 0) {
                        threechunk++;
                    }
                    else if (threechunk > 0 && myBtn.Background == Brushes.Black)
                    {
                        c++;
                    }
                }//end if in row
            }//end foreach


            if (c > 0)
            {
                result = a.ToString() + "  " + b.ToString() + "  " + c.ToString();
            }
            else if (c == 0 && b > 0)
            {
                result = a.ToString() + "  " + b.ToString();
            }
            else
                result = a.ToString();

            return result;

        }//end rowvalue

        public string colValue(int d)
        {
            int a = 0; //how many of the first chunk are there
            int b = 0; //how many of the second chunk are there
            int c = 0; //how many of the third chunk are there
            int twochunk = 0;
            int threechunk = 0;
            string result = "";

            foreach (System.Windows.Controls.Button myBtn in grdPuzzle.Children)
            {
                if (Grid.GetColumn(myBtn) == d)
                {
                    if (myBtn.Background == Brushes.Black && b == 0 && twochunk == 0)
                    {
                        a++;
                    }
                    else if ((myBtn.Background == Brushes.White || myBtn.Background == Brushes.Red) && a > 0 && twochunk == 0)
                    {
                        twochunk++;
                    }
                    else if (twochunk > 0 && myBtn.Background == Brushes.Black && threechunk == 0)
                    {
                        b++;
                    }
                    else if (threechunk == 0 && (myBtn.Background == Brushes.White || myBtn.Background == Brushes.Red) && a > 0 && b > 0)
                    {
                        threechunk++;
                    }
                    else if (threechunk > 0 && myBtn.Background == Brushes.Black)
                    {
                        c++;
                    }
                }//end if in row
            }//end foreach


            if (c > 0)
            {
                result = a.ToString() + Environment.NewLine + b.ToString() + Environment.NewLine + c.ToString();
            }
            else if (c == 0 && b > 0)
            {
                result = a.ToString() + Environment.NewLine + b.ToString();
            }
            else
                result = a.ToString();

            return result;
        }  

        private void playGame() {

            btnPlayAgain.Visibility = Visibility.Hidden;
            sharc.Visibility = Visibility.Hidden;
            bear.Visibility = Visibility.Hidden;
            fox.Visibility = Visibility.Hidden;
            squirrel.Visibility = Visibility.Hidden;


            gridInit();

                Random r = new Random();

            while (randomnum == prevgame)
            {
                randomnum = r.Next(1, 5); 
            }

                switch (randomnum) //randomize the puzzle
                {
                    case 1://bear
                        r0.Content = "1  2";
                        r1.Content = "6";
                        r2.Content = "7";
                        r3.Content = "7";
                        r4.Content = "6";
                        r5.Content = "8";
                        r6.Content = "8";
                        r7.Content = "7  1";
                        r8.Content = "10";
                        r9.Content = "2  2";

                        c0.Content = "1";
                        c1.Content = "3" + Environment.NewLine + "1" + Environment.NewLine + "3";
                        c2.Content = "10";
                        c3.Content = "8";
                        c4.Content = "8";
                        c5.Content = "9";
                        c6.Content = "9";
                        c7.Content = "8";
                        c8.Content = "2" + Environment.NewLine + "2";
                        c9.Content = "3";
                        break;

                    case 2://fox
                        r0.Content = "2  1";
                        r1.Content = "5";
                        r2.Content = "3  5";
                        r3.Content = "3  5";
                        r4.Content = "1  7";
                        r5.Content = "1  7";
                        r6.Content = "6";
                        r7.Content = "7";
                        r8.Content = "6";
                        r9.Content = "1  2";

                        c0.Content = "1" + Environment.NewLine + "1";
                        c1.Content = "2" + Environment.NewLine + "3";
                        c2.Content = "3" + Environment.NewLine + "3";
                        c3.Content = "7";
                        c4.Content = "5";
                        c5.Content = "8";
                        c6.Content = "10";
                        c7.Content = "6" + Environment.NewLine + "3";
                        c8.Content = "5";
                        c9.Content = "4" + Environment.NewLine + "1";
                        break;

                    case 3://dog
                        r0.Content = "2";
                        r1.Content = "2  4";
                        r2.Content = "9";
                        r3.Content = "2  1  2";
                        r4.Content = "8";
                        r5.Content = "5  2";
                        r6.Content = "8";
                        r7.Content = "9";
                        r8.Content = "9";
                        r9.Content = "7";

                        c0.Content = "1" + Environment.NewLine + "8";
                        c1.Content = "10";
                        c2.Content = "2" + Environment.NewLine + "6";
                        c3.Content = "8";
                        c4.Content = "2" + Environment.NewLine + "6";
                        c5.Content = "2" + Environment.NewLine + "1" + Environment.NewLine + "4";
                        c6.Content = "2" + Environment.NewLine + "6";
                        c7.Content = "8";
                        c8.Content = "2" + Environment.NewLine + "2";
                        c9.Content = "0";

                        break;
                    case 4://squirrel
                        r0.Content = "1  2";
                        r1.Content = "2  3";
                        r2.Content = "9";
                        r3.Content = "8  1";
                        r4.Content = "8  1";
                        r5.Content = "6  2";
                        r6.Content = "9";
                        r7.Content = "5";
                        r8.Content = "5";
                        r9.Content = "4";

                        c0.Content = "2" + Environment.NewLine + "1";
                        c1.Content = "7";
                        c2.Content = "6" + Environment.NewLine + "1";
                        c3.Content = "8";
                        c4.Content = "8";
                        c5.Content = "8";
                        c6.Content = "8";
                        c7.Content = "5" + Environment.NewLine + "3";
                        c8.Content = "3" + Environment.NewLine + "2";
                        c9.Content = "4";
                        break;

            }//end switch

            var rLabels = new List<Label> { r0, r1, r2, r3, r4, r5, r6, r7, r8, r9 };
            var cLabels = new List<Label> { c0, c1, c2, c3, c4, c5, c6, c7, c8, c9 };
            foreach (var Label in rLabels)
            {
                Label.Foreground = Brushes.Red;
            }
            foreach (var Label in cLabels)
            {
                Label.Foreground = Brushes.Red;
            }


        }//end playgame

        private void labelCheck() {
            var rLabels = new List<Label> { r0, r1, r2, r3, r4, r5, r6, r7, r8, r9 };
            var cLabels = new List<Label> { c0, c1, c2, c3, c4, c5, c6, c7, c8, c9 };
            foreach (var Label in rLabels)
            {
                int aa = Convert.ToInt32((Label.Name.ToString()).Substring(1));
                if (Label.Content.Equals(rowValue(aa)))
                {
                    Label.Foreground = Brushes.Green;
                    GameWin();

                }
                else
                {
                    Label.Foreground = Brushes.Red;
                }

            }//end foreach loop for rows

            foreach (var Label in cLabels)
            {
                int aa = Convert.ToInt32((Label.Name.ToString()).Substring(1));
                if (Label.Content.Equals(colValue(aa)))
                {
                    Label.Foreground = Brushes.Green;
                    GameWin();
                }
                else
                {
                    Label.Foreground = Brushes.Red;
                }

            }//end foreach loop for columns 

            if (GameWin() == true) {
                WinScreen();
            }

        }// end labelcheck

        private void Button_Click(object sender, RoutedEventArgs e) //play again button
        {
            prevgame = randomnum;
            playGame();
            btnPlayAgain.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //hide how-to box that appears initially
        {
            
            howtotxt.Visibility = Visibility.Hidden;
            xxx.Visibility = Visibility.Hidden;
        }

        private bool GameWin() { //check if the game has been won after a row or column turns green
            bool win = false;
            bool rowwin = false;
            bool colwin = false;
            var rLabels = new List<Label> { r0, r1, r2, r3, r4, r5, r6, r7, r8, r9 };
            var cLabels = new List<Label> { c0, c1, c2, c3, c4, c5, c6, c7, c8, c9 };
            foreach (var Label in cLabels) {
                if (Label.Foreground == Brushes.Green)
                {
                    colwin = true;

                }
                else
                {
                    colwin = false;
                    break;
                }
            }

            foreach (var Label in rLabels) {
                if (Label.Foreground == Brushes.Green)
                {
                    rowwin = true;

                }
                else {
                    rowwin = false;
                    break;
                }
            }

            if (rowwin && colwin) {
                win = true;
            }

            return win;
        
        }//end gamewin

        private void WinScreen() {
            switch (randomnum) {

                case 1:
                    btnPlayAgain.Visibility = Visibility.Visible;
                    bear.Visibility = Visibility.Visible;
                    break;

                case 2:
                    btnPlayAgain.Visibility = Visibility.Visible;
                    fox.Visibility = Visibility.Visible;
                    break;

                case 3:
                    btnPlayAgain.Visibility = Visibility.Visible;
                    sharc.Visibility = Visibility.Visible;
                    break;

                case 4:
                    btnPlayAgain.Visibility = Visibility.Visible;
                    squirrel.Visibility = Visibility.Visible;
                    break;

            }//end switch
        
        
        }//end winscreen
    }
}
