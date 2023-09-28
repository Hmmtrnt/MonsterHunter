using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController _characterController;
    [SerializeField] private Camera _camera;
    // �ړ��X�s�[�h
    private float _moveSpeed = 0.0f;
    // �d��
    [SerializeField] private float _gravity = 0.0f;

    private Vector3 _velocity = Vector3.zero;
    // HACK:�ϐ����e�L�g�[
    [SerializeField] private float _time;

    // �Q�[���p�b�h�̓��͏��
    private float _horizontalLeftStick;
    private float _verticalLeftStick;

    // ���
    private bool _isAvoid = false;
    // �������
    private float _avoidMaxTime = 30.0f;

    private float _avoidTime = 0;

    // ��������
    Vector3 _moveDirection = Vector3.zero;

    private Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();

        // �L���b�V�����Ă���
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 0")&& (_horizontalLeftStick != 0.0f || _verticalLeftStick != 0.0f))
        {
            _isAvoid = true;

            //Debug.Log("�ʂ��Ă���");
        }

        if(_isAvoid)
        {
            Evasion();
            _avoidTime++;
        }

        //Debug.Log(_avoidTime);

        if(_avoidTime >= _avoidMaxTime)
        {
            _isAvoid = false;
            _avoidTime = 0;
        }

        if (_isAvoid) return;
        Move();
    }

    // �f�o�b�O�p

    // �ړ�����
    private void Move()
    {
        // ���X�e�B�b�N���擾
        _horizontalLeftStick = Input.GetAxis("Horizontal");
        _verticalLeftStick = Input.GetAxis("Vertical");

        // �J�����̐��ʃx�N�g��
        Vector3 cameraForward = Vector3.Scale(_camera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

        // �J�����̌�����Vector�̙��K��ς���
        Vector3 verticalDirection = cameraForward * _verticalLeftStick * _moveSpeed;// �O��
        Vector3 horizontalDirection = _camera.transform.right * _horizontalLeftStick * _moveSpeed;// ���E

        // �_�b�V��
        if(Input.GetKey("joystick button 5"))
        {
            _moveSpeed = 15.0f;
        }
        else
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
    private void Evasion()
    {
        _characterController.Move(_moveDirection * 0.03f);
    }
}
