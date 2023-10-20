﻿/*プレイヤーステート*/

using UnityEngine;

public partial class PlayerState : MonoBehaviour
{
    //--納刀状態--//
    private static readonly StateIdle _idle = new();// アイドル.
    private static readonly StateAvoid _avoid = new();// 回避.
    private static readonly StateRunning _running = new();// 走る.
    private static readonly StateDash _dash = new();// ダッシュ.
    private static readonly StateRecovery _recovery = new();// 回復.

    //--抜刀状態--//
    private static readonly StateDrawnSwordTransition _drawSwordTransition = new();// 抜刀している.
    private static readonly StateIdleDrawnSword _idleDrawnSword = new();// アイドル.
    private static readonly StateRunDrawnSword _runDrawnSword = new();// 走る.
    private static readonly StateSheathingSword _sheathingSword = new();// 納刀する.
    private static readonly StateSteppingSlash _steppingSlash = new();// 踏み込み斬り.

    //--共通状態--//
    private static readonly StateDead _dead = new();// やられた.
    private static readonly StateDamage _damage = new();// ダメージを受けた

    // 現在のState.
    private StateBase _currentState = _idle;

    void Start()
    {
        Initialization();
        _AtCol.SetActive(false);
        _currentState.OnEnter(this, null);
    }

    void Update()
    {
        GetStickInput();
        AnimTransition();
        
        _currentState.OnUpdate(this);
        _currentState.OnChangeState(this);

        if (_input._YButtonDown)
        {
            _UnsheathedSword = true;
        }
        if (_input._XButtonDown || _input._RBButtonDown)
        {
            _UnsheathedSword = false;
        }
    }

    private void FixedUpdate()
    {
        SubstituteVariable();
        _currentState.OnFixedUpdate(this);

        if(_hitPoint <= 0)
        {
            OnDead();
        }

        if(_currentState != _dash &&
            _currentState != _avoid)
        {

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Monster")
        {
            OnDamage();
        }
    }

    // ステート変更.
    private void ChangeState(StateBase nextState)
    {
        _currentState.OnExit(this, nextState);
        nextState.OnEnter(this, _currentState);
        _currentState = nextState;
    }

    // プレイヤー情報の初期化.
    private void Initialization()
    {
        _input = GameObject.FindWithTag("Manager").GetComponent<ControllerManager>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
        _camera = GameObject.Find("Camera").GetComponent<Camera>();
        _AtCol = GameObject.Find("AttackCol");
        _Monster = GameObject.FindWithTag("Monster");
        _MonsterState = GameObject.FindWithTag("Monster").GetComponent<MonsterState>();
    }

    // アニメーション遷移.
    private void AnimTransition()
    {
        if (_animator == null) return;

        _animator.SetBool("Idle", _idleMotion);
        _animator.SetBool("Run", _runMotion);
        _animator.SetBool("DrawnSword", _drawnSword);
        _animator.SetBool("Avoid", _avoidMotion);
    }

    // 情報の代入.
    private void SubstituteVariable()
    {
        // 動く方向代入.
        _moveDirection = new Vector3(_leftStickHorizontal, 0.0f, _leftStickVertical);
        _moveDirection.Normalize();

        // カメラの正面.
        _cameraForward = Vector3.Scale(_camera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

        /*カメラの向きから移動方向取得*/
        // 正面.
        Vector3 moveForward = _cameraForward * _leftStickVertical;
        // 横.
        Vector3 moveSide = _camera.transform.right * _leftStickHorizontal;
        // 速度の代入.
        _moveVelocity = moveForward + moveSide;
        _avoidVelocity = _transform.forward * _avoidVelocityMagnification;

    }

    // ダメージを受けた時に遷移
    private void OnDamage()
    {
        if(_hitPoint <= 0) return;

        ChangeState(_damage);
    }

    // 体力が0になった時に呼び出す
    private void OnDead()
    {
        ChangeState(_dead);
    }

    // スティックの入力情報取得
    private void GetStickInput()
    {
        // 入力情報代入.
        _leftStickHorizontal = _input._LeftStickHorizontal;
        _leftStickVertical = _input._LeftStickVertical;
    }



    // ダッシュしているかどうかの情報取得.
    public bool GetIsDashing() { return _isDashing; }

    // 回避フレームの数を取得.
    public int GetAvoidTime() { return _avoidTime; }

    // 回避しているかどうかの情報取得.
    public bool GetIsAvoiding() { return _isAvoiding; }

    // 回復している時間取得.
    public int GetRecoveryTime() { return _currentRecoveryTime; }

    // 回復しているかどうかの情報取得.
    public bool GetIsRecovery() { return _isRecovery; }

    // 残り体力.
    public float GetHitPoint() { return _hitPoint; }
    // 体力最大値.
    public float GetMaxHitPoint() { return _maxHitPoint; }
    // 残りスタミナ.
    public float GetStamina() { return _stamina; }
    // スタミナ最大値.
    public float GetMaxStamina() { return _maxStamina; }

    // ダメージを与えた時の値.
    public float GetHunterAttack() { return _AttackPower; }

}