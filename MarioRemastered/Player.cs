using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioRemastered
{
    class Player
    {
        public static ContentManager content;
        public Texture2D currenttexture,
            //default
            texture_stand_left,texture_stand_right,texture_walk_right, texture_walk_left,
            texture_jump_left,texture_jump_right,
            //mini
            texture_stand_right_mini, texture_stand_left_mini,texture_jump_right_mini,texture_jump_left_mini,
            texture_walk_left_mini,texture_walk_right_mini,
            //fire
            texture_stand_right_fire, texture_stand_left_fire,texture_jump_right_fire,texture_jump_left_fire,
            texture_walk_left_fire,texture_walk_right_fire;
        public int width, height;
        public Vector2 position, velocity;
        public bool jumping,collusingLeft,collusingRight,collusingTop,collusingBottom,cameraRight;
        public Rectangle bot,top,right,left,bounds;
        public bool standingR = true, standingL = false, walkingRight = false, walkingLeft = false, onAir=true;
        public int size = 0;
        public int coin = 0;

        public Player(ContentManager content)
        {
            Player.content = content;
            texture_stand_right = content.Load<Texture2D>("texture_stand_right");
            texture_stand_left = content.Load<Texture2D>("texture_stand_left");
            texture_walk_right = content.Load<Texture2D>("texture_walk_right");
            texture_walk_left = content.Load<Texture2D>("texture_walk_left");
            texture_jump_left = content.Load<Texture2D>("texture_jump_left");
            texture_jump_right = content.Load<Texture2D>("texture_jump_right");
            texture_stand_right_mini = content.Load<Texture2D>("texture_stand_right_mini");
            texture_stand_left_mini = content.Load<Texture2D>("texture_stand_left_mini");
            texture_jump_right_mini = content.Load<Texture2D>("texture_jump_right_mini");
            texture_jump_left_mini = content.Load<Texture2D>("texture_jump_left_mini");
            texture_walk_right_mini = content.Load<Texture2D>("texture_walk_right_mini");
            texture_walk_left_mini = content.Load<Texture2D>("texture_walk_left_mini");
            texture_stand_right_fire = content.Load<Texture2D>("texture_stand_right_fire");
            texture_stand_left_fire = content.Load<Texture2D>("texture_stand_left_fire");
            texture_jump_right_fire = content.Load<Texture2D>("texture_jump_right_fire");
            texture_jump_left_fire = content.Load<Texture2D>("texture_jump_left_fire");
            texture_walk_right_fire = content.Load<Texture2D>("texture_walk_right_fire");
            texture_walk_left_fire = content.Load<Texture2D>("texture_walk_left_fire");
            currenttexture = texture_jump_right_mini;          
            position = new Vector2(0, 482);
            velocity = new Vector2(0, 0);
            width = currenttexture.Width;
            height = currenttexture.Height;
            bot = new Rectangle((int)position.X+5, (int)position.Y + height - 5, width-10, 5);
            top = new Rectangle((int)position.X+5, (int)position.Y, width-10, 5);
            left = new Rectangle((int)position.X, (int)position.Y+5, 5, height-10);
            right = new Rectangle((int)position.X + width - 5, (int)position.Y+5, 5, height-10);
            bounds = new Rectangle((int)position.X + 5, (int)position.Y + 5, width - 10, height - 10);
        }

        public void collectCoin()
        {
            coin++;
            Console.WriteLine("coin: " + coin);
        }
        public void takeDamage()
        {
            if (size == 0)
            {
                Console.WriteLine("MARIO DIED!");
            }
            else
            {
                size--;
                if (size == 0)
                {
                    position.Y += 48;
                }                
            }
            
        }
        public void myState()
        {
            if (walkingLeft)
            {
                Console.WriteLine("STATE: walking left");
            }
            else if (walkingRight)
            {
                Console.WriteLine("STATE: walking right");
            }
            else if (standingL)
            {
                Console.WriteLine("STATE: standing left");
            }
            else if (standingR)
            {
                Console.WriteLine("STATE: standing right");
            }
        }
        public void findState(char c)
        {
            if (c == 'l')
            {
                if (standingL)
                {
                    walkingLeft = true;
                    standingL = false;
                    standingR = false;
                    walkingRight = false;
                }
                else if (standingR)
                {
                    standingL = true;
                    standingR = false;
                    walkingRight = false;
                    walkingLeft = false;
                }
                else if (walkingRight)
                {
                    standingL = true;
                    standingR = false;
                    walkingRight = false;
                    walkingLeft = false;
                }
            }
            if (c == 'r')
            {
                if (standingR)
                {
                    walkingRight = true;
                    standingL = false;
                    standingR = false;
                    walkingLeft = false;
                }
                else if (standingL)
                {
                    standingR = true;
                    standingL = false;
                    walkingRight = false;
                    walkingLeft = false;
                }
                else if (walkingLeft)
                {
                    standingR = true;
                    standingL = false;
                    walkingRight = false;
                    walkingLeft = false;
                }

            }
            if (c == 'n')
            {
                if (Math.Abs(velocity.Y) > 0)
                {
                    onAir = true;
                }
                else
                {
                    onAir = false;
                }
                if (walkingRight)
                {
                    if(Math.Abs(velocity.X) < 2)
                    {
                        walkingRight = false;
                        standingR = true;
                    }
                }
                else if (walkingLeft)
                {
                    if(Math.Abs(velocity.X) < 2)
                    {
                        walkingLeft = false;
                        standingL = true;
                    }
                }
            }

        }

        public void animate()
        {

            if (standingR)
            {
                switch (size)
                {
                    case 0:
                        currenttexture = texture_stand_right_mini;
                        break;
                    case 1:
                        currenttexture = texture_stand_right;
                        break;
                    case 2:
                        currenttexture = texture_stand_right_fire;
                        break;
                }
                
            }
            if (standingL)
            {
                switch (size)
                {
                    case 0:
                        currenttexture = texture_stand_left_mini;
                        break;
                    case 1:
                        currenttexture = texture_stand_left;
                        break;
                    case 2:
                        currenttexture = texture_stand_left_fire;
                        break;
                }
               
            }
            if (walkingRight)
            {
                switch (size)
                {
                    case 0:
                        if (currenttexture.Name == "texture_stand_right_mini")
                        {
                            currenttexture = texture_walk_right_mini;//walk
                        }
                        else
                        {
                            currenttexture = texture_stand_right_mini;
                        }
                        break;
                    case 1:
                        if (currenttexture.Name == "texture_stand_right")
                        {
                            currenttexture = texture_walk_right;//walk
                        }
                        else
                        {
                            currenttexture = texture_stand_right;
                        }
                        break;
                    case 2:
                        if (currenttexture.Name == "texture_stand_right_fire")
                        {
                            currenttexture = texture_walk_right_fire;//walk
                        }
                        else
                        {
                            currenttexture = texture_stand_right_fire;
                        }
                        break;
                }
                
            }
            if (walkingLeft)
            {
                switch (size)
                {
                    case 0:
                        if (currenttexture.Name == "texture_stand_left_mini")
                        {
                            currenttexture = texture_walk_left_mini;//walk
                        }
                        else
                        {
                            currenttexture = texture_stand_left_mini;
                        }
                        break;
                    case 1:
                        if (currenttexture.Name == "texture_stand_left")
                        {
                            currenttexture = texture_walk_left;//walk
                        }
                        else
                        {
                            currenttexture = texture_stand_left;
                        }
                        break;
                    case 2:
                        if (currenttexture.Name == "texture_stand_left_fire")
                        {
                            currenttexture = texture_walk_left_fire;//walk
                        }
                        else
                        {
                            currenttexture = texture_stand_left_fire;
                        }
                        break;
                }
                
            }
            if (onAir)
            {
                switch (size)
                {
                    case 0:
                        if (walkingLeft || standingL)
                        {
                            currenttexture = texture_jump_left_mini;
                        }
                        else
                        {
                            currenttexture = texture_jump_right_mini;
                        }
                        break;
                    case 1:
                        if (walkingLeft || standingL)
                        {
                            currenttexture = texture_jump_left;
                        }
                        else
                        {
                            currenttexture = texture_jump_right;
                        }
                        break;
                    case 2:
                        if (walkingLeft || standingL)
                        {
                            currenttexture = texture_jump_left_fire;
                        }
                        else
                        {
                            currenttexture = texture_jump_right_fire;
                        }
                        break;
                }               
                
            }
            else if(currenttexture.Name.StartsWith("texture_jump_"))
            {
                switch (size)
                {
                    case 0:
                        if (walkingLeft || standingL)
                        {
                            currenttexture = texture_stand_left_mini;
                        }
                        else
                        {
                            currenttexture = texture_stand_right_mini;
                        }
                        break;
                    case 1:
                        if (walkingLeft || standingL)
                        {
                            currenttexture = texture_stand_left;
                        }
                        else
                        {
                            currenttexture = texture_stand_right;
                        }
                        break;
                    case 2:
                        if (walkingLeft || standingL)
                        {
                            currenttexture = texture_stand_left_fire;
                        }
                        else
                        {
                            currenttexture = texture_stand_right_fire;
                        }
                        break;
                }

                
            }
          
    

        }

        public void gravity()
        {
            if (!collusingBottom)
            {
                setVelY(1); //0.95
                jumping = true;
            }
            else
            {
                velocity.Y = 0;
                
            }
                     
        }

        public void move()
        {
            if (velocity.X > 6)
            {
                velocity.X = 6;
            }
            else if(velocity.X<-6)
            {
                velocity.X = -6;
            }
            if (cameraRight)
            {               
                position.Y += velocity.Y;
                friction();
            }
            else
            {
                position.X += velocity.X;
                position.Y += velocity.Y;
                friction();
            }
                
        }

        public void jump()
        {          
            if (!jumping && !collusingTop)
            {
                collusingBottom = false;
                jumping = true;                
                if (velocity.X > 3 || velocity.X < -3)
                {
                    velocity.Y -= 30;
                }
                else
                {
                    velocity.Y -= 20;
                }             
                
            }
            
        }

        public void friction()
        {
            velocity.X *= (float)0.9;
            velocity.Y *= (float)0.9;
        }
        
        public void setVelX(double num)
        {
            velocity.X += (float)num;
        }

        public void setVelY(double num)
        {
            velocity.Y += (float)num;
        }
        public void refresh()
        {
            width = currenttexture.Width;
            height = currenttexture.Height;
            bot.X = (int)position.X + 5;
            bot.Y = (int)position.Y + height - 5;
            bot.Width = width-10;
            bot.Height = 5;
            top.X = (int)position.X+5;
            top.Y = (int)position.Y;
            top.Width = width-10;
            top.Height = 5;
            left.X = (int)position.X;
            left.Y = (int)position.Y+5;
            left.Width = 5;
            left.Height = height - 10;
            right.X = (int)position.X+width-5;
            right.Y = (int)position.Y+5;
            right.Width = 5;
            right.Height = height - 10;
            bounds.X = (int)position.X + 5;
            bounds.Y = (int)position.Y + 5;
            bounds.Width = width - 10;
            bounds.Height = height - 10;
        }

        public Rectangle getBot()
        {
            refresh();
            return bot; 

        }
        public Rectangle getT()
        {
            refresh();
            return top;

        }
        public Rectangle getR()
        {
            refresh();
            return right;

        }
        public Rectangle getL()
        {
            refresh();
            return left;

        }

        public Rectangle getBounds()
        {
            bounds.X = (int)position.X;
            bounds.Y = (int)position.Y;
            return bounds;
        }
    }
}
