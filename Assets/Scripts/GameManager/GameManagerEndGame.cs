
using UnityEngine;
using TMPro;
using static GameUtility.Utility;


public class GameManagerEndGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ref_TotalScoreText;
    [SerializeField] GameManagerData ref_GameManagerData;
    [SerializeField] GameObject ref_GamePlaySpace;
    [SerializeField] GameObject ref_GameEndSpace;


    private void Start()
    {
        CheckIsNotNull(ref_TotalScoreText, "ref_TotalScoreText in GameManagerEndGame");
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in GameManagerEndGame");
        CheckIsNotNull(ref_GamePlaySpace, "ref_GamePlaySpace in GameManagerEndGame");
        CheckIsNotNull(ref_GameEndSpace, "ref_GameEndSpace in GameManagerEndGame");
    }

    public void HandleEndGame()
    {
        //Panel Active
        ref_GamePlaySpace.SetActive(false);
        ref_GameEndSpace.SetActive(true);

        //Total Score
        int score = ref_GameManagerData.game_score_;
        ref_TotalScoreText.text = "Total: " + score.ToString();
    }
}
