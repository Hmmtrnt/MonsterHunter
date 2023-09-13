using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // �v���C���[��Rigidbody�擾
    //private Rigidbody _rigidbody;

    // �L�����N�^�[�R���g���[���[
    private CharacterController _characterController;

    [SerializeField] private Camera _camera;

    // �i�ޕ���
    private Vector3 _moveDirection;
    private Vector3 _moveX;
    private Vector3 _moveZ;
    private Vector3 _cameraFront;

    // ����̍��W
    private Vector3 _targetPosition;

    // ���x
    private Vector3 _velocity = Vector3.zero;

    // �v���C���[�̃X�s�[�h
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _gravity = 10.0f;
    [SerializeField] private float _time = 1.0f;

    // �Q�[���p�b�h�X�e�B�b�N�̓��͏�Ԃ̕ϐ�
    private float _horizontal;
    private float _vertical;

    // ������Ă��邩�ǂ���
    private bool _isAvoid;

    // Start is called before the first frame update
    void Start()
    {
        //_rigidbody = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();

        _isAvoid = false;
    }

    // Update is called once per frame
    void Update()
    {
        Avoid();
        Move();
    }

    private void FixedUpdate()
    {
        FallDebug();
    }

    // �n�ʂ��痎�����珉���ʒu�̃X�|�[��
    private void FallDebug()
    {
        if (transform.position.y <= -10.0f)
        {
            transform.position = new Vector3(0.0f, 1.0f, 0.0f);
        }
    }

    // �ړ�
    private void Move()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        // �_�b�V��
        if(Input.GetKeyDown("joystick button 5"))
        {
            _speed = 10.0f;
        }
        // ���̃X�s�[�h�ɖ߂�
        if(Input.GetKeyUp("joystick button 5"))
        {
            _speed = 5.0f;
        }

        // �J�����̌�������ɂ������ʕ����̃x�N�g��
        _cameraFront = Vector3.Scale(_camera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;
        // �ړ�
        _moveZ = _cameraFront * _vertical * _speed;
        _moveX = _camera.transform.right * _horizontal * _speed;

        _moveDirection = _moveZ + _moveX + new Vector3(0.0f, _moveDirection.y, 0.0f);
        _moveDirection.y -= _gravity * Time.deltaTime;

        // �v���C���[�̐i�ޕ����Ɍ�����ύX
        transform.LookAt(transform.position + _moveZ + _moveX);
        // 
        _characterController.Move(_moveDirection * Time.deltaTime);

        //_rigidbody.AddForce(_horizontal, 0, _vertical, ForceMode.Force);
    }

    // �������
    private void Avoid()
    {
        // ����{�^���������Ƃ�
        if(Input.GetKeyDown("joystick button 0"))
        {
            _targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5f);
            _isAvoid = true;
        }

        // ��𒆂ł͂Ȃ��Ƃ��ɂ͔�΂�
        if (!_isAvoid) return;




        transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _velocity, _time);
        
        if(transform.position == _targetPosition)
        {
            _isAvoid=false;
        }
    }
}
