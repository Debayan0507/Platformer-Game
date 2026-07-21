using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float cameraSpeed = 3.0f;
    public float yOffset = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y + yOffset, -10);
        transform.position = Vector3.Lerp(transform.position, playerPos, cameraSpeed * Time.deltaTime);
    }
}