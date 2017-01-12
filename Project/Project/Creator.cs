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
    static class Creator
    {
        public static List<Coin> createCoin(int style, ContentManager Content, GraphicsDeviceManager graphics)
        {
            int width = graphics.GraphicsDevice.Viewport.Width;
            int height = graphics.GraphicsDevice.Viewport.Height;
            int rnd = new Random().Next(50, height - 550);
            List<Coin> coinList;
            coinList = new List<Coin>();
            switch (style)
            {
                case 0:
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(width + i * 65, rnd + j * 55, 50, 50)));
                        }
                    }
                    break;
                case 1:
                    int Px = width + 220;
                    int Py = rnd;

                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(Px + i * 65, Py + j * 55, 50, 50)));
                        }
                    }
                    Px = width + 110;
                    Py = rnd + 110;

                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(Px + i * 65, Py + j * 55, 50, 50)));
                        }
                    }
                    Px = width + 330;
                    Py = rnd + 110;

                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(Px + i * 65, Py + j * 55, 50, 50)));
                        }
                    }
                    Px = width;
                    Py = rnd + 220;

                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(Px + i * 65, Py + j * 55, 50, 50)));
                        }
                    }
                    Px = width + 220;
                    Py = rnd + 220;

                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(Px + i * 65, Py + j * 55, 50, 50)));
                        }
                    }
                    Px = width + 440;
                    Py = rnd + 220;

                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(Px + i * 65, Py + j * 55, 50, 50)));
                        }
                    }
                    Px = width + 110;
                    Py = rnd + 330;

                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(Px + i * 65, Py + j * 55, 50, 50)));
                        }
                    }
                    Px = width + 330;
                    Py = rnd + 330;
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(Px + i * 65, Py + j * 55, 50, 50)));
                        }
                    }
                    Px = width + 220;
                    Py = rnd + 440;

                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(Px + i * 65, Py + j * 55, 50, 50)));
                        }
                    }
                    break;
                case 2:
                    int xx = width;
                    int yy = rnd;
                    // start B
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx, yy, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 55, yy, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 110, yy, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 165, yy, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx, yy + 55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx, yy + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 165, yy + 55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 55, yy + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 110, yy + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx, yy + 165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 165, yy + 165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx, yy + 220, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 55, yy + 220, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 110, yy + 220, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 165, yy + 220, 50, 50)));
                    // End B
                    // Start A
                    int k = 50;
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 275 + k, yy, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 330 + k, yy, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 220 + k, yy + 55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 385 + k, yy + 55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 220 + k, yy + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 275 + k, yy + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 330 + k, yy + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 385 + k, yy + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 220 + k, yy + 165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 385 + k, yy + 165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 220 + k, yy + 220, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 385 + k, yy + 220, 50, 50)));
                    // End A
                    //Start R1
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx+495+k, yy, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx+550 + k, yy, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx+605+k, yy, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx+495 + k, yy+55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx+660 + k, yy+55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx+495 + k, yy+110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx+550 + k, yy+110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx+605 + k, yy+110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx+660 + k, yy+110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx+495 + k, yy+165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx+605 + k, yy+165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx+495 + k, yy+220, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx+660 + k, yy+220, 50, 50)));
                    //End R1
                    //Start R2
                    k = 315;
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 495 + k, yy, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 550 + k, yy, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 605 + k, yy, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 495 + k, yy + 55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 660 + k, yy + 55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 495 + k, yy + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 550 + k, yy + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 605 + k, yy + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 660 + k, yy + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 495 + k, yy + 165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 605 + k, yy + 165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 495 + k, yy + 220, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(xx + 660 + k, yy + 220, 50, 50)));
                    //End R2
                    //Start yy
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                               new Rectangle(xx+1045, yy, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                               new Rectangle(xx+1210, yy, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                               new Rectangle(xx+1045, yy+55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                               new Rectangle(xx+1210, yy+55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                               new Rectangle(xx+1045, yy+110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                               new Rectangle(xx+1100, yy+110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                               new Rectangle(xx+1155, yy+110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                               new Rectangle(xx+1210, yy+110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                               new Rectangle(xx+1130, yy+165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                               new Rectangle(xx+1130, yy+220, 50, 50)));
                    //End yy

                    break;
                case 3:
                    int x = width;
                    int y = rnd;
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+55, y, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+110, y, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+220, y, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+275, y, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x, y+55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+55, y+55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+110, y+55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+165, y+55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+220, y+55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+275, y+55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+330, y+55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x, y+110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+55, y+110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+110, y+110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+165, y+110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+220, y+110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+275, y+110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+330, y+110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+55, y+165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+110, y+165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 165, y + 165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+220, y+165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+275, y+165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+330, y+165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+110, y+220, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+165, y+220, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+220, y+220, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x+165, y+275, 50, 50)));

                    break;
                case 4:
                    break;
            }

            return coinList;
        }

    }
}

