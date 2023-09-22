using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    // リジットボディ
    private Rigidbody _rigidbody;

    // 移動速度
    [SerializeField] private Vector3 _velocity;
    // 入力値
    private Vector3 _input;

    // 地面と判定するレイヤーマスク
    [SerializeField] private LayerMask _groundLayers;

    // 速さ
    [SerializeField] private float _speed = 4.0f;

    // 接地しているかどうか
    [SerializeField] private bool _ifGrounded;

    // 接地確認のコライダの位置のオフセット
    [SerializeField] private Vector3 _groundPositionOffset = new Vector3(0.0f, 0.02f, 0.0f);
    // 接地確認の球のコライダの半径
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
