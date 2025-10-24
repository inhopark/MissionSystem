using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    // const
    private const float _moveSpeed = 5f;  // 이동 속도 설정
    private const float _rotationSpeed = 10f; // 회전 속도 조절
    private const float _followSpeed = 5f; // 카메라 추적 속도
    private const float _lookDownAngle = 45f;        // X축 기본 회전 각도

    private const string _defaultDebugMessage = "NPC 근처로 가세요.";

    [SerializeField]
    private TextMeshProUGUI _debugMessageUI = null;


    private Vector3 _offset = new Vector3(0f, 9f,-11f); // 카메라 위치 오프셋
    private Animator _animator = null;

    private void Start()
    {
        _animator = GetComponent<Animator>(); // Animator 컴포넌트 가져오기

        // 자식중 CheckCollision 있는지 체크후 Player를 넣어준다.
        PlayerCheckCollision checkCollision = transform.GetComponentInChildren<PlayerCheckCollision>();
        if(checkCollision != null)
        {
            checkCollision.SetPlayer(this);
        }

        // 초기 Debug 메세지 설정.
        if(_debugMessageUI != null)
        {
            _debugMessageUI.text = _defaultDebugMessage;
        }
    }

    private void Update()
    {
        // 입력값 받기 (WASD 또는 방향키)
        float moveX = Input.GetAxis("Horizontal"); // A, D or ←, →
        float moveZ = Input.GetAxis("Vertical");   // W, S or ↑, ↓

        // 이동 방향 벡터 계산
        Vector3 move = new Vector3(moveX, 0f, moveZ);

        // 애니메이션 상태 변경
        if (move.magnitude > 0f)  // 키를 누르고 있을 때
        {
            Move(move);

            PlayAnimation("Run");
        }
        else  // 아무 키도 안 눌렀을 때
        {
            PlayAnimation("Idle");
        }
    }

    // Player가 Update()에서 움직인 이후에 카메라가 따라오게 해서 부드럽게 동기화됩니다.
    private void LateUpdate()
    {
        // 카메라 위치 세팅
        Camera.main.transform.position = this.transform.position + _offset;

        // 항상 플레이어 바라보기
        Camera.main.transform.LookAt(this.transform);
    }

    private void Move(Vector3 targetPosition)
    {
        // 이동 방향을 바라보게 회전
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        // 실제 이동 처리
        transform.Translate(targetPosition * _moveSpeed * Time.deltaTime, Space.World);
    } 

    private void PlayAnimation(string animationName)
    {
        _animator.Play(animationName);
    }

    // NPC 가 컬리전에 충돌 했을 경우 처리.
    public void CheckCollisionTriggerEnter(Collider other)
    {
        if(_debugMessageUI != null)
        {
            other.transform.TryGetComponent<NPC>(out NPC npcComponent);
            if(npcComponent != null)
            {
                NPCDefine.NPCUnique npcUnique = npcComponent.GetNPCUnique();
                // Debug 용 UI에 표시.
                if(_debugMessageUI != null)
                {
                    _debugMessageUI.text = string.Format("{0}와 대화가 가능 합니다.", npcUnique.ToString());
                }
            }
        }
    }

}
