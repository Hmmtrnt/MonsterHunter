using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // デバッグ用変数
    // 武器オブジェクト
    [SerializeField] private GameObject _weaponObject;
    // 弾発射位置のオブジェクト
    [SerializeField] private GameObject _fireBulletObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // トリガーの入力状態取得
        float testTrigger = Input.GetAxis("L_R_Trigger");

        if(testTrigger != 0)
        {

        }

    }

    private void FixedUpdate()
    {
        if(Player._instance._isHoldWeapon)
        {
            _weaponObject.SetActive(true);
        }
        else if(!Player._instance._isHoldWeapon)
        {
            _weaponObject.SetActive(false);
        }
        
    }
}
