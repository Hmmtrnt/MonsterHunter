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

    // 回避スピード
    [SerializeField]private float _avoidSpeed = 0.0f;

    // 回避中
    public bool _isAvoid = false;
    // 最大回避フレーム数
    private float _avoidMaxTime = 30.0f;
    // 現在の回避フレーム数
    private float _avoidCurrentTime = 0;

    // 動く方向
    Vector3 _moveDirection = Vector3.zero;

    private Transform _transform;

    private Quaternion _targetRotation;
    // 抜刀状態かどうか
    private bool _isDrawnWepon;

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

        _targetRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (ControllerManager._inctance._AButtonDown&& (_horizontalLeftStick != 0.0f || _verticalLeftStick != 0.0f))
        {
            _isAvoid = true;
        }

        // 回避中
        if(_isAvoid)
        {
            //Avoid();

            MovementPlayer._inctance.Avoid();
            _avoidCurrentTime++;
        }

        if(_avoidCurrentTime >= _avoidMaxTime)
        {
            _isAvoid = false;
            _avoidCurrentTime = 0;
        }

        //Debug.Log(_isDrawnWepon);

        if (_isAvoid) return;
        //Movement();
        MovementPlayer._inctance.Movement();

        WeponState();

        //TestMove();

        //test++;
        //Debug.Log(test);
    }

    // デバッグ用

    // 移動処理
    private void Movement()
    {
        // 左スティック情報取得
        _horizontalLeftStick = ControllerManager._inctance._LeftStickHorizontal;
        _verticalLeftStick = ControllerManager._inctance._LeftStickVertical;

        // カメラの正面ベクトル
        Vector3 cameraForward = Vector3.Scale(_camera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

        // カメラの向きでVectorの咆哮を変える
        Vector3 verticalDirection = cameraForward * _verticalLeftStick * _moveSpeed;// 前後
        Vector3 horizontalDirection = _camera.transform.right * _horizontalLeftStick * _moveSpeed;// 左右

        // ダッシュ
        if(Stamina._instance.GetCurrentLengthGauge() <= Stamina._instance.GetLastGauge() &&
           ControllerManager._inctance._RBButton)
        {
            _moveSpeed = 4.0f;
        }
        else if(ControllerManager._inctance._RBButton)
        {
            _moveSpeed = 15.0f;
        }
        else if(!ControllerManager._inctance._RBButton)
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

    // プレイヤーの回転をブラッシュアップ
    private void TestMove()
    {
        // 左スティック情報取得
        _horizontalLeftStick = ControllerManager._inctance._LeftStickHorizontal;
        _verticalLeftStick = ControllerManager._inctance._LeftStickVertical;

        if (_horizontalLeftStick != 0 || _verticalLeftStick != 0)
        {
            // 移動
            _characterController.Move(transform.forward * 5.0f * Time.deltaTime);
        }

        
    }

    // 回避処理
    private void Avoid()
    {
        _moveDirection.y = _gravity;
        _characterController.Move((_transform.forward + new Vector3(0.0f, _moveDirection.y, 0.0f)) * _avoidSpeed * Time.deltaTime);
    }

    // プレイヤーの抜刀又は納刀状態取得
    private void WeponState()
    {
        if(ControllerManager._inctance._YButtonDown) 
        {
            _isDrawnWepon = true;
        }

        if (_isDrawnWepon) return;
       
        if(ControllerManager._inctance._XButtonDown)
        {
            _isDrawnWepon = false;
        }
        if(ControllerManager._inctance._RBButtonDown)
        {
            _isDrawnWepon = false;
        }
    }

    public bool GetDrawWepon()
    {
        return _isDrawnWepon;
    }
}
