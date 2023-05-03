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
    class Mushroom : Collectible
    {
        public bool collusingTop , collusingBot , collusingRight , collusingLeft;
        static SoundEffect grow;
        public Rectangle bot, top, right, left;
        public Vector2 velocity = new Vector2(0, 0);
        public Mushroom(ContentManager content, Player player, string tex, int x, int y) : base(content, player, tex, x, y)
        {
            bot = new Rectangle((int)position.X + 5, (int)position.Y + height - 5, width - 10, 5);
            top = new Rectangle((int)position.X + 5, (int)position.Y, width - 10, 5);
            left = new Rectangle((int)position.X, (int)position.Y + 5, 5, height - 10);
            right = new Rectangle((int)position.X + width - 5, (int)position.Y + 5, 5, height - 10);
            grow = content.Load<SoundEffect>("grow");
        }

        public override void collect()
        {
            player.size = 1;
            grow.Play(1, 0, 0);
        }

        public void refreshAll()
        {
            bot.X = (int)position.X + 5;
            bot.Y = (int)position.Y + height - 5;
            top.X = (int)position.X + 5;
            top.Y = (int)position.Y;
            left.X = (int)position.X;
            left.Y = (int)position.Y + 5;
            right.X = (int)position.X + width - 5;
            right.Y = (int)position.Y + 5;
        }

        public Rectangle getTop()
        {
            refreshAll();
            return top;
        }
        public Rectangle getBot()
        {
            refreshAll();
            return bot;
        }
        public Rectangle getLeft()
        {
            refreshAll();
            return left;
        }
        public Rectangle getRight()
        {
            refreshAll();
            return right;
        }

    }
}
