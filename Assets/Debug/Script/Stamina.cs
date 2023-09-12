using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    // スタミナ
    private float _maxStamina = 200;// 最大値
    private float _minStamina = 0;// 最小値
    private float _currentStamina;// 現在

    private float _recoveryStamina = 0.1f;
    private float _decreaseStamina = 0.01f;// スタミナの消費量

    [SerializeField] private Slider _slider;

    // Start is called before the first frame update
    void Start()
    {
        // スタミナバーを満タンにしておく
        _slider.value = 1;
        // 現在のスタミナを最大値にする
        _currentStamina = _maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScaleStamina();
        // Sliderにスタミナ情報を反映
        _slider.value = _currentStamina / _maxStamina;
    }

    // スタミナのUIの大きさを変更
    private void UpdateScaleStamina()
    {
        //if (!Input.GetKey("joystick button 5"))
        //{
        //    _currentStamina = _currentStamina + _recoveryStamina;
        //    if (_currentStamina >= _maxStamina)
        //    {
        //        _currentStamina = _maxStamina;
        //    }
        //}
        //else if(Input.GetKey("joystick button 5"))
        //{
        //    if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) return;
        //    _currentStamina = _currentStamina - _decreaseStamina;
        //    if (_currentStamina <= _minStamina)
        //    {
        //        _currentStamina = _minStamina;
        //    }
        //}

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
    }
}
