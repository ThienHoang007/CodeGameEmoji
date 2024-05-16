using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject GameOver;
    public float speed;
    private Rigidbody2D rb;
    private RaycastHit2D[] hit = new RaycastHit2D[2];
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
    }
    void Update()
    {
        MoveEnemy();
        checkGameOver();
    }
    private void MoveEnemy()
    {
        rb.velocity = new Vector2(this.transform.localScale.x * speed, rb.velocity.y);
    }
    private void checkGameOver()
    {
        hit[0] = Physics2D.Raycast(this.transform.position, this.transform.right, 2f);
        hit[1] = Physics2D.Raycast(this.transform.position, this.transform.right * -1, 2f);
        if (hit[0].collider != null && hit[0].collider.gameObject.CompareTag("ground")) 
        {
            GameOver.SetActive(true);
            Time.timeScale = 0f;
            return;
        }
        if (hit[1].collider != null && hit[1].collider.gameObject.CompareTag("ground"))
        {
            GameOver.SetActive(true);
            Time.timeScale = 0f;
            return;
        }
    }
}
