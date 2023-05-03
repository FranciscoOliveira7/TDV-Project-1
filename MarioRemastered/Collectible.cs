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
    class Collectible
    {
        public ContentManager content;
        public Texture2D texture;
        public Vector2 position;
        public int width, height;
        public Rectangle bounds;
        public Player player;

        public Collectible(ContentManager content,Player player,String tex,int x, int y)
        {
            this.player = player;
            this.content = content;          
            texture = content.Load<Texture2D>(tex);          
            width = texture.Width;
            height = texture.Height;
            position = new Vector2(x, y);
            bounds = new Rectangle((int)position.X, (int)position.Y, width, height);

        }

        public virtual void refresh()
        {
            bounds.X = (int)position.X;
            bounds.Y = (int)position.Y;
        }

        public Rectangle getBounds()
        {
            refresh();
            return bounds;
        }

        public void checkCollision()
        {
            refresh();
            if (bounds.Intersects(player.getBounds()))
            {
                dispose();               
                collect();              
            }
        }

        public void dispose()
        {
           position.X = -1280;
           position.Y = 0;          
           refresh();
        }

        public virtual void collect()
        {
            //override and do some stuff
        }

    }
}
