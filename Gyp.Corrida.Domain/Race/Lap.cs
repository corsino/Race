using Gyp.Corrida.Domain.Race.Services;

namespace Gyp.Corrida.Domain.Race
{
    public class Lap
    {
        public string Hour { get; set; }
        public Pilot Pilot { get; set; }
        public string LapNumber { get; set; }
        public string LapTime { get; set; }
        public string LapAVG { get; set; }

        public static Lap BuildLapObject(string lineOfFile)
        {
            char tab = '\u0009';
            var pilotNumber = lineOfFile.Substring(18, 3);
            var pilotName = lineOfFile.Substring(24, 25);

            return new Lap()
            {
                Hour = lineOfFile.Substring(0, 12),
                Pilot = new Pilot(pilotNumber, pilotName),
                LapNumber = lineOfFile.Replace(tab," ").Substring(55, 6),
                LapTime = lineOfFile.Substring(60, 20),
                LapAVG = lineOfFile.Substring(81, lineOfFile.Length-1)
            };
        }
    }
}
