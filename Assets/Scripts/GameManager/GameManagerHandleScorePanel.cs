using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static GameUtility.Utility;


public class GameManagerHandleScorePanel : MonoBehaviour
{
    [SerializeField] Slider ref_TimeBarSlider;
    [SerializeField] TextMeshProUGUI ref_ScoreText;
    [SerializeField] GameManagerData ref_GameManagerData;


    private void Start()
    {
        CheckIsNotNull(ref_ScoreText, "ref_ScoreText in GameManagerHandleScorePanel");

        if( CheckIsNotNull(ref_TimeBarSlider, "ref_TimeBarSlider in GameManagerHandleScorePanel") )
        {
            ref_TimeBarSlider.maxValue = GameData.SettingData.MAX_QUIZ_TIME;
        }
    }

    public void HandleScorePannel()
    {
        //if...
        UpdateScoreText();

        UpdateTimeBarSlider();
    }

    void UpdateScoreText()
    {
        int game_score = ref_GameManagerData.game_score_;
        string score_text = "Score: " + game_score.ToString();

        //Set Text
        ref_ScoreText.text = score_text;
    }

    void UpdateTimeBarSlider()
    {
        float timer_val = ref_GameManagerData.quiz_timer_;

        //Update TimeBarSlider
        ref_TimeBarSlider.value = timer_val;
    }
}
