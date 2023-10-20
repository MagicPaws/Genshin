using UnityEngine;

namespace Genshin
{
    /// <summary>
    /// 本类用于挂载在玩家上
    /// 使用状态机和输入系统
    /// </summary>
    [RequireComponent(typeof(PlayerInput))]
   public class Player : MonoBehaviour
    {
        private PlayerMovementStateMachine movementStateMachine;
        public PlayerInput Input{get;private set;}
        public Rigidbody Rigidbody { get; private set; }
        
        /// <summary>
        /// 初始化
        /// </summary>
        private void Awake()
        {
            // 创建 玩家移动状态机
            movementStateMachine = new PlayerMovementStateMachine(this);
            // 获取 封装后的输入系统
            Input = GetComponent<PlayerInput>();
            // 获取 刚体
            Rigidbody = GetComponent<Rigidbody>();
        }
        
        private void Start()
        {
            // 初始化状态为空闲
            movementStateMachine.ChangeState(movementStateMachine.IdlingState);
        }
        
        private void Update()
        {
            // 更新状态机输入
            movementStateMachine.HandleInput();
            // 更新状态机状态
            movementStateMachine.Update();
        }
        
        private void FixedUpdate()
        {
            // 更新物理状态机状态
            movementStateMachine.PhysicsUpdate();
        }
    }
}