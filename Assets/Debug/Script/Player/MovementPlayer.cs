using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    // シングルトン
    public static MovementPlayer _inctance;

    private Camera _camera;
    private CharacterController _characterController;

    // ゲームパッドの左スティック入力状態
    private float _horizontalLeftStick = 0.0f;
    private float _verticalLeftStick = 0.0f;

    // 移動速度
    private float _moveSpeed = 0.0f;
    // 回避速度
    private float _avoidSpeed = 30.0f;

    // 重力
    private float _gravity = -15.0f;

    // 動く方向
    Vector3 _moveDirection = Vector3.zero;

    private Transform _transform;

    

    private void Awake()
    {
        if(_inctance == null)
        {
            _inctance = this;
        }
        else
        {
            Destroy(_inctance);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _camera = GameObject.Find("Camera").GetComponent<Camera>();
        // キャッシュしておく
        _transform = transform;
    }

    // 移動処理
    public void Movement()
    {
        // 左スティック情報取得
        _horizontalLeftStick = ControllerManager._inctance._LeftStickHorizontal;
        _verticalLeftStick = ControllerManager._inctance._LeftStickVertical;

        // カメラの正面ベクトル
        Vector3 cameraForward = Vector3.Scale(_camera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

        // カメラの向きでVectorの咆哮を変える
        Vector3 verticalDirection = cameraForward * _verticalLeftStick * _moveSpeed;// 前後
        Vector3 horizontalDirection = _camera.transform.right * _horizontalLeftStick * _moveSpeed;// 左右

        // ダッシュ
        if (Stamina._instance.GetCurrentLengthGauge() <= Stamina._instance.GetLastGauge() &&
           ControllerManager._inctance._RBButton)
        {
            _moveSpeed = 4.0f;
        }
        else if (ControllerManager._inctance._RBButton)
        {
            _moveSpeed = 15.0f;
        }
        else if (!ControllerManager._inctance._RBButton)
        {
            _moveSpeed = 7.0f;
        }

        // 重力
        _moveDirection.y = _gravity;

        // 移動する方向
        _moveDirection = verticalDirection + horizontalDirection + new Vector3(0.0f, _moveDirection.y, 0.0f);

        // 移動する向き
        transform.LookAt(_transform.position + verticalDirection + horizontalDirection);


        // 移動
        _characterController.Move(_moveDirection * Time.deltaTime);
    }

    // 回避処理
    public void Avoid()
    {
        _moveDirection.y = _gravity;
        _characterController.Move((_transform.forward + new Vector3(0.0f, _moveDirection.y, 0.0f)) * _avoidSpeed * Time.deltaTime);
    }
}
