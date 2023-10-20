namespace Genshin
{
    /// <summary>
    /// 玩家静止时的状态
    /// </summary>
    public class PlayeridlingState : PlayerMovementState
    {
        public PlayeridlingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }
    }
}