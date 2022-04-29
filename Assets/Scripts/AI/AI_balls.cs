using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_balls : MonoBehaviour
{
    private Rigidbody rigid;
    public float secondWait = 1f;
    public float jumpSpeed = 35f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(WaitForJump());
    }

    private IEnumerator WaitForJump()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondWait);
            Vector3 tmp = new Vector3(0, 20, 0);
            rigid.AddForce(tmp * jumpSpeed);
        }
    }
}
