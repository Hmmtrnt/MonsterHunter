// モンスターのState変数

using UnityEngine;
using UnityEngine.UI;

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

    // 以下デバッグ用

    // デバッグ用ステータス
    // 体力
    private float _debagHitPoint = 300;
    // 攻撃力
    private float _debagAttackPower = 1;

    // デバッグ用攻撃判定
    private GameObject _debugAttackCol;
    // デバッグ用攻撃判定を生成するかどうか
    private bool _indicateAttackCol = false;

    
    private LineRenderer _line;

    // デバッグ用テキスト
    private Text _text;

}
