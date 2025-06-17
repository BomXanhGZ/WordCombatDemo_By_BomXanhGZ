
using UnityEngine;
using static GameUtility.Utility;
using static GameData.GameState;


public class BackHomeButton : MonoBehaviour
{
    [SerializeField] GameManagerReloadGame ref_GameManagerReloadGame;
    [SerializeField] GameObject ref_HomeWarp;
    [SerializeField] GameObject ref_GamePlayWarp;
    [SerializeField] GameObject ref_GameLevelWarp;


    private void Start()
    {
        CheckIsNotNull(ref_GameManagerReloadGame, "ref_GameManagerReloadGame in BackHomeButton");
        CheckIsNotNull(ref_HomeWarp, "ref_HomeWarp in BackHomeButton");
        CheckIsNotNull(ref_GamePlayWarp, "ref_GamePlayWarp in BackHomeButton");
        CheckIsNotNull(ref_GameLevelWarp, "ref_GameLevelWarp in BackHomeButton");
    }

    public void OnclickBackHomeButton()
    {
        //RESET PANEL
        ref_HomeWarp.SetActive(true);
        ref_GamePlayWarp.SetActive(false);
        ref_GameLevelWarp.SetActive(false);

        //RESET GAME PLAY
        /* when backhome button in GameLevelWarpObj 
         * =>  do not Reload Game Play*/
        if( gameObject.transform.parent.GetComponent<GameLevelWarpSpawnButton>() )
        { return; }

        ref_GameManagerReloadGame.ReloadGamePlay(None);

        //SAVE INTO DATA BASE
    }
}
