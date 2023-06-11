using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SonucManager : MonoBehaviour
{

    [SerializeField]
    private Image sonucImage;

    [SerializeField]
    private Text dogruText, yanlisText,puanText;

    [SerializeField]
    private GameObject tekrarOynaBtn,anaMenuBtn;

    float sureTimer;
    bool resimAcilsinmi;

    private void OnEnable()
    {
        sureTimer = 0;
        resimAcilsinmi = true;

        dogruText.text = "";
        yanlisText.text = "";
        puanText.text = "";

        tekrarOynaBtn.GetComponent<RectTransform>().localScale = Vector3.zero;
        anaMenuBtn.GetComponent<RectTransform>().localScale = Vector3.zero;

        StartCoroutine(ResimAcRoutine());

    }


    

    
    IEnumerator ResimAcRoutine()
    {
        while (resimAcilsinmi)
        {
            sureTimer += .15f;
            sonucImage.fillAmount = sureTimer;

            yield return new WaitForSeconds(0.1f);

            if (sureTimer >= 1)
            {
                sureTimer = 1;
                resimAcilsinmi = false;

                dogruText.text = "10 DOĞRU";
                yanlisText.text = "10 YANLIŞ";
                puanText.text = "250 PUAN";

                tekrarOynaBtn.GetComponent<RectTransform>().DOScale(1, .3f);
                anaMenuBtn.GetComponent<RectTransform>().DOScale(1, .3f);

            }
        }
    }
}
