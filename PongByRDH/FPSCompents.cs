using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongByRDH
{
    class FPSCompents: DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        SpriteFont font;

        int frameRate = 0;
        int framecounter = 0;
        TimeSpan time = TimeSpan.Zero;
        public FPSCompents(Game game): base(game)
        {
        }

        public override void Initialize()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            font = Game.Content.Load<SpriteFont>("font");
            base.Initialize();
        }
        protected override void LoadContent()
        {
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            time += gameTime.ElapsedGameTime;
            if (time > TimeSpan.FromSeconds(1))
            {
                time -= TimeSpan.FromSeconds(1);
                frameRate = framecounter;
                framecounter = 0;
            }
        }
        public override void Draw(GameTime gameTime)
        {
            framecounter++;
            spriteBatch.Begin();
            spriteBatch.DrawString(font, frameRate.ToString() + " FPS", new Vector2(GraphicsDeviceManager.DefaultBackBufferWidth / 2-50, 0), Color.White);
            spriteBatch.End();
        }
    }
}
