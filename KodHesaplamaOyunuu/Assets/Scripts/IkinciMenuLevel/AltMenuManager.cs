using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class AltMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject AltMenuPaneli;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip butonClick;

    void Start()
    {
        AltMenuPaneli.GetComponent<CanvasGroup>().DOFade(1, 1f);
        AltMenuPaneli.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
    }

    public void oyunAcilsin(string oyunAcilsin)
    {
        audioSource.PlayOneShot(butonClick);
        PlayerPrefs.SetString("oyunAcilsin", oyunAcilsin);
        SceneManager.LoadScene("GameLevel");
    }

    public void GeriDon()
    {
        audioSource.PlayOneShot(butonClick);
        SceneManager.LoadScene("MenuLevel");
    }
}
