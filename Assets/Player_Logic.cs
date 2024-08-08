using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Logic : MonoBehaviour
{
    //�v���C���[�̈ړ����鑬��
    public float move_speed = 15;

    //�v���C���[�̉�]���鑬��
    public float rotate_speed = 5;

    //�v���C���[�̉�]����
    //1 -> �i�v���C���[���猩�āj���v���
    //-1 -> �i�v���C���[���猩�āj�����v���
    private int rotate_direction = 0;

    //�v���C���[��Rigidbody
    public Rigidbody Rig = null;

    //�n�ʂɒ��n���Ă��邩���肷��ϐ�
    public bool grounded;

    //�W�����v��
    public float jumpPower;

    // Start is called before the first frame update
    void Start()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Horizontal_Rotate();

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

    private void OnCollisionEnter(Collision other)// ���I�u�W�F�N�g�ɐG�ꂽ���̏���
    {
        if(other.gameObject.tag == "Planet")// ����Planet�Ƃ����^�O�������I�u�W�F�N�g�ɐG�ꂽ��A
        {
            grounded = true;
        }
    }

    void Horizontal_Rotate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            rotate_direction = -1;
        }else if (Input.GetKey(KeyCode.E))
        {
            rotate_direction = 1;
        }else
        {
            rotate_direction = 0;
        }

        // �I�u�W�F�N�g����݂Đ������������Ƃ��ĉ�]������Quaternion���쐬
        Quaternion rot = Quaternion.AngleAxis(rotate_direction * rotate_speed, transform.up);
        // ���݂̎��M�̉�]�̏����擾����
        Quaternion q = this.transform.rotation;
        // �������āA���g�ɐݒ�
        this.transform.rotation = rot * q;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
