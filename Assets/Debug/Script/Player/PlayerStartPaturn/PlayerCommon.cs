using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private float _avoidTime    = 0;
    // 最大回避フレーム.
    private float _avoidMaxTime = 30;

    /*移動,回避共通変数*/
    // スタミナゲージ.
    private Image _staminaGauge;
    // 現在のスタミナゲージ.
    private float _currentStaminaGauge;
    // スタミナゲージの自動回復量.
    private float _autoRecoveryStaminaGauge = 0.001f;
    // ダッシュした時のスタミナゲージの減少量.
    private float _decreaseDashStaminaGauge = 0.0005f;
    // 回避した時のスタミナゲージの減少量
    private float _decreaseAvoidStaminaGauge = 0.1f;
    // スタミナ切れが起こるタイミングのゲージの長さ
    private float _defatigationGauge = 0.15f;

    // スタミナが自動回復しないときtrue
    private bool _isNoAutoRecovery = false;

    // 体力ゲージ.
    private Image _hitPointGauge;
    // 現在の体力ゲージ.
    private float _currentHitPointGauge;


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
        if(!_isNoAutoRecovery)
        {
            AutoRecoveryStaminaGauge();
        }
        OnFixedUpdate();
    }

    // プレイヤー情報の初期化
    private void Initialization()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
        _staminaGauge = GameObject.Find("StaminaGauge").GetComponent<Image>();
        _hitPointGauge = GameObject.Find("HitPointGauge").GetComponent<Image>();
        _camera = GameObject.Find("Camera").GetComponent<Camera>();
    }

    // 情報の代入
    private void SubstituteVariable()
    {
        // 現在のゲージの代入
        _currentStaminaGauge = _staminaGauge.fillAmount;
        _currentHitPointGauge = _hitPointGauge.fillAmount;

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

        // スタミナゲージが自動回復するかどうか
        _isNoAutoRecovery = _isDashing || _currentState is StateAvoid;
    }

    // スティックの入力情報取得
    private void GetStickInput()
    {
        // 入力情報代入.
        _leftStickHorizontal = ControllerManager._inctance._LeftStickHorizontal;
        _leftStickVertical = ControllerManager._inctance._LeftStickVertical;
    }

    // スタミナゲージの自動回復
    private void AutoRecoveryStaminaGauge()
    {
        _staminaGauge.fillAmount += _autoRecoveryStaminaGauge;
    }
}
