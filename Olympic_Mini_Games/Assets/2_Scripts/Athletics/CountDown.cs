using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    Sprite[] mBGSpriteArr;
    [SerializeField]
    GameObject mImgCountBG;
    [SerializeField]
    GameObject mTextGO;
    [SerializeField]
    Image[] mImgCountArr;
#pragma warning restore

    int mCountNum;

    private void Awake()
    {
        mCountNum = 0;
    }

    public bool ChangeCountBG()
    {
        switch(mCountNum)
        {
            case 0:
            case 1:
            case 2:
                mImgCountArr[mCountNum++].sprite = mBGSpriteArr[1];
                return true;
            case 3:
                mImgCountBG.SetActive(false);
                mTextGO.SetActive(true);
                mCountNum++;
                return true;
            case 4:
                gameObject.SetActive(false);
                return false;
            default:
                Debug.LogError("Wring Count Number : " + mCountNum);
                return false;

        }
    }
}
