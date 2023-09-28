// �X�^�~�i

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public static Stamina _inctance;

    // �X�^�~�i
    private float _maxStamina = 200;// �ő�l
    private float _minStamina = 0;// �ŏ��l
    private float _currentStamina;// ����

    // �X�^�~�i�񕜑��x
    private float _recoveryStamina = 0.1f;
    // �X�^�~�i�̏����
    private float _decreaseStamina = 0.01f;

    // �X�^�~�i�o�[
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        // �V���O���g���̎���
        if( _inctance == null )
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
        // �X�^�~�i�o�[�𖞃^���ɂ��Ă���
        _slider.value = 1;
        // ���݂̃X�^�~�i���ő�l�ɂ���
        _currentStamina = _maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScaleStamina();
        // Slider�ɃX�^�~�i���𔽉f
        _slider.value = _currentStamina / _maxStamina;
    }

    // �X�^�~�i��UI�̑傫����ύX
    private void UpdateScaleStamina()
    {
        // �_�b�V������ƃX�^�~�i�����X�Ɍ���
        if (Input.GetKey("joystick button 5") && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            _currentStamina = _currentStamina - _decreaseStamina;
            if (_currentStamina <= _minStamina)
            {
                _currentStamina = _minStamina;
            }
        }
        else
        {
            _currentStamina = _currentStamina + _recoveryStamina;
            if (_currentStamina >= _maxStamina)
            {
                _currentStamina = _maxStamina;
            }
        }

        // �������ƃX�^�~�i���ő�l��1/10���炷
        if(Input.GetKeyDown("joystick button 0") && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            _currentStamina = _currentStamina - (_maxStamina / 10.0f);
            if (_currentStamina <= _minStamina)
            {
                _currentStamina = _minStamina;
            }
        }
    }
}
