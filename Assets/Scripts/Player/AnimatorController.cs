using UnityEngine;
using UnityEngine.InputSystem;

public class AnimatorController : MonoBehaviour
{
    public PlayerController playerController = null;
    private Animator animator = null;

    private string trJump = "Jump";
    private string trDead = "Dead";

    private int Jump;
    private int Dead;

    void Start()
    {
        animator = GetComponent<Animator>();
        Jump = Animator.StringToHash(trJump);
        Dead = Animator.StringToHash(trDead);
    }

    void Update()
    {
        if (playerController.isDead)
        {
            animator.SetBool(Dead, true);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector3 input = context.ReadValue<Vector3>();

        if (input.magnitude > 1f) return;

        if (context.performed)
        {
            if (input.magnitude == 0f)
            {
                animator.ResetTrigger(Jump);
            }
            else
            {
                animator.SetTrigger(Jump);
            }
        }
    }
}