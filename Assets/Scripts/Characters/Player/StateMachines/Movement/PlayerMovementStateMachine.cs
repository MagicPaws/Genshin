namespace Genshin
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
        public Player Player { get;}
        /// <summary>
        /// 构造函数初始化
        /// </summary>
        /// <param name="player"></param>
        public PlayerMovementStateMachine(Player player)
        {
            IdlingState = new PlayeridlingState(this);
            WalkingState = new PlayerWalkingState(this);
            RunningState = new PlayerRunningState(this);
            SpringState = new PlayerSpringState(this);
            Player = player;
        }
    }
}