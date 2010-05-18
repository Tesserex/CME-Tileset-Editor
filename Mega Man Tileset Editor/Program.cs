using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Mega_Man_Tileset_Editor
{
    static class Program
    {
        private static Timer timer;
        public static event Action FrameTick;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            timer = new Timer();
            timer.Interval = 1000 / 60;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            Application.Run(new Form1());
        }

        static void timer_Tick(object sender, EventArgs e)
        {
            if (FrameTick != null) FrameTick();
        }

        public static void Animate(bool animate)
        {
            timer.Enabled = animate;
        }
    }
}
