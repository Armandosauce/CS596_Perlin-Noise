using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMapGeneration : MonoBehaviour
{

    public float[,] GenerateNoiseMap(int mapDepth, int mapWidth, float scale)
    {
        float[,] noiseMap = new float[mapDepth, mapWidth];

        for (int z = 0; z < mapDepth; z++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float sX = x / scale;
                float sZ = z / scale;

                float noise = Mathf.PerlinNoise(sX, sZ);
                noiseMap[z, x] = noise;
            }
        }
        return noiseMap;
    }
}
