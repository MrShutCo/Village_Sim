using System;

namespace Village_Sim {
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
            Script script = new Script();
            using (var game = new VillageSim())
            {
                script.addReference(game, "game");
                game.script = script;
                game.Run();
            }
        }
    }
#endif
}
