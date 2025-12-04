using System;

namespace ConsoleApp25
{
    public class valueDouble
    {
        public double value { get; set; }
        public valueDouble(double value)
        {
            this.value = value;
        }
        public static valueDouble operator +(valueDouble first, valueDouble second)
        {
            return new valueDouble(first.value + second.value);
           
        }
        public static valueDouble operator /(valueDouble first, valueDouble second)
        {
            return new valueDouble(first.value / second.value);

        }
        public static valueDouble operator *(valueDouble first, valueDouble second)
        {
            return new valueDouble(first.value * second.value);

        }
        public static bool operator <(valueDouble first, valueDouble second)
        {
            return first.value < second.value;

        }
        public static bool operator >(valueDouble first, valueDouble second)
        {
            return first.value > second.value;

        }
        public static bool operator <=(valueDouble first, valueDouble second)
        {
            return first.value <= second.value;

        }
        public static bool operator >=(valueDouble first, valueDouble second)
        {
            return first.value >= second.value;

        }
    }
}