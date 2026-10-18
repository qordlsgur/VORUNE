using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void UpdateMovementAnimation(float Speed)
    {
        animator.SetFloat("MoveSpeed", Speed);
    }

    public void UpdateDirection(float x, float z)
    {
        animator.SetFloat("PosX", x);
        animator.SetFloat("PosY", z);
    }
}
