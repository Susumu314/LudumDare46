using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Patient : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float playerdist = 0.5f;
    [SerializeField] public float cansaco = 1f;
    [SerializeField] float raioX = 1f;
    private Transform playerpos;
    private Vector3 target;
    private bool seguir = false;
    public bool ocupado = false;
    public GameObject utilizando;
    private GameObject canvas;
    private GameObject slider;
    void Start()
    {
        canvas = gameObject.transform.GetChild(0).gameObject;
        slider = canvas.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (seguir && !ocupado){
            Vector3 dir = (playerpos.position - transform.position).normalized;
            target = playerpos.position - dir * playerdist;
            transform.position = Vector3.MoveTowards(transform.position, target, .1f);
            utilizando = null;
        }
        progressbar();
    }

    public void follow(Transform player){
        seguir = true;
        playerpos = player;
        print("seguindo o player");
    }
    public void unfollow(){
        seguir = false;
        playerpos = null;
        print("parei de seguir o  player");
    }
    public void usando(GameObject obj){
        utilizando = obj;
        ocupado = true;
        GetComponent<BoxCollider>().isTrigger = true;
    }
    public void progressbar(){
        if (utilizando != null){
            switch (utilizando.GetComponent<Leito>().funcao){
                case "Cama":
                    if (!canvas.activeSelf){
                        canvas.SetActive(true);
                    }
                    slider.GetComponent<Slider>().value = 1f - cansaco;
                    break;
                default:
                    break;
            }
        }
        else
        {
            if(canvas !=null){
                if (canvas.activeSelf){
                    canvas.SetActive(false);
                }
            }
        }
    }
}
