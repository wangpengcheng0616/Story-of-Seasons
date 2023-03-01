using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D m_PlayerRb;
    [SerializeField] private float m_PlayerSpeed = 5f;
    private float m_InputX, m_InputY;
    private Vector2 movementInput;

    // Animator
    private Animator[] m_Animators;
    private bool m_IsMoving;
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private static readonly int InputX = Animator.StringToHash("InputX");
    private static readonly int InputY = Animator.StringToHash("InputY");


    private void Awake()
    {
        m_PlayerRb = GetComponent<Rigidbody2D>();

        m_Animators = GetComponentsInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void Update()
    {
        PlayerInput();
        SwitchAnimation();
    }

    private void PlayerInput()
    {
        m_InputX = Input.GetAxisRaw("Horizontal");
        m_InputY = Input.GetAxisRaw("Vertical");

        if (m_InputX != 0 && m_InputY != 0)
        {
            m_InputX *= 0.6f;
            m_InputY *= 0.6f;
        }

        /*
         * Slow Walk
         * Normal Run
         * Fast Run
         */

        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_InputX *= 1.5f;
            m_InputY *= 1.5f;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            m_InputX *= 0.5f;
            m_InputY *= 0.5f;
        }

        movementInput = new Vector2(m_InputX, m_InputY);

        m_IsMoving = movementInput != Vector2.zero;
    }

    public KeyCode KeyCode { get; }

    private void PlayerMove()
    {
        m_PlayerRb.MovePosition(m_PlayerRb.position + movementInput * (m_PlayerSpeed * Time.deltaTime));
    }

    private void SwitchAnimation()
    {
        foreach (var animator in m_Animators)
        {
            animator.SetBool(IsMoving, m_IsMoving);
            if (m_IsMoving)
            {
                animator.SetFloat(InputX, m_InputX);
                animator.SetFloat(InputY, m_InputY);
            }
        }
    }
}