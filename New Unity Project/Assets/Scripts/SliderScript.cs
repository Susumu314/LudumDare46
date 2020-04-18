using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera my_camera;
    [SerializeField] GameObject Paciente;
    void Start()
    {
        my_camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt (transform.position + my_camera.transform.rotation * Vector3.back, my_camera.transform.rotation * Vector3.down);
    }
}
