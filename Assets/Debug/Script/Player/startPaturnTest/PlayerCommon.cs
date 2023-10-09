using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerStateSample : MonoBehaviour
{
    /*�R���g���[���[�ϐ�*/
    // ���X�e�B�b�N�̓��͏��
    private float _leftStickHorizontal;
    private float _leftStickVertical;


    // ���݂̉���t���[��
    private float _avoidTime    = 0;
    // �ő����t���[��
    private float _avoidMaxTime = 30;

    // Start is called before the first frame update
    void Start()
    {
        OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        // ���͏����
        _leftStickHorizontal = ControllerManager._inctance._LeftStickHorizontal;
        _leftStickVertical   = ControllerManager._inctance._LeftStickVertical;

        OnUpdate();
    }

    private void FixedUpdate()
    {
        OnFixedUpdate();
    }
}
