using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float gravity = 5f;

    private List<GameObject> pacientes  =  new List<GameObject>();
    GameObject mais_proximo = null;
    bool carregando = false;
    bool isWorking = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        GuiandoPaciente();
    }

    private void Move(){
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newPosX = transform.position.x + deltaX;
        var deltaZ = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newPosZ = transform.position.z + deltaZ;
        transform.position = new Vector3(newPosX, transform.position.y, newPosZ);
    }

    private void GuiandoPaciente(){
        if(Input.GetButtonDown("Fire1") && !carregando){
            carregando = true;
            foreach(GameObject paciente in pacientes){
                if (mais_proximo == null){
                    mais_proximo = paciente;
                }
                else{
                    if(Vector3.Distance(mais_proximo.transform.position, transform.position) > Vector3.Distance(paciente.transform.position, transform.position)){
                        mais_proximo = paciente;
                    }
                }
            }
            mais_proximo.GetComponent<Patient>().follow(transform);
        }
        else if(Input.GetButtonDown("Fire1") && carregando){
            carregando = false;
            mais_proximo.GetComponent<Patient>().unfollow();
            mais_proximo  = null;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag  == "Paciente"){
            pacientes.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag  == "Paciente"){
            if (other.gameObject != mais_proximo){
                pacientes.Remove(other.gameObject);
            }
        }
    }
}
