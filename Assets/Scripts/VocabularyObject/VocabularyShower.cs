
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using static GameUtility.Utility;


public class VocabularyShower : MonoBehaviour
{
    public bool is_cleared_ { set; get; } = false;
    public int vb_count_ { set; get; } = 0;             //counter for vocabulary list
    public int true_answer_order_ {  set; get; } = -1;    //true answer pos in all answer button
    public List<string> answer_list_ { set; get; } = new List<string>();

    [SerializeField] TextMeshProUGUI ref_QuizText;
    [SerializeField] TextMeshProUGUI[] ref_AnswerTexts;
    [SerializeField] VocabularyQuizGenerator ref_VocabularyQuizGenerator;


    private void Start()
    {
        CheckIsNotNull(ref_QuizText, "ref_QuizText in VocabularyShower");
        CheckIsNotNull(ref_VocabularyQuizGenerator, "VocabularyQuizGenerator in VocabularyShower");

        for (int i = 0; i < ref_AnswerTexts.Length; i++)
        {
            CheckIsNotNull(ref_AnswerTexts[i], "ref_AnswerText " + ref_AnswerTexts[i] + "in VocabularyShower");
        }
    }

    public void SetTextForGamePlay()
    {
    //SET DATA

        //Get Quiz SettingData
        Vocabulary vocab = ref_VocabularyQuizGenerator.randomized_list_[vb_count_];

        //Set True Answer Pos in button order
        true_answer_order_ = UnityEngine.Random.Range(0, ref_AnswerTexts.Length);

        //rand False Answer text
        List<string> false_answer_data = new List<string>(answer_list_);    //coppy list
        false_answer_data.Remove(vocab.meaning_);                           //remove true answer

        string[] false_answers = false_answer_data                          //false answers
                                .OrderBy(x => UnityEngine.Random.value)
                                .Take(3).ToArray();



    //SET TEXT

        //Set Quiz text
        ref_QuizText.text = vocab.kanji_;

        int false_count = 0;                                            //for false_answer array

        for (int i = 0; i < ref_AnswerTexts.Length; i++)
        {
            //Set True Text
            if(i == true_answer_order_)
            {
                ref_AnswerTexts[i].text = vocab.meaning_;
                continue;
            }

            //Set False Text
            ref_AnswerTexts[i].text = false_answers[false_count];
            false_count++;
        }

      vb_count_++;

        //Handle End Game
        if(vb_count_ == ref_VocabularyQuizGenerator.randomized_list_.Count)
        {
            is_cleared_ = true;
        }
    }

    public void SetAnswerList(List<Vocabulary> _list)
    {
        answer_list_.Clear();

        foreach (var vocab in _list)
        {
            answer_list_.Add(vocab.meaning_);
        }
    }
}
