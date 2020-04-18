using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float gravity = 5f;

    private List<GameObject> pacientes  =  new List<GameObject>();
    private List<GameObject> Interagiveis  =  new List<GameObject>();
    GameObject closerpatient = null;
    GameObject closerobj = null;
    bool carregando = false;
    bool isWorking = false;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        GuiandoPaciente();
    }

    private void Move(){
        rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
    }

    private void GuiandoPaciente(){
        if(Input.GetButtonDown("Fire1") && !carregando){
            foreach(GameObject paciente in pacientes){
                if (closerpatient == null){
                    closerpatient = paciente;
                }
                else{
                    if(Vector3.Distance(closerpatient.transform.position, transform.position) > Vector3.Distance(paciente.transform.position, transform.position)){
                        closerpatient = paciente;
                    }
                }
            }
            if (closerpatient.GetComponent<Patient>().ocupado){
                closerpatient.GetComponent<Patient>().utilizando.GetComponent<Leito>().removepatient();
            }
            closerpatient.GetComponent<Patient>().follow(transform);
            carregando = true;
        }
        else if(Input.GetButtonDown("Fire1") && carregando){
            foreach(GameObject obj in Interagiveis){
                if (closerobj == null){
                    closerobj = obj;
                }
                else{
                    if(Vector3.Distance(closerobj.transform.position, transform.position) > Vector3.Distance(obj.transform.position, transform.position)){
                        closerobj = obj;
                    }
                }
            }
            if (closerobj != null){
                if (!closerobj.GetComponent<Leito>().ocupado){
                    closerobj.GetComponent<Leito>().putpatient(closerpatient);
                }
            }
            carregando = false;
            closerpatient.GetComponent<Patient>().unfollow();
            closerpatient  = null;
        }
        closerobj = null;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag  == "Paciente"){
            pacientes.Add(other.gameObject);
        }
        if (other.tag == "Interagivel"){
            Interagiveis.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag  == "Paciente"){
            if (other.gameObject != closerpatient){
                pacientes.Remove(other.gameObject);
            }
        }
        if (other.tag == "Interagivel"){
            Interagiveis.Remove(other.gameObject);
        }
    }
}
