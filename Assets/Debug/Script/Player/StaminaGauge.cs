// �X�^�~�i�Q�[�W�̊Ǘ�.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaGauge : MonoBehaviour
{
    // �C���X�^���X
    public static StaminaGauge _instance;
    // �Q�[�W.
    private Image _gauge;
    // ���݂̃Q�[�W�̒���.
    private float _currentGauge;
    // ������̃Q�[�W�����



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
        // ���݂̃Q�[�W�̒����擾.
        _currentGauge = _gauge.fillAmount;

    }
}
