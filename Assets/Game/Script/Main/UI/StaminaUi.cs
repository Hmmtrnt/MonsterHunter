// スタミナゲージの処理

using UnityEngine;
using UnityEngine.UI;

public class StaminaUi : MonoBehaviour
{
    // プレイヤー情報
    private PlayerState _playerState;

    // スタミナゲージ.
    private Image _gauge;

    // スタミナが自動回復しないときtrue.
    private bool _isNoAutoRecovery = false;

    [Header("点滅するときの最初の色")]
    [SerializeField] private Color32 _startColor;

    [Header("点滅するときの次の色")]
    [SerializeField] private Color32 _endColor;

    [Header("一回の点滅するときの長さ")]
    [SerializeField] private float _blinkingTime = 1.0f;

    void Start()
    {
        _gauge = GetComponent<Image>();
        _gauge.fillAmount = 1.0f;
        _playerState = GameObject.Find("Hunter").GetComponent<PlayerState>();
    }

    void Update()
    {
        //if (_playerState.GetAvoidTime() != 1) return;

        //if (_playerState.GetIsAvoiding())
        //{
        //    AvoidStaminaConsumption();
        //}
    }

    private void FixedUpdate()
    {
        _gauge.fillAmount = _playerState.GetStamina() / _playerState.GetMaxStamina();

        if(_gauge.fillAmount <= 1.0f / 5)
        {
            _gauge.color = Color.Lerp(_startColor, _endColor, Mathf.PingPong(Time.time / _blinkingTime, 1.0f));
        }
        else if(_gauge.fillAmount >= 1.0f / 5)
        {
            _gauge.color = _startColor;
        }
    }
}
