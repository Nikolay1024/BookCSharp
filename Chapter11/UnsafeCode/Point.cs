﻿namespace UnsafeCode
{
    struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public override string ToString() => $"[{X}; {Y}]";
    }
}
