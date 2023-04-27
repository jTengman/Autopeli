using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentCollision : MonoBehaviour
{
    public AudioSource CrashSound;
    public int cubesPerAxis = 5;
    public float force = 300f;
    public float radius = 2f;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PickUp_Damaged")
        {
            GameManager gm = other.GetComponent<GameManager>();
            gm.TentHit();
            Main();
            Instantiate(CrashSound, transform.position, transform.rotation);
            //gameObject.SetActive(false);

        }

    }
    void Main()
    {
        for (int x = 0; x < cubesPerAxis; x++)
        {
            for (int y = 0; y < cubesPerAxis; y++)
            {
                for (int z = 0; z < cubesPerAxis; z++)
                {
                    CreateCube(new Vector3(x, y, z));
                }
            }
        }
        Destroy(gameObject);
    }

    void CreateCube(Vector3 coordinates)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        Renderer rd = cube.GetComponent<Renderer>();
        rd.material = GetComponent<Renderer>().material;
        cube.transform.localScale = transform.localScale / cubesPerAxis;

        Vector3 firstCube = transform.position - transform.localScale / cubesPerAxis;

        cube.transform.position = firstCube + Vector3.Scale(coordinates, cube.transform.localScale);

        Rigidbody rb = cube.AddComponent<Rigidbody>();
        rb.AddExplosionForce(force, transform.position, radius);
    }
}
