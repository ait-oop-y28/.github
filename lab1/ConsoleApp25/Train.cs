using System;

namespace ConsoleApp25
{
    public class train
    {
        valueDouble mass;
        public valueDouble speed { get; private set; }
        valueDouble acceleration;
        valueDouble max_allowed_force;
        public train(double mass, double max_allowed_force)
        {
            this.mass = new valueDouble(mass);
            speed = new valueDouble(0);
            acceleration = new valueDouble(0);
            this.max_allowed_force = new valueDouble(max_allowed_force);
        }
        public Result attempt_to_pass_distance(valueDouble distance, TimeSpan time_precision, valueDouble power_applied, valueDouble speed_limit)
        {
            TimeSpan time = new TimeSpan(0);
            valueDouble distance_traveled = new valueDouble(0);
            while (distance_traveled < distance)
            {
                acceleration = power_applied / mass;
                speed += acceleration * new valueDouble(time_precision.TotalSeconds);
                distance_traveled += speed * new valueDouble(time_precision.TotalSeconds);
                time = time.Add(time_precision);
                if (speed <= new valueDouble(0) && acceleration <= new valueDouble(0))
                {
                    return Result.Failure();
                }
                if(speed > speed_limit && speed_limit.value != -1)
                {
                    return Result.Failure();
                }    

            }
            return Result.Success(time);
        }
    }
}