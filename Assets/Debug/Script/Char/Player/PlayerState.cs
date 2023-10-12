/*プレイヤーステート*/

using UnityEngine;

public partial class PlayerState : MonoBehaviour
{
    // Stateのインスタンス.
    private static readonly StateIdle _idle = new();
    private static readonly StateAvoid _avoid = new();
    private static readonly StateRunning _running = new();
    private static readonly StateRecovery _recovery = new();
    private static readonly StateDead _dead = new();


    // 現在のState.
    private StateBase _currentState = _idle;

    void Start()
    {
        Initialization();
        //OnStart();
        _currentState.OnEnter(this, null);
    }

    void Update()
    {
        GetStickInput();
        //OnUpdate();
        _currentState.OnUpdate(this);
        _currentState.OnChangeState(this);

        if (ControllerManager._inctance._YButtonDown)
        {
            _UnsheathedSword = true;
        }
        if (ControllerManager._inctance._XButtonDown || ControllerManager._inctance._RBButtonDown)
        {
            _UnsheathedSword = false;
        }

    }

    private void FixedUpdate()
    {
        SubstituteVariable();
        //OnFixedUpdate();
        _currentState.OnFixedUpdate(this);

        _debagObject.SetActive(_UnsheathedSword);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Finish")
        {
            Debug.Log("dafds");
        }
    }

    // ステート変更.
    private void ChangeState(StateBase nextState)
    {
        _currentState.OnExit(this, nextState);
        nextState.OnEnter(this, _currentState);
        _currentState = nextState;
    }

    // プレイヤー情報の初期化
    private void Initialization()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _debagObject = GameObject.Find("UnsheathedSwordFlag");
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