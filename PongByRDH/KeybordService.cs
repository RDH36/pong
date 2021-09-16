using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongByRDH
{
    class KeybordService: GameComponent, IkeybordService
    {
        KeyboardState kbstate;

        public KeybordService(Game game) : base(game)
        {
            ServiceHelper.Add<IkeybordService>(this);
        }

        public bool IskeyDown(Keys keys)
        {
            return kbstate.IsKeyDown(keys);
        }
        public override void Update(GameTime gameTime)
        {
            kbstate = Keyboard.GetState();
            base.Update(gameTime);
        }
    }
}
