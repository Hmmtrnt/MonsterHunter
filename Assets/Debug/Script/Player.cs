using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // プレイヤーのRigidbody取得
    //private Rigidbody _rigidbody;

    // キャラクターコントローラー
    private CharacterController _characterController;

    [SerializeField] private Camera _camera;

    // 進む方向
    private Vector3 _moveDirection;
    private Vector3 _moveX;
    private Vector3 _moveZ;
    private Vector3 _cameraFront;

    // プレイヤーのスピード
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _gravity = 10.0f;

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

        // ダッシュ
        if(Input.GetKeyDown("joystick button 5"))
        {
            _speed = 10.0f;
        }
        // 元のスピードに戻す
        if(Input.GetKeyUp("joystick button 5"))
        {
            _speed = 5.0f;
        }

        // カメラの向きを基準にした正面方向のベクトル
        _cameraFront = Vector3.Scale(_camera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;
        // 移動
        _moveZ = _cameraFront * _vertical * _speed;
        _moveX = _camera.transform.right * _horizontal * _speed;

        _moveDirection = _moveZ + _moveX + new Vector3(0.0f, _moveDirection.y, 0.0f);
        _moveDirection.y -= _gravity * Time.deltaTime;

        // プレイヤーの進む方向に向きを変更
        transform.LookAt(transform.position + _moveZ + _moveX);
        // 
        _characterController.Move(_moveDirection * Time.deltaTime);

        //_rigidbody.AddForce(_horizontal, 0, _vertical, ForceMode.Force);
    }
}
