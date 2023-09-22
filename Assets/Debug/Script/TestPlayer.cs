using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    // ���W�b�g�{�f�B
    private Rigidbody _rigidbody;

    // �ړ����x
    [SerializeField] private Vector3 _velocity;
    // ���͒l
    private Vector3 _input;

    // �n�ʂƔ��肷�郌�C���[�}�X�N
    [SerializeField] private LayerMask _groundLayers;

    // ����
    [SerializeField] private float _speed = 4.0f;

    // �ڒn���Ă��邩�ǂ���
    [SerializeField] private bool _ifGrounded;

    // �ڒn�m�F�̃R���C�_�̈ʒu�̃I�t�Z�b�g
    [SerializeField] private Vector3 _groundPositionOffset = new Vector3(0.0f, 0.02f, 0.0f);
    // �ڒn�m�F�̋��̃R���C�_�̔��a
    [SerializeField] private float groundColliderRadius = 0.29f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
