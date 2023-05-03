using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioRemastered
{
    class Monster
    {
        public ContentManager content;
        public Texture2D texture;
        public Vector2 position;
        public int width, height;
        public Rectangle bounds,right,left,top;
        public Player player;
        public int rotation = 0;
        public bool collusingRight,collusingLeft;

        public Monster(ContentManager content, Player player, String tex, int x, int y)
        {
            this.player = player;
            this.content = content;
            texture = content.Load<Texture2D>(tex);
            width = texture.Width;
            height = texture.Height;
            position = new Vector2(x, y);
            bounds = new Rectangle((int)position.X, (int)position.Y, width, height);
            left = new Rectangle((int)position.X, (int)position.Y + 5, 5, height - 10);
            top = new Rectangle((int)position.X, (int)position.Y , width, 10);
            right = new Rectangle((int)position.X + width - 5, (int)position.Y + 5, 5, height - 10);
        }

        public void refresh()
        {
            left.X = (int)position.X;
            left.Y = (int)position.Y + 5;
            right.X = (int)position.X + width - 5;
            right.Y = (int)position.Y + 5;
            top.X = (int)position.X;
            top.Y = (int)position.Y;
        }

        public void refbounds()
        {
            bounds.X = (int)position.X;
            bounds.Y = (int)position.Y;
        }

        public void move()
        {
            if (rotation == 0)
            {
                position.X += 5;
            }
            if(rotation == 1)
            {
                position.X -= 5;
            }
        }

        public void checkCollision()
        {
            refbounds();
            refresh();
            if (bounds.Intersects(player.getBounds()))
            {                
                if (top.Intersects(player.getBot()))
                {
                    //Console.WriteLine("---MONSTER DIED---");
                    player.position.Y -= 60;
                    position.X = -2000;
                    rotation = 3;
                }
                else
                {
                    //Console.WriteLine("---MARIO DAMAGED---");
                    player.takeDamage();
                    if (rotation == 0)
                    {
                        rotation = 1;
                    }
                    else if (rotation == 1)
                    {
                        rotation = 0;
                    }
                }
            }
        }

        public Rectangle getLeft()
        {
            refresh();
            return left;
        }
        public Rectangle getRight()
        {
            refresh();
            return right;
        }

    }

    

}
