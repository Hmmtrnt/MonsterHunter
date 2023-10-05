using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{
    public enum StateType
    {
        NONE,       // ����
        IDLE,       // �A�C�h��
        RUNNING,    // �����j���O
        DASH,       // �_�b�V��
        AVOID,      // ���
    }

    public interface IState
    {
        StateType GetCurrentState { get; }
        // ���̏�Ԃ�
        bool ChangeState(IState nextState);

        // HACK:���S�����ŏ����Ă��邽�ߌ�ŃR�����g����
        // ���̏�Ԃֈڍs����Ƃ�
        void OnStateChanged();
        // ��Ԃ̂͂���
        void OnStateBegin();
        // ��Ԃ̏I��
        void OnStateEnd();
        // �X�V����
        void Update(float deltaTime);
        // ���̏�Ԃ��Z�b�g
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
            // ������
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
        // �Ȃ�₱��
        protected Transform m_moveTarget = null;
        // �����ړ�����
        protected Vector3 m_moveDestination = Vector3.zero;
        // �����ړ��X�s�[�h
        protected float m_moveSpeed = 0.0f;
        // ��������Sate
        private IState m_nextState = null;
        // ����State�̏I��
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
