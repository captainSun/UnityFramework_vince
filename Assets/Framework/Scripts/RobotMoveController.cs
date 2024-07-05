using UnityEngine;

namespace Framework.Scripts
{
    public class RobotMoveController : MonoBehaviour
    {
        public float walkSpeed = 5f; // 行走速度
        public float runSpeed = 10f; // 奔跑速度
        Animator animator;
        private bool isChange = false;

        private CharacterController cc;
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
            cc = GetComponent<CharacterController>();
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
                float h = Input.GetAxis("Horizontal");
                float v = Input.GetAxis("Vertical");
               
                Quaternion CameraForward = Quaternion.Euler(0,Camera.main.transform.localRotation.eulerAngles.y,0);//相机正方向角度
                Vector3 inputDir = new Vector3(h, 0, v);// 输入的向量
                Vector3 targetDir = CameraForward * inputDir;// 移动方向
                float moveSpeed = currentState == MovementState.Walking ? walkSpeed : runSpeed; //移动速度
                Vector3 turnForward = Vector3.RotateTowards(transform.forward, targetDir, moveSpeed * Time.deltaTime, 0f);//转向角度
                
                cc.Move(targetDir * moveSpeed * Time.deltaTime);
                transform.Translate(targetDir * Time.deltaTime * moveSpeed,Space.World);
                transform.rotation = Quaternion.LookRotation(turnForward);

            }

        }
        
    }

    

}