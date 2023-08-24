using UnityEngine;

public class Path : MonoBehaviour
{
    public GameObject obj;
    public GameObject[] pathPoints;
    public float speed;

    private int pathIndex = 0;
    private Terrain terrain;

    // Start is called before the first frame update
    void Start()
    {
        obj.transform.position = pathPoints[pathIndex].transform.position;

        // Get a reference to the terrain
        terrain = Terrain.activeTerrain;
    }

    // Update is called once per frame
    void Update()
    {
        if (pathIndex >= pathPoints.Length) return;
        
        Vector3 targetPos = pathPoints[pathIndex].transform.position;

        // Move the obj towards the target position
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, targetPos, speed * Time.deltaTime);

        float terrainHeight = terrain.SampleHeight(obj.transform.position);

        // Adjust the trolley's position to stick to the terrain while maintaining its own height
        obj.transform.position = new Vector3(obj.transform.position.x, terrainHeight + obj.GetComponent<Renderer>().bounds.extents.y, obj.transform.position.z);

        // Rotate the obj to face the target position
        if (obj.transform.position != targetPos)
        {
            Vector3 direction = targetPos - obj.transform.position;
            direction.y = 0; // Prevent tilting up or down
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            obj.transform.rotation = Quaternion.Slerp(obj.transform.rotation, targetRotation, 5 * Time.deltaTime);
        }

        // Check if the obj has reached the current target point
        if (Vector3.Distance(obj.transform.position, targetPos) < 0.1f)
        {
            pathIndex++;
        }
    }
}