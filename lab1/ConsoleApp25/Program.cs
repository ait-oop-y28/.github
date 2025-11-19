using System;

namespace ConsoleApp25
{
    class Program
    {
        static track_part reg_track(double length)
        {
            return new track_part(new valueDouble(0), new valueDouble(-1), new valueDouble(length));
        }
        static track_part power_track(double power, double length)
        {
            return new track_part(new valueDouble(power), new valueDouble(-1), new valueDouble(length));
        }
        static track_part station(double max_speed)
        {
            return new track_part(new valueDouble(0), new valueDouble(max_speed), new valueDouble(1));
        }
        static TimeSpan DefaultTimeSpan()
        {
            return new TimeSpan(0, 0, 1);
        }
        static void Main(string[] args)
        {
            //Arrange
            track_part[] parts = { power_track(1, 1), reg_track(10) };
            train train_ = new train(1, 1000);
            track track_ = new track(parts, train_, 100);
            //act
            Result res = track_.run_simulation(DefaultTimeSpan());
            //assert
            var r1 = new TimeSpan(0, 0, 11);
            var r2 = res.Value;
        }
    }
}