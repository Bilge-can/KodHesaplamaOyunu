using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPaneli;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip butonClick;

    void Start()
    {
        menuPaneli.GetComponent<CanvasGroup>().DOFade(1, 1f);
        menuPaneli.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
    }

    public void ikinciLeveleGec()
    {
        audioSource.PlayOneShot(butonClick);
        SceneManager.LoadScene("ikinciMenuLevel");
    }

    public void AyarlariYap()
    {
        audioSource.PlayOneShot(butonClick);
        //daha sonra kodlaması yapılacak
    }

    public void OyundanCik()
    {
        audioSource.PlayOneShot(butonClick);
        Application.Quit();
    }

    
}
