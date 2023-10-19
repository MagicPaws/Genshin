using UnityEngine;

namespace Genshin
{
    public abstract class StateMachine
    {
        protected IState currentState;
        
        /// <summary>
        /// 退出当前状态，进入新状态
        /// </summary>
        /// <param name="newState">新状态</param>
        public void ChangeState(IState newState)
        {
            currentState?.Exit();
            
            currentState = newState;
            
            currentState.Enter();
        }
        
       public void HandleInput()
        {
            //调用当前状态的输入处理函数
            currentState?.HandleInput();
        }
       public void Update()
       {
           //调用当前状态的更新函数
           currentState?.Update();
       }
       public void PhysicsUpdate()
       {
           //调用当前状态的物理更新函数
           currentState?.PhysicsUpdate();
       }
    }
}