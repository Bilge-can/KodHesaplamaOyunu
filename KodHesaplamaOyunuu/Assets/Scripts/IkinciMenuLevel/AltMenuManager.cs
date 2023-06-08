using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AltMenuManager : MonoBehaviour
{
    
    void Start()
    {
        
    }

    public void oyunAcilsin(string oyunAcilsin)
    {
        PlayerPrefs.SetString("oyunAcilsin", oyunAcilsin);
        SceneManager.LoadScene("GameLevel");
    }
    
}
