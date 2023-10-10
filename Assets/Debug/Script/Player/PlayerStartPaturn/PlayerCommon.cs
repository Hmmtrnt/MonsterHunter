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
    // 体力ゲージ.
    private Image _hitPointGauge;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
        _staminaGauge = GameObject.Find("StaminaGauge").GetComponent<Image>();
        _hitPointGauge = GameObject.Find("HitPointGauge").GetComponent <Image>();
        _camera = GameObject.Find("Camera").GetComponent<Camera>();

        OnStart();
    }

    void Update()
    {
        // 入力情報代入.
        _leftStickHorizontal = ControllerManager._inctance._LeftStickHorizontal;
        _leftStickVertical   = ControllerManager._inctance._LeftStickVertical;

        


        OnUpdate();
    }

    private void FixedUpdate()
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

        OnFixedUpdate();
    }
}
