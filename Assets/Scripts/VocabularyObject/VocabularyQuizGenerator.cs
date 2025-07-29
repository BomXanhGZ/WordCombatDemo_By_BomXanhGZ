
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static GameUtility.Utility;


public class VocabularyQuizGenerator : MonoBehaviour
{
    public List<Vocabulary> randomized_list_ { private set; get; }

    [SerializeField] VocabularyLoader ref_VocabularyLoader;
    [SerializeField] VocabularyShower ref_VocabularyShower;


    void Start()
    {
        CheckIsNotNull(ref_VocabularyLoader, "ref_VocabularyLoader in VocabularyQuizGenerator");
        CheckIsNotNull(ref_VocabularyShower, "ref_VocabularyShower in VocabularyQuizGenerator");
    }

    public List<Vocabulary> GetRandomizeList()
    {
        randomized_list_ = ref_VocabularyLoader.vocabularies;
        randomized_list_ = randomized_list_.OrderBy(x => Random.value).ToList();        //random list

        if (randomized_list_.Count <= 0 || randomized_list_ == null)
        {
            Debug.LogError("null randomized_list_ at GetRandomizeList Method in  VocabularyQuizGenerator ");
            return null;
        }

        return randomized_list_;
    }
}
