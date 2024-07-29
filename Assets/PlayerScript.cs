using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public Rigidbody rd;

    private bool isGraund = true;

    Vector3 moveSpeed = new Vector3(5, 5, 5);

    float jump = 20;

    float distance = 0.3f;

    bool doubleJumpFlag = false;

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

        Vector3 rayPosition = transform.position;
        rayPosition.y = transform.position.y + 0.3f;
        Ray ray = new Ray(rayPosition, Vector3.down);

        isGraund = Physics.Raycast(ray, distance);

        Debug.DrawRay(rayPosition, Vector3.down * distance, Color.blue);

        if (isGraund == true)
        {

            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);

            if (Input.GetKey(KeyCode.Space))
            {
                move.y += jump;
                doubleJumpFlag = true;

            }
        }

      if(doubleJumpFlag == true) 
        {
            if (Input.GetKey(KeyCode.Space))
            {
                move.y += jump;
                doubleJumpFlag = false;

            }
        }

        rd.velocity = move;

    }
}
