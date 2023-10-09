using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerStateSample : MonoBehaviour
{
    private Rigidbody _rigidbody;

    // transform���L���b�V��
    private Transform _transform;

    /*�R���g���[���[�ϐ�*/
    // ���X�e�B�b�N�̓��͏��
    private float _leftStickHorizontal;
    private float _leftStickVertical;

    // �ړ�����
    private Vector3 _moveDirection;
    // ���鎞�̈ړ��{��
    private float _moveVelocityRunMagnification = 12;
    // �_�b�V�����̈ړ��{��
    private float _moveVelocityDashMagnigication = 20;
    // �ړ����x�{��
    private float _moveVelocityMagnification = 12;
    // �ړ����x
    private Vector3 _moveVelocity = new (0.0f,0.0f,0.0f);
    // �d��
    private float _gravity = -10.0f;
    // ��𑬓x�{��
    private float _avoidVelocityMagnification = 30;
    // ��𑬓x
    private Vector3 _avoidVelocity = new (0.0f,0.0f,0.0f);

    // ���݂̉���t���[��
    private float _avoidTime    = 0;
    // �ő����t���[��
    private float _avoidMaxTime = 30;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;

        OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        // ���͏����
        _leftStickHorizontal = ControllerManager._inctance._LeftStickHorizontal;
        _leftStickVertical   = ControllerManager._inctance._LeftStickVertical;

        _moveDirection = new Vector3(_leftStickHorizontal, 0.0f, _leftStickVertical);
        _moveDirection.Normalize();

        _moveVelocity = _moveDirection * _moveVelocityMagnification;
        _avoidVelocity = _transform.forward * _avoidVelocityMagnification;


        OnUpdate();
    }

    private void FixedUpdate()
    {
        OnFixedUpdate();
    }
}
