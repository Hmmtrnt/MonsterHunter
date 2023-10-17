// プレイヤーの変数.

using UnityEngine;

public partial class PlayerState
{
    // コントローラーの入力情報
    ControllerManager _input;

    // プレイヤーのステータス.
    // 体力.
    private int _HitPoint = 200;
    // スタミナ.
    private int _Stamina = 200;
    // 攻撃力.
    private float _AttackPower = 100;

    // モーション値.
    private float _MotionValue = 0;

    // Rigidbody.
    private Rigidbody _rigidbody;

    // 納刀抜刀を確認するデバッグ用オブジェクト.
    private GameObject _debagObject;

    

    // transformをキャッシュ.
    private Transform _transform;
    // カメラ.
    private Camera _camera;
    // カメラの正面.
    private Vector3 _cameraForward;

    /*コントローラー変数*/
    // 左スティックの入力情報.
    private float _leftStickHorizontal;
    private float _leftStickVertical;

    // 抜刀状態
    // true :抜刀.
    // false:納刀.
    private bool _UnsheathedSword = false;

    // 現在の攻撃のモーション値.
    private int _currentAttackMotionValue = 0;
    // 最大攻撃のモーション値.
    private int _maxAttackMotionValue = 0;

    // 攻撃判定.

    /*アイドル状態時の変数*/


    /*移動時の変数*/
    // 移動方向.
    private Vector3 _moveDirection;
    // 走る時の移動倍率.
    private float _moveVelocityRunMagnification = 12;
    // ダッシュ時の移動倍率.
    private float _moveVelocityDashMagnigication = 20;
    // 移動速度倍率.
    private float _moveVelocityMagnification = 12;
    // 回復しながらの移動倍率.
    private float _moveVelocityRecoveryMagnification = 10;

    // 移動速度.
    private Vector3 _moveVelocity = new(0.0f, 0.0f, 0.0f);
    // ダッシュしているかどうか.
    private bool _isDashing = false;
    // 重力.
    private float _gravity = -10.0f;

    /*回避時の変数*/
    // 回避速度倍率.
    private float _avoidVelocityMagnification = 30;
    // 回避速度.
    private Vector3 _avoidVelocity = new(0.0f, 0.0f, 0.0f);
    // 現在の回避フレーム.
    private int _avoidTime = 0;
    // 最大回避フレーム.
    private int _avoidMaxTime = 30;
    // 回避しているかどうか.
    private bool _isAvoiding = false;

    /*回復*/
    // 回復しているかどうか.
    private bool _isRecovery = false;
    // 現在の回復時間.
    private int _currentRecoveryTime = 0;
    // 最大回復時間.
    private int _maxRecoveryTime = 200;
}