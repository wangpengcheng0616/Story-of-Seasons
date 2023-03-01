using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D m_PlayerRb;
    [SerializeField] private float m_PlayerSpeed = 5f;
    private float m_InputX, m_InputY;
    private Vector2 movementInput;


    private void Awake()
    {
        m_PlayerRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void Update()
    {
        PlayerInput();
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

        movementInput = new Vector2(m_InputX, m_InputY);
    }

    private void PlayerMove()
    {
        m_PlayerRb.MovePosition(m_PlayerRb.position + movementInput * (m_PlayerSpeed * Time.deltaTime));
    }
}