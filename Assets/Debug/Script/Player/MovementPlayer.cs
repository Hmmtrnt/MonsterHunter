using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    // �V���O���g��
    public static MovementPlayer _inctance;

    private Camera _camera;
    private CharacterController _characterController;

    // �Q�[���p�b�h�̍��X�e�B�b�N���͏��
    private float _horizontalLeftStick = 0.0f;
    private float _verticalLeftStick = 0.0f;

    // �ړ����x
    private float _moveSpeed = 0.0f;
    // ��𑬓x
    private float _avoidSpeed = 30.0f;

    // �d��
    private float _gravity = -15.0f;

    // ��������
    Vector3 _moveDirection = Vector3.zero;

    private Transform _transform;

    

    private void Awake()
    {
        if(_inctance == null)
        {
            _inctance = this;
        }
        else
        {
            Destroy(_inctance);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _camera = GameObject.Find("Camera").GetComponent<Camera>();
        // �L���b�V�����Ă���
        _transform = transform;
    }

    // �ړ�����
    public void Movement()
    {
        // ���X�e�B�b�N���擾
        _horizontalLeftStick = ControllerManager._inctance._LeftStickHorizontal;
        _verticalLeftStick = ControllerManager._inctance._LeftStickVertical;

        // �J�����̐��ʃx�N�g��
        Vector3 cameraForward = Vector3.Scale(_camera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

        // �J�����̌�����Vector�̙��K��ς���
        Vector3 verticalDirection = cameraForward * _verticalLeftStick * _moveSpeed;// �O��
        Vector3 horizontalDirection = _camera.transform.right * _horizontalLeftStick * _moveSpeed;// ���E

        // �_�b�V��
        if (Stamina._instance.GetCurrentLengthGauge() <= Stamina._instance.GetLastGauge() &&
           ControllerManager._inctance._RBButton)
        {
            _moveSpeed = 4.0f;
        }
        else if (ControllerManager._inctance._RBButton)
        {
            _moveSpeed = 15.0f;
        }
        else if (!ControllerManager._inctance._RBButton)
        {
            _moveSpeed = 7.0f;
        }

        // �d��
        _moveDirection.y = _gravity;

        // �ړ��������
        _moveDirection = verticalDirection + horizontalDirection + new Vector3(0.0f, _moveDirection.y, 0.0f);

        // �ړ��������
        transform.LookAt(_transform.position + verticalDirection + horizontalDirection);


        // �ړ�
        _characterController.Move(_moveDirection * Time.deltaTime);
    }

    // �������
    public void Avoid()
    {
        _moveDirection.y = _gravity;
        _characterController.Move((_transform.forward + new Vector3(0.0f, _moveDirection.y, 0.0f)) * _avoidSpeed * Time.deltaTime);
    }
}
