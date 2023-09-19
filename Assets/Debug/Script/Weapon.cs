using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // デバッグ用変数
    // 武器オブジェクト
    [SerializeField] private GameObject _weaponObject;
    // 弾発射位置のオブジェクト
    [SerializeField] private GameObject _fireBulletPositionObject;
    // 弾
    [SerializeField] private GameObject _bulletObject;

    // 弾が消える時間
    private float _disappearBulletTime;

    // 生成したかどうか
    private bool _isGenerated;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // トリガーの入力状態取得
        float testTrigger = Input.GetAxis("L_R_Trigger");

        disappearBullet();


        if (!Player._instance._isHoldWeapon) return;
        // 弾発射
        if(testTrigger >= 0.5)
        {
            if (_isGenerated) return;
            Instantiate(_bulletObject, _fireBulletPositionObject.transform.position, Quaternion.identity);
            _isGenerated = true;
        }
        else if(testTrigger == 0)
        {
            _isGenerated=false;
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


    private void disappearBullet()
    {
        // 消える時間をカウント中
        _disappearBulletTime = Time.deltaTime;

        Debug.Log(_disappearBulletTime);

        if(_disappearBulletTime >= 5)
        {
            Destroy(_bulletObject);
            _disappearBulletTime=0;
        }
    }
}
