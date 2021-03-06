﻿using System;
using RunehackValley.Engine;
using RunehackValley.Specifics;
using RunehackValley.Views;

namespace RunehackValley
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
            using (var game = new MainGame(new SmallPartOfTown()))
                game.Run();
        }
    }
#endif
}
