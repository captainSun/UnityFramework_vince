using UnityEngine;

namespace Framework.Scripts
{
    public class RobotMoveController : MonoBehaviour
    {
        public float walkSpeed = 5f; // 行走速度
        public float runSpeed = 10f; // 奔跑速度
        public float rotationSpeed = 5f; //转向速度
        Animator animator;
        // 定义不同的状态枚举
        enum MovementState
        {
            Idle,
            Walking,
            Running,
        }

        MovementState currentState = MovementState.Idle;

        void Start()
        {
            animator = GetComponentInChildren<Animator>();
        }

        void Update()
        {
            // 根据输入更新当前状态
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                    currentState = MovementState.Running;
                else
                    currentState = MovementState.Walking;
            }
            else
            {
                currentState = MovementState.Idle;
            }

            // 根据当前状态切换动画
            switch (currentState)
            {
                case MovementState.Idle:
                    animator.SetBool("playWalking", false);
                    animator.SetBool("playRunning", false);
                    break;
                case MovementState.Walking:
                    animator.SetBool("playWalking", true);
                    animator.SetBool("playRunning", false);
                    break;
                case MovementState.Running:
                    animator.SetBool("playWalking", false);
                    animator.SetBool("playRunning", true);
                    break;
            }

            if (currentState != MovementState.Idle)
            {
                // // 根据输入计算移动
                // float moveHorizontal = Input.GetAxis("Horizontal");
                // float moveVertical = Input.GetAxis("Vertical");
                // Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;
                // float speed = currentState == MovementState.Walking ? walkSpeed : runSpeed;
                // transform.Translate(movement * Time.deltaTime * speed);
                // //
                // // 计算移动方向并调整角色的朝向
                // if (movement.magnitude > 0)
                // {
                //     Quaternion targetRotation = Quaternion.LookRotation(transform.TransformDirection(movement));
                //     transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                // }
                Vector2 direction = Vector2.zero;
                if (Input.GetKey(KeyCode.W))
                {
                    direction = new Vector2(0, 1);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    direction = new Vector2(0, -1);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    direction = new Vector2(1, 0);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    direction = new Vector2(-1, 0);
                }
                
                float speed = currentState == MovementState.Walking ? walkSpeed : runSpeed; //移动速度
                Vector3 pos = transform.position; //当前位置
                pos.x += (speed * direction.x * Time.deltaTime);
                pos.z += (speed * direction.y * Time.deltaTime);

                transform.LookAt(pos);
                transform.position = pos;
                
            }

        }
        
    }

    

}