
using System.Collections.Generic;
using UnityEngine;
using static GameData.GameState;
using static GameUtility.Utility;


class ReplayButton : MonoBehaviour
{
    [SerializeField] GameManagerReloadGame ref_GameManagerReloadGame;
    [SerializeField] VocabularyQuizGenerator ref_VocabularyQuizGenerator;
    [SerializeField] VocabularyShower ref_VocabularyShower;
    [SerializeField] AudioManagerSources ref_AudioManagerSources;
    [SerializeField] AudioManagerSFX ref_AudioManagerSFX;
    [SerializeField] AudioManagerBGM ref_AudioManagerBGM;


    private void Start()
    {
        CheckIsNotNull(ref_GameManagerReloadGame ,"ref_GameManagerReloadGame in ReplayButton");
        CheckIsNotNull(ref_VocabularyQuizGenerator, "ref_VocabularyQuizGenerator in ReplayButton");
        CheckIsNotNull(ref_VocabularyShower, "ref_VocabularyShower in ReplayButton");
        CheckIsNotNull(ref_AudioManagerSources, "ref_AudioManagerSources in ReplayButton");
        CheckIsNotNull(ref_AudioManagerSFX, "ref_AudioManagerSFX in ReplayButton");
        CheckIsNotNull(ref_AudioManagerBGM, "ref_AudioManagerBGM in ReplayButton");
    }

    public void OnclickReplayButton()
    {
        //Audio
        AudioClip replay_sfx = ref_AudioManagerSources.SFX_click_start_game_;   //SFX
        ref_AudioManagerSFX.PlaySFX(replay_sfx);

        ref_AudioManagerBGM.PlayRandomBGM();                                    //BGM

        //reset Vocabulary list
        List<Vocabulary> l_rand_list = ref_VocabularyQuizGenerator.GetRandomizeList();
        ref_VocabularyShower.SetAnswerList(l_rand_list);

        //reload game
        ref_GameManagerReloadGame.ReloadGamePlay(Intro);
    }
}