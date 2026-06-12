using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 5;
    public float pipeOffset = 10;

    private float timer = 0;
    private bool spawningPipes = false;

    // Update is called once per frame
    void Update()
    {
        if (!spawningPipes) return;
        
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
            return;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }

    }

    void spawnPipe()
    {
        float minPoint = transform.position.y - pipeOffset;
        float maxPoint = transform.position.y + pipeOffset;

        float randomY = Random.Range(minPoint, maxPoint);

        Instantiate(pipe, new Vector3(transform.position.x, randomY, 0), transform.rotation);
    }

    public void startSpawning()
    {
        spawningPipes = true;
        spawnPipe();
    }
}
