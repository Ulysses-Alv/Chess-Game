using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public static GridSystem Instance;
    void Start()
    {
        Instance = this;
    }

    public float size = 0.5f;

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position += transform.position;

        Vector3 result = new Vector3(
            position.x * size,
            position.y * size, 
            0f);

        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (float x = 0; x < 4; x += .5f)
        {
            for (float y = 0; y < 4; y += .5f)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, y, 0f));
                Gizmos.DrawSphere(point, 0.11f);
            }
        }
    }
}
