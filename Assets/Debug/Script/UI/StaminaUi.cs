// �X�^�~�i�Q�[�W�̏���

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaUi : MonoBehaviour
{
    public static StaminaUi _instance;

    private PlayerStateSample _playerState;

    // �X�e�B�b�N�̓��͏��
    private float _leftStickHorizontal;
    private float _leftStickVertical;

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
    private bool _isDashing = false;

    void Start()
    {
        _Gauge = GetComponent<Image>();
        _Gauge.fillAmount = 1.0f;
    }

    void Update()
    {
        _leftStickHorizontal = ControllerManager._inctance._LeftStickHorizontal;
        _leftStickVertical = ControllerManager._inctance._LeftStickVertical;
        _isDashing = (_leftStickHorizontal != 0 || _leftStickVertical != 0) &&
            ControllerManager._inctance._RBButton;

        IsNoAutoRecovery();
        //if(_playerState._currentState == new PlayerStateSample.StateIdle())
        //{
        //    Debug.Log("adaiofda");
        //}

    }

    private void FixedUpdate()
    {
        _currentGauge = _Gauge.fillAmount;

        if(_isDashing)
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
        if(_isDashing)
        {
            _isNoAutoRecovery = true;
        }
        else
        {
            _isNoAutoRecovery = false;
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
}
