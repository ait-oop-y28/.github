namespace ConsoleApp25
{
    public class track_part
    {
        public valueDouble power_applied { get; private set; }
        public valueDouble speed_limit { get; private set; }
        public valueDouble length { get; private set; }
        public track_part(valueDouble power_applied, valueDouble speed_limit, valueDouble length)
        {
            this.power_applied = power_applied;
            this.speed_limit = speed_limit;
            this.length = length;
        }
    }
}