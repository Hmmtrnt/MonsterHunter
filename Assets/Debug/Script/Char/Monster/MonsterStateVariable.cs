// モンスターのState変数

using UnityEngine;

public partial class MonsterState
{
    // 以下デバッグ用
    // 目標のプレイヤー
    private GameObject _hunter;
    private Transform _trasnform;
    private Rigidbody _rigidbody;
    private PlayerState _state;

    // 追従スピード
    private float _followingSpeed = 1;

    // 当たったオブジェクトのタグ取得
    private string _collisionTag = null;

    // デバッグ用ステータス
    // 体力
    private float _debagHitPoint = 300;
    // 攻撃力
    private float _debagAttackPower = 50;

    // デバッグ用攻撃判定
    private GameObject _debugAttackCol;
    // デバッグ用攻撃判定を生成するかどうか
    private bool _indicateAttackCol = false;

}
