// スタミナゲージの処理

using UnityEngine;
using UnityEngine.UI;

public class StaminaUi : MonoBehaviour
{
    public static StaminaUi _instance;
    // プレイヤー情報
    private PlayerStateSample _playerState;

    // スタミナゲージ.
    private Image _Gauge;
    // 現在のスタミナゲージ.
    private float _currentGauge;
    // スタミナゲージの自動回復量.
    private float _autoRecoveryGauge = 0.001f;
    // ダッシュした時のスタミナゲージの減少量.
    private float _decreaseDashGauge = 0.0005f;
    // 回避した時のスタミナゲージの減少量.
    private float _decreaseAvoidGauge = 0.1f;
    // スタミナ切れが起こるタイミングのゲージの長さ.
    private float _defatigationGauge = 0.15f;

    // スタミナが自動回復しないときtrue.
    private bool _isNoAutoRecovery = false;

    void Start()
    {
        _Gauge = GetComponent<Image>();
        _Gauge.fillAmount = 1.0f;
        _playerState = GameObject.Find("Hunter2").GetComponent<PlayerStateSample>();
    }

    void Update()
    {
        Debug.Log(_playerState.GetAvoidTime());

        if (_playerState.GetAvoidTime() != 1) return;

        if (_playerState.GetIsAvoiding())
        {
            AvoidStaminaConsumption();
        }

    }

    private void FixedUpdate()
    {
        _currentGauge = _Gauge.fillAmount;

        IsNoAutoRecovery();


        if (_playerState.GetIsDashing())
        {
            DashStaminaConsumption();
        }

        if (!_isNoAutoRecovery)
        {
            AutoRecovery();
        }
        
    }

    // 自動回復できるかどうか
    private void IsNoAutoRecovery()
    {
        if(!_playerState.GetIsDashing() && !_playerState.GetIsAvoiding())
        {
            _isNoAutoRecovery = false;
        }
        else
        {
            _isNoAutoRecovery = true;
        }
    }

    // 自動回復.
    private void AutoRecovery()
    {
        _Gauge.fillAmount += _autoRecoveryGauge;
    }

    // ダッシュ時のスタミナ消費
    private void DashStaminaConsumption()
    {
        _Gauge.fillAmount -= _decreaseDashGauge;
    }

    // 回避時のスタミナ消費
    private void AvoidStaminaConsumption()
    {
        _Gauge.fillAmount -= _decreaseAvoidGauge;
    }
}
