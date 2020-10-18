using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject main;
    public GameObject instructions;
    public GameObject tips;

    void Start()
    {
        back();
    }
    public void startgame()
    {
        SceneManager.LoadScene(1);
    }
    public void tointstructions()
    {
        main.SetActive(false);
        instructions.SetActive(true);
    }
    public void back()
    {
        main.SetActive(true);
        instructions.SetActive(false);
        tips.SetActive(false);
    }
    public void toTips()
    {
        main.SetActive(false);
        tips.SetActive(true);
    }
}
