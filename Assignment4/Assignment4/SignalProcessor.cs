using System;
using System.Drawing;

namespace Assignment4
{
    public static class SignalProcessor
    {
        public static double[] GetGaussianFilter1D(double sigma)
        {
            int arrayLength = (int)Math.Ceiling(sigma * 6);
            if (arrayLength % 2 == 0)
            {
                arrayLength++;
            }

            double[] filter = new double[arrayLength];

            int halfIndex = arrayLength / 2;
            for (int i = 0; i < filter.Length; i++)
            {
                int distance = (halfIndex - i);

                double filterValue = (1 / (sigma * Math.Pow((2 * Math.PI), 0.5))) * Math.Exp((-Math.Pow(distance, 2)) / (2 * Math.Pow(sigma, 2)));
                filter[i] = filterValue;
            }

            return filter;
        }

        public static double[] Convolve1D(double[] signal, double[] filter)
        {
            int length = signal.Length;
            double[] result = new double[length];

            int halfIndex = filter.Length / 2;

            for (int i = 0; i < length; i++)
            {
                int startIdx = i - halfIndex;
                int endIdx = i + halfIndex;
                int k = 0;

                double filteredValue = 0;
                for (int j = startIdx; j < endIdx + 1; j++)
                {
                    if (j < 0 || j > length - 1)
                    {
                    }
                    else
                    {
                        filteredValue += signal[j] * filter[filter.Length - 1 - k];
                    }
                    k++;
                }

                result[i] = filteredValue;
            }
            return result;
        }

        public static double[,] GetGaussianFilter2D(double sigma)
        {
            int arrayLength = (int)Math.Ceiling(sigma * 6);
            if (arrayLength % 2 == 0)
            {
                arrayLength++;
            }

            double[,] filter = new double[arrayLength, arrayLength];

            int halfIndex = arrayLength / 2;
            for (int i = 0; i < arrayLength; i++)
            {
                for (int j = 0; j < arrayLength; j++)
                {
                    int xDistance = (halfIndex - i);
                    int yDistance = (halfIndex - j);

                    double filterValue = 1 / (2 * Math.PI * Math.Pow(sigma, 2)) * Math.Exp(-(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2)) / (2 * Math.Pow(sigma, 2)));

                    filter[i, j] = filterValue;
                }
            }

            return filter;
        }

        public static Bitmap ConvolveImage(Bitmap bitmap, double[,] filter)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

            byte[,] reds = new byte[width, height];
            byte[,] greens = new byte[width, height];
            byte[,] blues = new byte[width, height]; 

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    reds[i, j] = bitmap.GetPixel(i, j).R;
                    greens[i, j] = bitmap.GetPixel(i, j).G;
                    blues[i, j] = bitmap.GetPixel(i, j).B;
                }
            }

            byte[,] filteredReds = SignalProcessor.Convolve2D(reds, filter);
            byte[,] filteredGreens = SignalProcessor.Convolve2D(greens, filter);
            byte[,] filteredBlues = SignalProcessor.Convolve2D(blues, filter);

            Bitmap result = new Bitmap(width, height);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color newColor = Color.FromArgb(filteredReds[i, j], filteredGreens[i, j], filteredBlues[i, j]);
                    result.SetPixel(i, j, newColor);
                }
            }

            return result;
        }

        public static byte[,] Convolve2D(byte[,] signal, double[,] filter)
        {
            int signalXLength = signal.GetLength(1);
            int signalYLength = signal.GetLength(0);

            int filterXLength = filter.GetLength(1);
            int filterYLength = filter.GetLength(0);

            byte[,] result = new byte[signalXLength, signalYLength];

            for (int y = 0; y < signalYLength; y++)
            {
                for (int x = 0; x < signalXLength; x++)
                {
                    int startXIdx = x - filterXLength / 2;
                    int endXIdx = x + filterXLength / 2;

                    int startYIdx = y - filterYLength / 2;
                    int endYIdx = y + filterYLength / 2;

                    double filteredValue = 0;

                    int filterX = 0;
                    for (int i = startXIdx; i < endXIdx + 1; i++)
                    {
                        int filterY = 0;
                        for (int j = startYIdx; j < endYIdx + 1; j++)
                        {
                            if (i < 0 || i > signalXLength - 1 || j < 0 || j > signalYLength - 1)
                            {
                            }
                            else
                            {
                                filteredValue += signal[j, i] * filter[filterXLength - 1 - filterX, filterYLength - 1 - filterY];
                            }
                            filterY++;
                        }
                        filterX++;
                    }

                    if (filteredValue > 255)
                    {
                        result[y, x] = (byte)255;
                    }
                    else if (filteredValue < 0)
                    {
                        result[y, x] = (byte)0;
                    }
                    else
                    {
                        result[y, x] = (byte)filteredValue;
                    }
                }
            }
            return result;
        }
    }
}