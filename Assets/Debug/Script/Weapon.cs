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

    [SerializeField] private float _bulletSpeed;

    // 弾数
    [SerializeField] private int _bulletNumber;

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


        if (!Player._instance._isHoldWeapon) return;
        // 弾発射
        if(testTrigger >= 0.5)
        {
            if (_isGenerated || _bulletNumber == 0) return;
            disappearBullet();
            _bulletNumber -= 1;
            _isGenerated = true;
        }
        else if(testTrigger == 0)
        {
            _isGenerated=false;
        }

        if(Input.GetKeyDown("joystick button 3"))
        {
            _bulletNumber = 6;
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
        // 弾の発射位置
        Vector3 firePos = _fireBulletPositionObject.transform.position;
        // 発射位置に弾を生成
        GameObject newBullet = Instantiate(_bulletObject, firePos, transform.rotation);

        // 出現させたボールのz軸方向
        Vector3 direction = newBullet.transform.forward;
        // 弾の発射方向に発射
        newBullet.GetComponent<Rigidbody>().AddForce(direction * _bulletSpeed, ForceMode.Impulse);

        // 出現したボールを消去
        Destroy(newBullet, 1.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
    }
}
