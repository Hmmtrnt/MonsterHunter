using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // プレイヤーのインスタンス
    public static Player _instance;

    // キャラクターコントローラー
    private CharacterController _characterController;

    [SerializeField] private Camera _camera;

    // 回避距離
    [SerializeField] private float _AvoidDistance;

    // 進む方向
    private Vector3 _moveDirection;
    private Vector3 _moveX;
    private Vector3 _moveZ;
    private Vector3 _cameraFront;

    // 回避先の座標
    private Vector3 _targetPosition;

    // 速度
    private Vector3 _velocity = Vector3.zero;

    // プレイヤーのスピード
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _gravity = 10.0f;
    //[SerializeField] private float _time = 1.0f;

    // ゲームパッドスティックの入力状態の変数
    private float _horizontal;
    private float _vertical;

    // 回避しているかどうか
    public bool _isAvoid;
    // 抜刀しているかどうか
    public bool _isHoldWeapon;

    // 回避しているフレーム数
    private int _AvoidFlame;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //_rigidbody = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();

        _isAvoid = false;
        _isHoldWeapon = false;
        _AvoidFlame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Avoid();
        if (_isAvoid) return;
        HoldWeapon();
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

    // 移動
    private void Move()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        float _trigger = Input.GetAxis("L_R_Trigger");

        // ダッシュ
        if(Input.GetKey("joystick button 5"))
        {
            if (_isHoldWeapon) return;
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
        
        if(!_isHoldWeapon)
        // プレイヤーの進む方向に向きを変更
        transform.LookAt(transform.position + _moveZ + _moveX);
        // 移動
        _characterController.Move(_moveDirection * Time.deltaTime);

        _targetPosition = new Vector3(transform.position.x + _horizontal, transform.position.y, transform.position.z + _vertical);

    }

    // 回避処理
    private void Avoid()
    {
        // 移動しながらAボタンを押すと回避フラグON
        if(Input.GetKeyDown("joystick button 0") && (_horizontal!= 0 || _vertical != 0))
        {
            _isAvoid = true;
        }

        if (!_isAvoid) return;

        _AvoidFlame++;

        _speed = 5.0f;
        _moveZ = _cameraFront * _vertical * _speed;
        _moveX = _camera.transform.right * _horizontal * _speed;

        _moveDirection = _moveZ + _moveX + new Vector3(0.0f, _moveDirection.y, 0.0f);
        _moveDirection.y -= _gravity * Time.deltaTime;

        // 回避時の移動
        _characterController.Move(_moveDirection * _AvoidDistance);
        
        // 回避終了時に回避フラグOFFと回避時間をリセット
        if(_AvoidFlame >= 60)
        {
            _isAvoid = false;
            _AvoidFlame = 0;
        }
    }

    // 武器を構える
    private void HoldWeapon()
    {
        // 抜刀状態にするかどうか
        //if(Input.GetKeyDown("joystick button 3"))
        //{
        //    if(!_isHoldWeapon) _isHoldWeapon = true;
        //    if(_isHoldWeapon) _isHoldWeapon = false;
        //}

        if(!_isHoldWeapon)
        {
            if(Input.GetKeyDown("joystick button 3"))
            {
                _isHoldWeapon = true;
            }
        }
        else if(_isHoldWeapon) 
        {
            if (Input.GetKeyDown("joystick button 2"))
            {
                _isHoldWeapon = false;
            }
        }
    }
}
