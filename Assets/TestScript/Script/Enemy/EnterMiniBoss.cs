using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterMiniBoss : MonoBehaviour
{
    public GameObject MiniBoss;
    MeshRenderer mesh;
    BoxCollider col;

    public Transform movePoint;

    bool isOnce = true;

    // Start is called before the first frame update
    void Start()
    {
        mesh=gameObject.GetComponent<MeshRenderer>();
        col=gameObject.GetComponent<BoxCollider>();

        mesh.enabled=false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player)&&isOnce==true)
        {
            //col.isTrigger = true;
            Instantiate(MiniBoss, movePoint.position, movePoint.rotation);
            isOnce = false;
        }
    }
}
