
using UnityEngine;
using static GameData.SettingData;
using static GameUtility.Utility;
using static GameData.GameState;


public class GameManagerUpDateQuiz : MonoBehaviour
{
    [SerializeField] GameManagerData ref_GameManagerData;
    [SerializeField] GameManagerEndGame ref_GameManagerEndGame;
    [SerializeField] VocabularyShower ref_VocabularyShower;


    private void Start()
    {
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in GameManagerUpDateQuiz");
        CheckIsNotNull(ref_GameManagerEndGame, "ref_GameManagerEndGame in GameManagerUpDateQuiz");
        CheckIsNotNull(ref_VocabularyShower, "ref_VocabularyShower in GameManagerUpDateQuiz");
    }

    public void UpdateQuiz()
    {
        //If vocab cleared => End Game
        if(ref_VocabularyShower.is_cleared_ == true)
        {
            ref_GameManagerData.game_state_ = None;         //game state
            ref_GameManagerEndGame.HandleEndGame();         //end game
            
            Debug.Log("EndGame");
            return;
        }

        //Update Quiz
        ref_VocabularyShower.SetTextForGamePlay();

        //Reset Timer
        ref_GameManagerData.quiz_timer_ = MAX_QUIZ_TIME;

        Debug.Log("Update quiz was Called");
    }
}
