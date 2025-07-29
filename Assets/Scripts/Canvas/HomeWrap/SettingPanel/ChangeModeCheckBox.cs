
using GameData;
using UnityEngine;
using UnityEngine.UI;
using static GameUtility.Utility;


public class ChangeModeCheckBox : MonoBehaviour
{
    [SerializeField] Toggle ref_ReadingMode;
    [SerializeField] Toggle ref_MeaningMode;
    [SerializeField] GameManagerData ref_GameManagerData;
    [SerializeField] GameManagerHandleChangeMode ref_GameManagerChangeGameMode;


    private void Start()
    {
        CheckIsNotNull(ref_MeaningMode, "ref_MeaningMode in ChangeModeCheckBox");
        CheckIsNotNull(ref_ReadingMode, "ref_ReadingMode in ChangeModeCheckBox");
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in ChangeModeCheckBox");
        CheckIsNotNull(ref_GameManagerChangeGameMode, "ref_GameManagerChangeGameMode in ChangeModeCheckBox");

        if(ref_GameManagerData.game_mode_ == GameMode.Reading)
        {
            ref_ReadingMode.isOn = true;
            ref_MeaningMode.isOn = false;
        }
        else if (ref_GameManagerData.game_mode_ == GameMode.Meaning)
        {
            ref_ReadingMode.isOn = false;
            ref_MeaningMode.isOn = true;
        }
    }

    public void OnclickReading()
    {
        if (ref_GameManagerData.game_mode_ == GameMode.Reading)
        return;

        ref_ReadingMode.isOn = true;
        ref_MeaningMode.isOn = false;
        ref_GameManagerChangeGameMode.ChangeGameMode(GameMode.Reading);
    }

    public void OnclickMeaning()
    {
        if (ref_GameManagerData.game_mode_ == GameMode.Meaning)
        return;

        ref_ReadingMode.isOn = false;
        ref_MeaningMode.isOn = true;
        ref_GameManagerChangeGameMode.ChangeGameMode(GameMode.Meaning);
    }
}
