using UnityEngine;
namespace Genshin
{
    /// <summary>
    /// 玩家移动时的状态基类
    /// </summary>
    public class PlayerMovementState : IState
    {
        //玩家移动状态机
        protected PlayerMovementStateMachine stateMachine;
        
        //用于存储新输入系统的Vector2值
        protected Vector2 movementInput;
        
        //用于存储新输入系统的速度标量
        protected float baseSpeed = 5.0f;
        
        //用于存储新输入系统的速度倍率
        protected float speedModifier = 1.0f;
        
        /// <summary>
        /// 有参构造函数
        /// 传入一个PlayerMovementState,用于初始化
        /// </summary>
        /// <param name="playerMovementStateMachine">用于初始化的PlayerMovementState</param>
        public PlayerMovementState(PlayerMovementStateMachine playerMovementStateMachine)
        {
            stateMachine = playerMovementStateMachine;
        }
        
// 以下为IState接口的实现
// 标记为虚函数方便子类继续重写
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

// 以下为本状态的方法
#region Main　Methods
        /// <summary>
        /// 获取新输入系统中的玩家输入Vector2，并存储在movementInput中
        /// </summary>
        private void ReadMovementInput()
        {
            movementInput = stateMachine.Player.Input.PlayerActions.Movement.ReadValue<Vector2>();
        }
        
        /// <summary>
        /// 玩家移动时的逻辑
        /// 通过新输入系统获取移动的水平面方向,通过对刚体施加力来移动
        /// </summary>
        private void Move()
        {
            // 如果玩家没有输入或者速度倍率为0，那么不进行移动 早返回
            if (movementInput == Vector2.zero || speedModifier == 0f) return;
            
            Vector3 movementDirection = GetMovementInputDirection();

            float movementSpeed = GetMovementSpeed();

            Vector3 currentPlayerHorizontalVelocity = GetPlayerHorizontalVelocity();
            //通过对刚体施加力的方式移动玩家
            stateMachine.Player.Rigidbody.AddForce(movementSpeed * movementDirection - currentPlayerHorizontalVelocity, ForceMode.VelocityChange);
        }
#endregion

// 以下为可复用的方法
#region Reusable Methoods
        /// <summary>
        /// 获取玩家输入的移动方向
        /// 通过获取新输入系统中的Vector2来决定移动方向
        /// </summary>
        /// <returns> 返回水平面方向 </returns>
        protected Vector3 GetMovementInputDirection()
        {
            return new Vector3(movementInput.x, 0f, movementInput.y);
        }
        
        /// <summary>
        /// 获取玩家水平面速度
        /// </summary>
        /// <returns> 返回水平面的速度 </returns>
        protected Vector3 GetPlayerHorizontalVelocity()
        {
            //通过刚体的速度获取玩家的速度，然后将y轴速度置为0，得到玩家的水平面速度
            Vector3 playerHorizontalVelocity = stateMachine.Player.Rigidbody.velocity;
            playerHorizontalVelocity.y = 0f;
            
            return playerHorizontalVelocity;
        }
        
        /// <summary>
        /// 获取玩家速度标量
        /// </summary>
        /// <returns> 返回基础速度与速度倍率的积 </returns>
        private float GetMovementSpeed()
        {
            return baseSpeed * speedModifier;
        }
#endregion
    }
}