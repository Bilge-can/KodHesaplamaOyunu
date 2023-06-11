using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject baslaImage;

    [SerializeField]
    private GameObject dogruImage, yanlisImage;

    [SerializeField]
    private Text soruText, birinciSonucText, ikinciSonucText, ucuncuSonucText;

    [SerializeField]
    private Text dogruAdetText, yanlisAdetText, puanText;
    string oyunAcilsin;

    string dogruSonuc;
    int birinciYanlisSonuc;
    int ikinciYanlisSonuc;

    int dogruAdet, yanlisAdet, toplamPuan;


    void Start()
    {
        dogruAdet = 0;
        yanlisAdet = 0;
        toplamPuan = 0;

        dogruImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        yanlisImage.GetComponent<RectTransform>().localScale = Vector3.zero;

        if (PlayerPrefs.HasKey("oyunAcilsin"))
        {
            oyunAcilsin = PlayerPrefs.GetString("oyunAcilsin");
        }

        StartCoroutine(baslaYaziRoutine());


    }

    IEnumerator baslaYaziRoutine()
    {
        baslaImage.GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        yield return new WaitForSeconds(0.6f);
        baslaImage.GetComponent<RectTransform>().DOScale(0f, 0.5f).SetEase(Ease.InBack);
        baslaImage.GetComponent<CanvasGroup>().DOFade(0f, 1f);
        yield return new WaitForSeconds(0.6f);

        OyunaBasla();

    }

    void OyunaBasla()
    {
        SoruyuYazdir();
    }

    public void SoruyuYazdir()
    {
        string[] soru = { "225", "110", "136", "177", "125", "165", "134", "142", "256", "123" };
        string selectedSoru = soru[UnityEngine.Random.Range(0, soru.Length)];
        soruText.text = selectedSoru;

        Dictionary<string, string> dogruSonuclar = new Dictionary<string, string>()
    {
        { "225", "T" },
        { "110", "E" },
        { "136", "I" },
        { "177", "A" },
        { "125", "C" },
        { "165", "Ş" },
        { "134", "D" },
        { "142", "B" },
        { "256", "R" },
        { "123", "F" }
    };

        List<string> harfListesi = new List<string>()
    {
        "Ç", "K", "M", "L", "G"
    };

        string dogruCevap = dogruSonuclar[selectedSoru];
        dogruSonuc = dogruCevap;
        List<string> karisikHarfler = Karistir(harfListesi, dogruCevap);

        birinciSonucText.text = karisikHarfler[0];
        ikinciSonucText.text = karisikHarfler[1];
        ucuncuSonucText.text = karisikHarfler[2];
    }

    List<string> Karistir(List<string> liste, string dogruCevap)
    {
        List<string> karisikListe = new List<string>(liste);
        int n = karisikListe.Count;

        // Doğru cevabın indeksini alalım
        int dogruIndex = karisikListe.IndexOf(dogruCevap);

        // Doğru cevabı listeden çıkaralım
        karisikListe.Remove(dogruCevap);

        // Listeyi karıştıralım
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            string value = karisikListe[k];
            karisikListe[k] = karisikListe[n];
            karisikListe[n] = value;
        }

        // Doğru cevabı farklı bir yere yerleştirelim
        karisikListe.Insert(UnityEngine.Random.Range(0, n + 1), dogruCevap);

        return karisikListe;
    }

    public void SonucuKontrolEt(string textSonucu)
    {
        dogruImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        yanlisImage.GetComponent<RectTransform>().localScale = Vector3.zero;

        if (textSonucu == dogruSonuc)
        {
            dogruAdet++;
            toplamPuan += 20;
            dogruImage.GetComponent<RectTransform>().DOScale(1, .1f);
        }
        else
        {
            yanlisAdet++;
            yanlisImage.GetComponent<RectTransform>().DOScale(1, .1f);
        }

        dogruAdetText.text = dogruAdet.ToString()+ " DOĞRU";
        yanlisAdetText.text = yanlisAdet.ToString() + " YANLIŞ";
        puanText.text = toplamPuan.ToString() + " PUAN";
        SoruyuYazdir();
    }


}














