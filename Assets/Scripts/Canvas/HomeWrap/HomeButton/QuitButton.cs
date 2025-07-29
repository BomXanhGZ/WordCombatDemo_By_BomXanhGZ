

using UnityEngine;
using static GameUtility.Utility;


public class QuitButton : MonoBehaviour
{
    [SerializeField] AudioManagerSources ref_AudioManagerSources;
    [SerializeField] AudioManagerSFX ref_AudioManagerSFX;


    private void Start()
    {
        CheckIsNotNull(ref_AudioManagerSources, "ref_AudioManagerSources in QuitButton");    
        CheckIsNotNull(ref_AudioManagerSFX, "ref_AudioManagerSFX in QuitButton");    
    }

    public void OnClickQuitButton()
    {
        //Audio
        AudioClip click_sfx = ref_AudioManagerSources.SFX_click_;
        ref_AudioManagerSFX.PlaySFX(click_sfx);

        //Handle Exit Game
        Debug.Log("Quit Button Pressed");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;    //From Unity Editor

#else
        Application.Quit();                                 //From Built

#endif
    }
}
