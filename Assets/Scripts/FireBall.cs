using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float fireBallSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * fireBallSpeed * Time.deltaTime);
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
