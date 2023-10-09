using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerStateSample : MonoBehaviour
{
    private Rigidbody _rigidbody;

    // transformをキャッシュ
    private Transform _transform;

    /*コントローラー変数*/
    // 左スティックの入力情報
    private float _leftStickHorizontal;
    private float _leftStickVertical;

    // 移動方向
    private Vector3 _moveDirection;
    // 走る時の移動倍率
    private float _moveVelocityRunMagnification = 12;
    // ダッシュ時の移動倍率
    private float _moveVelocityDashMagnigication = 20;
    // 移動速度倍率
    private float _moveVelocityMagnification = 12;
    // 移動速度
    private Vector3 _moveVelocity = new (0.0f,0.0f,0.0f);
    // 重力
    private float _gravity = -10.0f;
    // 回避速度倍率
    private float _avoidVelocityMagnification = 30;
    // 回避速度
    private Vector3 _avoidVelocity = new (0.0f,0.0f,0.0f);

    // 現在の回避フレーム
    private float _avoidTime    = 0;
    // 最大回避フレーム
    private float _avoidMaxTime = 30;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;

        OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        // 入力情報代入
        _leftStickHorizontal = ControllerManager._inctance._LeftStickHorizontal;
        _leftStickVertical   = ControllerManager._inctance._LeftStickVertical;

        _moveDirection = new Vector3(_leftStickHorizontal, 0.0f, _leftStickVertical);
        _moveDirection.Normalize();

        _moveVelocity = _moveDirection * _moveVelocityMagnification;
        _avoidVelocity = _transform.forward * _avoidVelocityMagnification;


        OnUpdate();
    }

    private void FixedUpdate()
    {
        OnFixedUpdate();
    }
}
