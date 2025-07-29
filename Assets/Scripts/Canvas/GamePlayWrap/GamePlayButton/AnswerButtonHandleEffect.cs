
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static GameUtility.Utility;


public class AnswerButtonHandleEffect : MonoBehaviour
{
    public readonly     float EFFECT_TIME = 0.1f;
    public              Color defaulde_button_color {  get; private set; }
    [SerializeField]    Image ref_Image;


    private void Start()
    {
        bool is_not_null = CheckIsNotNull(ref_Image, "renderer of " + ref_Image.gameObject.name );
        if( is_not_null )
        {
            defaulde_button_color = ref_Image.color;
        }
    }

    public void HandleColorEffect(bool _val)
    {
        //change color
        if(_val == true)
        {
            ref_Image.color = Color.green;
        }
        else
        {
            ref_Image.color = Color.red;
        }

        //reset color with 
        StartCoroutine( ReSetColor() );
    }


    IEnumerator ReSetColor()
    {
        yield return new WaitForSeconds( EFFECT_TIME );

        ref_Image.color = defaulde_button_color;
    }
}
