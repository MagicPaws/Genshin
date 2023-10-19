using UnityEngine;
using UnityEngine.InputSystem;

namespace Genshin.Characters.Player.StateMachines.Movement.States
{
    public class PlayerMovementState : IState
    {
        protected PlayerMovementStateMachine stateMachine;
        //用于存储新输入系统的Vector2值
        protected Vector2 movementInput;
        protected float baseSpeed = 5.0f;
        protected float speedModifier = 1.0f;
        public PlayerMovementState(PlayerMovementStateMachine playerMovementStateMachine)
        {
            stateMachine = playerMovementStateMachine;
        }

        public PlayerMovementState()
        {
            
        }

        #region IState Methoods
        public virtual void Enter()
        {
            Debug.Log("状态： " + GetType().Name);
        }

        public virtual void HandleInput()
        {
            ReadMovementInput();
        }
        
        public virtual void Exit()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void PhysicsUpdate()
        {
            Move();
        }
        #endregion
        #region Main　Methods

        private void ReadMovementInput()
        {
            // 获取玩家的移动输入
            // Todo: 无法获取到输入信息
            movementInput = stateMachine.Player.Input.PlayerActions.Movement.ReadValue<Vector2>();
        }
        private void Move()
        {
            if (movementInput == Vector2.zero || speedModifier == 0f) return;
            
            Vector3 movementDirection = GetMovementInputDirection();
             
            float movementSpeed = GetMovementSpeed();
            
            Vector3 currentPlayerHorizontalVelocity = GetPlayerHorizontalVelocity();
            stateMachine.Player.Rigidbody.AddForce(movementSpeed * movementDirection  - currentPlayerHorizontalVelocity,ForceMode.VelocityChange);
            
        }

        private float GetMovementSpeed()
        {
            return baseSpeed * speedModifier;
        }

        #endregion

        #region Reusable Methoods
        protected Vector3 GetMovementInputDirection()
        {
            return new Vector3(movementInput.x, 0f, movementInput.y);
        }
        
        protected Vector3 GetPlayerHorizontalVelocity()
        {
            Vector3 playerHorizontalVelocity = stateMachine.Player.Rigidbody.velocity;

            playerHorizontalVelocity.y = 0f;
            return playerHorizontalVelocity;
        }
        #endregion
    }
}