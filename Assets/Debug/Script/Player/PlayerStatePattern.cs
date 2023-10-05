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
            Debug.Log("�A�C�h���`�F���W");
        }

        void IState.OnStateBegin()
        {
            IsEndState = false;
            Debug.Log("�A�C�h���͂���");
        }
        void IState.OnStateEnd()
        {
            IsEndState = true;
            Debug.Log("�A�C�h���I��");
        }
        void IState.Update(float deltaTime)
        {
            Debug.Log("�A�C�h��");
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
            Debug.Log("����`�F���W");
        }
        void IState.OnStateBegin() 
        {
            IsEndState = false;
            Debug.Log("����͂���");
        }
        void IState.OnStateEnd()
        {
            IsEndState = true;
            Debug.Log("����I��");
        }
        void IState.Update(float deltaTime) 
        {
            Debug.Log("����");

            if (IsEndState) return;
            if(m_nextState != null)
            {
                (this as IState).ChangeState(m_nextState);
                return;
            }

            // ���X�e�B�b�N���擾
            //_horizontalLeftStick = ControllerManager._inctance._LeftStickHorizontal;
            //_verticalLeftStick = ControllerManager._inctance._LeftStickVertical;

            //// �J�����̐��ʃx�N�g��
            //Vector3 cameraForward = Vector3.Scale(_camera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

            //// �J�����̌�����Vector�̙��K��ς���
            //Vector3 verticalDirection = cameraForward * _verticalLeftStick * _moveSpeed;// �O��
            //Vector3 horizontalDirection = _camera.transform.right * _horizontalLeftStick * _moveSpeed;// ���E

            //// �_�b�V��
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

            //// �d��
            //_moveDirection.y = _gravity;

            //// �ړ��������
            //_moveDirection = verticalDirection + horizontalDirection + new Vector3(0.0f, _moveDirection.y, 0.0f);

            //// �ړ��������
            //transform.LookAt(_transform.position + verticalDirection + horizontalDirection);


            //// �ړ�
            //_characterController.Move(_moveDirection * Time.deltaTime);


            //if (m_moveTarget == null) return;
            //Vector3 currentPosition = m_moveTarget.position;
            //Vector3 moveVec = (m_moveDestination - currentPosition).normalized;
            //m_moveTarget.position = currentPosition + moveVec * (m_moveSpeed * deltaTime);

        }

        void IState.SetNextState(IState nextState) { m_nextState = nextState; }
        IState IState.GetNextState() {  return m_nextState; }

        #endregion// ====IState====

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

    // �Q�[���p�b�h�̓��͏��
    private float _horizontalLeftStick;
    private float _verticalLeftStick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalLeftStick = ControllerManager._inctance._LeftStickHorizontal;
        _verticalLeftStick = ControllerManager._inctance._LeftStickVertical;

        currentState.Update(Time.deltaTime);
        //Debug.Log("��");

        if(_horizontalLeftStick != 0 ||
            _verticalLeftStick != 0)
        {
            Debug.Log("�`�F���W");
            //currentState.SetNextState(MoveState);
        }
    }
}
