using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DataStruct
{
    public DataStruct(int _level_idx = 0, int _score = 0, int _top_ans = 0)
    {
        level_idx_ = _level_idx;
        score_ = _score;
        top_ans_ = _top_ans;
    }

    public int level_idx_ { get; set; }
    public int score_ { get; set; }
    public int top_ans_ { get; set; }
}