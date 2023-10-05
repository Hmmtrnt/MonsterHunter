using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        #region ==== IState ====

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
        }

        void IState.OnStateBegin()
        {
            IsEndState = false;
        }
        void IState.OnStateEnd()
        {
            IsEndState = true;
        }
        void IState.Update(float deltaTime)
        {
            if (IsEndState) return;
            if(m_nextState != null)
            {
                (this as IState).ChangeState(m_nextState);
                return;
            }
        }

        void IState.SetNextState(IState nextState) { m_nextState = nextState; }
        IState IState.GetNextState() { return m_nextState; }

        #endregion // IState

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

        #region ====IState====

        StateType IState.GetCurrentState { get; } = StateType.RUNNING;
        bool IState.ChangeState(IState nextState)
        {
            IState state = this;
            state.OnStateEnd();
            if(nextState == null) return false;

            nextState.OnStateChanged();
            nextState.OnStateBegin();
        }

        #endregion// ====IState====
    }
}

public class PlayerStatePattern : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
