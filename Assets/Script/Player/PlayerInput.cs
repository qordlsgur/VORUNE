using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float moveX { get; private set; }
    public float moveZ { get; private set; }

    public bool sprintHeld;
    public bool jumpPressed;

    public bool backStep;
    public bool dashStep;

    void Update()
    {
        ReadMovementInput();
        Dash();
        Jump();
        ReadCombatInput();
        ReadDodgeInput();
    }

    private void ReadMovementInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (moveX == 0 && moveZ == 0)
            {
                backStep = true;
            }
            else
            {
                dashStep = true;
            }
        }

        sprintHeld = Input.GetKey(KeyCode.LeftShift);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            jumpPressed = true;
    }

    private void ReadCombatInput()
    {

    }

    private void ReadDodgeInput()
    {

    }
}
