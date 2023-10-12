using StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace StatePattern
{
    public enum StateType
    {
        NONE,       // 無し
        IDLE,       // アイドル
        RUNNING,    // ランニング
        DASH,       // ダッシュ
        AVOID,      // 回避
    }

    public interface IState
    {
        StateType GetCurrentState { get; }
        // 次の状態へ
        bool ChangeState(IState nextState);

        // HACK:↓全部勘で書いているため後でコメント直す
        // 次の状態へ移行するとき
        void OnStateChanged();
        // 状態のはじめ
        void OnStateBegin();
        // 状態の終了
        void OnStateEnd();
        // 更新処理
        void Update(float deltaTime);
        // 次の状態をセット
        void SetNextState(IState nextState);
        IState GetNextState();
    }

    public class IdleState : IState
    {
        private IState m_nextState = null;
        public bool IsEndState { get; private set; } = false;

        StateType IState.GetCurrentState { get; } = StateType.IDLE;

        bool IState.ChangeState(IState nextState)
        {
            IState state = this;
            state.OnStateEnd();
            if (nextState == null) return false;

            nextState.OnStateChanged();
            nextState.OnStateBegin();

            return true;
        }

        void IState.OnStateChanged()
        {
            // 初期化
            Debug.Log("アイドルチェンジ");
        }

        void IState.OnStateBegin()
        {
            IsEndState = false;
            Debug.Log("アイドルはじめ");
        }
        void IState.OnStateEnd()
        {
            IsEndState = true;
            Debug.Log("アイドル終了");
        }
        void IState.Update(float deltaTime)
        {
            Debug.Log("アイドル");
            if (IsEndState) return;
            if(m_nextState != null)
            {
                (this as IState).ChangeState(m_nextState);
                return;
            }
        }

        void IState.SetNextState(IState nextState) { m_nextState = nextState; }
        IState IState.GetNextState() { return m_nextState; }

    }

    public class MoveState : IState
    {
        // なんやこれ
        protected Transform m_moveTarget = null;
        // 多分移動方向
        protected Vector3 m_moveDestination = Vector3.zero;
        // 多分移動スピード
        protected float m_moveSpeed = 0.0f;
        // 多分次のSate
        private IState m_nextState = null;
        // 多分Stateの終了
        public bool IsEndState { get; private set; } = false;

        StateType IState.GetCurrentState { get; } = StateType.RUNNING;
        bool IState.ChangeState(IState nextState)
        {
            Debug.Log("CangeState");
            IState state = this;
            state.OnStateEnd();
            if(nextState == null) return false;

            nextState.OnStateChanged();
            nextState.OnStateBegin();
            return true;
        }

        void IState.OnStateChanged()
        {
            // Initialize
            Debug.Log("走るチェンジ");
        }
        void IState.OnStateBegin() 
        {
            IsEndState = false;
            Debug.Log("走るはじめ");
        }
        void IState.OnStateEnd()
        {
            IsEndState = true;
            Debug.Log("走る終了");
        }
        void IState.Update(float deltaTime) 
        {
            Debug.Log("走る");

            if (IsEndState) return;
            if(m_nextState != null)
            {
                (this as IState).ChangeState(m_nextState);
                return;
            }

            // 左スティック情報取得
            //_horizontalLeftStick = ControllerManager._inctance._LeftStickHorizontal;
            //_verticalLeftStick = ControllerManager._inctance._LeftStickVertical;

            //// カメラの正面ベクトル
            //Vector3 cameraForward = Vector3.Scale(_camera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

            //// カメラの向きでVectorの咆哮を変える
            //Vector3 verticalDirection = cameraForward * _verticalLeftStick * _moveSpeed;// 前後
            //Vector3 horizontalDirection = _camera.transform.right * _horizontalLeftStick * _moveSpeed;// 左右

            //// ダッシュ
            //if (Stamina._instance.GetCurrentLengthGauge() <= Stamina._instance.GetLastGauge() &&
            //   ControllerManager._inctance._RBButton)
            //{
            //    _moveSpeed = 4.0f;
            //}
            //else if (ControllerManager._inctance._RBButton)
            //{
            //    _moveSpeed = 15.0f;
            //}
            //else if (!ControllerManager._inctance._RBButton)
            //{
            //    _moveSpeed = 7.0f;
            //}

            //// 重力
            //_moveDirection.y = _gravity;

            //// 移動する方向
            //_moveDirection = verticalDirection + horizontalDirection + new Vector3(0.0f, _moveDirection.y, 0.0f);

            //// 移動する向き
            //transform.LookAt(_transform.position + verticalDirection + horizontalDirection);


            //// 移動
            //_characterController.Move(_moveDirection * Time.deltaTime);


            //if (m_moveTarget == null) return;
            //Vector3 currentPosition = m_moveTarget.position;
            //Vector3 moveVec = (m_moveDestination - currentPosition).normalized;
            //m_moveTarget.position = currentPosition + moveVec * (m_moveSpeed * deltaTime);

        }

        void IState.SetNextState(IState nextState) { m_nextState = nextState; }
        IState IState.GetNextState() {  return m_nextState; }


        public void SetTarget(Transform target, Vector3 destination, float speedPerSec)
        {
            m_moveTarget = target;
            m_moveDestination = destination;
            m_moveSpeed = speedPerSec;
        }
    }
}

public class PlayerStatePattern : MonoBehaviour
{
    private IState currentState = new IdleState();

    // ゲームパッドの入力状態
    private float _horizontalLeftStick;
    private float _verticalLeftStick;

    // Start is called before the first frame update
    void Start()
    {
        currentState.OnStateChanged();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalLeftStick = ControllerManager._inctance._LeftStickHorizontal;
        _verticalLeftStick = ControllerManager._inctance._LeftStickVertical;

        currentState.Update(Time.deltaTime);
        //Debug.Log("あ");

        if(_horizontalLeftStick != 0 ||
            _verticalLeftStick != 0)
        {
            Debug.Log("チェンジ");
            currentState = new MoveState();
        }
    }
}
