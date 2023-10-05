using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player _inctance;

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

    // ����X�s�[�h
    [SerializeField]private float _avoidSpeed = 0.0f;

    // ���
    public bool _isAvoid = false;
    // �ő����t���[����
    private float _avoidMaxTime = 30.0f;
    // ���݂̉���t���[����
    private float _avoidCurrentTime = 0;

    // ��������
    Vector3 _moveDirection = Vector3.zero;

    private Transform _transform;

    private Quaternion _targetRotation;
    // ������Ԃ��ǂ���
    private bool _isDrawnWepon;

    private void Awake()
    {
        if(_inctance == null)
        {
            _inctance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();

        // �L���b�V�����Ă���
        _transform = transform;

        _targetRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (ControllerManager._inctance._AButtonDown&& (_horizontalLeftStick != 0.0f || _verticalLeftStick != 0.0f))
        {
            _isAvoid = true;
        }

        // ���
        if(_isAvoid)
        {
            //Avoid();

            MovementPlayer._inctance.Avoid();
            _avoidCurrentTime++;
        }

        if(_avoidCurrentTime >= _avoidMaxTime)
        {
            _isAvoid = false;
            _avoidCurrentTime = 0;
        }

        //Debug.Log(_isDrawnWepon);

        if (_isAvoid) return;
        //Movement();
        MovementPlayer._inctance.Movement();

        WeponState();

        //TestMove();

        //test++;
        //Debug.Log(test);
    }

    // �f�o�b�O�p

    // �ړ�����
    private void Movement()
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
        if(Stamina._instance.GetCurrentLengthGauge() <= Stamina._instance.GetLastGauge() &&
           ControllerManager._inctance._RBButton)
        {
            _moveSpeed = 4.0f;
        }
        else if(ControllerManager._inctance._RBButton)
        {
            _moveSpeed = 15.0f;
        }
        else if(!ControllerManager._inctance._RBButton)
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

    // �v���C���[�̉�]���u���b�V���A�b�v
    private void TestMove()
    {
        // ���X�e�B�b�N���擾
        _horizontalLeftStick = ControllerManager._inctance._LeftStickHorizontal;
        _verticalLeftStick = ControllerManager._inctance._LeftStickVertical;

        if (_horizontalLeftStick != 0 || _verticalLeftStick != 0)
        {
            // �ړ�
            _characterController.Move(transform.forward * 5.0f * Time.deltaTime);
        }

        
    }

    // �������
    private void Avoid()
    {
        _moveDirection.y = _gravity;
        _characterController.Move((_transform.forward + new Vector3(0.0f, _moveDirection.y, 0.0f)) * _avoidSpeed * Time.deltaTime);
    }

    // �v���C���[�̔������͔[����Ԏ擾
    private void WeponState()
    {
        if(ControllerManager._inctance._YButtonDown) 
        {
            _isDrawnWepon = true;
        }

        if (_isDrawnWepon) return;
       
        if(ControllerManager._inctance._XButtonDown)
        {
            _isDrawnWepon = false;
        }
        if(ControllerManager._inctance._RBButtonDown)
        {
            _isDrawnWepon = false;
        }
    }

    public bool GetDrawWepon()
    {
        return _isDrawnWepon;
    }
}
