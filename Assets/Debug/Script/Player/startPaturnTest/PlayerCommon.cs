using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerStateSample : MonoBehaviour
{
    /*コントローラー変数*/
    // 左スティックの入力情報
    private float _leftStickHorizontal;
    private float _leftStickVertical;


    // 現在の回避フレーム
    private float _avoidTime    = 0;
    // 最大回避フレーム
    private float _avoidMaxTime = 30;

    // Start is called before the first frame update
    void Start()
    {
        OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        // 入力情報代入
        _leftStickHorizontal = ControllerManager._inctance._LeftStickHorizontal;
        _leftStickVertical   = ControllerManager._inctance._LeftStickVertical;

        OnUpdate();
    }

    private void FixedUpdate()
    {
        OnFixedUpdate();
    }
}
