// プレイヤーの全体の動き

using UnityEngine;

public partial class PlayerStateSample : MonoBehaviour
{
    private Rigidbody _rigidbody;

    // transformをキャッシュ.
    private Transform _transform;
    // カメラ
    private Camera _camera;
    // カメラの正面
    private Vector3 _cameraForward;


    /*コントローラー変数*/
    // 左スティックの入力情報.
    private float _leftStickHorizontal;
    private float _leftStickVertical;

    /*アイドル状態時の変数*/

    /*移動時の変数*/
    // 移動方向.
    private Vector3 _moveDirection;
    // 走る時の移動倍率.
    private float _moveVelocityRunMagnification = 12;
    // ダッシュ時の移動倍率.
    private float _moveVelocityDashMagnigication = 20;
    // 移動速度倍率.
    private float _moveVelocityMagnification = 12;
    // 回復しながらの移動倍率
    private float _moveVelocityRecoveryMagnification = 10;

    // 移動速度.
    private Vector3 _moveVelocity = new (0.0f,0.0f,0.0f);
    // ダッシュしているかどうか.
    private bool _isDashing = false;
    // 重力.
    private float _gravity = -10.0f;

    /*回避時の変数*/
    // 回避速度倍率.
    private float _avoidVelocityMagnification = 30;
    // 回避速度.
    private Vector3 _avoidVelocity = new (0.0f,0.0f,0.0f);
    // 現在の回避フレーム.
    private int _avoidTime    = 0;
    // 最大回避フレーム.
    private int _avoidMaxTime = 30;
    // 回避しているかどうか.
    private bool _isAvoiding = false;

    /*回復*/
    // 回復しているかどうか.
    private bool _isRecovery = false;
    // 現在の回復時間
    private float _currentRecoveryTime = 0;
    // 最大回復時間
    private float _maxRecoveryTime = 200;



    void Start()
    {
        Initialization();
        OnStart();
    }

    void Update()
    {
        GetStickInput();
        OnUpdate();
    }

    private void FixedUpdate()
    {
        SubstituteVariable();
        OnFixedUpdate();
    }

    // プレイヤー情報の初期化
    private void Initialization()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
        _camera = GameObject.Find("Camera").GetComponent<Camera>();
    }

    // 情報の代入
    private void SubstituteVariable()
    {

        // 動く方向代入.
        _moveDirection = new Vector3(_leftStickHorizontal, 0.0f, _leftStickVertical);
        _moveDirection.Normalize();

        // カメラの正面
        _cameraForward = Vector3.Scale(_camera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

        /*カメラの向きから移動方向取得*/
        // 正面
        Vector3 moveForward = _cameraForward * _leftStickVertical;
        // 横
        Vector3 moveSide = _camera.transform.right * _leftStickHorizontal;
        // 速度の代入.
        _moveVelocity = moveForward + moveSide;
        _avoidVelocity = _transform.forward * _avoidVelocityMagnification;

    }

    // スティックの入力情報取得
    private void GetStickInput()
    {
        // 入力情報代入.
        _leftStickHorizontal = ControllerManager._inctance._LeftStickHorizontal;
        _leftStickVertical = ControllerManager._inctance._LeftStickVertical;
    }

    // ダッシュしているかどうかの情報取得
    public bool GetIsDashing() { return _isDashing; }

    // 回避フレームの数を取得
    public int GetAvoidTime() { return _avoidTime; }

    // 回避しているかどうかの情報取得
    public bool GetIsAvoiding() { return _isAvoiding; }

    // 回復しているかどうかの情報取得
    public bool GetIsRecovery() { return _isRecovery; }
}
