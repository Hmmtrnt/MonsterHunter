using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player _inctance;

    CharacterController _characterController;
    [SerializeField] private Camera _camera;
    // 移動スピード
    private float _moveSpeed = 0.0f;
    // 重力
    [SerializeField] private float _gravity = 0.0f;

    private Vector3 _velocity = Vector3.zero;
    // HACK:変数名テキトー
    [SerializeField] private float _time;

    // ゲームパッドの入力状態
    private float _horizontalLeftStick;
    private float _verticalLeftStick;

    [SerializeField]private float _avoidSpeed = 0.0f;

    // 回避中
    private bool _isAvoid = false;
    // 回避時間
    private float _avoidMaxTime = 45.0f;

    private float _avoidTime = 0;

    // 動く方向
    Vector3 _moveDirection = Vector3.zero;

    private Transform _transform;

    private void Awake()
    {
        if(_inctance == null)
        {
            _inctance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();

        // キャッシュしておく
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 0")&& (_horizontalLeftStick != 0.0f || _verticalLeftStick != 0.0f))
        {
            _isAvoid = true;
        }

        // 回避中
        if(_isAvoid)
        {
            Evasion();
            _avoidTime++;
        }

        if(_avoidTime >= _avoidMaxTime)
        {
            _isAvoid = false;
            _avoidTime = 0;
        }

        if (_isAvoid) return;
        Movement();
    }

    // デバッグ用

    // 移動処理
    private void Movement()
    {
        // 左スティック情報取得
        _horizontalLeftStick = Input.GetAxis("Horizontal");
        _verticalLeftStick = Input.GetAxis("Vertical");

        // カメラの正面ベクトル
        Vector3 cameraForward = Vector3.Scale(_camera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

        // カメラの向きでVectorの咆哮を変える
        Vector3 verticalDirection = cameraForward * _verticalLeftStick * _moveSpeed;// 前後
        Vector3 horizontalDirection = _camera.transform.right * _horizontalLeftStick * _moveSpeed;// 左右

        // ダッシュ
        if(Input.GetKey("joystick button 5"))
        {
            _moveSpeed = 15.0f;
        }
        else
        {
            _moveSpeed = 7.0f;
        }

        // 重力
        _moveDirection.y = _gravity;

        // 移動する方向
        _moveDirection = verticalDirection + horizontalDirection + new Vector3(0.0f, _moveDirection.y, 0.0f);

        // 移動する向き
        transform.LookAt(_transform.position + verticalDirection + horizontalDirection); 
        // 移動
        _characterController.Move(_moveDirection * Time.deltaTime);
    }

    // 回避処理
    private void Evasion()
    {
        _moveDirection.y = _gravity;
        _characterController.Move((_transform.forward + new Vector3(0.0f, _moveDirection.y, 0.0f)) * _avoidSpeed * Time.deltaTime);
    }
}
