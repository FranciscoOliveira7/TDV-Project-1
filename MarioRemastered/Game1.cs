using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;

namespace MarioRemastered
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {   
        GraphicsDeviceManager graphics;
        Song song;
        SoundEffect hop;
        KeyboardState ks1, ks2;
        public static SpriteBatch spriteBatch;
        Player mario;
        Ground ground,ground2,ground3,kutular1,boru1,boru2,boru4,boru5,kutular2,kutular3,boru3,
                kutular4,kutular5,kutular6,kutular7,kutular8, miniboru1;
        Coin coin1, coin2, coin3, coin4, coin5,coin6, coin7, coin8, coin9,coin10, coin11, coin12, coin13, coin14;
        Monster mon1,mon2;
        MushroomGround mantarkutu1,mantarkutu2;
        CoinGround coinkutu1,coinkutu2,coinkutu3,coinkutu4,coinkutu5;
        List<Ground> currentGroundList;
        List<MushroomGround> currentMushroomGroundList;
        List<Mushroom> currentMushroomList;
        List<Coin> currentCoinList;
        List<CoinGround> currentCoinGroundList;
        List<Monster> currentMonsterList;
        Texture2D background;
        Vector2 bgposition = new Vector2(0, 0);
        TimeSpan x = new TimeSpan(0, 0, 0);
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.IsFullScreen = false;
            Content.RootDirectory = "Content";

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            mario = new Player(Content);
            ground = new Ground(Content, mario,"aa",0,600);
            ground2 = new Ground(Content, mario, "aa", 1280, 600);
            ground3 = new Ground(Content, mario, "aa", 2560, 600);
            kutular1 = new Ground(Content, mario, "kutular", 500, 440);
            kutular2 = new Ground(Content, mario, "kutular", 1250, 320);
            kutular3 = new Ground(Content, mario, "kutular", 1530, 440);
            kutular4 = new Ground(Content, mario, "kutular", 1920, 400);
            kutular5 = new Ground(Content, mario, "kutular", 2300, 370);
            kutular6 = new Ground(Content, mario, "kutular", 2500, 320);
            kutular7 = new Ground(Content, mario, "kutular", 2700, 270);
            kutular8 = new Ground(Content, mario, "kutular", 3090, 350);
            mantarkutu1 = new MushroomGround(Content, mario, "kutu", 596, 280);
            mantarkutu2 = new MushroomGround(Content, mario, "kutu", 2558, 170);
            boru1 = new Ground(Content, mario, "pipe", 900, 482);
            boru2 = new Ground(Content, mario, "pipe", 1100, 482);
            boru3 = new Ground(Content, mario, "pipe", 1800, 482);
            boru4 = new Ground(Content, mario, "pipe", 2970, 482);
            boru5 = new Ground(Content, mario, "pipe", 3400, 482);
            miniboru1 = new Ground(Content, mario, "pipe_mini", 2170, 514);
            coin1 = new Coin(Content, mario, "coin", 1020, 275);
            coin2 = new Coin(Content, mario, "coin", 1252, 275);
            coin3 = new Coin(Content, mario, "coin", 1300, 275);
            coin4 = new Coin(Content, mario, "coin", 1348, 275);
            coin5 = new Coin(Content, mario, "coin", 1396, 275);
            coin6 = new Coin(Content, mario, "coin", 1880, 552);
            coin7 = new Coin(Content, mario, "coin", 1940, 552);
            coin8 = new Coin(Content, mario, "coin", 2000, 552);
            coin9 = new Coin(Content, mario, "coin", 2060, 552);
            coin10 = new Coin(Content, mario, "coin", 2120, 552);
            coin11 = new Coin(Content, mario, "coin", 2705, 224);
            coin12 = new Coin(Content, mario, "coin", 2753, 224);
            coin13 = new Coin(Content, mario, "coin", 2801, 224);
            coin14 = new Coin(Content, mario, "coin", 2849, 224);
            coinkutu1 = new CoinGround(5, Content, mario, "kutu", 452, 440);
            coinkutu2 = new CoinGround(3, Content, mario, "kutu", 548, 280);
            coinkutu3 = new CoinGround(2, Content, mario, "kutu", 1968, 225);
            coinkutu4 = new CoinGround(1, Content, mario, "kutu", 2016, 225);
            coinkutu5 = new CoinGround(1, Content, mario, "kutu", 3282, 350);
            mon1 = new Monster(Content, mario, "goomba", 1450, 540);
            mon2 = new Monster(Content, mario, "goomba", 2570, 540);
            currentGroundList = new List<Ground>();
            currentGroundList.Add(ground);
            currentGroundList.Add(ground2);
            currentGroundList.Add(ground3);
            currentGroundList.Add(kutular1);
            currentGroundList.Add(kutular2);
            currentGroundList.Add(kutular3);
            currentGroundList.Add(kutular4);
            currentGroundList.Add(kutular5);
            currentGroundList.Add(kutular6);
            currentGroundList.Add(kutular7);
            currentGroundList.Add(kutular8);
            currentGroundList.Add(boru1);
            currentGroundList.Add(boru2);
            currentGroundList.Add(boru3);
            currentGroundList.Add(boru4);
            currentGroundList.Add(boru5);
            currentGroundList.Add(miniboru1);
            currentMushroomGroundList = new List<MushroomGround>();
            currentMushroomGroundList.Add(mantarkutu1);
            currentMushroomGroundList.Add(mantarkutu2);
            currentMushroomList = new List<Mushroom>();            
            currentCoinList = new List<Coin>();
            currentCoinList.Add(coin1);
            currentCoinList.Add(coin2);
            currentCoinList.Add(coin3);
            currentCoinList.Add(coin4);
            currentCoinList.Add(coin5);
            currentCoinList.Add(coin6);
            currentCoinList.Add(coin7);
            currentCoinList.Add(coin8);
            currentCoinList.Add(coin9);
            currentCoinList.Add(coin10);
            currentCoinList.Add(coin11);
            currentCoinList.Add(coin12);
            currentCoinList.Add(coin13);
            currentCoinList.Add(coin14);
            currentCoinGroundList = new List<CoinGround>();
            currentCoinGroundList.Add(coinkutu1);
            currentCoinGroundList.Add(coinkutu2);
            currentCoinGroundList.Add(coinkutu3);
            currentCoinGroundList.Add(coinkutu4);
            currentCoinGroundList.Add(coinkutu5);
            currentMonsterList = new List<Monster>();
            currentMonsterList.Add(mon1);
            currentMonsterList.Add(mon2);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);           
            background = Content.Load<Texture2D>("back");
            song = Content.Load<Song>("backgroundmusic");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(song);
            MediaPlayer.Volume = (float)0.4;
            hop = Content.Load<SoundEffect>("jump");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            Console.WriteLine("MarioX: " + mario.position.X + " y: "+mario.position.Y+" velx: "+mario.velocity.X);
            // Console.WriteLine("Ground: " + ground.position.X + " y: " + ground.position.Y);
            if (mario.position.X < 740)
            {
                mario.cameraRight = false;
            }            
            
            foreach (var mgnd in currentMushroomGroundList)
            {
                if (mgnd.mushroomActivated() && !mgnd.addedToList)
                {
                    currentMushroomList.Add(mgnd.m);
                    mgnd.addedToList = true;
                }
            }
       

            foreach (var gnd in currentGroundList)
            {
                gnd.checkCollision();
                foreach (var mon in currentMonsterList)
                {
                    gnd.checkMonsterCollision(mon);
                }
            }

            foreach (var mgnd in currentMushroomGroundList)
            {
                mgnd.checkCollision();
                foreach (var mon in currentMonsterList)
                {
                    mgnd.checkMonsterCollision(mon);
                }
            }

            foreach (var m in currentMushroomList)
            {
                m.checkCollision();
            }

            foreach (var c in currentCoinList)
            {
                c.checkCollision();
            }
            foreach (var ck in currentCoinGroundList)
            {
                ck.checkCollision();
                foreach (var mon in currentMonsterList)
                {
                    ck.checkMonsterCollision(mon);
                }
            }
            foreach (var mon in currentMonsterList)
            {
                mon.checkCollision();
            }


            if (mario.position.X <= 0)
            {
                mario.position.X = 0;
                mario.velocity.X = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ks1 = Keyboard.GetState();
            if (ks1.IsKeyDown(Keys.Up) && ks2.IsKeyUp(Keys.Up))
            {
                mario.jump();
                hop.Play((float)0.1,0,0);
            }
            ks2 = ks1;

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && !mario.collusingLeft)
            {
                mario.findState('l');
                
                if (mario.cameraRight)
                {
                    mario.cameraRight = false;
                    mario.velocity.X = 0;
                }

                if (mario.position.X <= 0)
                {
                    mario.position.X = 0;
                }
                else
                {

                    mario.setVelX(-1); //0.75
                }

            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right) && !mario.collusingRight)
            {
                mario.findState('r');
                if (mario.position.X >= 740)
                {
                    mario.setVelX(1);
                    mario.cameraRight = true;
                }
                else
                {
                    mario.setVelX(1);
                }

            }

            if (mario.collusingRight == false && mario.cameraRight && Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                foreach (var gnd in currentGroundList)
                {
                    gnd.position.X -= mario.velocity.X;
                }
                foreach (var mgnd in currentMushroomGroundList)
                {
                    mgnd.position.X -= mario.velocity.X;
                }
                foreach (var m in currentMushroomList)
                {
                    m.position.X -= mario.velocity.X;
                }
                foreach (var c in currentCoinList)
                {
                    c.position.X -= mario.velocity.X;
                }
                foreach (var ck in currentCoinGroundList)
                {
                    ck.position.X -= mario.velocity.X;
                }
                foreach (var mon in currentMonsterList)
                {
                    mon.position.X -= mario.velocity.X;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.X))
            {
                if (mario.size == 0)
                {
                    mario.size = 1;
                }
                else if (mario.size == 1)
                {
                    mario.size = 2;
                }
                else if (mario.size == 2)
                {
                    mario.size = 0;
                }
            }



            mario.findState('n');
            //mario.myState();
            mario.gravity();
            if (mario.velocity.X > 6)
            {
                mario.velocity.X = 6;
            }
            else if (mario.velocity.X < -6)
            {
                mario.velocity.X = -6;
            }
            foreach (var mon in currentMonsterList)
            {
                mon.move();
            }
            mario.move();

            if (mario.position.Y > 720)
            {
                Console.WriteLine("GAME OVER!");
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkSlateGray);
            spriteBatch.Begin();
            //Console.WriteLine(gameTime.ElapsedGameTime);
            x += gameTime.ElapsedGameTime;
            //Console.WriteLine(x.Milliseconds);
            if (x.Milliseconds == 100)
            {
                mario.animate();
                x = gameTime.ElapsedGameTime;
            }
            spriteBatch.Draw(background, bgposition, Color.White);
            spriteBatch.Draw(mario.currenttexture, mario.position, Color.White);
            foreach (var mgnd in currentMushroomGroundList)
            {
                spriteBatch.Draw(mgnd.texture, mgnd.position, Color.White);
            }
            foreach (var gnd in currentGroundList)
            {
                spriteBatch.Draw(gnd.texture, gnd.position, Color.White);
            }            
            foreach (var m in currentMushroomList)
            {
                spriteBatch.Draw(m.texture, m.position, Color.White);
            }
            foreach (var c in currentCoinList)
            {
                spriteBatch.Draw(c.texture, c.position, Color.White);
            }
            foreach (var ck in currentCoinGroundList)
            {
                spriteBatch.Draw(ck.texture, ck.position, Color.White);
            }
            foreach (var mon in currentMonsterList)
            {
                spriteBatch.Draw(mon.texture, mon.position, Color.White);
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
