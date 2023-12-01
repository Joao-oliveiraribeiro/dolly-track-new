

using UnityEngine;

public class PathFollwong : MonoBehaviour
{
    public Transform[] pathPoints; // Array to hold the waypoints/path points
    public float moveSpeed = 5.0f; // Speed at which the object moves along the path
    private int currentPoint = 0; // Index of the current waypoint/path point

    void Update()
    {
        // Check if there are path points defined
        if (pathPoints.Length == 0)
        {
            Debug.LogWarning("No path points defined!");
            return;
        }

        // Move towards the current waypoint/path point
        transform.position = Vector3.MoveTowards(transform.position, pathPoints[currentPoint].position, moveSpeed * Time.deltaTime);

        // Check if the object has reached the current waypoint/path point
        if (Vector3.Distance(transform.position, pathPoints[currentPoint].position) < 0.1f)
        {
            // Move to the next waypoint/path point in the array
            currentPoint++;

            // If the current point exceeds the number of path points, reset to the beginning
            if (currentPoint >= pathPoints.Length)
            {
                currentPoint = 0; // Loop back to the start of the path
            }
        }
    }
}
