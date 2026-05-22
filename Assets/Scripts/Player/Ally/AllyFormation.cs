using System.Collections.Generic;
using UnityEngine;

public static class AllyFormation
{
    private static float _radius = 3f;

    public static List<Vector3> GetFormationPositions(Vector3 center, int count)
    {
        List<Vector3> positions = new List<Vector3>();

        for (int i = 0; i < count; i++)
        {
            float angle = i * (360f / 6f) * Mathf.Deg2Rad;
            float x = center.x + _radius * Mathf.Cos(angle);
            float z = center.z + _radius * Mathf.Sin(angle);
            positions.Add(new Vector3(x, center.y, z));
        }

        return positions;
    }
}