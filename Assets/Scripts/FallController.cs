using System.Collections;
using UnityEngine;

public class FallController : MonoBehaviour
{
    public GameObject floor;
    public GameObject player;
    public bool flag;

    private void Start()
    {
        flag = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !flag)
        {
            floor.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(CounterFall());
        }
    }

    IEnumerator CounterFall()
    {
        yield return new WaitForSeconds(30);
        player.transform.position = new Vector3(-2,15,-42);
        floor.GetComponent<BoxCollider>().enabled = true;
        flag = true;
    }
}
