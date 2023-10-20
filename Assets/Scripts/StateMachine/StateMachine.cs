namespace Genshin
{
    /// <summary>
    /// 状态机
    /// </summary>
    public abstract class StateMachine
    {
        protected IState currentState;
        
        /// <summary>
        /// 切换状态
        /// 退出当前状态,进入新状态
        /// </summary>
        /// <param name="newState">新状态</param>
        public void ChangeState(IState newState)
        {
            currentState?.Exit();
            
            currentState = newState;
            
            currentState.Enter();
        }
        
        /// <summary>
        /// 处理输入
        /// </summary>
       public void HandleInput()
        {
            currentState?.HandleInput();
        }
        
        /// <summary>
        /// 本状态的每帧调用
        /// </summary>
       public void Update()
       {
           currentState?.Update();
       }
        
        /// <summary>
        /// 本状态的物理帧调用
        /// </summary>
       public void PhysicsUpdate()
       {
           currentState?.PhysicsUpdate();
       }
    }
}