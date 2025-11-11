using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour
{
    
        public GameObject blockPrefab;
        public GameObject WaterPrefab;
        public GameObject GrassPrefab;
        public int width = 20;
        public int depth = 20;
        public int maxHeight = 16; // Y
        [SerializeField] float noiseScale = 20f;

        void Start()
        {
            float offsetX = Random.Range(-9999f, 9999f);
            float offsetZ = Random.Range(-9999f, 9999f);

            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < depth; z++)
                {
                    float nx = (x + offsetX) / noiseScale;
                    float nz = (z + offsetZ) / noiseScale;

                    float noise = Mathf.PerlinNoise(nx, nz);

                    int h = Mathf.FloorToInt(noise * maxHeight);

                    if (h <= 0) continue;

                    for (int y = 0; y <= h; y++)
                    {
                        if( y == h )
                        
                            GrassPlace(x, y, z);
                        
                        else
                        
                            Place(x, y, z);
                        
                        
                    }

                    for (int y = 0; y <= 5; y++)
                    {
                        WaterPlace(x, y, z);
                    }


                }
            }
        }

        private void Place(int x, int y, int z)
        {
            var go = Instantiate(blockPrefab, new Vector3(x, y, z), Quaternion.identity, transform);
            go.name = $"B_{x}_{y}_{z}";
        }
        private void WaterPlace(int x, int y, int z)
        {
            var go = Instantiate(WaterPrefab, new Vector3(x, y, z), Quaternion.identity, transform);
            go.name = $"B_{x}_{y}_{z}";
        }
        private void GrassPlace(int x, int y, int z)
        {
            var go = Instantiate(GrassPrefab, new Vector3(x, y, z), Quaternion.identity, transform);
            go.name = $"B_{x}_{y}_{z}";
        }
    }



