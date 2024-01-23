using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    void Start() {gameObject.SetActive(false);}

    private void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            player.transform.position = new Vector3(109f, 2f, -189f);
        }
    }
}
