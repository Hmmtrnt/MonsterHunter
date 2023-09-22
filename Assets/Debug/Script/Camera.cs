// 三人称視点のカメラ処理

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // プレイヤーオブジェクト
    [SerializeField] private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 右スティックの入力状態
        float horizontal = Input.GetAxis("Horizontal2");
        float vertical = Input.GetAxis("Vertical2");

        // Y軸回転
        if(Mathf.Abs(horizontal) > 0.1f)
        {
            transform.RotateAround(_player.transform.position, Vector3.up, horizontal);
        }
        // X軸回転
        if(Mathf.Abs(vertical) > 0.1f)
        {
            transform.RotateAround(_player.transform.position, transform.right, vertical);
        }
    }
}
