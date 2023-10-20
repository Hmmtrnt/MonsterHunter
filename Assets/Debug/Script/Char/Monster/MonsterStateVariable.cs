// モンスターのState変数

using UnityEngine;

public partial class MonsterState
{
    // 以下デバッグ用
    // 目標のプレイヤー
    private GameObject _Hunter;
    // 追従スピード
    private float _followingSpeed = 1;

    // 当たったオブジェクトのタグ取得
    private string _collisionTag = null;

    // デバッグ用ステータス
    // 体力
    private float _debagHitPoint = 1000;
    // 攻撃力
    private float _debagAttackPower = 50;

}
