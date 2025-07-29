
using UnityEngine;
using TMPro;
using static GameUtility.Utility;


public class GameManagerEndGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ref_TotalScoreText;
    [SerializeField] TextMeshProUGUI ref_CorrectAnswerText;
    [SerializeField] GameManagerData ref_GameManagerData;
    [SerializeField] DataBaseUpdateData ref_DataBaseUpdateData;
    [SerializeField] GameObject ref_GamePlaySpace;
    [SerializeField] GameObject ref_GameEndSpace;
    [SerializeField] AudioManagerSources ref_AudioManagerSources;
    [SerializeField] AudioManagerSFX ref_AudioManagerSFX;
    [SerializeField] AudioManagerBGM ref_AudioManagerBGM;


    private void Start()
    {
        CheckIsNotNull(ref_TotalScoreText, "ref_TotalScoreText in GameManagerEndGame");
        CheckIsNotNull(ref_CorrectAnswerText, "ref_CorrectAnswerText in GameManagerEndGame");
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in GameManagerEndGame");
        CheckIsNotNull(ref_DataBaseUpdateData, "ref_DataBaseUpdateData in GameManagerEndGame");
        CheckIsNotNull(ref_GamePlaySpace, "ref_GamePlaySpace in GameManagerEndGame");
        CheckIsNotNull(ref_GameEndSpace, "ref_GameEndSpace in GameManagerEndGame");
        CheckIsNotNull(ref_AudioManagerSources, "ref_AudioManagerSources in GameManagerEndGame");
        CheckIsNotNull(ref_AudioManagerSFX, "ref_AudioManagerSFX in GameManagerEndGame");
        CheckIsNotNull(ref_AudioManagerBGM, "ref_AudioManagerBGM in GameManagerEndGame");
    }

    public void HandleEndGame()
    {
        //Panel Active
        ref_GamePlaySpace.SetActive(false);
        ref_GameEndSpace.SetActive(true);

        //Audio
        AudioSource ref_BGM_channel_ = ref_AudioManagerBGM.GetBGM_Channel();        //BGM
        ref_BGM_channel_.Stop();

        AudioClip end_sfx = ref_AudioManagerSources.SFX_end_game_;                  //SFX
        ref_AudioManagerSFX.PlaySFX(end_sfx);

        //Correct Answer
        int correct_ans = ref_GameManagerData.correct_ans_;
        ref_CorrectAnswerText.text = "Correct: " + correct_ans.ToString();

        //Total Score
        int score = ref_GameManagerData.game_score_;
        ref_TotalScoreText.text = "Score: " + score.ToString();

        //Update DataBase
        ref_DataBaseUpdateData.UpdateDataBase(  ref_GameManagerData.level_idx_,
                                                score, correct_ans);
    }
}
