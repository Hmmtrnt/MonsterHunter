// �X�^�~�i�Q�[�W�̏���

using UnityEngine;
using UnityEngine.UI;

public class StaminaUi : MonoBehaviour
{
    public static StaminaUi _instance;
    // �v���C���[���
    private PlayerStateSample _playerState;

    // �X�^�~�i�Q�[�W.
    private Image _Gauge;
    // ���݂̃X�^�~�i�Q�[�W.
    private float _currentGauge;
    // �X�^�~�i�Q�[�W�̎����񕜗�.
    private float _autoRecoveryGauge = 0.001f;
    // �_�b�V���������̃X�^�~�i�Q�[�W�̌�����.
    private float _decreaseDashGauge = 0.0005f;
    // ����������̃X�^�~�i�Q�[�W�̌�����.
    private float _decreaseAvoidGauge = 0.1f;
    // �X�^�~�i�؂ꂪ�N����^�C�~���O�̃Q�[�W�̒���.
    private float _defatigationGauge = 0.15f;

    // �X�^�~�i�������񕜂��Ȃ��Ƃ�true.
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

    // �����񕜂ł��邩�ǂ���
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

    // ������.
    private void AutoRecovery()
    {
        _Gauge.fillAmount += _autoRecoveryGauge;
    }

    // �_�b�V�����̃X�^�~�i����
    private void DashStaminaConsumption()
    {
        _Gauge.fillAmount -= _decreaseDashGauge;
    }

    // ������̃X�^�~�i����
    private void AvoidStaminaConsumption()
    {
        _Gauge.fillAmount -= _decreaseAvoidGauge;
    }
}
