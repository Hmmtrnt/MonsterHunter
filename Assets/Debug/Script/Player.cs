using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // �v���C���[�̃C���X�^���X
    public static Player _instance;

    // �L�����N�^�[�R���g���[���[
    private CharacterController _characterController;

    [SerializeField] private Camera _camera;

    // �������
    [SerializeField] private float _AvoidDistance;

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
    //[SerializeField] private float _time = 1.0f;

    // �Q�[���p�b�h�X�e�B�b�N�̓��͏�Ԃ̕ϐ�
    private float _horizontal;
    private float _vertical;

    // ������Ă��邩�ǂ���
    public bool _isAvoid;
    // �������Ă��邩�ǂ���
    public bool _isHoldWeapon;

    // ������Ă���t���[����
    private int _AvoidFlame;

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
        //_rigidbody = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();

        _isAvoid = false;
        _isHoldWeapon = false;
        _AvoidFlame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Avoid();
        if (_isAvoid) return;
        HoldWeapon();
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
        float _trigger = Input.GetAxis("L_R_Trigger");

        // �_�b�V��
        if(Input.GetKey("joystick button 5"))
        {
            if (_isHoldWeapon) return;
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
        
        if(!_isHoldWeapon)
        // �v���C���[�̐i�ޕ����Ɍ�����ύX
        transform.LookAt(transform.position + _moveZ + _moveX);
        // �ړ�
        _characterController.Move(_moveDirection * Time.deltaTime);

        _targetPosition = new Vector3(transform.position.x + _horizontal, transform.position.y, transform.position.z + _vertical);

    }

    // �������
    private void Avoid()
    {
        // �ړ����Ȃ���A�{�^���������Ɖ���t���OON
        if(Input.GetKeyDown("joystick button 0") && (_horizontal!= 0 || _vertical != 0))
        {
            _isAvoid = true;
        }

        if (!_isAvoid) return;

        _AvoidFlame++;

        _speed = 5.0f;
        _moveZ = _cameraFront * _vertical * _speed;
        _moveX = _camera.transform.right * _horizontal * _speed;

        _moveDirection = _moveZ + _moveX + new Vector3(0.0f, _moveDirection.y, 0.0f);
        _moveDirection.y -= _gravity * Time.deltaTime;

        // ������̈ړ�
        _characterController.Move(_moveDirection * _AvoidDistance);
        
        // ����I�����ɉ���t���OOFF�Ɖ�����Ԃ����Z�b�g
        if(_AvoidFlame >= 60)
        {
            _isAvoid = false;
            _AvoidFlame = 0;
        }
    }

    // ������\����
    private void HoldWeapon()
    {
        // ������Ԃɂ��邩�ǂ���
        //if(Input.GetKeyDown("joystick button 3"))
        //{
        //    if(!_isHoldWeapon) _isHoldWeapon = true;
        //    if(_isHoldWeapon) _isHoldWeapon = false;
        //}

        if(!_isHoldWeapon)
        {
            if(Input.GetKeyDown("joystick button 3"))
            {
                _isHoldWeapon = true;
            }
        }
        else if(_isHoldWeapon) 
        {
            if (Input.GetKeyDown("joystick button 2"))
            {
                _isHoldWeapon = false;
            }
        }
    }
}
