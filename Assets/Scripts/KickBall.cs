using UnityEngine;

public class KickBall : MonoBehaviour
{
    public GameObject ball;
    public Transform throwDirection;
    public Collider throwAreaCollider; // Assign the collider in the inspector

    private Rigidbody ballRb;
    private bool isBallThrown = false;

    void Start()
    {
        ballRb = ball.GetComponent<Rigidbody>();
        if (ballRb != null)
        {
            ballRb.drag = 0.7f; // Adjust the drag value as needed
        }
    }

    void Update()
    {
        if (IsPlayerInThrowArea() && Input.GetKeyDown(KeyCode.E))
        {
            ThrowBall();
        }
    }

    bool IsPlayerInThrowArea()
    {
        return throwAreaCollider != null && throwAreaCollider.bounds.Contains(transform.position);
    }

    void ThrowBall()
    {
        if (ballRb != null)
        {
            Vector3 direction = throwDirection != null ? throwDirection.forward : transform.forward;
            ballRb.AddForce(direction * 4f, ForceMode.Impulse);
            isBallThrown = true;

            // Reset the flag after a delay or when the ball comes to a stop
            Invoke("ResetBallThrownFlag", 1.0f);
        }
    }

    void ResetBallThrownFlag()
    {
        isBallThrown = false;
    }
}
