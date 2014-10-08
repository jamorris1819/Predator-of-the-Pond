using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Screen_Management_Library;

namespace Predator_of_the_Pond
{
    class Player
    {
        Vector2 position;
        float xmotion, ymotion, xchangeto, ychangeto, speed, size;
        float friction = 1.05f;
        Texture2D[] sprites;

        public Texture2D[] Sprites
        {
            get { return sprites; }
            set { sprites = value; }
        }

        public float Size
        {
            get { return size; }
            set { size = value; }
        }

        public Rectangle Bounds
        {
            get { return new Rectangle((int)position.X, (int)position.Y, (int)(sprites[0].Width * size), (int)(sprites[1].Height * size)); }
        }

        public Player()
        {
            xmotion = 0;
            ymotion = 0;
            speed = 16;
            size = 0.4f;
            position = new Vector2(400, 400);
            sprites = new Texture2D[2];
        }

        public void Update()
        {
            //Set desired direction, but don't move immediately
            if (InputHandler.KeyDown(Keys.D)) xchangeto = 1;
            else if (InputHandler.KeyDown(Keys.A)) xchangeto = -1;
            else xchangeto = 0;

            if (InputHandler.KeyDown(Keys.S)) ychangeto = 1;
            else if (InputHandler.KeyDown(Keys.W)) ychangeto = -1;
            else ychangeto = 0;

            xmotion = MathHelper.SmoothStep(xmotion, xchangeto, 0.1f); //Change the motion smoothly to the desired direction
            ymotion = MathHelper.SmoothStep(ymotion, ychangeto, 0.1f); 

            position = Vector2.Add(position, speed * new Vector2(xmotion, ymotion)); //Give the object the motion
            xmotion /= friction;
            ymotion /= friction;

            if (InputHandler.KeyPressed(Keys.Space)) size += 0.025f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if(xmotion > 0)
                spriteBatch.Draw(sprites[0], new Rectangle((int)position.X, (int)position.Y, (int)(sprites[0].Width * size), (int)(sprites[0].Height * size)), Color.White);
            else
                spriteBatch.Draw(sprites[1], new Rectangle((int)position.X, (int)position.Y, (int)(sprites[1].Width * size), (int)(sprites[1].Height * size)), Color.White);
            spriteBatch.End();
        }
    }
}
