using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    private float x;
    private float y;
    private float z;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float dashSpeed;
    [SerializeField]
    private float acceleration = 15f;
    [SerializeField]
    private float deceleration = 20f;
    [SerializeField]
    private float jumpSpeed;

    private bool isDashing;
    private bool isJumping;
    private bool isGrounded;

    public float currentSpeed;

    [SerializeField]
    private LayerMask groundLayer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        float targetSpeed = isDashing ? dashSpeed : moveSpeed;

        if (x != 0 || z != 0)
        {
            Accelerate(targetSpeed);
        }
        else
            Decelerate();

        Move(x, z);

        if (isJumping)
        {
            isJumping = false;
            Jump();
        }
    }

    public void SetDash(bool dash)
    {
        isDashing = dash;
    }

    public void SetJump()
    {
        isJumping = true;
    }

    public void SetMoveInput(float x, float z)
    {
        this.x = x;
        this.z = z;
    }

    private void Move(float x, float z)
    {
        Vector3 Direction = new Vector3(x, 0, z).normalized;

        if (Direction.sqrMagnitude > 0.01f)
            transform.rotation = Quaternion.LookRotation(Direction);

        rb.MovePosition(
            rb.position + Direction * currentSpeed * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        if (!isGrounded)
            return;

        Vector3 velocity = rb.linearVelocity;
        velocity.y = jumpSpeed;
        rb.linearVelocity = velocity;

        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 플레이어가 Inspector 에서 선택한 Layer의 값을 받아둔다.
        // 충돌한 친구의 Layer의 번호가 6이라고 가정을 하면 1을 6으로 바꿔준다.
        // 만약 & 즉 겹치는게 없으면
        if ((groundLayer.value & (1 << collision.gameObject.layer)) == 0)
            return;

        // 유니티에서 충돌 시 값이 들어간다.
        foreach (ContactPoint contact in collision.contacts)
        {
            // 충돌한 면이 위쪽을 향하는지 확인
            if (contact.normal.y > 0.5f)
            {
                isGrounded = true;
                return;
            }
        }
    }

    private void Accelerate(float Speed)
    {
        currentSpeed = Mathf.MoveTowards(
            currentSpeed, Speed, acceleration * Time.fixedDeltaTime);
    }

    private void Decelerate()
    {
        currentSpeed = Mathf.MoveTowards(
            currentSpeed, 0, deceleration * Time.fixedDeltaTime);
    }
}
