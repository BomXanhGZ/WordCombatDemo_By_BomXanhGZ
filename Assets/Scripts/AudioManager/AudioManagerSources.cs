

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;


public class AudioManagerSources : MonoBehaviour
{
    //FilePath
    const string BGM_HOME_SOURCE_PATH = "AudioSources/bgm/bgmhome";
    const string BGM_SOURCE_PATH = "AudioSources/bgm/bgm";
    const string SFX_SOURCE_PATH = "AudioSources/sfx/";

    //BGMAudio
    public AudioClip BGM_home_ { private set; get; }
    public List<AudioClip> BGM_clips_ { private set; get; }
    
    //SFXAudio
    public AudioClip SFX_click_ { private set; get; }
    public AudioClip SFX_click_start_game_ { private set; get; }
    public AudioClip SFX_end_game_ { private set; get; }
    public AudioClip SFX_true_aws_ { private set; get; }
    public AudioClip SFX_false_aws_ { private set; get; }


    private void Awake()
    {
        InitBGM();
        InitSFX();
    }

    bool InitBGM()
    {
        //BGM Home
        BGM_home_ = Resources.Load<AudioClip>(BGM_HOME_SOURCE_PATH);

        //BGM Game
        AudioClip[] bgm = Resources.LoadAll<AudioClip>(BGM_SOURCE_PATH);
        if (bgm.Length <= 0)
        {
            UnityEngine.Debug.LogError("Error at InitBGM");
            return false;
        }

        BGM_clips_ = bgm.ToList();
        if (bgm.Length <= 0)
        {
            UnityEngine.Debug.LogError("Error at InitBGM");
            return false;
        }

        return true;
    }

    bool InitSFX()
    {
        SFX_click_              = Resources.Load<AudioClip>(SFX_SOURCE_PATH + "click");
        SFX_click_start_game_   = Resources.Load<AudioClip>(SFX_SOURCE_PATH + "click_start_game");
        SFX_end_game_           = Resources.Load<AudioClip>(SFX_SOURCE_PATH + "end_game");
        SFX_true_aws_           = Resources.Load<AudioClip>(SFX_SOURCE_PATH + "true_asw");
        SFX_false_aws_          = Resources.Load<AudioClip>(SFX_SOURCE_PATH + "false_asw");

        if(    !SFX_click_ 
            || !SFX_click_start_game_ 
            || !SFX_end_game_ 
            || !SFX_true_aws_ 
            || !SFX_false_aws_)
        {
            UnityEngine.Debug.LogError("Null at InitSFX in AudioManagerSources");
            return false;
        }

        return true;
    }
}
