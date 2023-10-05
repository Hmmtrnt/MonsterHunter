using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public static Stamina _instance;

    // �Q�[�W�I�u�W�F�N�g.
    Image _gauge;
    // ���݂̃Q�[�W.
    private float _currentGauge = 0;
    // ����X�s�[�h��������̃Q�[�W�̒���
    private float _lastGauge = 0.15f;
    // �Q�[�W�̉񕜃X�s�[�h
    private float _recoverySpeed = 0.003f;
    // ������̃Q�[�W�����
    private float _avoidanceCostGauge;
    // �����Ă���Ƃ��̃Q�[�W�����
    private float _runCostGauge = 0.0005f;
    // �����Ă��邩�ǂ���
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

    // �X�^�~�i��������
    private void AutomaticRecovery()
    {
        _gauge.fillAmount += _recoverySpeed;
    }

    // �_�b�V�����̃Q�[�W����
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


    // ������̃Q�[�W����
    private void Avoidance()
    {
        //if (ControllerManager._inctance._LeftStickHorizontal == 0.0f ||
        //    ControllerManager._inctance._LeftStickVertical == 0.0f) return;

        // ������s�����Ƃ�
        bool isAvoid = ControllerManager._inctance._AButtonDown &&
            (ControllerManager._inctance._LeftStickHorizontal != 0.0f ||
            ControllerManager._inctance._LeftStickVertical != 0.0f);

        if (isAvoid)
        {
            _gauge.fillAmount -= _avoidanceCostGauge;
        }
    }

    // ���݂̃Q�[�W�̒������擾
    public float GetCurrentLengthGauge()
    {
        return _currentGauge;
    }

    // ����X�s�[�h���x���Ȃ�Q�[�W�̒����擾
    public float GetLastGauge()
    {
        return _lastGauge;
    }
}
