using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public static Stamina _instance;

    // ゲージオブジェクト.
    Image _gauge;
    // 現在のゲージ.
    private float _currentGauge = 0;
    // 走るスピードが落ちるのゲージの長さ
    private float _lastGauge = 0.15f;
    // ゲージの回復スピード
    private float _recoverySpeed = 0.003f;
    // 回避時のゲージ消費量
    private float _avoidanceCostGauge;
    // 走っているときのゲージ消費量
    private float _runCostGauge = 0.0005f;
    // 走っているかどうか
    private bool _isRuning = false;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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

        if (_isRuning || Player._inctance._isAvoid) return;

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

    // 現在のゲージの長さを取得
    public float GetCurrentLengthGauge()
    {
        return _currentGauge;
    }

    // 走るスピードが遅くなるゲージの長さ取得
    public float GetLastGauge()
    {
        return _lastGauge;
    }
}
