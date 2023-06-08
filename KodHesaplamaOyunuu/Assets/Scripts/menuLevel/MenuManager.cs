using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPaneli;
    
    void Start()
    {
        menuPaneli.GetComponent<CanvasGroup>().DOFade(1, 1f);
        menuPaneli.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
    }

    public void ikinciLeveleGec()
    {
        SceneManager.LoadScene("ikinciMenuLevel");
    }

    public void AyarlariYap()
    {
        //daha sonra kodlaması yapılacak
    }

    public void OyundanCik()
    {
        Application.Quit();
    }

    
}
