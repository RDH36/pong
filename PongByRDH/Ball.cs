using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongByRDH
{
    class Ball: Sprite
    {
        float speed;
        int maxHeigth;
        int maxWidth;
        Vector2 direction;
        int scoreOne = 0;
        int scoreTwo = 0;
        SoundEffect ballSplas;
        SoundEffect maty;

        public Ball(Vector2 position, int maxHeigth, int maxWidth) : base(position)
        {
            this.maxHeigth = maxHeigth;
            this.maxWidth = maxWidth;
            this.direction = new Vector2(1, 1);
            this.speed = 0.2f;
        }

        public void Move(GameTime gameTime, Bat playerOne, Bat playerTwo, ref bool started)
        {
            Update(direction * speed * gameTime.ElapsedGameTime.Milliseconds);
            Rectangle ballRect = new Rectangle((int)Position.X, (int)Position.Y, (int)Texture.Width, (int)Texture.Height);
            Rectangle playerOneRect = new Rectangle((int)playerOne.Position.X, (int)playerOne.Position.Y, 
                (int)playerOne.Texture.Width, (int)playerOne.Texture.Height);
            Rectangle playerTwoRect = new Rectangle((int)playerTwo.Position.X, (int)playerTwo.Position.Y,
                (int)playerTwo.Texture.Width, (int)playerTwo.Texture.Height);
            if (Position.Y <= 100)
                direction.Y *= -1;
            else if (Position.Y >= maxHeigth - Texture.Height)
                direction.Y *= -1;
            else if (ballRect.Intersects(playerOneRect))
            {
                ballSplas.Play();
                direction.X *= -1;
                speed += 0.01f;
            }
            else if (ballRect.Intersects(playerTwoRect))
            {
                ballSplas.Play();
                direction.X *= -1;
                speed += 0.01f;
            }
             else if (Position.X + Texture.Width >= maxWidth)
            {
                maty.Play();
                playerOne.Note = "Score J1: ";
                Position = new Vector2(maxWidth / 2 - Texture.Width / 2, maxHeigth / 2
                - Texture.Height / 2);
                scoreOne++;
                playerOne.Note += scoreOne;
                if(scoreOne == 3)
                {
                    playerOne.Win = "PLAYER 1 WIN !! \n Appuyer sur ENTRE pour Rejouer"; 
                    scoreOne = 0;
                    started = false;
                }

            }
            else if(Position.X <= 0)
            {
                maty.Play();
                playerTwo.Note = "Score J2: ";
                Position = new Vector2(maxWidth / 2 - Texture.Width / 2, maxHeigth / 2
                - Texture.Height / 2);
                scoreTwo++;
                playerTwo.Note += scoreTwo;
                if (scoreTwo == 3)
                {
                    playerTwo.Win = "PLAYER 2 WIN !! \n Appuyer sur ENTRE pour Rejouer";
                    scoreTwo = 0;
                    started = false;
                }
            }

        }
        public void restart(Bat playerOne, Bat playerTwo)
        {
            playerTwo.Note = " ";
            playerOne.Note = " ";
            playerTwo.Win = " ";
            playerOne.Win = " ";
            scoreOne = 0;
            scoreTwo = 0;
            speed = 0.2f;
        }
        public void LoadMusic(ContentManager content, string ball, string but)
        {
            maty = content.Load<SoundEffect>(but);
            ballSplas = content.Load<SoundEffect>(ball);
        }
    }
}
