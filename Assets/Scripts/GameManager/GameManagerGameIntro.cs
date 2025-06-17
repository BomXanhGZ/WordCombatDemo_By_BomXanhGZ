
using TMPro;
using UnityEngine;
using static GameData.SettingData;
using static GameUtility.Utility;


public class GameManagerGameIntro : MonoBehaviour
{
    //Intro Text
    readonly string INTRO_1 = "Ready !!!";
    readonly string INTRO_2 = "Go !!!";

    //float max_size_;                          //for intro
    //static float intro_size;

    //reference
    [SerializeField] TextMeshProUGUI ref_QuizText;          //USE QUIZ TEXT TO GAME INTRO
    [SerializeField] GameManagerData ref_GameManagerData;


    private void Start()
    {
        CheckIsNotNull(ref_QuizText, "ref_QuizText in GameManagerGameIntro");
    }

    public void RunGameIntro()
    {
        float time_val = ref_GameManagerData.quiz_timer_;
        string intro_text = "";

        //Is UnShow Intro
        if (time_val <= 0.1f)
        {
            //UnShow
            this.enabled = false;
            return;
        }

        //Text Intro
        if (time_val >= (MAX_QUIZ_TIME - 1) )
        {
            intro_text = INTRO_1;
        }
        else if (time_val < 1)
        {
            intro_text = INTRO_2;
        }
        else
        {
            int count = (int)ref_GameManagerData.quiz_timer_;
            intro_text = count.ToString();
        }

        //Set Text
        ref_QuizText.text = intro_text;
    }
}
