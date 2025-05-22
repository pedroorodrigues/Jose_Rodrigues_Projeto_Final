using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public GameObject HTP;
    public GameObject HTP2;
    public GameObject HTP3;
    public GameObject HTP4;
    public GameObject HTP5;

    public void Start()
    {
        HTP.SetActive(false);
        HTP2.SetActive(false);
        HTP3.SetActive(false);
        HTP4.SetActive(false);
        HTP5.SetActive(false);
    }
    private void Update()
    {
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void HowToPlay()
    {
        HTP.SetActive(true);
        HTP2.SetActive(false);
        HTP3.SetActive(false);
        HTP4.SetActive(false);
        HTP5.SetActive(false);
    }
    public void HowToPlay2()
    {
        HTP.SetActive(false);
        HTP2.SetActive(true);
        HTP3.SetActive(false);
        HTP4.SetActive(false);
        HTP5.SetActive(false);
    }
    public void HowToPlay3()
    {
        HTP.SetActive(false);
        HTP2.SetActive(false);
        HTP3.SetActive(true);
        HTP4.SetActive(false);
        HTP5.SetActive(false);
    }
    public void HowToPlay4()
    {
        HTP.SetActive(false);
        HTP2.SetActive(false);
        HTP3.SetActive(false);
        HTP4.SetActive(true);
        HTP5.SetActive(false);
    }
    public void HowToPlay5()
    {
        HTP.SetActive(false);
        HTP2.SetActive(false);
        HTP3.SetActive(false);
        HTP4.SetActive(false);
        HTP5.SetActive(true);
    }
    public void BackToMenu()
    {
        HTP.SetActive(false);
        HTP2.SetActive(false);
        HTP3.SetActive(false);
        HTP4.SetActive(false);
        HTP5.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("EXIT");
    }
}

