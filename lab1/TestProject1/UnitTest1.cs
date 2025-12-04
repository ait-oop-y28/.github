using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp25;
using System;

namespace TestProject1
{
    [TestClass]
    public class track_test
    {
        track_part reg_track(double length)
        {
            return new track_part(new valueDouble(0), new valueDouble(-1), new valueDouble(length));
        }
        track_part power_track(double power,double length)
        {
            return new track_part(new valueDouble(power), new valueDouble(-1), new valueDouble(length));
        }
        track_part station(double max_speed)
        {
            return new track_part(new valueDouble(0), new valueDouble(max_speed), new valueDouble(1));
        }
        TimeSpan DefaultTimeSpan()
        {
            return new TimeSpan(0,0,1);
        }

        [TestMethod]
        public void run_simulation_11_whenRegularTrackAfterPowerTrack()
        {
            //Arrange
            track_part[] parts = { power_track(1, 1), reg_track( 10) };
            train train_ = new train(1, 1000);
            track track_ = new track(parts, train_, 100);
            //act
            Result res = track_.run_simulation(DefaultTimeSpan());
            //assert
            Assert.AreEqual(new TimeSpan(0,0,11), res.Value);

        }
        [TestMethod]
        public void run_simulation_11_whenPowerIsTooMuchForStop()
        {
            //Arrange
            track_part[] parts = { power_track(100,1), reg_track(10) };
            train train_ = new train(1, 1000);
            track track_ = new track(parts, train_, 10);
            //act
            Result res = track_.run_simulation(DefaultTimeSpan());
            //assert
            Assert.AreEqual(false, res.IsSuccess);

        }
        [TestMethod]
        public void run_simulation_11_whenStationCanReceiveTrain()
        {
            //Arrange
            track_part[] parts = { power_track(1, 1), reg_track(5), station(1000), reg_track(4) };
            train train_ = new train(1, 1000);
            track track_ = new track(parts, train_, 1000);
            //act
            Result res = track_.run_simulation(DefaultTimeSpan());
            //assert
            Assert.AreEqual(new TimeSpan(0, 0, 11), res.Value);

        }
        [TestMethod]
        public void run_simulation_11_whenStationCannotReceiveTrain()
        {
            //Arrange
            track_part[] parts = { power_track(100, 1), station(10), reg_track(4) };
            train train_ = new train(1, 1000);
            track track_ = new track(parts, train_, 10);
            //act
            Result res = track_.run_simulation(DefaultTimeSpan());
            //assert
            Assert.AreEqual(false, res.IsSuccess);

        }
        [TestMethod]
        public void run_simulation_11_whenPowerIsTooMuchForStopButNotForStation()
        {
            //Arrange
            track_part[] parts = { power_track(100, 1), reg_track(5), station(1000), reg_track(4) };
            train train_ = new train(1, 1000);
            track track_ = new track(parts, train_, 10);
            //act
            Result res = track_.run_simulation(DefaultTimeSpan());
            //assert
            Assert.AreEqual(false, res.IsSuccess);

        }
        [TestMethod]
        public void run_simulation_7_whenTrainSpeedUpAndSlowDown()
        {
            //Arrange
            track_part[] parts = { power_track(100, 1), reg_track( 5), power_track(-99, 1), station(10),
            power_track(100, 1),reg_track( 5),power_track(-99, 1)};
            train train_ = new train(1, 1000);
            track track_ = new track(parts, train_, 10);
            //act
            Result res = track_.run_simulation(DefaultTimeSpan());
            //assert
            Assert.AreEqual(new TimeSpan(0, 0, 7), res.Value);

        }
        [TestMethod]
        public void run_simulation_7_whenNoPowerTRackPresent()
        {
            //Arrange
            track_part[] parts = { reg_track( 5)};
            train train_ = new train(1, 1000);
            track track_ = new track(parts, train_, 10);
            //act
            Result res = track_.run_simulation(DefaultTimeSpan());
            //assert
            Assert.AreEqual(false, res.IsSuccess);

        }
        [TestMethod]
        public void run_simulation_7_whenTrainTryingToGoBackward()
        {
            //Arrange
            track_part[] parts = { power_track(5,100), power_track(-10, 100) };
            train train_ = new train(1, 1000);
            track track_ = new track(parts, train_, 10);
            //act
            Result res = track_.run_simulation(DefaultTimeSpan());
            //assert
            Assert.AreEqual(false, res.IsSuccess);

        }

    }
}
