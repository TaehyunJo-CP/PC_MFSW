using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    public enum EFeatureFlags
    {
        Default = 0b_0000_0000,
        Men = 0b_0000_0001,
        Women = 0b_0000_0010,
        Rectangle = 0b_0000_0100,
        Round = 0b_0000_1000,
        Aviator = 0b_0001_0000,
        Red = 0b_0010_0000,
        Blue = 0b_0100_0000,
        Black = 0b_1000_0000,
    }
}
