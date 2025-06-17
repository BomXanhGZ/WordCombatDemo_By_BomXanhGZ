

using UnityEngine;

public class QuitButton : MonoBehaviour
{

    public void OnClickQuitButton()
    {
        Debug.Log("Quit Button Pressed");

#if UNITY_EDITOR
        //From Unity Editor
        UnityEditor.EditorApplication.isPlaying = false;

#else
        //From Built
        Application.Quit();

#endif
    }
}
