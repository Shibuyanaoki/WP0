using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public Rigidbody rd;

    Vector3 moveSpeed = new Vector3(5, 5, 5);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 move = rd.velocity;

        if (Input.GetKey(KeyCode.W))
        {
            move.z = moveSpeed.z;

        }else if(Input.GetKey(KeyCode.A))
        {
            move.x = -moveSpeed.x;

        }else if(Input.GetKey(KeyCode.S))
        {
            move.z = -moveSpeed.z;

        }else if(Input.GetKey(KeyCode.D)) 
        { 
            move.x = moveSpeed.x;

        }else
        {
            move = new Vector3(0, 0, 0);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            move.y = moveSpeed.y;
        }

        rd.velocity = move;

    }
}
