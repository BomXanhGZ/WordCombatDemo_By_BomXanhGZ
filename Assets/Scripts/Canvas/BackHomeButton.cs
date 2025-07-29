
using UnityEngine;
using static GameUtility.Utility;
using static GameData.GameState;


public class BackHomeButton : MonoBehaviour
{
    [SerializeField] GameManagerReloadGame ref_GameManagerReloadGame;
    [SerializeField] BackGroundHandleBKGD ref_BackGroundHandleBKGD;
    [SerializeField] GameObject ref_HomeWarp;
    [SerializeField] GameObject ref_GamePlayWarp;
    [SerializeField] GameObject ref_GameLevelWarp;
    [SerializeField] AudioManagerSources ref_AudioManagerSources;
    [SerializeField] AudioManagerSFX ref_AudioManagerSFX;
    [SerializeField] AudioManagerBGM ref_AudioManagerBGM;


    private void Start()
    {
        CheckIsNotNull(ref_GameManagerReloadGame, "ref_GameManagerReloadGame in BackHomeButton");
        CheckIsNotNull(ref_BackGroundHandleBKGD, "ref_BackGroundHandleBKGD in BackHomeButton");
        CheckIsNotNull(ref_HomeWarp, "ref_HomeWarp in BackHomeButton");
        CheckIsNotNull(ref_GamePlayWarp, "ref_GamePlayWarp in BackHomeButton");
        CheckIsNotNull(ref_GameLevelWarp, "ref_GameLevelWarp in BackHomeButton");
        CheckIsNotNull(ref_AudioManagerSources, "ref_AudioManagerSources in BackHomeButton");
        CheckIsNotNull(ref_AudioManagerSFX, "ref_AudioManagerSFX in BackHomeButton");
        CheckIsNotNull(ref_AudioManagerBGM, "ref_AudioManagerBGM in BackHomeButton");
    }

    public void OnclickBackHomeButton()
    {
        //Audio
        AudioClip click_sfx = ref_AudioManagerSources.SFX_click_;           //SFX
        ref_AudioManagerSFX.PlaySFX(click_sfx);

        if( !this.gameObject.CompareTag("InGameLevelWrap") )                //BGM
        {
            ref_AudioManagerBGM.PlayHomeBGM();
        }

        //Back Ground
        ref_BackGroundHandleBKGD.ShowBackGroundfromIdx( ref_BackGroundHandleBKGD
                                                        .HOME_BACK_GROUND_INDEX );

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
    }
}
