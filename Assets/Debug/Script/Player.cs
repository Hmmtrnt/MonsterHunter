using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // プレイヤーのRigidbody取得
    //private Rigidbody _rigidbody;

    // キャラクターコントローラー
    private CharacterController _characterController;

    // 進む方向
    private Vector3 _moveDirection;
    private Vector3 _moveX;
    private Vector3 _moveZ;
    private Vector3 _cameraFront;

    // ゲームパッドスティックの入力状態の変数
    private float _horizontal;
    private float _vertical;

    // Start is called before the first frame update
    void Start()
    {
        //_rigidbody = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        FallDebug();
    }

    // 地面から落ちたら初期位置のスポーン
    private void FallDebug()
    {
        if (transform.position.y <= -10.0f)
        {
            transform.position = new Vector3(0.0f, 1.0f, 0.0f);
        }
    }

    // プレイヤーの動き
    private void Move()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        //_cameraFront = Vector3.Scale()
        //_moveZ

        //_moveDirection = _horizontal + _vertical;

        transform.LookAt(transform.position);
        _characterController.Move(_moveDirection);

        //_rigidbody.AddForce(_horizontal, 0, _vertical, ForceMode.Force);
    }
}
