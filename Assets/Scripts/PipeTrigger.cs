using UnityEngine;

public class PipeTrigger : MonoBehaviour
{
    public LogicScript logic;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Birb"))
        {
            logic.addScore(1);
        }
    }
}
