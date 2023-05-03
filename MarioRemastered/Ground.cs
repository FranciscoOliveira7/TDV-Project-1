using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioRemastered
{
    class Ground
    {
        public ContentManager content;
        public Player player;
        public Texture2D texture;
        public Vector2 position;
        public int width, height;
        public Rectangle gnd;

        public Ground(ContentManager content, Player player,String tex,int x, int y)
        {
            this.player = player;
            this.content = content;
            texture = content.Load<Texture2D>(tex);
            width = texture.Width;
            height = texture.Height;
            position = new Vector2(x, y);
            gnd = new Rectangle((int)position.X, (int)position.Y, width, height);
            
        }

        public void refresh()
        {
            gnd.X = (int)position.X;
            gnd.Y = (int)position.Y;
        }
       
        public void newBot()
        {
            refresh();
            if (gnd.Intersects(player.getBot())){

                player.velocity.Y = 0;
                player.position.Y = gnd.Y - player.height;            
                player.jumping = false;
                player.collusingBottom = true;
                         

            }
            else
            {
                player.collusingBottom = false;
            }
        }

        public virtual void newTop()
        {
            refresh();
            if (gnd.Intersects(player.getT()))
            {               
                if (!player.collusingTop)
                {       
                player.velocity.Y = 0;
                player.jumping = true;                
                player.position.Y = gnd.Y + height;
                
                player.collusingTop = true;
                }

            }
            else
            {
                player.collusingTop = false;
            }
        }

        public void newLeft()
        {
            refresh();
                   
            if (gnd.Intersects(player.getL()))
            {               

                player.velocity.X = 0;
                player.position.X = gnd.X + width;
                player.collusingLeft = true;

            }
            else
            {
                player.collusingLeft = false;
            }
        }

        public void newRight()
        {
            refresh();
            if (gnd.Intersects(player.getR()))
            {                
                if (!player.collusingRight)
                {
                    player.velocity.X = 0;
                    player.position.X = gnd.X-player.currenttexture.Width;
                    player.collusingRight = true;
                }                
            }
            else
            {
                player.collusingRight = false;
            }
        }

        public void checkMonsterCollision(Monster mon)
        {
            refresh();
            if (gnd.Intersects(mon.getLeft()))
            {
                mon.rotation = 0;
            }

            if (gnd.Intersects(mon.getRight()))
            {
                mon.rotation = 1;
            }
        }


        
        public void checkCollision()
        {
            newBot();
            newTop();
            newRight();
            newLeft();
            

            //checkBottomCollision();
            //checkLeftCollision();
           // checkRightCollision();
           // checkTopCollision();
        }
    }
}
