
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
    [SerializeField] TextMeshProUGUI[] ref_AnswerText;

    [SerializeField] Slider ref_TimeBarSlider;
    [SerializeField] GameObject ref_GamePlaySpace;
    [SerializeField] GameObject ref_GameMenuSpace;
    [SerializeField] GameObject ref_GameEndSpace;
    [SerializeField] VocabularyShower ref_VocabularyShower;
    [SerializeField] GameManagerGameIntro ref_GameManagerGameIntro;
    [SerializeField] GameManagerData ref_GameManagerData;


    private void Start()
    {
        for (int i = 0; i < ref_AnswerText.Length; i++)
        { CheckIsNotNull(ref_AnswerText[i], "ref_AnswerText in GameManagerReloadGame"); }

        CheckIsNotNull(ref_TimeBarSlider, "ref_TimeBarSlider in GameManagerReloadGame");
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
        ref_GameManagerData.game_score_ = 0;
        ref_GameManagerData.quiz_timer_ = MAX_QUIZ_TIME;

        ref_TimeBarSlider.value = MAX_QUIZ_TIME;                //time bar

        ref_VocabularyShower.true_answer_order_ = -1;           //vocab data
        ref_VocabularyShower.vb_count_ = 0;
        ref_VocabularyShower.is_cleared_ = false;


        //Game UI Intro
        ref_GameManagerGameIntro.enabled = true;
        for (int i = 0; i < ref_AnswerText.Length; i++)
        {
            ref_AnswerText[i].text = "---";
        }

        //UnPause
        Time.timeScale = 1.0f;
    }
}
