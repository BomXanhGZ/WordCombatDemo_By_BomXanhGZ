
using System.Collections.Generic;
using UnityEngine;
using static GameData.GameState;
using static GameUtility.Utility;


class ReplayButton : MonoBehaviour
{
    [SerializeField] GameManagerReloadGame ref_GameManagerReloadGame;
    [SerializeField] VocabularyQuizGenerator ref_VocabularyQuizGenerator;
    [SerializeField] VocabularyShower ref_VocabularyShower;


    private void Start()
    {
        CheckIsNotNull(ref_GameManagerReloadGame ,"ref_GameManagerReloadGame in ReplayButton");
        CheckIsNotNull(ref_VocabularyQuizGenerator, "ref_VocabularyQuizGenerator in ReplayButton");
        CheckIsNotNull(ref_VocabularyShower, "ref_VocabularyShower in ReplayButton");
    }

    public void OnclickReplayButton()
    {
        //reset Vocabulary list
        List<Vocabulary> l_rand_list = ref_VocabularyQuizGenerator.GetRandomizeList();
        ref_VocabularyShower.SetAnswerList(l_rand_list);

        //reload game
        ref_GameManagerReloadGame.ReloadGamePlay(Intro);
    }
}