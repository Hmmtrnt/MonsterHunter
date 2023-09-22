// �O�l�̎��_�̃J��������

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // �v���C���[�I�u�W�F�N�g
    [SerializeField] private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �E�X�e�B�b�N�̓��͏��
        float horizontal = Input.GetAxis("Horizontal2");
        float vertical = Input.GetAxis("Vertical2");

        // Y����]
        if(Mathf.Abs(horizontal) > 0.1f)
        {
            transform.RotateAround(_player.transform.position, Vector3.up, horizontal);
        }
        // X����]
        if(Mathf.Abs(vertical) > 0.1f)
        {
            transform.RotateAround(_player.transform.position, transform.right, vertical);
        }
    }
}
