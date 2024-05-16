using System.Collections;
using UnityEngine;

public class InstancEnemy : MonoBehaviour
{
    [SerializeField] private GameObject m_Enemy;
    private void Start()
    {
        
    }
    private void instance()
    {
        Instantiate(m_Enemy, this.transform.position, Quaternion.identity);
    }
    public IEnumerator InstanAfterTime(float time)
    {
        yield return new WaitForSeconds(time);  
        instance();
        StartCoroutine(InstanAfterTime(Random.Range(2.5f, 5.5f)));
    }
}
