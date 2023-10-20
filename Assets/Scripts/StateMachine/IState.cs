namespace Genshin
{/// <summary>
 /// 包含了状态的基本方法
 /// </summary>
    public interface IState
    {
        /// <summary>
        /// 进入状态时调用
        /// </summary>
        public void Enter();
        
        /// <summary>
        /// 处理输入
        /// </summary>
        public void HandleInput();
        
        /// <summary>
        /// 退出状态时调用
        /// </summary>
        public void Exit();
        
        /// <summary>
        /// 本状态内每帧调用
        /// </summary>
        public void Update();
        
        
        /// <summary>
        /// 本状态内物理帧调用
        /// </summary>
        public void PhysicsUpdate();
    }
}
