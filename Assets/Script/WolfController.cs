using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour
{

    public GameObject boom;
    public float minBoomTime = 0;
    public float maxBoomTime = 4;
    private float boomTime = 0;
    private float lastBoomTime = 0;
    private GameObject Sheep;
    private GameObject gameController;
    private Animator anim;
    public float throughBoomTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        UpdateBoomTime();
        Sheep = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("isBoom", false);
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastBoomTime + boomTime - throughBoomTime)
        {
            anim.SetBool("isBoom", true);
        }
        if (Time.time >= lastBoomTime + boomTime)
        {
            ThrowBomb();
        }
    }

    void UpdateBoomTime()
    {
        lastBoomTime = Time.time;
        boomTime = Random.Range(minBoomTime, maxBoomTime);
    }

    void ThrowBomb()
    {
        GameObject bom = Instantiate(boom, transform.position, Quaternion.identity) as GameObject;
        bom.GetComponent<BoomController>().target = Sheep.transform.position;
        UpdateBoomTime();
        anim.SetBool("isBoom", false);
        gameController.GetComponent<GameController>().GetPoint();
    }

}
