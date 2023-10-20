using UnityEngine;

namespace Genshin
{
    /// <summary>
    /// 在本类中通过使用新输入系统中的数据重构
    /// 本类主要提供给Player类作为新输入系统的封装来使用
    /// </summary>
    public class PlayerInput : MonoBehaviour
    {
        //新输入系统
        public PlayerInputActions InputActions { get; private set; }

        //新输入系统中的PlayerActions的ActionMap
        public PlayerInputActions.PlayerActions PlayerActions { get; private set; }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Awake()
        {
            // 初始化新输入系统
            InputActions = new PlayerInputActions();
            // 初始化PlayerActions 内包含玩家输入映射信息
            PlayerActions = InputActions.Player;
        }

        /// <summary>
        /// 启用新输入系统
        /// 新输入系统必须调用Enable()启用
        /// </summary>
        private void OnEnable()
        {
            InputActions.Enable();
        }
        
        /// <summary>
        /// 禁用新输入系统
        /// </summary>
        private void OnDisable()
        {
            InputActions.Disable();
        }
    }
}