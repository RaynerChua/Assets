using UnityEngine;

public class MovingBlockBehaviour : MonoBehaviour
{
    public float moveHeight = 2f;
    public float moveSpeed = 1f;
    private Vector3 startPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (CompareTag("MovingBlock"))
        {
            startPosition = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
         if (CompareTag("MovingBlock"))
        {
            float newY = Mathf.PingPong(Time.time * moveSpeed, moveHeight);
            transform.position = new Vector3(startPosition.x, startPosition.y + newY, startPosition.z);
        }
    }
}
