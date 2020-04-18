using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("myObject").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
