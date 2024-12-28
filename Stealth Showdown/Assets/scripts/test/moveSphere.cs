using UnityEngine;

public class moveSphere : MonoBehaviour
{
    public float _speed = 50f;
    public float _horizontalSpeed = 60f;
    private float trust = 500f;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * _horizontalSpeed * Time.fixedDeltaTime;
        float v = Input.GetAxis("Vertical") * _speed * Time.fixedDeltaTime;

        _rb.linearVelocity = transform.TransformDirection(new Vector3(h, v));
        
    }

    private void OnCollisionEnter2D(Collision2D collision) // ��������� �� ������������
       // collision - ������ � ������� ��������������
    {
        if (collision.gameObject.name == "block") // ���� ������������� � �������� �� ����� block
        {
            _rb.AddForce(new Vector2(-1f,0f) * trust); // ��������� ���� ��� ������������ (������)
        }
    }
    private void OnCollisionStay2D(Collision2D collision) // ��������� �� ������������
                                                           // collision - ������ � ������� ��������������
    {
        if (collision.gameObject.name == "block") // ���� ������������� � �������� �� ����� block
        {
            _rb.AddForce(new Vector2(-1f, 0f) * trust); // ��������� ���� ��� ������������ (������)
        }
    }
    private void OnCollisionExit2D(Collision2D collision) // ��������� �� ������������
                                                           // collision - ������ � ������� ��������������
    {
        if (collision.gameObject.name == "block") // ���� ������������� � �������� �� ����� block
        {
            _rb.AddForce(new Vector2(-1f, 0f) * trust); // ��������� ���� ��� ������������ (������)
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //  ������������ ��������������� � ���������
    {
        if (collision.gameObject.name == "trigger")
        {
            Debug.Log("It's trap");
        }
    }

    private void OnTriggerStay2D(Collider2D collision) //  ������������ ��������������� � ���������
    {
        if(collision.gameObject.name == "trigger")
        {
            Debug.Log("�������");
        }
    }
    private void OnTriggerExit2D(Collider2D collision) //  ������������ ��������������� � ���������
    {
        if (collision.gameObject.name == "trigger")
        {
            Destroy(gameObject);
        }
    }
}
