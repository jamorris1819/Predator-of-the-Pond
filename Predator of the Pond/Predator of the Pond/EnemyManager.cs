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
    static class EnemyManager
    {
        static List<Enemy> enemies = new List<Enemy>();
        static Random random = new Random();

        public static List<Enemy> Enemies
        {
            get { return enemies; }
            set { enemies = value; }
        }

        public static void Update(Player player)
        {
            for (int i = 0; i < enemies.Count; i += 1)
            {
                Enemy enemy = enemies[i];
                if (!enemy.OnScreen(1280))
                    enemies.RemoveAt(i);
                enemy.Update();
                if (player.Bounds.Intersects(
                    new Rectangle((int)enemy.Position.X, (int)enemy.Position.Y,
                    (int)(Enemy.Sprites[0].Width * enemy.Size), (int)(Enemy.Sprites[0].Height * enemy.Size))))
                {
                    if (enemy.Size < player.Size)
                    {
                        enemies.RemoveAt(i);
                        player.Size += 0.025f;
                    }
                    else
                    {
                        player.Size = 0.4f;
                        Reset();
                    }
                }

            }
            Console.WriteLine(enemies.Count);
            if (enemies.Count <= 4)
                CreateEnemy();

            
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
            if(enemy.Direction == 1)
                enemy.Position = new Vector2(-Enemy.Sprites[0].Width * enemy.Size,
                    random.Next(720 - (int)(Enemy.Sprites[0].Width * enemy.Size)));
            else
                enemy.Position = new Vector2(1280 + (Enemy.Sprites[0].Width * enemy.Size),
                    random.Next(720 - (int)(Enemy.Sprites[0].Width * enemy.Size)));
            enemies.Add(enemy);
        }

        public static void Reset()
        {
            for (int i = 0; i < enemies.Count; i += 1)
                enemies.RemoveAt(i);
        }
    }
}
