using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public GameObject circleCenter; // The center of the circle
    public GameObject arrowPrefab;  // The arrow prefab to be spawned
    public float radius = 1.5f;      // Radius of the circle
    public float rotationSpeed = 200.0f; // Rotation speed in degrees per second
    

    private GameObject spawnedArrow; // Reference to the spawned arrow
    private float angle = 0.0f; // Current angle of the arrow

    private void Start()
    {

        // Spawn the arrow prefab at the center of the circle
        spawnedArrow = Instantiate(arrowPrefab, circleCenter.transform.position, Quaternion.identity);
        spawnedArrow.transform.position = CalculateArrowPosition(angle);
        
        
    }

    private void Update()
    {
        // Detect 'A' and 'D' key inputs for rotation
        float rotationInput = Input.GetAxis("Horizontal");

        // Calculate the new angle based on the rotation input
        angle += -rotationInput * rotationSpeed * Time.deltaTime;
        angle = Mathf.Clamp(angle, 10, 170);

        // Calculate the arrow's position on the circumference of the circle
        Vector3 arrowPosition = CalculateArrowPosition(angle);

        // Update the arrow's position and rotation
        spawnedArrow.transform.position = arrowPosition;
        spawnedArrow.transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }

    private Vector3 CalculateArrowPosition(float angle)
    {
        float radians = angle * Mathf.Deg2Rad;
        float x = circleCenter.transform.position.x + radius * Mathf.Cos(radians);
        float y = circleCenter.transform.position.y + radius * Mathf.Sin(radians);
        return new Vector3(x, y, 0);
    }

    
        // Add functionality for damage taken
    

    //  TODO: Add collision check for "good memories" and add functionality for increasing idea bar
}
