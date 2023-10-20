namespace Genshin
{
    /// <summary>
    /// 玩家移动时的状态机
    /// </summary>
    public class PlayerMovementStateMachine : StateMachine
    {
        // 静止状态
        public PlayeridlingState IdlingState { get;}
        // 步行状态
        public PlayerWalkingState WalkingState { get;}
        // 奔跑状态
        public PlayerRunningState RunningState { get;}
        // 跳跃状态
        public PlayerSpringState SpringState { get;}
        public Player Player { get; }
        
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