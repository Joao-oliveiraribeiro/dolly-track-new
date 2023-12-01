using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BezierCurveMovement : MonoBehaviour
{
    public Transform[] controlPoints; // Array of control points defining the curve
    public float speed = 2.0f; // Speed at which the object moves along the curve

    private float t = 0f; // Parameter t for the curve

    void Update()
    {
        // Increment t based on speed and time
        t += Time.deltaTime * speed;

        if (t > 1f) // Reached the end of the curve
        {
            t = 1f;
            // Optionally reset t to 0 to make the object loop back to the start of the curve
            // t = 0f;
        }

        // Calculate the position along the curve using Bezier formula
        Vector3 newPos = CalculateBezierPoint(t, controlPoints);

        // Set the object's position to the calculated position on the curve
        transform.position = newPos;
    }

    // Bezier curve calculation function
    Vector3 CalculateBezierPoint(float t, Transform[] points)
    {
        if (points.Length < 4) return Vector3.zero;

        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * points[0].position;
        p += 3 * uu * t * points[1].position;
        p += 3 * u * tt * points[2].position;
        p += ttt * points[3].position;

        return p;
    }
}
