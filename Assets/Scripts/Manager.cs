using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

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
   
    public tower t;
    public GameObject point;
    public GameObject point2;
    public Camera cam;
    public EventSystem ES;
    public GameObject roundbutton;

    void Start()
    {
        lt = loset;
        m.place = true;
       
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
    void Update()
    {
        
        if (Input.touchCount == 0)
        {
            return;
        }

        var touch = Input.GetTouch(0);
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(touch.position);

        if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            return;
        }
        else
        {
            if (Physics.Raycast(ray, out hit))
            {
                //var hitPose = s_Hits[0].pose;
                point2.transform.position = hit.point;
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
        m.place = false;
        clone.manager = this;
        
        current = clone;
        
        point.SetActive(false);
        point2.SetActive(true);
    }
    public void StartRound()
    {
        roundend = false;
        current.Round(round);
        round++;
        roundbutton.SetActive(false);
    }
    public void PlaceScene()
    {
        /*
        tower clone;
        clone = Instantiate(t, new Vector3(0, 0, 0), Quaternion.identity);
        //current.gameObject.transform.SetParent(null);
        clone.gameObject.transform.SetParent(content.transform);
        //m.content = clone.transform;
        current.hit(150f);
        NextButton.SetActive(false);
        */
        GameObject clone;
        clone = Appear(t.gameObject);
        current.hit(150f);
        m.place = false;
    }
    public void Placetower()
    {
        GameObject clone;
        clone = Appear(t.gameObject);
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
    public GameObject Appear(GameObject thing)
    {
        
                GameObject clone;
                clone = Instantiate(thing, point2.transform.position, Quaternion.identity);
                clone.transform.SetParent(content.transform);
                return clone;
            
    }
}
