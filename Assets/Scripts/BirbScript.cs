using UnityEngine;
using UnityEngine.InputSystem;

public class BirbScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public LogicScript logic;
    public float flapStrength;
    public float topFlapHeight = 12;
    public float rotationSensitivity = 5;
    public float minRotation = -70;
    public float maxRotation = 90;


    private bool waitingForInput = true;
    private bool birdIsAlive = true;
    private float oldGravScale;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        oldGravScale = myRigidBody.gravityScale;
        myRigidBody.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitingForInput)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                waitingForInput = false;
                logic.startSpawningPipes();
                logic.hideControlPrompt();
                myRigidBody.gravityScale = oldGravScale;
            }
            else
            {
                return;
            }
        }

        handleFlap();
        handleRotation();
    }

    private void handleFlap()
    {
        if (canFlap())
        {
            myRigidBody.linearVelocity = Vector2.up * flapStrength;
        }
    }

    private bool canFlap()
    {
        return Keyboard.current.spaceKey.wasPressedThisFrame && birdIsAlive && transform.position.y <= topFlapHeight;
    }
    
    private void handleRotation()
    {
        if (!birdIsAlive) return;

        float rotation = myRigidBody.linearVelocity.y * rotationSensitivity;

        transform.eulerAngles = new Vector3(0, 0, Mathf.Clamp(rotation, minRotation, maxRotation));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            logic.gameOver();
            birdIsAlive = false;
        }

    }
}
