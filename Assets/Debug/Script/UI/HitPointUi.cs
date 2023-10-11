// Hpゲージ

using UnityEngine;
using UnityEngine.UI;

public class HitPointUi : MonoBehaviour
{
    public static StaminaUi _instance;
    // プレイヤー情報
    private PlayerStateSample _playerState;

    // ゲージ.
    private Image _Gauge;
    // 現在のスタミナゲージ.
    private float _currentGauge;
    // ダメージを食らった時の減少量.
    private float _decreaseDashGauge = 0.0005f;
    // 体力の回復量
    private float _increaseRecoveryGauge = 0.003f;

    // Start is called before the first frame update
    void Start()
    {
        _playerState = GameObject.Find("Hunter2").GetComponent<PlayerStateSample>();

        _Gauge = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _currentGauge = _Gauge.fillAmount;

        if(_playerState.GetIsRecovery())
        {
            OnRecovery();
        }
    }

    // ダメージを受けた時の体力変動
    private void OnDamage()
    {

    }

    // 回復しているときの体力変動
    private void OnRecovery()
    {
        _Gauge.fillAmount += _increaseRecoveryGauge;
    }
}
