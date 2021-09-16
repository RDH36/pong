using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongByRDH
{
    class Bat: Sprite
    {
        float speed;
        int maxHeight;
        Keys keysDown;
        Keys keysUp;
        string win = " ";

        public string Win
        {
            get { return win; }
            set { win = value; }
        }
        public Bat(Vector2 position, int maxHeigth, Keys keysDown, Keys keysUp) : base(position)
        {
            this.keysDown = keysDown;
            this.keysUp = keysUp;
            this.maxHeight = maxHeigth;
            this.speed = 0.5f;
        }

        public void Move(GameTime gameTime)
        {
            if (ServiceHelper.Get<IkeybordService>().IskeyDown(keysUp))
                if (Position.Y > 100)
                    Update(new Vector2(0, -1 * gameTime.ElapsedGameTime.Milliseconds * speed));
            if (ServiceHelper.Get<IkeybordService>().IskeyDown(keysDown))
                if (Position.Y < maxHeight - Texture.Height)
                    Update(new Vector2(0, 1 * gameTime.ElapsedGameTime.Milliseconds * speed));
        }
        public void DrawWin(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(Font, this.win, position, color);
            spriteBatch.End();
        }
    }
}
