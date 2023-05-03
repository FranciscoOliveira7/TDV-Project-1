using System;
using System.Windows.Forms;

namespace MarioRemastered
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           /*
            StartScreen startscreen = new StartScreen();
            startscreen.ShowDialog();
            */
             using (var game = new Game1()) { 
                    game.Run();
            }
    
        }
        
    }
#endif
}
