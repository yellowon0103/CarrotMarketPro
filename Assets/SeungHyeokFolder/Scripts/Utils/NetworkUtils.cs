using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NetworkUtils
{
    public static Vector3 GetRandomSpawnPoint()
    {
        return new Vector3(Random.Range(-3, 3), 1, Random.Range(-3, 3));
    }
}
