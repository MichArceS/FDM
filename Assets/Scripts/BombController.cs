using Unity.VisualScripting;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            Instantiate(explosionPrefab, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
