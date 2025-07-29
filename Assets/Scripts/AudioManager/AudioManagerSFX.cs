
using System.Collections;
using UnityEngine;
using static GameUtility.Utility;
using static LocalData;


public class AudioManagerSFX : MonoBehaviour
{
    [SerializeField] AudioSource SFX_channel_;
    public AudioSource GetSFX_Channel() => SFX_channel_;


    private void Start()
    {
        if( CheckIsNotNull(SFX_channel_, "SFX_channel_ in AudioManagerSFX") )
        {
            //vulume start setting
            SFX_channel_.volume = PlayerPrefs.GetFloat(SFX_VOLUME_KEY, /*default*/ 0.4f);
        }
    }

    public void PlaySFX(AudioClip _clip)
    {
        if (!_clip)
        {
            Debug.LogError("null Clip At PlaySFX in AudioManagerSFX");
            return;
        }

        if (SFX_channel_.isPlaying)
        {
            StartCoroutine( PlayAndDestroyCoroutine(_clip) );
            return;
        }

        SFX_channel_.clip = _clip;
        SFX_channel_.Play();
    }

    IEnumerator PlayAndDestroyCoroutine(AudioClip _clip)
    {
        GameObject temporary_audio = new GameObject();
        AudioSource temp_channel = temporary_audio.AddComponent<AudioSource>();
        temp_channel.clip = _clip;
        temp_channel.Play();

        yield return new WaitForSeconds( _clip.length );
        Destroy( temporary_audio );
    }
}
