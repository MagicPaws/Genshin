using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Genshin
{
    public interface IState
    {
        // 进入状态
        public void Enter();
        // 处理输入
        public void HandleInput();
        // 退出状态
        public void Exit();
        // 更新状态
        public void Update();
        // 物理更新
        public void PhysicsUpdate();
    }
}
