
using UnityEngine;
using static GameUtility.Utility;


public class BackGroundHandleBKGD : MonoBehaviour
{
    public readonly int HOME_BACK_GROUND_INDEX = 0;

    [SerializeField] Sprite[] ref_BackGroundList;           //at idx 0: home bkgd
    [SerializeField] SpriteRenderer ref_BkgdRenderer;


    private void Start()
    {
        for (int i = 0; i < ref_BackGroundList.Length; i++)
        {
            CheckIsNotNull(ref_BackGroundList[i], i + " of ref_BackGroundList in BackGroundHandleBKGD");
        }

        CheckIsNotNull(ref_BkgdRenderer, "ref_BkgdRenderer in BackGroundHandleBKGD");
    }

    public void ShowBackGroundfromIdx(int _level_idx)
    {
        ref_BkgdRenderer.sprite = ref_BackGroundList[_level_idx];
    }
}
