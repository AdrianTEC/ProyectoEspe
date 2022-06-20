namespace RestAPI_XF1Online.Data
{
    public static class ScoreRules
    {

        public static Dictionary<string, int> Qualifying = new Dictionary<string, int>() {
            {"Q1", 1},
            {"Q2", 2},
            {"Q3", 3},
            {"NotClassified", -5},
            {"Disqualification", -10}
        };

        public static List<int> QualifyingPositions = new List<int>(){
            0, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1
        };

        public static Dictionary<string, int> Race = new Dictionary<string, int>() {
            {"Classified", 1},
            {"FastestLap", 5},
            {"NotClassified", -10},
            {"Disqualification", -20}
        };

        public static List<int> RacePositions = new List<int>() {
            0, 25, 18, 15, 12, 10, 8, 6, 4, 2, 1
        };




    }
}
