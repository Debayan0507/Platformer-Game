using System.Collections;
using System.Linq.Expressions;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public GameObject player;
    public GameObject fireBall;
    public float minX = 1.6f;
    public float maxX = 3.4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(MonsterShoot());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator MonsterShoot()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 1; i <= 10; i++)
        {
            Vector3 positionRange = new Vector3(transform.position.x, Random.Range(minX, maxX));
            Instantiate(fireBall, positionRange, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(2f);
    }
}
