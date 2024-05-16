using UnityEngine;

public class BulletOne : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy")) collision.gameObject.GetComponent<Enemy>().speed *= 2;
        Destroy(this.gameObject);
    }
}
