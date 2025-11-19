using System;

namespace ConsoleApp25
{
    public class track
    {
        private track_part[] track_parts;
        private train train_;
        private valueDouble speed_limit;
        public track(track_part[] track_parts, train train_, double speed_limit)
        {
            this.track_parts = track_parts;
            this.train_ = train_;
            this.speed_limit = new valueDouble(speed_limit);
        }
        public Result run_simulation(TimeSpan time_precision)
        {
            bool success = true;
            TimeSpan time = new TimeSpan(0);
            for (int i = 0; i < track_parts.Length; i++)
            {
                Result temp = train_.attempt_to_pass_distance(track_parts[i].length, time_precision, track_parts[i].power_applied, track_parts[i].speed_limit);
                success = success && temp.IsSuccess;
                time += temp.Value;
            }
            if (train_.speed > speed_limit)
                return Result.Failure();
            if(success)
                return Result.Success(time);
            return Result.Failure();
        }
    }
}