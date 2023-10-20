namespace Genshin
{
    /// <summary>
    /// 玩家跑动时的状态
    /// </summary>
    public class PlayerRunningState : PlayerMovementState
    {
        public PlayerRunningState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }
    }
}