using UnityEngine;

public class BulletFun : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().speed = 0.25f;
        }

        Destroy(this.gameObject);
    }
}
