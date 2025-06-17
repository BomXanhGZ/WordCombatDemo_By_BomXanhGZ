
using UnityEngine;
using static GameUtility.Utility;
using static GameData.SettingData;


/*calculate score_with_time with Quiz_Timer and Get Result to GameManagerData set game_score_*/
public class AnswerButtonHandleEvent : MonoBehaviour
{
    public int button_order_;

    [SerializeField] GameManagerData ref_GameManagerData;
    [SerializeField] GameManagerUpDateQuiz ref_GameManagerUpDateQuiz;
    [SerializeField] VocabularyShower ref_VocabularyShower;


    private void Start()
    {
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in AnswerButtonHandleEvent");
        CheckIsNotNull(ref_GameManagerUpDateQuiz, "ref_GameManagerUpDateQuiz in AnswerButtonHandleEvent");
        CheckIsNotNull(ref_VocabularyShower, "ref_VocabularyShower in AnswerButtonHandleEvent");
    }

    public void OnClickAnswerButton()
    {
        //only handle event if game state is Isplay
        if(ref_GameManagerData.game_state_ != GameData.GameState.IsPlay)
        { return; }


        float quiz_timme = ref_GameManagerData.quiz_timer_;
        int true_button_order = ref_VocabularyShower.true_answer_order_;
        int score_with_time;

        //Handle choice
        if(button_order_ != true_button_order)
        {
            //miss effect
            ref_GameManagerUpDateQuiz.UpdateQuiz();
            return;
        }

        //Handle Score with when button is true answer
        switch(quiz_timme)
        {
            case float n when n >= PERFECT_TIME:
                score_with_time = PERFECT_SCORE;
                break;
            
            case float n when n >= GREAT_TIME:
                score_with_time = GREAT_SCORE;
                break;
               
            case float n when n >= NICE_TIME:
                score_with_time = NICE_SCORE;
                break;

            //when miss
            default:
                score_with_time = 0;
                break;
        }

        Debug.Log("score_with_time is: " + score_with_time.ToString());
        ref_GameManagerData.game_score_ += score_with_time;
        ref_GameManagerUpDateQuiz.UpdateQuiz();

        //true effect
    }
}
