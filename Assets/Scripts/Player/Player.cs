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

    private bool m_CanInput = true;

    private void Awake()
    {
        m_PlayerRb = GetComponent<Rigidbody2D>();

        m_Animators = GetComponentsInChildren<Animator>();

        EventHandler.GameSceneLoadEvent += OnGameSceneLoadEvent;
        EventHandler.GameSceneUnloadEvent += OnGameSceneUnloadEvent;
        EventHandler.GameMoveToPositionEvent += OnGameMoveToPositionEvent;
    }

    private void FixedUpdate()
    {
        if (m_CanInput)
        {
            PlayerMove();
        }
    }

    private void Update()
    {
        if (m_CanInput)
        {
            PlayerInput();
            SwitchAnimation();
        }
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

    private void OnGameSceneLoadEvent()
    {
        m_CanInput = true;
    }

    private void OnGameSceneUnloadEvent()
    {
        m_CanInput = false;
    }

    private void OnGameMoveToPositionEvent(Vector3 position)
    {
        transform.position = position;
    }

    private void OnDestroy()
    {
        EventHandler.GameSceneLoadEvent -= OnGameSceneLoadEvent;
        EventHandler.GameSceneUnloadEvent -= OnGameSceneUnloadEvent;
        EventHandler.GameMoveToPositionEvent -= OnGameMoveToPositionEvent;
    }
}