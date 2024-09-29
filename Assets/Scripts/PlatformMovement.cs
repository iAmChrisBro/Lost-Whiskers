using UnityEngine;

public class PointMovement : MonoBehaviour
{
    public Transform[] points;  // Array of points the object will move between
    public float speed = 2f;    // Speed at which the object will move
    private int i = 0;          // Index for tracking current point
    private bool movingForward = true; // To track direction of movement (forward or backward)

    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {

            // Update the index based on the current direction
            if (movingForward)
            {
                i++;
                if (i == points.Length) // Reached the last point
                {
                    i--; // Step back to stay within bounds
                    movingForward = false; // Switch direction to backward
                   
                }
            }
            else
            {
                i--;
                if (i == -1) // Reached the first point
                {
                    i++; // Step forward to stay within bounds
                    movingForward = true; // Switch direction to forward
                }
            }
        }

        // Move the object towards the current target point
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
}
