// プレイヤーの全体の動き

using UnityEngine;

public partial class PlayerStateSample : MonoBehaviour
{
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

    public int GetRecoveryTime() { return _currentRecoveryTime; }

    // 回復しているかどうかの情報取得
    public bool GetIsRecovery() { return _isRecovery; }
}
