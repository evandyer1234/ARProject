using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class robot : MonoBehaviour
{
    public Slider scale;
    public Slider rotation;

    public float size = 1f;
    public float angle = 0f;

    MakeAppearOnPlane MAON;
    public GameObject manager;

    void start()
    {
        MAON = manager.GetComponent<MakeAppearOnPlane>();
    }
    public void ScaleChange()
    {
        size = scale.value;
        gameObject.transform.localScale = new Vector3(size, size, size);
    }
    public void DirectionChange()
    {
        angle = rotation.value;
        gameObject.transform.localEulerAngles = new Vector3(0f, angle, 0f);
    }
    public void TogglePlane()
    {
        if (MAON != null)
        {
            MAON.enabled = !MAON.enabled;
        }
    }
}
