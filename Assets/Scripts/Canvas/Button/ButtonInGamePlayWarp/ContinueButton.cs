
using UnityEngine;
using static GameUtility.Utility;
using static GameData.GameState;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] GameManagerData ref_GameManagerData;
    [SerializeField] GameObject ref_GamePlaySpace;
    [SerializeField] GameObject ref_GameMenuSpace;


    private void Start()
    {
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in ContinueButton");
        CheckIsNotNull(ref_GamePlaySpace, "ref_GamePlaySpace in ContinueButton");
        CheckIsNotNull(ref_GameMenuSpace, "ref_GameMenuSpace in ContinueButton");
    }

    /*UNPAUSE GAME*/
    public void OnClickContinueButton()
    {
        //UnPause Setting
        ref_GameManagerData.game_state_ = IsPlay;
        Time.timeScale = 1.0f;

        //panel active
        ref_GamePlaySpace.SetActive(true);
        ref_GameMenuSpace.SetActive(false);
    }
}
