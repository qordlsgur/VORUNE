using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float moveX { get; private set; }
    public float moveZ { get; private set; }

    public bool sprintHeld;
    public bool jumpPressed;

    void Update()
    {
        Dash();
        Jump();
        ReadMovementInput();
        ReadCombatInput();
        ReadDodgeInput();
    }

    // 움직임
    private void ReadMovementInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
    }

    private void Dash()
    {
        sprintHeld = Input.GetKey(KeyCode.LeftShift);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            jumpPressed = true;
    }

    // 전투
    private void ReadCombatInput()
    {

    }

    // 
    private void ReadDodgeInput()
    {

    }
}
