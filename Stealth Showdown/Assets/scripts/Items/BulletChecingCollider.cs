using UnityEngine;

[RequireComponent (typeof(CircleCollider2D))]
public class BulletChecingCollider : MonoBehaviour
{
 private CircleCollider2D _circleCollider;

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "thief")
        {
            Destroy(gameObject);
        }
    }
}
