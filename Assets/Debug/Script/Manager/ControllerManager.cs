using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    // �C���X�^���X
    public static ControllerManager _inctance;

    // �X�e�B�b�N�̓��͏��
    public float _LeftStickHorizontal = 0;
    public float _LeftStickVertical = 0;
    public bool  _LeftStickButton;
    public bool  _LeftStickButtonDown;
    public bool  _LeftStickButtonUp;

    public float _RightStickHorizontal = 0;
    public float _RightStickVertical = 0;
    public bool  _RightStickButton;
    public bool  _RightStickButtonDown;
    public bool  _RightStickButtonUp;

    // �g���K�[���͏��
    public float _LeftTrigger = 0;
    public float _RightTrigger = 0;

    // Xbox�{�^�����͏��
    // Button�F������
    // Down  �F�������u��
    // Up    �F�����I���u��
    public bool _AButton;
    public bool _AButtonDown;
    public bool _AButtonUp;

    public bool _BButton;
    public bool _BButtonDown;
    public bool _BButtonUp;

    public bool _XButton;
    public bool _XButtonDown;
    public bool _XButtonUp;

    public bool _YButton;
    public bool _YButtonDown;
    public bool _YButtonUp;

    public bool _LBButton;
    public bool _LBButtonDown;
    public bool _LBButtonUp;

    public bool _RBButton;
    public bool _RBButtonDown;
    public bool _RBButtonUp;

    public bool _ViewButton;
    public bool _ViewButtonDown;
    public bool _ViewButtonUp;

    public bool _MenuButton;
    public bool _MenuButtonDown;
    public bool _MenuButtonUp;

    

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
        
    }

    // Update is called once per frame
    void Update()
    {
        // �X�e�B�b�N�̓��͏��擾
        _LeftStickHorizontal = Input.GetAxis("HorizontalLeft");
        _LeftStickVertical = Input.GetAxis("VerticalLeft");
        _LeftStickButton = Input.GetKey("joystick button 8");
        _LeftStickButtonDown = Input.GetKeyDown("joystick button 8");
        _LeftStickButtonUp = Input.GetKeyUp("joystick button 8");

        _RightStickHorizontal = Input.GetAxis("HorizontalRight");
        _RightStickVertical = Input.GetAxis("VerticalRight");
        _RightStickButton = Input.GetKey("joystick button 9");
        _RightStickButtonDown = Input.GetKeyDown("joystick button 9");
        _RightStickButtonUp = Input.GetKeyUp("joystick button 9");

        // �g���K�[���͏��
        _LeftTrigger = Input.GetAxis("LTrigger");
        _RightTrigger = Input.GetAxis("RTrigger");

        // �{�^�����͏��
        _AButton = Input.GetKey("joystick button 0");
        _AButtonDown = Input.GetKeyDown("joystick button 0");
        _AButtonUp = Input.GetKeyUp("joystick button 0");

        _BButton = Input.GetKey("joystick button 1");
        _BButtonDown = Input.GetKeyDown("joystick button 1");
        _BButtonUp = Input.GetKeyUp("joystick button 1");

        _XButton = Input.GetKey("joystick button 2");
        _XButtonDown = Input.GetKeyDown("joystick button 2");
        _XButtonUp = Input.GetKeyUp("joystick button 2");

        _YButton = Input.GetKey("joystick button 3");
        _YButtonDown = Input.GetKeyDown("joystick button 3");
        _YButtonUp = Input.GetKeyUp("joystick button 3");

        _LBButton = Input.GetKey("joystick button 4");
        _LBButtonDown = Input.GetKeyDown("joystick button 4");
        _LBButtonUp = Input.GetKeyUp("joystick button 4");

        _RBButton = Input.GetKey("joystick button 5");
        _RBButtonDown = Input.GetKeyDown("joystick button 5");
        _RBButtonUp = Input.GetKeyUp("joystick button 5");

        _ViewButton = Input.GetKey("joystick button 6");
        _ViewButtonDown = Input.GetKeyDown("joystick button 6");
        _ViewButtonUp = Input.GetKeyUp("joystick button 6");

        _MenuButton = Input.GetKey("joystick button 7");
        _MenuButtonDown = Input.GetKeyDown("joystick button 7");
        _MenuButtonUp = Input.GetKeyUp("joystick button 7");



}
}
