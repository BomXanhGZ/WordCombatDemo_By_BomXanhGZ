
using UnityEngine;
using static GameUtility.Utility;
using static GameData.GameState
    ;

public class MenuButton : MonoBehaviour
{
    [SerializeField] GameManagerData ref_GameManagerData;
    [SerializeField] GameObject ref_GamePlaySpace;
    [SerializeField] GameObject ref_GameMenuSpace;


    private void Start()
    {
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in MenuButton");
        CheckIsNotNull(ref_GamePlaySpace, "ref_GamePlaySpace in MenuButton");
        CheckIsNotNull(ref_GameMenuSpace, "ref_GameMenuSpace in MenuButton");
    }


    /*PAUSE GAME*/
    public void OnClickMenuButton()
    {
        //pause Setting
        ref_GameManagerData.game_state_ = IsPause;
        Time.timeScale = 0;

        //panel state
        ref_GameMenuSpace.SetActive(true);
        ref_GamePlaySpace.SetActive(false);
    }
}
