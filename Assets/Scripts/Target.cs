using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameObject level;
    private LevelManager lM;
    public MyScriptableObject Datas;

    private void Start()
    {
        level = GameObject.FindGameObjectWithTag("Level");
        lM = level.GetComponent<LevelManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ball"))
        {
            if(this.gameObject.CompareTag("B100p"))
            {
                Datas.score += 100;
                BrickDed();
                Destroy(this.gameObject);
                
            }

            if (this.gameObject.CompareTag("B200p"))
            {
                Datas.score += 200;
                BrickDed();
                Destroy(this.gameObject);
            }

            if (this.gameObject.CompareTag("B500p"))
            {
                Datas.score += 500;
                BrickDed();
                Destroy(this.gameObject);
            }

            if (this.gameObject.CompareTag("BadBrick"))
            {
                Datas.score -= 500;
                Destroy(this.gameObject);
            }

        }
    }

    void BrickDed()
    {
        lM.bricksCurrentlyBreak++;
    }
}
