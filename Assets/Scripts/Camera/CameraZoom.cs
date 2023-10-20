using Cinemachine;
using UnityEngine;

namespace Genshin
{
    /// <summary>
    /// 通过滚轮控制相机距离
    /// </summary>
    public class CameraZoom : MonoBehaviour
    {
        // 默认距离
        [SerializeField] [Range(0f, 10f)] private float defaultDistance = 6f;
        // 最小距离
        [SerializeField] [Range(0f, 10f)] private float minDistance = 1f;
        // 最大距离
        [SerializeField] [Range(0f, 10f)] private float maxDistance = 6f;
        // 平滑度
        [SerializeField] [Range(0f, 10f)] private float smoothing = 4f;
        // 缩放灵敏度
        [SerializeField] [Range(0f, 10f)] private float zoomSensitivity = 3f;
        // 相机位移器
        private CinemachineFramingTransposer framingTransposer;
        // 相机输入提供者组件
        private CinemachineInputProvider InputProvider;
        // 当前目标距离
        private float currentTargetDistance;

        private void Awake()
        {
            // 获取相机位移器
            framingTransposer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>();

            // 获取相机输入提供者
            InputProvider = GetComponent<CinemachineInputProvider>();

            // 设置当前目标距离
            currentTargetDistance = defaultDistance;
        }

        private void Update()
        {
            Zoom();
        }

        /// <summary>
        /// 缩放
        /// </summary>
        private void Zoom()
        {
            // 获取缩放值
            float zoomValue = InputProvider.GetAxisValue(2) * zoomSensitivity;
            // 设置当前目标距离,并限制大小
            currentTargetDistance = Mathf.Clamp(currentTargetDistance+ zoomValue,minDistance, maxDistance);
            // 获取相机距离
            float currentDistance = framingTransposer.m_CameraDistance;
            // 若已到达目标距离 则不再移动相机
            if (currentDistance == currentTargetDistance)
            {
                return;
            }
            // 计算当前距离和目标距离之间的插值
            float lerpedZoomValue = Mathf.Lerp(currentDistance, currentTargetDistance, smoothing * Time.deltaTime);
            // 将插值赋值给framingTransposer的m_CameraDistance
            framingTransposer.m_CameraDistance = lerpedZoomValue;
        }
    }
}