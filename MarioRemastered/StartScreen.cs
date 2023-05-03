using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarioRemastered
{
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread gamethread = new Thread(StartGame);
            gamethread.Start();
            
        }

        private void StartGame()
        {
            Game1 game = new Game1();
            game.Run();
        }
    }
}
