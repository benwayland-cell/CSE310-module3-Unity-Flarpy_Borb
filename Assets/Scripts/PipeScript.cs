using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -45;
    
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
