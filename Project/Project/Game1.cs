using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Project
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {

        int bgCounter = 1;
        List<float> elapsedMissile;
        // List<float> elapsedZapper;
        float speedTime = 0;
        float lazerNextGen = 0;
        bool isPause = false;
        bool isDead = false;
        int coinStyle;
        int gameMode;
        Score score;
        Random rnd;
        //Zapper zapper;
        Background background;
        Background background2;
        List<Coin> coinList;
        Barry barry;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SoundEffect myMusic;
        SoundEffectInstance soundEngineInstance;
        SpriteFont sf;
        List<Missile> missileList;
        List<Zapper> zapperList;
        Color[] barryTextureData;
        Color[] zapperTextureData;
        Texture2D pause;
        Texture2D gameOver;
        SuperSpeed superSpeed;
        PowerUp powerUp;
        List<Lazer> lazerList;
        bool isMusic = true;
        bool issfx = true;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            //Setting The Game To Full Screen
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferMultiSampling = false;
            graphics.IsFullScreen = false;
            Content.RootDirectory = "Content";
            rnd = new Random();
        }


        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            base.Initialize();
        }

        private void startUp()
        {
            //Loading PowerUp
            powerUp = new PowerUp(Content, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height, 0, 0,
                    new Rectangle(graphics.GraphicsDevice.Viewport.Width - 500, rnd.Next(200, 800), 132, 132));
            //Loading Lazer
            lazerList = Creator.createLazer(rnd.Next(0, 4), Content);
            //Loading Zapper
            zapperList = new List<Zapper>();
            for (int i = 0; i < 6; i++)
            {
                int rnd2 = 0;
                for (int j = 0; j < 3; j++) rnd2 = rnd.Next(0, graphics.GraphicsDevice.Viewport.Height - 200);
                Zapper zapper = new Zapper(Content, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height, 0, 0,
                    new Rectangle(graphics.GraphicsDevice.Viewport.Width - 500, -500, 97, 263));
                zapperTextureData = zapper.getTextureData();
                zapperList.Add(zapper);
            }

            //Loading Score Font
            sf = Content.Load<SpriteFont>("SpriteFont1");

            //Loading Barry
            barry = new Barry(Content, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height, 0, 0,
                new Rectangle(200, 0, 100, 100));
            barryTextureData = barry.getTextureData();

            // Loading Backgrounds
            background = new Background(Content, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height, 0, 0,
                new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height));
            background2 = new Background(Content, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height, 0, 0,
                new Rectangle(graphics.GraphicsDevice.Viewport.Width, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height));

            //Loading Music
            myMusic = Content.Load<SoundEffect>("music");
            soundEngineInstance = myMusic.CreateInstance();
            soundEngineInstance.Volume = 0.5f;
            soundEngineInstance.IsLooped = true;

            //Loading Coins
            int rnd3 = rnd.Next(0, graphics.GraphicsDevice.Viewport.Height - 100);
            coinStyle = rnd.Next(0, 7);
            coinList = Creator.createCoin(coinStyle, Content, graphics);


            //Loading Missile
            elapsedMissile = new List<float>();
            missileList = new List<Missile>();
            for (int i = 0; i < 6; i++)
            {
                rnd3 = rnd.Next(50, graphics.GraphicsDevice.Viewport.Height - 100);
                missileList.Add(new Missile(Content, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height, 0, 0,
                    new Rectangle(graphics.GraphicsDevice.Viewport.Width - 100, 300, 100, 100)));
                elapsedMissile.Add(0f);
            }
            //Load Score
            score = new Score(Content);

            //Load Pause Screen
            pause = Content.Load<Texture2D>("pause");
            //Load Game Over Screen
            gameOver = Content.Load<Texture2D>("gameOver");
            //Load Super Speed
            superSpeed = new SuperSpeed(Content, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height, 0, 0,
                    new Rectangle(graphics.GraphicsDevice.Viewport.Width + 100, 300, 80, 80));
            //Load PowerUp
            powerUp = new PowerUp(Content, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height, 0, 0,
                    new Rectangle(graphics.GraphicsDevice.Viewport.Width, 300, 50, 50));
        }
        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            startUp();


        }

        protected override void UnloadContent()
        {

        }

        KeyboardState oldState;
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) this.Exit();

            if (gameMode == 0)
            //first menu
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space)) gameMode = 1;
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Point p = new Point(Mouse.GetState().X, Mouse.GetState().Y);
                    Rectangle r = new Rectangle(1365, 50, 530, 140);
                    if (r.Contains(p))
                    {

                        gameMode = 1;
                        isPause = false;
                    }
                    r.Y = 235;
                    if (r.Contains(p))
                    {

                        this.Exit();
                        
                    }                    
                    r.Y = 730;
                    r.X = 1500;
                    r.Width = 260;
                    r.Height = 130;
                    if (r.Contains(p))
                    {

                        this.Exit();
                    }
                    r.Y = 915;
                    r.X = 1445;
                    r.Width = 120;
                    r.Height = 120;
                    if (r.Contains(p))
                    {
                        //sound check
                        this.Exit();
                    }
                    r.X = 1705;
                    if (r.Contains(p))
                    {
                        //sound check
                        this.Exit();
                    }
                }
            }
            else if (gameMode == 1)
            //playing
            {
                Updater(gameTime);
                if (Keyboard.GetState().IsKeyDown(Keys.P) && oldState.IsKeyUp(Keys.P))
                {
                    gameMode = 2;
                    isPause = true;
                }
                //Play Background Music
                if (soundEngineInstance.State == SoundState.Stopped)
                {

                    soundEngineInstance.Play();
                }
                else
                    soundEngineInstance.Resume();


            }
            else if (gameMode == 2)
            //pause
            {
                if (Keyboard.GetState().IsKeyDown(Keys.P) && oldState.IsKeyUp(Keys.P))
                {
                    gameMode = 1;
                    isPause = false;
                }
                if(Mouse.GetState().LeftButton==ButtonState.Pressed)
                {
                    Point p = new Point(Mouse.GetState().X, Mouse.GetState().Y);
                    Rectangle r = new Rectangle(710, 345, 415, 140);
                    if (r.Contains(p))
                    {
                        
                        gameMode = 1;
                        isPause = false;
                    }
                    r.Y = 560;
                    if (r.Contains(p))
                    {

                        gameMode = 1;
                        isPause = false;
                        startUp();
                    }
                    r.Y = 780;
                    if (r.Contains(p))
                    {

                        gameMode = 3;
                        barry.isDead = true;
                        isDead=true;
                        isPause = false;
                    }
                    r.X = 1685;
                    r.Y = 45;
                    r.Width = r.Height = 130;
                    if (r.Contains(p))
                    {
                        this.Exit();

                        gameMode = 0;
                        isPause = false;
                    }
                    r.X = 1810;
                    if (r.Contains(p))
                    {
                        this.Exit();
                        gameMode = 0;
                        isPause = false;
                    }
                }
                //Stop Background Music
                soundEngineInstance.Pause();

            }
            else if (gameMode == 3)
            // barry dies
            {
                soundEngineInstance.Pause();
                isDead = true;
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    isDead = false;
                    gameMode = 1;
                    startUp();
                }

            }
            oldState = Keyboard.GetState();

            base.Update(gameTime);
        }
        public void Updater(GameTime gameTime)
        {
            #region make harder
            if (((float)gameTime.TotalGameTime.TotalSeconds > 10f && (float)gameTime.TotalGameTime.TotalSeconds < 10.01f)
                    || ((float)gameTime.TotalGameTime.TotalSeconds > 20f && (float)gameTime.TotalGameTime.TotalSeconds < 20.01f)
                    || ((float)gameTime.TotalGameTime.TotalSeconds > 30f && (float)gameTime.TotalGameTime.TotalSeconds < 30.01f))
            {
                for (int i = 0; i < 3; i++)
                {
                    int rnd3 = rnd.Next(50, graphics.GraphicsDevice.Viewport.Height - 100);
                    missileList.Add(new Missile(Content, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height, 0, 0,
                        new Rectangle(graphics.GraphicsDevice.Viewport.Width - 100, 0, 100, 100)));
                    elapsedMissile.Add(0f);
                }
                for (int i = 0; i < 3; i++)
                {
                    int rnd2 = 0;
                    for (int j = 0; j < 3; j++) rnd2 = rnd.Next(0, graphics.GraphicsDevice.Viewport.Height - 200);
                    Zapper zapper = new Zapper(Content, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height, 0, 0,
                        new Rectangle(graphics.GraphicsDevice.Viewport.Width - 500, -500, 97, 263));
                    zapperTextureData = zapper.getTextureData();
                    zapperList.Add(zapper);
                }
            }
            #endregion

            #region coin
            //Coin Hit Check
            foreach (Coin coin in coinList)
            {
                if ((!coin.isHit) && ((barry.position.X > coin.position.X && barry.position.X < coin.getRight() && barry.getBottom() > coin.position.Y && barry.getBottom() < coin.getBottom())
                                    || (barry.getRight() > coin.position.X && barry.getBottom() > coin.position.Y && barry.position.Y < coin.getBottom() && barry.position.X < coin.getRight())
                                    || (barry.position.Y < coin.getBottom() && barry.position.X > coin.position.X && barry.position.X < coin.getRight() && barry.getBottom() > coin.position.Y)))
                {
                    coin.collision();
                    score.gotCoins();
                }

            }
            //Changing Coin Pattern
            if (coinList[coinList.Count - 1].isLeft())
            {
                int backupStyle = coinStyle;
                while ((coinStyle = rnd.Next(0, 7)) == backupStyle) ;
                coinList = Creator.createCoin(coinStyle, Content, graphics);

            }
            #endregion

            #region lazer
            foreach (Lazer lazer in lazerList)
            {
                //if ((!lazer.isHit && lazer.isActive && !superSpeed.isActivated) && ((barry.position.X > lazer.position.X && barry.position.X < lazer.getRight() && barry.getBottom() > (lazer.position.Y + 50) && barry.getBottom() < lazer.getBottom())
                //                    || (barry.getRight() > lazer.position.X && barry.getBottom() > (lazer.position.Y + 50) && barry.position.Y < lazer.getBottom() && barry.position.X < lazer.getRight())
                //                    || (barry.position.Y < lazer.getBottom() && barry.position.X > lazer.position.X && barry.position.X < lazer.getRight() && barry.getBottom() > (lazer.position.Y + 50))))
                //{
                //    score.writeHighScore();
                //    //this.Exit();
                //    lazer.isHit = true;
                //    barry.isDead = true;
                //}

            }
            #endregion

            gameMode = barry.die();

            //Score Calculation
            score.run(gameTime, superSpeed.isActivated);


            //Barry Movement
            barry.physics(gameTime, superSpeed.isActivated);

            //Movements
            foreach (Coin coin in coinList) coin.move(gameTime);
            if ((float)gameTime.TotalGameTime.TotalSeconds > lazerNextGen)
            {
                foreach (Lazer lazer in lazerList)
                    lazer.turnOn(gameTime);
                foreach (Zapper zapper in zapperList)
                    if (zapper.isLeft() || zapper.isRight()) zapper.regenerate(gameTime);
                foreach (Missile missile in missileList)
                    if (missile.isLeft() || missile.isRight()) missile.regenerate(gameTime);
            }

            if (!lazerList[lazerList.Count - 1].isActive && lazerList[lazerList.Count - 1].isDown && lazerList[lazerList.Count - 1].position.Y == 0)
            {
                lazerNextGen = (float)gameTime.TotalGameTime.TotalSeconds + (float)rnd.Next(7, 15);
                lazerList = Creator.createLazer(rnd.Next(0, 4), Content);
            }

            #region missile
            //Missile Hit Check
            //foreach (Missile missile in missileList)
            //{
            //    if ((!superSpeed.isActivated) && (!missile.isHit) && ((barry.position.X > missile.position.X && barry.position.X < missile.getRight() && barry.getBottom() > missile.position.Y && barry.getBottom() < missile.getBottom())
            //                        || (barry.getRight() > missile.position.X && barry.getBottom() > missile.position.Y && barry.position.Y < missile.getBottom() && barry.position.X < missile.getRight())
            //                        || (barry.position.Y < missile.getBottom() && barry.position.X > missile.position.X && barry.position.X < missile.getRight() && barry.getBottom() > missile.position.Y)))
            //    {
            //        missile.collision();
            //        score.writeHighScore();
            //        //this.Exit();

            //        barry.isDead = true;
            //    }

            //}
            foreach (Missile missile in missileList)
            {
                missile.move(gameTime);
                if (missile.nextGen < gameTime.TotalGameTime.TotalSeconds && !missile.isLeft())
                {
                    if (elapsedMissile[missileList.IndexOf(missile)] > 5000)
                    {
                        missile.fire();
                    }
                    else if (elapsedMissile[missileList.IndexOf(missile)] > 4000)
                    {
                        elapsedMissile[missileList.IndexOf(missile)] += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                        missile.lockOn(gameTime);
                    }
                    else
                    {
                        elapsedMissile[missileList.IndexOf(missile)] += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                        missile.load(new Vector2(barry.position.X, barry.position.Y), gameTime);
                    }
                }
                else if (missile.isLeft())
                {
                    missile.regenerate(gameTime);
                    //     Console.WriteLine("-->"+missileList.IndexOf(missile));
                    elapsedMissile[missileList.IndexOf(missile)] = 0;
                }
            }
            #endregion

            #region zapper
            Matrix barryTransform =
                Matrix.CreateTranslation(new Vector3(new Vector2(barry.position.X, barry.position.Y), 0.0f));

            Rectangle barryRectangle =
                new Rectangle((int)barry.position.X, (int)barry.position.Y,
                barry.position.Width, barry.position.Height);

            //foreach (Zapper zapper in zapperList)
            //{
            //    Matrix zapperTransform =
            //       Matrix.CreateTranslation(new Vector3(-new Vector2(zapper.position.Width / 2, zapper.position.Height / 2), 0.0f)) *
            //       // Matrix.CreateScale(block.Scale) *  would go here
            //       Matrix.CreateRotationZ(zapper.getRotation()) *
            //       Matrix.CreateTranslation(new Vector3(new Vector2(zapper.position.X, zapper.position.Y), 0.0f));
            //    Rectangle zapperRectangle = Collision.CalculateBoundingRectangle(
            //                 new Rectangle(0, 0, zapper.position.Width, zapper.position.Height),
            //                 zapperTransform);
            //    //Zapper Hit Check
            //    if (barryRectangle.Intersects(zapperRectangle))
            //    {
            //        // Check collision with person
            //        if ((!superSpeed.isActivated )&&( !zapper.isHit) && (!barry.isDead) && Collision.IntersectPixels(barryTransform, barry.position.Width,
            //                            barry.position.Height, barryTextureData,
            //                            zapperTransform, zapper.position.Width,
            //                            zapper.position.Height, zapperTextureData))
            //        {
            //            score.writeHighScore();
            //            zapper.isHit = true;
            //            barry.isDead = true;


            //            //this.Exit();
            //        }
            //    }
            //}
            foreach (Zapper z in zapperList)
            {
                z.screenZap(gameTime);
            }
            foreach (Zapper zapper in zapperList)
            {
                if (zapper.nextGen < gameTime.TotalGameTime.TotalSeconds && !zapper.isLeft())
                {
                    zapper.move(gameTime);
                }
                if (zapper.isLeft())
                {
                    zapper.regenerate(gameTime);
                }
            }
            #endregion

            #region superspeed
            //if ((!superSpeed.isActivated) && ((barry.position.X > superSpeed.position.X && barry.position.X < superSpeed.getRight() && barry.getBottom() > superSpeed.position.Y && barry.getBottom() < superSpeed.getBottom())
            //                        || (barry.getRight() > superSpeed.position.X && barry.getBottom() > superSpeed.position.Y && barry.position.Y < superSpeed.getBottom() && barry.position.X < superSpeed.getRight())
            //                        || (barry.position.Y < superSpeed.getBottom() && barry.position.X > superSpeed.position.X && barry.position.X < superSpeed.getRight() && barry.getBottom() > superSpeed.position.Y)))
            //{
            //    superSpeed.collide();
            //    superSpeed.regenerate(gameTime);
            //    speedTime = (float)gameTime.TotalGameTime.TotalSeconds;
            //}
            if (superSpeed.isActivated && speedTime + 3 < (float)gameTime.TotalGameTime.TotalSeconds) superSpeed.isActivated = false;
            if (superSpeed.nextGen < gameTime.TotalGameTime.TotalSeconds && !superSpeed.isLeft())
            {
                superSpeed.move(gameTime);
            }
            if (superSpeed.isLeft())
            {
                superSpeed.regenerate(gameTime);
            }
            #endregion

            //if ((!superSpeed.isActivated) && ((barry.position.X > powerUp.position.X && barry.position.X < powerUp.getRight() && barry.getBottom() > (powerUp.position.Y + 50) && barry.getBottom() < powerUp.getBottom())
            //                       || (barry.getRight() > powerUp.position.X && barry.getBottom() > (powerUp.position.Y + 50) && barry.position.Y < powerUp.getBottom() && barry.position.X < powerUp.getRight())
            //                       || (barry.position.Y < powerUp.getBottom() && barry.position.X > powerUp.position.X && barry.position.X < powerUp.getRight() && barry.getBottom() > (powerUp.position.Y + 50))))
            //{
            //    powerUp.regenerate(gameTime);
            //    barry.isGravityActive = true;
            //}
            if (powerUp.isLeft()) powerUp.regenerate(gameTime);
            powerUp.move(gameTime);
            background.move();
            if (bgCounter > 18) bgCounter = 1;
            if (background.switchBack(background2.position.X + background2.backGround.Width, bgCounter)) bgCounter++;
            background2.move();
            if (background2.switchBack(background.position.X + background.backGround.Width, bgCounter)) bgCounter++;
        }



        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            if (gameMode != 0)
            {
                //Drawing Barry and Background
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                barry.drawBarry(spriteBatch);

                background.drawBackground(spriteBatch);
                background2.drawBackground(spriteBatch);
                spriteBatch.End();


                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                powerUp.drawPowerUp(spriteBatch);
                spriteBatch.End();

                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                superSpeed.drawSuperSpeed(spriteBatch);
                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                foreach (Zapper zapper in zapperList)
                    zapper.drawZapper(spriteBatch);
                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                foreach (Missile missile in missileList)
                    missile.drawMissile(spriteBatch);
                spriteBatch.End();

                //Taken Coins
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                score.drawCoinScore(spriteBatch);
                spriteBatch.End();

                ////Passed distance
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                score.drawScore(spriteBatch);
                spriteBatch.End();

                //Drawing Lazers
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                foreach (Lazer lazer in lazerList)
                    lazer.drawLazer(spriteBatch);
                spriteBatch.End();

                //Drawing coins
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                foreach (Coin coin in coinList)
                {
                    if (!coin.isHit)
                        coin.drawCoin(spriteBatch);
                }
                spriteBatch.End();
            }
            else
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                spriteBatch.Draw(Content.Load<Texture2D>("Menu\\home"), new Rectangle(0,0,1920,1080), Color.White);
                spriteBatch.End();
            }
            if (isPause)
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                spriteBatch.Draw(pause, new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.Draw(Content.Load<Texture2D>("pauseAlpha"), new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height), Color.White);
                
                spriteBatch.End();
            }
            if (isDead)
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                spriteBatch.Draw(gameOver, new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.End();

                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                score.drawDeadScore(spriteBatch, 400, 170, 60, 96);
                spriteBatch.End();

                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                score.drawDeadCoin(spriteBatch, 640, 340, 25, 40, false);
                spriteBatch.End();

                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                score.drawDeadCoin(spriteBatch, 1380, 670, 20, 32, true);
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }



    }
}
