using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class PlayerStateSample : MonoBehaviour
{
    private Rigidbody _rigidbody;

    // transform���L���b�V��.
    private Transform _transform;
    // �J����
    private Camera _camera;
    // �J�����̐���
    private Vector3 _cameraForward;

    /*�R���g���[���[�ϐ�*/
    // ���X�e�B�b�N�̓��͏��.
    private float _leftStickHorizontal;
    private float _leftStickVertical;

    /*�A�C�h����Ԏ��̕ϐ�*/

    /*�ړ����̕ϐ�*/
    // �ړ�����.
    private Vector3 _moveDirection;
    // ���鎞�̈ړ��{��.
    private float _moveVelocityRunMagnification = 12;
    // �_�b�V�����̈ړ��{��.
    private float _moveVelocityDashMagnigication = 20;
    // �ړ����x�{��.
    private float _moveVelocityMagnification = 12;
    // �ړ����x.
    private Vector3 _moveVelocity = new (0.0f,0.0f,0.0f);
    // �_�b�V�����Ă��邩�ǂ���.
    private bool _isDashing = false;
    // �d��.
    private float _gravity = -10.0f;

    /*������̕ϐ�*/
    // ��𑬓x�{��.
    private float _avoidVelocityMagnification = 30;
    // ��𑬓x.
    private Vector3 _avoidVelocity = new (0.0f,0.0f,0.0f);
    // ���݂̉���t���[��.
    private float _avoidTime    = 0;
    // �ő����t���[��.
    private float _avoidMaxTime = 30;


    void Start()
    {
        Initialization();
        OnStart();
    }

    void Update()
    {
        GetStickInput();
        OnUpdate();
    }

    private void FixedUpdate()
    {
        SubstituteVariable();
        OnFixedUpdate();
    }

    // �v���C���[���̏�����
    private void Initialization()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
        _camera = GameObject.Find("Camera").GetComponent<Camera>();
    }

    // ���̑��
    private void SubstituteVariable()
    {

        // �����������.
        _moveDirection = new Vector3(_leftStickHorizontal, 0.0f, _leftStickVertical);
        _moveDirection.Normalize();

        // �J�����̐���
        _cameraForward = Vector3.Scale(_camera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

        /*�J�����̌�������ړ������擾*/
        // ����
        Vector3 moveForward = _cameraForward * _leftStickVertical;
        // ��
        Vector3 moveSide = _camera.transform.right * _leftStickHorizontal;
        // ���x�̑��.
        _moveVelocity = moveForward + moveSide;
        _avoidVelocity = _transform.forward * _avoidVelocityMagnification;

    }

    // �X�e�B�b�N�̓��͏��擾
    private void GetStickInput()
    {
        // ���͏����.
        _leftStickHorizontal = ControllerManager._inctance._LeftStickHorizontal;
        _leftStickVertical = ControllerManager._inctance._LeftStickVertical;
    }

}
