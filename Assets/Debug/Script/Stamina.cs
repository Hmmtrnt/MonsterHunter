using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    // �Q�[�W�I�u�W�F�N�g.
    Image _gauge;
    // ���݂̃Q�[�W.
    private float _currentGauge = 0;
    // �Q�[�W�̉񕜃X�s�[�h
    private float _recoverySpeed = 0.003f;
    // ������̃Q�[�W�����
    private float _avoidanceCostGauge;

    // Start is called before the first frame update
    void Start()
    {
        _gauge = GameObject.Find("StaminaGauge").GetComponent<Image>();
        _avoidanceCostGauge = 1.0f / 8.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        Avoidance();
    }

    private void FixedUpdate()
    {
        _currentGauge = _gauge.fillAmount;
        AutomaticRecovery();

    }

    // �X�^�~�i�������񕜏���
    private void AutomaticRecovery()
    {
        _gauge.fillAmount += _recoverySpeed;
    }

    // ������̃Q�[�W����̏���
    private void Avoidance()
    {
        if (Input.GetAxis("Horizontal") == 0.0f ||
            Input.GetAxis("Vertical") == 0.0f) return;


        if (Input.GetKeyDown("joystick button 0"))
        {
            _gauge.fillAmount -= _avoidanceCostGauge;
        }
    }
}
