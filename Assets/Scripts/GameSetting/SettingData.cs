
namespace GameData
{
    public enum GameState
    {
        None = 0,
        IsPlay = 1,
        IsPause = 2,
        Intro = 3
    }

    public static class SettingData
    {

        //QUIZ TIME
        public const float MAX_QUIZ_TIME = 5.0f;
        public const float PERFECT_TIME = 3.0f;
        public const float GREAT_TIME = 1.5f;
        public const float NICE_TIME = 0.01f;

        //FLAGS
        public const int KANJI = 0;
        public const int READING = 1;
        public const int MEANING = 2;

        //SCORE VALUE
        public const int PERFECT_SCORE = 5;
        public const int GREAT_SCORE = 3;
        public const int NICE_SCORE = 1;
        public const int MISSED_SCORE = 0;

    }
}
