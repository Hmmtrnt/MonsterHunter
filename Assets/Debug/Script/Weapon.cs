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

    [SerializeField] private float _bulletSpeed;

    // �e��
    [SerializeField] private int _bulletNumber;

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


        if (!Player._instance._isHoldWeapon) return;
        // �e����
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
        // �e�̔��ˈʒu
        Vector3 firePos = _fireBulletPositionObject.transform.position;
        // ���ˈʒu�ɒe�𐶐�
        GameObject newBullet = Instantiate(_bulletObject, firePos, transform.rotation);

        // �o���������{�[����z������
        Vector3 direction = newBullet.transform.forward;
        // �e�̔��˕����ɔ���
        newBullet.GetComponent<Rigidbody>().AddForce(direction * _bulletSpeed, ForceMode.Impulse);

        // �o�������{�[��������
        Destroy(newBullet, 1.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
    }
}
