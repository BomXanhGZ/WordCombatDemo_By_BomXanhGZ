
using GameData;
using UnityEngine;
using static GameUtility.Utility;
using static LocalData;


public class GameManagerHandleChangeMode : MonoBehaviour
{
    [SerializeField] GameManagerData ref_GameManagerData;
    [SerializeField] DataBaseTemporary ref_DataBaseTemporary;


    private void Start()
    {
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in GameManagerHandleChangeMode");
        CheckIsNotNull(ref_DataBaseTemporary, "ref_DataBaseTemporary in GameManagerHandleChangeMode");
    }

    public void ChangeGameMode(GameMode _mode)
    {
        //current Mode
        ref_GameManagerData.game_mode_ = _mode;

        //Local Data
        SetGameMode(_mode);

        //Change Db
        ref_DataBaseTemporary.LoadDataBase();
    }
}
