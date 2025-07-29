
using UnityEngine;
using static GameUtility.Utility;
using static LocalData;


public class AudioManagerBGM : MonoBehaviour
{
    [SerializeField] AudioSource BGM_channel_;
    [SerializeField] AudioManagerSources ref_AudioManagerSources;

    public AudioSource GetBGM_Channel() => BGM_channel_;


    private void Start()
    {
        CheckIsNotNull(ref_AudioManagerSources, "ref_AudioManagerSources in AudioManagerBGM");
        if( CheckIsNotNull(BGM_channel_, "BGM_channel_ in AudioManagerBGM") )
        {
            //volume start setting
            BGM_channel_.volume = PlayerPrefs.GetFloat(BGM_VOLUME_KEY, /*default*/0.25f);
        }

        PlayHomeBGM();
    }

    public void PlayRandomBGM()
    {
        bool is_not_null = CheckIsNotNull(ref_AudioManagerSources, "ref_AudioManagerSources At PlayRandomBGM in AudioManagerBGM");
        if (!is_not_null) { return; }

        if(BGM_channel_.isPlaying)
        {BGM_channel_.Stop(); }

        AudioClip rd_clip = ref_AudioManagerSources.BGM_clips_
                            [ Random.Range(0, ref_AudioManagerSources.BGM_clips_.Count) ];

        if(rd_clip == null )
        {
            Debug.LogError("Null at PlayBMG in AudioManagerBGM");
            return;
        }

        BGM_channel_.clip = rd_clip;
        BGM_channel_.Play();
    }

    public void PlayHomeBGM()
    {
        if (BGM_channel_.isPlaying)
        { BGM_channel_.Stop(); }

        BGM_channel_.clip = ref_AudioManagerSources.BGM_home_;
        BGM_channel_.Play();
    }
}
