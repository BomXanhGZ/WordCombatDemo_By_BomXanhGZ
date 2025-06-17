
using GameData;
using UnityEngine;
using static GameData.GameState;
using static GameData.SettingData;
using static GameUtility.Utility;


public class GameManagerData : MonoBehaviour
{
    //game controlls
    public int game_score_ { set; get; } = 0;
    public float quiz_timer_ { set; get; } = MAX_QUIZ_TIME;
    public GameState game_state_ { set; get; } = None;

    //Game Datas
    public TextAsset[] csv_files_ { set; get; }

    //references
    [SerializeField] GameManagerGameIntro ref_GameManagerGameIntro;
    [SerializeField] GameManagerUpDateQuiz ref_GameManagerUpDateQuiz;
    [SerializeField] GameManagerHandleQuizTimer ref_GameManagerHandleQuizTimer;
    [SerializeField] GameManagerHandleScorePanel ref_GameManagerHandleScorePanel;


    private void Start()
    {
        CheckIsNotNull(ref_GameManagerGameIntro, "ref_GameManagerGameIntro in GameManagerData");
        CheckIsNotNull(ref_GameManagerUpDateQuiz, "ref_GameManagerUpDateQuiz in GameManagerData");
        CheckIsNotNull(ref_GameManagerHandleQuizTimer, "ref_GameManagerHandleQuizTimer in GameManagerData");
        CheckIsNotNull(ref_GameManagerHandleScorePanel, "ref_GameManagerHandleScorePanel in GameManagerData");

        //load all file VocabData
        csv_files_ = Resources.LoadAll<TextAsset>("VocabularyDatas");
    }


    //GLOBAL HANDLE
    private void Update()
    {
        if (game_state_ == IsPlay)
        {
            //Handle Timer
            bool is_update_quiz = ref_GameManagerHandleQuizTimer.HandleQuizTimer(this);

            //Handle Game Quiz
            if(is_update_quiz)
                ref_GameManagerUpDateQuiz.UpdateQuiz();

            //Handle Game Score / Time Bar
            ref_GameManagerHandleScorePanel.HandleScorePannel();
        }
        else if (game_state_ == Intro)
        {
            //Run Intro
            ref_GameManagerGameIntro.RunGameIntro();

            //Handle time Intro
            bool is_intro_time_up = ref_GameManagerHandleQuizTimer.HandleQuizTimer(this);
            if (is_intro_time_up)
            {
                game_state_ = IsPlay;
            }
        }
    }
}
