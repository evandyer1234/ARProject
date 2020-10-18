using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    public Base baseprefab;
    public Base current;
    public int round = 1;
    public GameObject Losetext;
    public float loset = 5f;
    float lt;
    bool lost = false;
    public MakeAppearOnPlane m;
    
    public GameObject content;
    public bool roundend = true;
    public bool baseplaced = false;
    public tower t;
    public GameObject point;
   
    public GameObject NextButton;

    void Start()
    {
        lt = loset;
        m.place = true;
        NextButton.SetActive(false);
    }
    void FixedUpdate()
    {
        if (lost)
        {
            lt -= Time.fixedDeltaTime;
            if (lt <= 0)
            {
                lost = false;
                lt = loset;
                Restart();
            }
        }
        
    }
    
    public void Restart()
    {
        roundend = true;
        Time.timeScale = 1f;
        foreach (Parent p in FindObjectsOfType<Parent>())
        {
            Destroy(p.gameObject);
        }
        m.place = false;
        Losetext.SetActive(false);
        round = 1;
    }
    public void Startgame()
    {
        Base clone;
        clone = Instantiate(baseprefab, point.transform.position, Quaternion.identity);
        clone.gameObject.transform.SetParent(content.transform);
        
        clone.manager = this;
        
        current = clone;
        NextButton.SetActive(true);
    }
    public void StartRound()
    {
        roundend = false;
        current.Round(round);
        round++;
    }
    public void PlaceScene()
    {
       
        tower clone;
        clone = Instantiate(t, new Vector3(0, 0, 0), Quaternion.identity);
        //current.gameObject.transform.SetParent(null);
        clone.gameObject.transform.SetParent(content.transform);
        //m.content = clone.transform;
        current.hit(150f);
        NextButton.SetActive(false);
    }
    public void Placetower()
    {
        tower clone;
        clone = Instantiate(t, new Vector3(0, 0, 0), Quaternion.identity);
        current.gameObject.transform.SetParent(null);
        m.content = clone.transform;
        current.hit(150f);
    }
    public void Lose()
    {
        Time.timeScale = 0.2f;
        Losetext.SetActive(true);
        current.spawn = false;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
    }
}
