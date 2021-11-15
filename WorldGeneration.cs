using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour {
    private GameObject currentBlockType;
    public GameObject[] blockTypes;

    private Vector3 Pos;

    public int worldsize = 100;
    public int layeramount = 1;

    void Start() {
        generateTerrain();
    }

    void generateTerrain() {
        int seed_x = Random.Range(1, 10000000);
        int seed_z = Random.Range(1, 10000000);
        float freq = Random.Range(16, 32);
        float amp = Random.Range(8, 16);
        // float freq = 10f;
        // float amp = 10f;

        Pos = this.transform.position;

        for (int x = 0; x < worldsize; x++) {
            for (int z = 0; z < worldsize; z++) {
                for (int y = 0; y < layeramount; y++) {
                    float noise_y;
                    noise_y = Mathf.PerlinNoise((seed_x + Pos.x + x) / (freq * 4f), (seed_z + Pos.z + z) / (freq * 4f)) * (amp * 4f);
                    noise_y = noise_y + Mathf.PerlinNoise((seed_x + Pos.x + x) / freq, (seed_z + Pos.z + z) / freq) * amp;
                    noise_y = Mathf.Floor(noise_y);

                    if (y + noise_y > amp * 3) {
                        currentBlockType = blockTypes[1];
                    }
                    else {
                        currentBlockType = blockTypes[0];
                    }

                    GameObject newBlock = GameObject.Instantiate(currentBlockType);
                    newBlock.transform.position = new Vector3(Pos.x + x, y + noise_y, Pos.z + z);
                }
            }
        }
    }
}
