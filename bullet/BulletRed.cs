using UnityEngine;

public class BulletRed : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground")) this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        Destroy(this.gameObject, 5f);
    }
}
