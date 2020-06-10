using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryScene : MonoBehaviour
{
    public GameObject ui1;
    public GameObject ui2;
    public GameObject ui3;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    public GameObject backButton1;
    public GameObject backButton2;

    public void ui2Active()
    {
        ui1.SetActive(false);
        button1.SetActive(false);
        ui2.SetActive(true);
        button2.SetActive(true);
        backButton1.SetActive(true);
    }

    public void ui3Active()
    {
        ui2.SetActive(false);
        button2.SetActive(false);
        backButton1.SetActive(false);
        ui3.SetActive(true);
        button3.SetActive(true);
        backButton2.SetActive(true);
    }

    public void back1Active()
    {
        backButton1.SetActive(false);
        ui1.SetActive(true);
        button1.SetActive(true);
        ui2.SetActive(false);
        button2.SetActive(false);
    }

    public void back2Active()
    {
        backButton2.SetActive(false);
        backButton1.SetActive(true);
        ui2.SetActive(true);
        ui3.SetActive(false);
        button3.SetActive(false);
        button2.SetActive(true);
    }

    public void GameActive()
    {
        SceneManager.LoadScene("MainScene");
    }
}
