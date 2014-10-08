using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace Predator_of_the_Pond
{
    class Enemy
    {
        int direction;
        int speed;
        Vector2 position;
        float size;
        Random random;
        static Texture2D[] sprites = new Texture2D[2];

        public static Texture2D[] Sprites
        {
            get { return sprites; }
            set { sprites = value; }
        }

        public int Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public float Size
        {
            get { return size; }
        }

        public bool OnScreen(int width)
        {
            return !((direction == 1 && position.X > width) || (direction == -1 && position.X < -(sprites[1].Width * size)));
        }

        public Enemy()
        {
            position = new Vector2(500, 350);
            random = new Random();
            direction = (random.Next(1, 3) == 1) ? 1 : -1;
            speed = random.Next(5, 10);
            size = random.Next(1, 3) - (float)random.NextDouble() + 0.05f;
            speed -= (int)size;
        }

        public void Update()
        {
            position.X += (speed * direction);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (direction == 1)
                spriteBatch.Draw(sprites[0], new Rectangle((int)position.X, (int)position.Y, (int)(sprites[0].Width * size), (int)(sprites[0].Height * size)), Color.White);
            else
                spriteBatch.Draw(sprites[1], new Rectangle((int)position.X, (int)position.Y, (int)(sprites[1].Width * size), (int)(sprites[1].Height * size)), Color.White);
            spriteBatch.End();
        }
    }
}
