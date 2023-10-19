using UnityEngine;

namespace Genshin
{
    [RequireComponent(typeof(PlayerInput))]
   public class Player : MonoBehaviour
    {
        private PlayerMovementStateMachine movementStateMachine;
        public PlayerInput Input{get;private set;}
        public Rigidbody Rigidbody { get; private set; }
        private void Awake()
        {
            // 创建一个玩家移动状态机
            movementStateMachine = new PlayerMovementStateMachine(this);
            // 获取玩家自身输入器
            Input = GetComponent<PlayerInput>();
            // 获取自身刚体
            Rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            // 开始时，将状态机设置为空闲状态
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