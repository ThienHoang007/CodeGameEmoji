using UnityEngine;

public class bulletTwo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy")) collision.gameObject.transform.localScale = new Vector3(1, 1, 1);
        Destroy(this.gameObject);
    }
}
