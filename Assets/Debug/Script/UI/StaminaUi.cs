using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaUi : MonoBehaviour
{
    public static StaminaUi _instance;

    // スティックの入力情報
    private float _leftStickHorizontal;
    private float _leftStickVertical;

    // スタミナゲージ.
    private Image _Gauge;
    // 現在のスタミナゲージ.
    private float _currentGauge;
    // スタミナゲージの自動回復量.
    private float _autoRecoveryGauge = 0.001f;
    // ダッシュした時のスタミナゲージの減少量.
    private float _decreaseDashGauge = 0.0005f;
    // 回避した時のスタミナゲージの減少量
    private float _decreaseAvoidGauge = 0.1f;
    // スタミナ切れが起こるタイミングのゲージの長さ
    private float _defatigationGauge = 0.15f;

    // スタミナが自動回復しないときtrue
    private bool _isNoAutoRecovery = false;

    void Start()
    {
        _Gauge = GetComponent<Image>();
    }

    void Update()
    {
        _leftStickHorizontal = ControllerManager._inctance._LeftStickHorizontal;
        _leftStickVertical = ControllerManager._inctance._LeftStickVertical;
    }

    private void FixedUpdate()
    {
        _currentGauge = _Gauge.fillAmount;

        if (_isNoAutoRecovery)
        {
            AutoRecovery();
        }
        
    }

    private void AutoRecovery()
    {
        _Gauge.fillAmount += _autoRecoveryGauge;
    }
}
