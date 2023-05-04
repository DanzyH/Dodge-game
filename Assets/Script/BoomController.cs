using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : MonoBehaviour
{
    public Vector3 target;
    public float moveSpeed = 2;
    public float destroyTime = 2;
    public GameObject explor;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((transform.position - target) * moveSpeed * Time.deltaTime * -1);

    }

    void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded) return;
        GameObject exp = Instantiate(explor, transform.position, Quaternion.identity) as GameObject;
        Destroy(exp, 0.5f);
    }

    /*void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag.Equals("Player"))
       {
           Destroy(gameObject);
       }
    }*/

}
