// Hp�Q�[�W

using UnityEngine;
using UnityEngine.UI;

public class HitPointUi : MonoBehaviour
{
    public static StaminaUi _instance;
    // �v���C���[���
    private PlayerStateSample _playerState;

    // �Q�[�W.
    private Image _Gauge;
    // ���݂̃X�^�~�i�Q�[�W.
    private float _currentGauge;
    // �_���[�W��H��������̌�����.
    private float _decreaseDashGauge = 0.0005f;
    // �̗͂̉񕜗�
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

    // �_���[�W���󂯂����̗͕̑ϓ�
    private void OnDamage()
    {

    }

    // �񕜂��Ă���Ƃ��̗͕̑ϓ�
    private void OnRecovery()
    {
        _Gauge.fillAmount += _increaseRecoveryGauge;
    }
}
