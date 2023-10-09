using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerStateSample : MonoBehaviour
{
    Rigidbody _rigidbody;

    /*�R���g���[���[�ϐ�*/
    // ���X�e�B�b�N�̓��͏��
    private float _leftStickHorizontal;
    private float _leftStickVertical;

    // �ړ����x
    private Vector3 _moveSpeed;

    // ���݂̉���t���[��
    private float _avoidTime    = 0;
    // �ő����t���[��
    private float _avoidMaxTime = 30;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        // ���͏����
        _leftStickHorizontal = ControllerManager._inctance._LeftStickHorizontal;
        _leftStickVertical   = ControllerManager._inctance._LeftStickVertical;

        _moveSpeed = new Vector3(_leftStickHorizontal, 0.0f, _leftStickVertical);

        OnUpdate();
    }

    private void FixedUpdate()
    {
        OnFixedUpdate();
    }
}
