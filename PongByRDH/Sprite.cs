using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongByRDH
{
    class Sprite
    {
        Texture2D texture;
        Vector2 position;
        SpriteFont font;
        Rectangle rectangleDestination;
        Vector2 origin = Vector2.Zero;
        Vector2 scale = Vector2.One;
        SpriteEffects effects = SpriteEffects.None;
        Rectangle? sourceRectangle = null;
        Color kolor = Color.White;
        float rotation = 0;
        string note = " ";

        public string Note
        {
            get { return note; }
            set { note = value; }
        }
        public SpriteFont Font
        {
            get { return font; }
            set { font = value; }
        }

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }
        public Vector2 Scale
        {
            get { return scale; }
            set { scale = value; }
        }
        public Rectangle? SourceRectangle
        {
            get { return sourceRectangle; }
            set { sourceRectangle = value; }
        }
        public Rectangle DestinationRectangle
        {
            get { return rectangleDestination; }
            set { rectangleDestination = value; }
        }
        public Color Kolor
        {
            get { return kolor; }
            set { kolor = value; }
        }
        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }
        public SpriteEffects Effects
        {
            get { return effects; }
            set { effects = value; }
        }

        public Sprite(Vector2 position)
        {
            this.position = position;
        }
        public Sprite(Vector2 position, Rectangle? sourceRectangle)
        {
            this.position = position;
            this.sourceRectangle = sourceRectangle;
        }
        public Sprite(Vector2 position, Rectangle? sourceRectangle, Color color)
        {
            this.position = position;
            this.sourceRectangle = sourceRectangle;
            this.kolor = color;
        }
        public Sprite(Vector2 position, Rectangle? sourceRectangle, Color color, float rotation)
        {
            this.position = position;
            this.sourceRectangle = sourceRectangle;
            this.kolor = color;
            this.rotation = rotation;
        }
        public Sprite(Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin)
        {
            this.position = position;
            this.sourceRectangle = sourceRectangle;
            this.kolor = color;
            this.rotation = rotation;
            this.origin = origin;
        }
        public Sprite(Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale)
        {
            this.position = position;
            this.sourceRectangle = sourceRectangle;
            this.kolor = color;
            this.rotation = rotation;
            this.origin = origin;
            this.scale = scale;
        }
        public Sprite(Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects)
        {
            this.position = position;
            this.sourceRectangle = sourceRectangle;
            this.kolor = color;
            this.rotation = rotation;
            this.origin = origin;
            this.scale = scale;
            this.effects = effects;
        }

        public void LoadContent(ContentManager Content, string assetName)
        {
            this.texture = Content.Load<Texture2D>(assetName);
        }
        public void LoadFont(ContentManager Content, string assetName)
        {
            this.font = Content.Load<SpriteFont>(assetName);
        }
        public void Update(Vector2 translate)
        {
            this.position += translate;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, sourceRectangle, kolor, rotation, origin, Scale, effects,0);
            spriteBatch.End();   
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(this.font, this.note, position, color);
            spriteBatch.End();
        }
    }
}
