
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static GameData.GameState;
using static GameData.SettingData;
using static GameUtility.Utility;
using GameData;
using UnityEngine.UI;


public class GameManagerReloadGame : MonoBehaviour
{
    [SerializeField] GameObject[] ref_AnswerButton;
    [SerializeField] Slider ref_TimeBarSlider;
    [SerializeField] TextMeshProUGUI ref_ScoreTextInGamePlay;
    [SerializeField] GameObject ref_GamePlaySpace;
    [SerializeField] GameObject ref_GameMenuSpace;
    [SerializeField] GameObject ref_GameEndSpace;
    [SerializeField] VocabularyShower ref_VocabularyShower;
    [SerializeField] GameManagerGameIntro ref_GameManagerGameIntro;
    [SerializeField] GameManagerData ref_GameManagerData;


    private void Start()
    {
        for (int i = 0; i < ref_AnswerButton.Length; i++)
        { CheckIsNotNull(ref_AnswerButton[i], "ref_AnswerButton in GameManagerReloadGame");}

        CheckIsNotNull(ref_TimeBarSlider, "ref_TimeBarSlider in GameManagerReloadGame");
        CheckIsNotNull(ref_ScoreTextInGamePlay, "ref_ScoreTextInGamePlay in GameManagerReloadGame");
        CheckIsNotNull(ref_GamePlaySpace, "ref_GamePlaySpace in GameManagerReloadGame");
        CheckIsNotNull(ref_GameMenuSpace, "ref_GameMenuSpace in GameManagerReloadGame");
        CheckIsNotNull(ref_GameEndSpace, "ref_GameEndSpace in GameManagerReloadGame");
        CheckIsNotNull(ref_VocabularyShower, "ref_VocabularyShower in GameManagerReloadGame");
        CheckIsNotNull(ref_GameManagerGameIntro, "ref_GameManagerGameIntro in GameManagerReloadGame");
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in GameManagerReloadGame");
    }

    /*USE TO REPLAY AND RESTART*/
    public void ReloadGamePlay(GameState _state)
    {
        //GamePlay warp active
        ref_GamePlaySpace.SetActive(true);
        ref_GameMenuSpace.SetActive(false);
        ref_GameEndSpace.SetActive(false);

        //Game data
        ref_GameManagerData.game_state_ = _state;               //game manager data
        ref_GameManagerData.last_state = GameState.None;
        ref_GameManagerData.game_score_ = 0;
        ref_GameManagerData.correct_ans_ = 0;
        ref_GameManagerData.quiz_timer_ = MAX_QUIZ_TIME;

        ref_VocabularyShower.true_answer_order_ = -1;           //vocab data
        ref_VocabularyShower.vb_count_ = 0;
        ref_VocabularyShower.is_cleared_ = false;

        //UI Score Panel
        ref_ScoreTextInGamePlay.text = "Score: " + 0.ToString();    //Score text
        ref_TimeBarSlider.value = MAX_QUIZ_TIME;                    //time bar

        //Game UI Intro
        ref_GameManagerGameIntro.enabled = true;

        //AnswerButton
        string aws_intro_text = "---";                                      //text
        Color aws_intro_color = ref_AnswerButton[0]                         //color
                                .GetComponent<AnswerButtonHandleEffect>()
                                .defaulde_button_color;
        for (int i = 0; i < ref_AnswerButton.Length; i++)                   //Reset
        {
            ref_AnswerButton[i].GetComponentInChildren<TextMeshProUGUI>().text = aws_intro_text;
            ref_AnswerButton[i].GetComponent<Image>().color = aws_intro_color;
        }

        //UnPause
        Time.timeScale = 1.0f;
    }
}
