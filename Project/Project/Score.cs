using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Linq;
using System.Text;

namespace Project
{
   
    class Score
    {
        float elapsed;
        int takenCoins;
        int meters;
        int allCoins;
        int bestScore;
        List<Texture2D> digits;
        List<Texture2D> digitsCoin;
        Texture2D mSign;
        Texture2D coinSign;  
        public Score(ContentManager Content)
        {
            meters = 0;
            takenCoins = 0;
            mSign = Content.Load<Texture2D>("Score\\m");
            coinSign = Content.Load<Texture2D>("Score\\coin");
            //Get Best Score
            if ((File.readFile() != null))
            {
                List<string[]> scores = File.readFile();
                if (scores.Count != 0)
                {
                    bestScore = Int32.Parse(scores[scores.Count - 1][0]);
                    allCoins = Int32.Parse(scores[scores.Count - 1][1]);
                }
                else
                {
                    bestScore = 0;
                    allCoins = 0;
                } 
                    
            }
            else
            {
                bestScore = 0;
                allCoins = 0;
            }
            digits = new List<Texture2D>();
            for(int i=0;i<10;i++)
            {
                digits.Add(Content.Load<Texture2D>("Score\\"+  i));
            }
            digitsCoin = new List<Texture2D>();
            for (int i = 0; i < 10; i++)
            {
                 digitsCoin.Add(Content.Load<Texture2D>("Score\\" + i+"g"));
            }
        }
        public void gotCoins()
        {
            takenCoins++;
        }
        public void run(GameTime gameTime, bool isSpeedy)
        {
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsed >= 60 && !isSpeedy)
            {
                meters++;
                elapsed = 0;
            }
            else if (elapsed >= 20 && isSpeedy)
                {
                    meters+=2;
                    elapsed = 0;
                }
        }
        public void writeHighScore()
        {
            if (meters > bestScore)
            {
                File.writeFile("" + meters + "," + (allCoins+takenCoins));
            }
            else
            {
                File.writeFile("" + bestScore + "," + (allCoins + takenCoins));
            }
        }
        public int getAllCoins()
        {
            return allCoins;
        }
        public void drawScore(SpriteBatch spriteBatch)
        {
            char[] metr=meters.ToString().ToCharArray();
            int i = 0;
            while (i<metr.Length)
            {
                switch (metr[i])
                {
                    case '0':
                        spriteBatch.Draw(digits[0], new Rectangle(20+i*22,40,21,36), Color.White);
                        break;
                    case '1':
                        spriteBatch.Draw(digits[1], new Rectangle(20+i*22,40,21,36), Color.White);
                        break;
                    case '2':
                        spriteBatch.Draw(digits[2], new Rectangle(20+i*22,40,21,36), Color.White);
                        break;
                    case '3':
                        spriteBatch.Draw(digits[3], new Rectangle(20+i*22,40,21,36), Color.White);
                        break;
                    case '4':
                        spriteBatch.Draw(digits[4], new Rectangle(20+i*22,40,21,36), Color.White);
                        break;
                    case '5':
                        spriteBatch.Draw(digits[5], new Rectangle(20+i*22,40,21,36), Color.White);
                        break;
                    case '6':
                        spriteBatch.Draw(digits[6], new Rectangle(20+i*22,40,21,36), Color.White);
                        break;
                    case '7':
                        spriteBatch.Draw(digits[7], new Rectangle(20+i*22,40,21,36), Color.White);
                        break;
                    case '8':
                        spriteBatch.Draw(digits[8], new Rectangle(20+i*22,40,21,36), Color.White);
                        break;
                    case '9':
                        spriteBatch.Draw(digits[9], new Rectangle(20+i*22,40,21,36), Color.White);
                        break;
                }
                i++;
            }
            spriteBatch.Draw(mSign, new Rectangle(20 + i * 22, 40, 21, 36), Color.White);

        }
        
        public void drawCoinScore(SpriteBatch spriteBatch)
        {
            char[] coins = takenCoins.ToString().ToCharArray();
            int i = 0;
            while (i < coins.Length)
            {
                switch (coins[i])
                {
                    case '0':
                        spriteBatch.Draw(digitsCoin[0], new Rectangle(20 + i * 16, 80, 15, 24), Color.White);
                        break;
                    case '1':
                        spriteBatch.Draw(digitsCoin[1], new Rectangle(20 + i * 16, 80, 15, 24), Color.White);
                        break;
                    case '2':
                        spriteBatch.Draw(digitsCoin[2], new Rectangle(20 + i * 16, 80, 15, 24), Color.White);
                        break;
                    case '3':
                        spriteBatch.Draw(digitsCoin[3], new Rectangle(20 + i * 16, 80, 15, 24), Color.White);
                        break;
                    case '4':
                        spriteBatch.Draw(digitsCoin[4], new Rectangle(20 + i * 16, 80, 15, 24), Color.White);
                        break;
                    case '5':
                        spriteBatch.Draw(digitsCoin[5], new Rectangle(20 + i * 16, 80, 15, 24), Color.White);
                        break;
                    case '6':
                        spriteBatch.Draw(digitsCoin[6], new Rectangle(20 + i * 16, 80, 15, 24), Color.White);
                        break;
                    case '7':
                        spriteBatch.Draw(digitsCoin[7], new Rectangle(20 + i * 16, 80, 15, 24), Color.White);
                        break;
                    case '8':
                        spriteBatch.Draw(digitsCoin[8], new Rectangle(20 + i * 16, 80, 15, 24), Color.White);
                        break;
                    case '9':
                        spriteBatch.Draw(digitsCoin[9], new Rectangle(20 + i * 16, 80, 15, 24), Color.White);
                        break;
                }
                i++;
            }
            spriteBatch.Draw(coinSign, new Rectangle(20 + i * 17, 80, 24, 24), Color.White);
        }

        public void drawDeadScore(SpriteBatch spritebatch)
        {

        }


    }
}
