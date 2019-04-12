using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{

    private Material material;
    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        material = Resources.Load<Material>("PlayerMaterial");
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            meshRenderer.material = material;
        }
    }

}
