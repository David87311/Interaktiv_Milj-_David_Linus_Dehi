using UnityEngine;

public class LookAt : MonoBehaviour
{
    private Transform player;

    void Start()
    {
        // Assuming your player has a tag "Player". If not, you can find the player in another way.
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {
        if (player != null)
        {
            // Face the player
            transform.LookAt(player);
            // Optional: Ensure only rotation around the Y-axis
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
    }
}
