using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    // ゲージオブジェクト.
    Image _gauge;
    // 現在のゲージ.
    private float _currentGauge = 0;
    // ゲージの回復スピード
    private float _recoverySpeed = 0.003f;
    // 回避時のゲージ消費量
    private float _avoidanceCostGauge;
    // 走っているときのゲージ消費量
    private float _runCostGauge = 0.001f;
    private bool _isRuning = false;

    // Start is called before the first frame update
    void Start()
    {
        _gauge = GameObject.Find("StaminaGauge").GetComponent<Image>();
        _avoidanceCostGauge = 1.0f / 8.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Avoidance();
    }

    private void FixedUpdate()
    {
        _currentGauge = _gauge.fillAmount;

        if (_isRuning) return;

        AutomaticRecovery();

    }

    // スタミナを自動回復
    private void AutomaticRecovery()
    {
        _gauge.fillAmount += _recoverySpeed;
    }

    // ダッシュ時のゲージ消費
    private void Run()
    {
        if(ControllerManager._inctance._RBButton)
        {
            _gauge.fillAmount -= _runCostGauge;
            _isRuning = true;
        }
        else
        {
            _isRuning = false;
        }
    }


    // 回避時のゲージ消費
    private void Avoidance()
    {
        //if (ControllerManager._inctance._LeftStickHorizontal == 0.0f ||
        //    ControllerManager._inctance._LeftStickVertical == 0.0f) return;

        // 回避を行ったとき
        bool isAvoid = ControllerManager._inctance._AButtonDown &&
            (ControllerManager._inctance._LeftStickHorizontal != 0.0f ||
            ControllerManager._inctance._LeftStickVertical != 0.0f);

        if (isAvoid)
        {
            _gauge.fillAmount -= _avoidanceCostGauge;
        }
    }
}
