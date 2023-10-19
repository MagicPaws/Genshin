using Genshin.Characters.Player.StateMachines.Movement.States.Grounded;
using Genshin.Characters.Player.StateMachines.Movement.States.Grounded.Moving;

namespace Genshin.Characters.Player.StateMachines.Movement
{
   public class PlayerMovementStateMachine : StateMachine
    {
        // 获取玩家静止状态
        public PlayeridlingState IdlingState { get; }
        // 获取玩家步行状态
        public PlayerWalkingState WalkingState { get; }
        // 获取玩家奔跑状态
        public PlayerRunningState RunningState { get; }
        // 获取玩家弹跳状态
        public PlayerSpringState SpringState { get; }

        /// <summary>
        /// 构造函数初始化
        /// </summary>
        public PlayerMovementStateMachine()
        {
            IdlingState = new PlayeridlingState();
            WalkingState = new PlayerWalkingState();
            RunningState = new PlayerRunningState();
            SpringState = new PlayerSpringState();
        }
    }
}