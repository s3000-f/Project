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
                    //square 
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
                    //table
                    int Px = width + 280;
                    int Py = rnd;

                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(Px + i * 65, Py + j * 55, 50, 50)));
                        }
                    }
                    Px = width + 140;
                    Py = rnd + 110;

                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(Px + i * 65, Py + j * 55, 50, 50)));
                        }
                    }
                    Px = width + 450;
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
                    Px = width + 280;
                    Py = rnd + 220;

                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(Px + i * 65, Py + j * 55, 50, 50)));
                        }
                    }

                    Px = width + 140;
                    Py = rnd + 330;

                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(Px + i * 65, Py + j * 55, 50, 50)));
                        }
                    }
                    Px = width + 450;
                    Py = rnd + 330;
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(Px + i * 65, Py + j * 55, 50, 50)));
                        }
                    }
                    Px = width + 280;
                    Py = rnd + 440;

                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(Px + i * 65, Py + j * 55, 50, 50)));
                        }
                    }
                    Px = width + 590;
                    Py = rnd + 220;

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
                    //barry
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
                    //Start Y
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                               new Rectangle(xx + 1045, yy, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                               new Rectangle(xx + 1210, yy, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                               new Rectangle(xx + 1045, yy + 55, 50, 50)));

                    coinList.Add(new Coin(Content, width, height, 0, 0,
                               new Rectangle(xx + 1045, yy + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                               new Rectangle(xx + 1100, yy + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                               new Rectangle(xx + 1155, yy + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                               new Rectangle(xx + 1210, yy + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                               new Rectangle(xx + 1130, yy + 165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                               new Rectangle(xx + 1130, yy + 220, 50, 50)));

                    coinList.Add(new Coin(Content, width, height, 0, 0,
                              new Rectangle(xx + 1210, yy + 55, 50, 50)));
                    //End Y

                    break;
                case 3:
                    //heart
                    int x = width;
                    int y = rnd;
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 55, y, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 110, y, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 220, y, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 275, y, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x, y + 55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 55, y + 55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 110, y + 55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 165, y + 55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 220, y + 55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 275, y + 55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 330, y + 55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x, y + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 55, y + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 110, y + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 165, y + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 220, y + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 275, y + 110, 50, 50)));

                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 55, y + 165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 110, y + 165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 165, y + 165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 220, y + 165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 275, y + 165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 110, y + 220, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 165, y + 220, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 220, y + 220, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 165, y + 275, 50, 50)));

                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x + 330, y + 110, 50, 50)));

                    break;
                case 4:
                    //N
                    int Nx = width;
                    int Ny = rnd;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(Nx + i * 55, Ny + j * 55, 50, 50)));
                        }
                    }
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(Nx + 165, Ny + 55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(Nx + 220, Ny + 55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(Nx + 220, Ny + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(Nx + 275, Ny + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(Nx + 275, Ny + 165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(Nx + 330, Ny + 165, 50, 50)));
                    Nx += 385;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(Nx + i * 55, Ny + j * 55, 50, 50)));
                        }
                    }
                    break;
                case 5:
                    //rectangle
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(width, rnd + 55, 50, 50)));
                    for (int i = 0; i < 13; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(width + 55 + i * 55, rnd + j * 55, 50, 50)));
                        }
                    }
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(width + 770, rnd + 55, 50, 50)));
                    break;
                case 6:
                    //hana
                    int x6 = width;
                    int y6 = rnd;
                    //H
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6, y6, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6, y6 + 55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6, y6 + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6, y6 + 165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6, y6 + 220, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 55, y6 + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 110, y6 + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 165, y6, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 165, y6 + 55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 165, y6 + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 165, y6 + 165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 165, y6 + 220, 50, 50)));
                    //A
                    int k6 = 50;
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 275 + k6, y6, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 330 + k6, y6, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 220 + k6, y6 + 55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 385 + k6, y6 + 55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 220 + k6, y6 + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 275 + k6, y6 + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 330 + k6, y6 + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 385 + k6, y6 + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 220 + k6, y6 + 165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 385 + k6, y6 + 165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 220 + k6, y6 + 220, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 385 + k6, y6 + 220, 50, 50)));
                    //N
                    k6 = 385 + 50 + 110;
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + k6, y6, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + k6, y6 + 55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + k6, y6 + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + k6, y6 + 165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + k6, y6 + 220, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + k6 + 55, y6 + 80, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + k6 + 110, y6 + 135, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + k6 + 165, y6, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + k6 + 165, y6 + 55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + k6 + 165, y6 + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + k6 + 165, y6 + 165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + k6 + 165, y6 + 220, 50, 50)));
                    //A
                    k6 += 50;
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 275 + k6, y6, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 330 + k6, y6, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 220 + k6, y6 + 55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 385 + k6, y6 + 55, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 220 + k6, y6 + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 275 + k6, y6 + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 330 + k6, y6 + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 385 + k6, y6 + 110, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 220 + k6, y6 + 165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 385 + k6, y6 + 165, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 220 + k6, y6 + 220, 50, 50)));
                    coinList.Add(new Coin(Content, width, height, 0, 0,
                                new Rectangle(x6 + 385 + k6, y6 + 220, 50, 50)));
                    break;
            }

            return coinList;
        }

    }
}