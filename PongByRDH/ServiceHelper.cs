using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongByRDH
{
    class ServiceHelper
    {
        static Game game;

        public static Game Game
        {
            set { game = value; }
        }

        public static void Add<T>(T service) where T : class
        {
            game.Services.AddService(typeof(T), service);
        }

        public static T Get<T>() where T : class
        {
            return game.Services.GetService(typeof(T)) as T;
        }
    }
}
