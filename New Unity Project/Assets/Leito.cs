using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leito : MonoBehaviour
{
    // Start is called before the first frame update
    public bool ocupado = false;
    GameObject paciente;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void putpatient(GameObject p){
        paciente = p;
        paciente.GetComponent<Patient>().usando(this.gameObject);
        paciente.transform.position = transform.position + new Vector3(0, 1f, 0);
        paciente.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
    }

    public void removepatient(){
        if (paciente != null){
            paciente.GetComponent<Patient>().ocupado = false;
            paciente.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            ocupado = false;
        }
    }
}
