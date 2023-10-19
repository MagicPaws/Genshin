using UnityEngine;

namespace Genshin.Characters.Player.Utilities.Input
{
    public class PlayerInput : MonoBehaviour
    {
        //新输入系统
        public PlayerInputActions InputActions { get; private set; }
        //新输入系统中的PlayerActions的ActionMap
        public PlayerInputActions.PlayerActions PlayerActions { get; private set; }
        
        private void Awake()
        {
            //初始化新输入系统
            InputActions = new PlayerInputActions();
            
            PlayerActions = InputActions.Player;
        }

        // 当启用时调用
        private void OnEnable()
        {
            // 启用输入动作
            InputActions.Enable();
        }

        // 当禁用时调用
        private void OnDisable()
        {
            // 禁用输入动作
            InputActions.Disable();
        }
    }


}