using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerStateSample : MonoBehaviour
{
    Rigidbody _rigidbody;

    /*コントローラー変数*/
    // 左スティックの入力情報
    private float _leftStickHorizontal;
    private float _leftStickVertical;

    // 移動速度
    private Vector3 _moveSpeed;

    // 現在の回避フレーム
    private float _avoidTime    = 0;
    // 最大回避フレーム
    private float _avoidMaxTime = 30;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        // 入力情報代入
        _leftStickHorizontal = ControllerManager._inctance._LeftStickHorizontal;
        _leftStickVertical   = ControllerManager._inctance._LeftStickVertical;

        _moveSpeed = new Vector3(_leftStickHorizontal, 0.0f, _leftStickVertical);

        OnUpdate();
    }

    private void FixedUpdate()
    {
        OnFixedUpdate();
    }
}
