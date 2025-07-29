
using GameData;
using UnityEngine;


public static class LocalData
{
    /*Use PlayerPrefs to save local setting data for game*/

    //LOCAL DATA KEY NAME
    public static readonly string BGM_VOLUME_KEY = "bgm_volume";
    public static readonly string SFX_VOLUME_KEY = "sfx_volume";
    public static readonly string GAME_MODE_KEY = "game_mode";


    //Set GameMode
    public static void SetGameMode(GameMode _mode)
    {
        PlayerPrefs.SetInt(GAME_MODE_KEY, (int)_mode);
    }

    //Get GameMode
    public static GameMode GetGameMode()
    {
        int mode = PlayerPrefs.GetInt(GAME_MODE_KEY, (int)GameMode.Reading /*defaulfe mode*/ );
        return (GameMode)mode;
    }
}
