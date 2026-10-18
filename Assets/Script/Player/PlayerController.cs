using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput     playerInput;
    private PlayerMovement  playerMovement;
    private PlayerLockOn    playerLockOn;
    private PlayerDodge     playerDodge;
    private PlayerCombat    playerCombat;
    private PlayerAnimation playerAnimation;

    [SerializeField]
    private float x;
    [SerializeField]
    private float y;
    [SerializeField]
    private float z;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
        playerLockOn = GetComponent<PlayerLockOn>();
        playerDodge = GetComponent<PlayerDodge>();
        playerCombat = GetComponent<PlayerCombat>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    void Start()
    {
      
    }

    void Update()
    {
        x = playerInput.moveX;
        z = playerInput.moveZ;

        playerMovement.SetDash(playerInput.sprintHeld);
        playerMovement.SetMoveInput(x, z);
        playerAnimation.UpdateDirection(x, z);
        playerAnimation.UpdateMovementAnimation(playerMovement.currentSpeed);

        if(playerInput.jumpPressed)
        {
            playerMovement.SetJump();
            playerInput.jumpPressed = false;
        }
    }
}
