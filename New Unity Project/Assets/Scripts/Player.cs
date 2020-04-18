using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float gravity = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move(){
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newPosX = transform.position.x + deltaX;
        var deltaZ = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newPosZ = transform.position.z + deltaZ;
        transform.position = new Vector3(newPosX, transform.position.y, newPosZ);
    }
}
