using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;
    float _rotation_v = 0.2f;

    void Start()
    {
        Managers.Input.KeyAction -= Onkeyboard;
        Managers.Input.KeyAction += Onkeyboard;
    }

    void Update()
    {

    }

    void Onkeyboard()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), _rotation_v);
            Player_Forward();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), _rotation_v);
            Player_Forward();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), _rotation_v);
            Player_Forward();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), _rotation_v);
            Player_Forward();
        }
    }

    void Player_Forward()
    {
        transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
    }
}
