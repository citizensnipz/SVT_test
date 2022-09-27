using System;
using System.Text.Json.Serialization;

namespace SVT_test
{
    public class Robot
    {
        public Robot() { }

        [JsonPropertyName("robotId")]
        public string? RobotId { get; set; }

        [JsonPropertyName("batteryLevel")]
        public int BatteryLevel { get; set; }

        [JsonPropertyName("y")]
        public int YCoord { get; set; }

        [JsonPropertyName("x")]
        public int XCoord { get; set; }
    }

    public class RobotData
    {
        public RobotData(string id, double dist, int batt)
        {
            RobotId = id;
            DistanceToGoal = dist;
            BatteryLevel = batt;
        }

        [JsonPropertyName("robotId")]
        public string? RobotId { get; set; }

        [JsonPropertyName("distanceToGoal")]
        public double DistanceToGoal { get; set; }

        [JsonPropertyName("batteryLevel")]
        public int BatteryLevel { get; set; }
    }

    public class InputData
    {
        public InputData() { }
        [JsonPropertyName("loadId")]
        public string? LoadId { get; set; }

        [JsonPropertyName("y")]
        public int YCoord { get; set; }

        [JsonPropertyName("x")]
        public int XCoord { get; set; }
    }
}
