using UnityEngine;

namespace Framework.Scripts
{
    using UnityEngine;

    public class ThirdPersonCamera : MonoBehaviour
    {
        public Transform target; // 跟随的目标物体
        public float distance = 5.0f; // 摄像机与目标的距离
        public float height = 3.0f; // 摄像机距离目标的高度
        public float rotationDamping = 2.0f; // 摄像机旋转的阻尼系数
        public float heightDamping = 2.0f; // 摄像机高度的阻尼系数
        public float rotationSpeed = 2.0f; // 摄像机旋转速度

        private float currentRotationAngle = 0.0f;

        void LateUpdate()
        {
            // 如果目标不存在，则退出
            if (!target)
                return;

            // 计算目标的旋转角度
            float wantedRotationAngle = target.eulerAngles.y;
            float wantedHeight = target.position.y + height;

            // 计算当前摄像机的高度
            float currentHeight = transform.position.y;

            // 计算摄像机的平滑高度
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

            // 计算目标的旋转差值
            float rotationDiff = wantedRotationAngle - currentRotationAngle;

            // 计算摄像机的旋转角度
            currentRotationAngle += rotationDiff * rotationSpeed * Time.deltaTime;

            // 将欧拉角转换为旋转
            Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            // 设置摄像机的位置和旋转
            transform.position = target.position - currentRotation * Vector3.forward * distance;
            transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

            // 使摄像机始终面向目标
            transform.LookAt(target);
        }
    }

}