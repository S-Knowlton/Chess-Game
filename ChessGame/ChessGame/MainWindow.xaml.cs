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

namespace ChessGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Player p1 = new Player(1);
            Player p2 = new Player(2);

            Board board1 = new Board(p1, p2);
            board1.PrintBoard();

            System.Console.WriteLine("\n\n");

            Board board2 = new Board(board1);
            board2.PrintBoard();

            //start game logic here

        }
    }
}
