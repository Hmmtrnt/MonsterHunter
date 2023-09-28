// スタミナ

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public static Stamina _inctance;

    // スタミナ
    private float _maxStamina = 200;// 最大値
    private float _minStamina = 0;// 最小値
    private float _currentStamina;// 現在

    // スタミナ回復速度
    private float _recoveryStamina = 0.1f;
    // スタミナの消費量
    private float _decreaseStamina = 0.01f;

    // スタミナバー
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        // シングルトンの呪文
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
        // ダッシュするとスタミナが徐々に減る
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

        // 回避するとスタミナを最大値の1/10減らす
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
