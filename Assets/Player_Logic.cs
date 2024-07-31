using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Logic : MonoBehaviour
{

    public float move_speed = 15;

    public float rotate_speed = 5;

    //プレイヤーの回転向き
    //1 -> （プレイヤーから見て）時計回り
    //-1 -> （プレイヤーから見て）反時計回り
    private int ratate_direction = 0;

    private Rigidbody Rig = null;

    public bool grounded;

    public float jumpPower;

    // Start is called before the first frame update
    void Start()
    {
        //Jump();
    }

    private void FixedUpdate()
    {
        //Horizontal_Rotate();

        Vector3 move_direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        Rig.MovePosition(Rig.position + transform.TransformDirection(move_direction) * move_speed * Time.deltaTime);

    }

    void Jump()
    {
        if (grounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                grounded = false;
                Rig.AddForce(transform.up * jumpPower * 100);
            } 
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Planet")
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
