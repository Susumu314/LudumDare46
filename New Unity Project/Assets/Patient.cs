﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float playerdist = 0.5f;
    private Transform playerpos;
    private Vector3 target;
    private bool seguir = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (seguir){
            Vector3 dir = (playerpos.position - transform.position).normalized;
            target = playerpos.position - dir * playerdist;
            transform.position = Vector3.MoveTowards(transform.position, target, .05f);
        }
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
}
