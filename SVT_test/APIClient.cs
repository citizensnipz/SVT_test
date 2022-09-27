using System;
using System.Text.Json;

namespace SVT_test
{
    public class APIClient
    {
        private static async Task<List<Robot>> HandleApi()
        {
            client.DefaultRequestHeaders.Accept.Clear();

            var streamTask =
                client
                    .GetStreamAsync("https://60c8ed887dafc90017ffbd56.mockapi.io/robots");

            var robots = await JsonSerializer.DeserializeAsync<List<Robot>>(await streamTask);

            return robots;
        }

        public static async Task<RobotData> GetRobot(InputData input)
        {
            //get list of robots from api endpoint
            var robots = await HandleApi();

            //instantiate persistent variables
            double prevDist = 0;
            double currDist = 0;
            Robot bestBot = new Robot();
            List<Robot> botList = new List<Robot>();

            //iterate over all robots from api
            foreach (Robot robot in robots)
            {
                //calculate distance
                double numA = Math.Pow((robot.XCoord - input.XCoord), 2);
                double numB = Math.Pow((robot.YCoord - input.YCoord), 2);
                currDist = Math.Sqrt(numA + numB);

                //sets bestBot to be the closest
                if (prevDist == 0 || currDist < prevDist)
                {
                    prevDist = currDist;
                    bestBot = robot;
                }

                //accumulates bots that return a distance under 10
                if (currDist < 10)
                {
                    botList.Add(bestBot);
                }
            }

            //robots under 10 distance are compared for most battery level
            if (botList.Count > 1)
            {
                foreach (Robot robot in botList)
                {
                    if (robot.BatteryLevel > bestBot.BatteryLevel)
                    {
                        bestBot = robot;
                    }
                }
            }

            RobotData bestBotData = new RobotData(bestBot.RobotId, Math.Round(prevDist, 1), bestBot.BatteryLevel);

            return bestBotData;
        }

        private static readonly HttpClient client = new HttpClient();
    }
}

