
using UnityEngine;
using static GameUtility.Utility;


public class PlayButton : MonoBehaviour
{
    [SerializeField] GameObject ref_HomeWarp;
    [SerializeField] GameObject ref_GameLevelWarp;
    [SerializeField] AudioManagerSources ref_AudioManagerSources;
    [SerializeField] AudioManagerSFX ref_AudioManagerSFX;


    private void Start()
    {
        CheckIsNotNull(ref_HomeWarp, "ref_HomeWarp in PlayButton");
        CheckIsNotNull(ref_GameLevelWarp, "ref_GameLevelWarp in PlayButton");
        CheckIsNotNull(ref_AudioManagerSources, "ref_AudioManagerSources in PlayButton");
    }

    public void OnClickPlayButton()
    {
        //Audio
        AudioClip click_sfx = ref_AudioManagerSources.SFX_click_;       //get sfx from sources
        ref_AudioManagerSFX.PlaySFX(click_sfx);                         //play with SFX component

        //UI
        ref_GameLevelWarp.SetActive(true);
        ref_HomeWarp.SetActive(false);
    }
}
