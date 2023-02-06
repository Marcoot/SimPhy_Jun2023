using System;

namespace BaseProject
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new SimPhy_Jun2022())
                game.Run();
        }
    }
}
