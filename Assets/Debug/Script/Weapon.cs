using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // �f�o�b�O�p�ϐ�
    // ����I�u�W�F�N�g
    [SerializeField] private GameObject _weaponObject;
    // �e���ˈʒu�̃I�u�W�F�N�g
    [SerializeField] private GameObject _fireBulletObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �g���K�[�̓��͏�Ԏ擾
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
