using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace MarioRemastered
{
    class Coin : Collectible
    {
        static SoundEffect altin;
        public Coin(ContentManager content, Player player, string tex, int x, int y) : base(content, player, tex, x, y)
        {
            altin = content.Load<SoundEffect>("altin");
        }

        public override void collect()
        {
            player.collectCoin();
            altin.Play(1, 0, 0);
        }
    }
}
