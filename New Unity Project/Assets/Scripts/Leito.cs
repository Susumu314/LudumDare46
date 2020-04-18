using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leito : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string funcao = "";
    public bool ocupado = false;
    GameObject paciente;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (paciente != null){//faz alguma coisa
            switch (funcao)
            {
                case "Cama":
                    print("maluko ta descansando na cama");
                    cama();
                    break;
                case "RaioX":
                    print("maluko ta tirando raioX");
                    break;
                default:
                    break;
            }
        }
    }

    public void putpatient(GameObject p){
        paciente = p;
        ocupado = true;
        paciente.GetComponent<Patient>().usando(this.gameObject);
        switch (funcao)
            {
                case "Cama":
                    paciente.transform.position = transform.position + new Vector3(0, 1f, 0);
                    break;
                case "RaioX":
                    paciente.transform.position = transform.position + new Vector3(0, 0, -1f);
                    break;
                default:
                    break;
            }
        paciente.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
    }

    public void removepatient(){
        if (paciente != null){
            paciente.GetComponent<Patient>().ocupado = false;
            paciente.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            paciente.GetComponent<BoxCollider>().isTrigger = false;
            ocupado = false;
            paciente = null;
        }
    }

    private void cama(){
        if  ((paciente.GetComponent<Patient>().cansaco -= 1 * Time.deltaTime) < 0){
            paciente.GetComponent<Patient>().cansaco = 0;
        }
    }
}
