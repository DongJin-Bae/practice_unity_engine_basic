using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;
    float _rotation_v = 0.2f;

    Vector3 _destPos;

    public enum PlayerState
    {
        Die,
        Moving,
        Idle,
    }

    PlayerState _state = PlayerState.Idle;

    void Start()
    {
        //Managers.Input.KeyAction -= OnKeyboard;
        //Managers.Input.KeyAction += OnKeyboard;

        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;

        // TEMP
        Managers.UI.ShowSceneUI<UI_Inven>();
    }

    void UpdateDie()
    {

    }

    void UpdateIdle()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed", 0);
    }

    void UpdateMoving()
    {

        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.0001f)
        {
            _state = PlayerState.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(Delta_Speed(), 0, dir.magnitude);
            transform.position += dir.normalized * moveDist;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), _rotation_v);
        }

        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed", _speed);

    }

    void Update()
    {
        switch (_state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;

            case PlayerState.Moving:
                UpdateMoving();
                break;

            case PlayerState.Idle:
                UpdateIdle();
                break;
        }
    }

    //void OnKeyboard()
    //{
    //    if (Input.GetKey(KeyCode.W))
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), _rotation_v);
    //        Player_Forward();
    //    }
    //    else if (Input.GetKey(KeyCode.S))
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), _rotation_v);
    //        Player_Forward();
    //    }
    //    else if (Input.GetKey(KeyCode.A))
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), _rotation_v);
    //        Player_Forward();
    //    }
    //    else if (Input.GetKey(KeyCode.D))
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), _rotation_v);
    //        Player_Forward();
    //    }

    //    _moveToDest = false;
    //}

    void OnMouseClicked(Define.MouseEvent evt)
    {
        //if (evt != Define.MouseEvent.Click) return;
        
        if (_state == PlayerState.Die) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall")))
        {
            _destPos = hit.point;
            _state = PlayerState.Moving;
        }
    }

    void Player_Forward()
    {
        transform.position += transform.TransformDirection(Vector3.forward * Delta_Speed());
    }

    float Delta_Speed()
    {
        return Time.deltaTime * _speed;
    }

}
