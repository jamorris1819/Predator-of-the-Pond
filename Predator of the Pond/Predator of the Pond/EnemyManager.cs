using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

using Predator_of_the_Pond.GameScreens;

using Screen_Management_Library;
using Screen_Management_Library.Controls;

namespace Predator_of_the_Pond
{
    static class EnemyManager
    {
        static List<Enemy> enemies = new List<Enemy>();
        static Random random = new Random();
        static int time = 0;
        static int timeout = 3;

        public static List<Enemy> Enemies
        {
            get { return enemies; }
            set { enemies = value; }
        }

        public static void Update(Player player, GameStateManager stateManager, Game1 GameRef)
        {
            time += 1;
            for (int i = 0; i < enemies.Count; i += 1)
            {
                Enemy enemy = enemies[i];
                enemy.Update();
                if (!enemy.OnScreen(1280))
                    enemies.RemoveAt(i);
                Rectangle body = new Rectangle((int)enemy.Position.X, (int)enemy.Position.Y,
                    (int)(Enemy.Sprites[0].Width * enemy.Size), (int)(Enemy.Sprites[0].Height * enemy.Size));
                body.Height /= 2;
                body.Width /= 2;
                body.Y += (body.Height) / 2;
                body.X += (body.Width) / 2;
                if (player.Bounds.Intersects(body))
                {
                    if (enemy.Size < player.Size)
                    {
                        enemies.RemoveAt(i);
                        player.Grow();
                        GameRef.Content.Load<SoundEffect>("Audio/pop").Play();
                    }
                    else
                    {
                        player.Die();
                        Reset();
                        
                        MediaPlayer.Play(GameRef.sadMusic);
                        stateManager.ChangeState(GameRef.GameOverScreen);
                    }
                }
            }

            if (enemies.Count <= 6 && time > timeout)   // Stops all fish being created at the same time
            {
                CreateEnemy();
                time = 0;
            }

            if (InputHandler.KeyPressed(Keys.L))
                foreach (Enemy enemy in enemies)
                    Console.WriteLine(enemy.Position);
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < enemies.Count; i += 1)
            {
                Enemy enemy = enemies[i];
                enemy.Draw(spriteBatch);
            }
        }

        public static void CreateEnemy()
        {
            Enemy enemy = new Enemy();
            enemies.Add(enemy);
        }

        public static void Reset()
        {
            for (int i = 0; i < enemies.Count; i += 1)
            {
                enemies[i].Position = new Vector2(10000, 10000);
            }
        }
    }
}
