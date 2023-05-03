using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace MarioRemastered
{
    class CoinGround : MushroomGround
    {
        int counter = 0;
        static SoundEffect altin;
        public CoinGround(int sayac,ContentManager content, Player player, string tex, int x, int y) : base(content, player, tex, x, y)
        {
            counter = sayac;
            altin = content.Load<SoundEffect>("altin");
        }
        public override void newTop()
        {
            refresh();
            if (gnd.Intersects(player.getT()))
            {
                if (counter > 0)
                {
                    counter--;
                    player.collectCoin();
                    altin.Play(1, 0, 0);
                    if (counter == 0)
                    {
                       texture = off;
                    }                    
                }
                if (!player.collusingTop)
                {
                    player.velocity.Y = 0;
                    player.jumping = true;
                    player.collusingTop = true;
                    player.position.Y = gnd.Y + height;
                }
            }
            else
            {
                player.collusingTop = false;
            }
        }
    }
}
