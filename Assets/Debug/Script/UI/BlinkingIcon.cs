/*�A�C�R���̓_��*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingIcon : MonoBehaviour
{
    // ���Ă͂߂�A�C�R��
    private GameObject[] _images = new GameObject[2];
    // �\������Ă��邩�ǂ���
    private bool[] _isActive = new bool[2] {true, false};
    // �_�ł��鎞�Ԃ̃^�C�~���O
    private int _blinkingTime = 120;
    // ���݂̓_�ł��鎞��
    private int _blinkingCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        _images[0] = GameObject.Find("WeponIcom");
        _images[1] = GameObject.Find("DiscoveryIcom");


    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        _blinkingCount++;

        

        //for(int i = 0; i < _images.Length; i++)
        //{
        //}
        //_images[0].SetActive(_isActive[0]);
        //_images[1].SetActive(_isActive[1]);
        //if (_blinkingCount >= _blinkingTime) return;

        //for(int i =0; i < _isActive.Length; i++)
        //{
        //    if(_isActive[i])
        //    {
        //        _isActive[i] = false;
        //    }
        //    else
        //    {
        //        _isActive[i] = true;
        //    }
        //}

        //_blinkingCount = 0;
    }
}
