using System;
using Genshin.Characters.Player.StateMachines.Movement;
using Genshin.Characters.Player.StateMachines.Movement.States;
using Genshin.Characters.Player.StateMachines.Movement.States.Grounded;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Genshin.Characters.Player
{
    [RequireComponent(typeof(PlayerInput))]
   public class Player : MonoBehaviour
    {
        private PlayerMovementStateMachine movementStateMachine;
        public PlayerInput Input{get;private set;}
        
        private void Awake()
        {
            // 创建一个玩家移动状态机
            movementStateMachine = new PlayerMovementStateMachine();
            // 获取玩家自身输入器
            Input = GetComponent<PlayerInput>();
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