using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerHandleQuizTimer : MonoBehaviour
{
    public bool HandleQuizTimer(GameManagerData _gameManagerData)
    {
        bool is_time_up = false;

        //Pass fram
        if (_gameManagerData.quiz_timer_ > 0)
        {
            Debug.Log("quiz timer: " + _gameManagerData.quiz_timer_);

            _gameManagerData.quiz_timer_ -= Time.deltaTime;
        }
        else
        {
            is_time_up = true;
        }

        return is_time_up;
    }
}
