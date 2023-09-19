using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // �f�o�b�O�p�ϐ�
    // ����I�u�W�F�N�g
    [SerializeField] private GameObject _weaponObject;
    // �e���ˈʒu�̃I�u�W�F�N�g
    [SerializeField] private GameObject _fireBulletPositionObject;
    // �e
    [SerializeField] private GameObject _bulletObject;

    // �e�������鎞��
    private float _disappearBulletTime;

    // �����������ǂ���
    private bool _isGenerated;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // �g���K�[�̓��͏�Ԏ擾
        float testTrigger = Input.GetAxis("L_R_Trigger");

        disappearBullet();


        if (!Player._instance._isHoldWeapon) return;
        // �e����
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
        // �����鎞�Ԃ��J�E���g��
        _disappearBulletTime = Time.deltaTime;

        Debug.Log(_disappearBulletTime);

        if(_disappearBulletTime >= 5)
        {
            Destroy(_bulletObject);
            _disappearBulletTime=0;
        }
    }
}
