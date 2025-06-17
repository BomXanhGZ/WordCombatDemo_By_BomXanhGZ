
using UnityEngine;
using static GameUtility.Utility;

public class PlayButton : MonoBehaviour
{
    [SerializeField] GameObject ref_HomeWarp;
    [SerializeField] GameObject ref_GameLevelWarp;


    private void Start()
    {
        CheckIsNotNull(ref_HomeWarp, "ref_HomeWarp in PlayButton");
        CheckIsNotNull(ref_GameLevelWarp, "ref_GameLevelWarp in PlayButton");
    }

    public void OnClickPlayButton()
    {
        ref_GameLevelWarp.SetActive(true);
        ref_HomeWarp.SetActive(false);
    }
}
