// スタミナゲージの管理.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaGauge : MonoBehaviour
{
    // インスタンス
    public static StaminaGauge _instance;
    // ゲージ.
    private Image _gauge;
    // 現在のゲージの長さ.
    private float _currentGauge;
    // 回避時のゲージ消費量



    private void Awake()
    {
        if( _instance == null )
        {
            _instance = new ();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _gauge = GameObject.Find("StaminaGauge").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // 現在のゲージの長さ取得.
        _currentGauge = _gauge.fillAmount;

    }
}
