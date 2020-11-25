using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarScriptShin : MonoBehaviour
{
    public float moveDistance;
    public float returnDistance;
    public float actionSeconds;
    public float waitSeconds;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MovingSign());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator PillarAnim()
    {
        yield return new WaitForSeconds(actionSeconds);
        MoveAnimation();
    }

    IEnumerator MovingSign()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitSeconds);
            PillarSign();
        }
    }

    void PillarSign()
    {
        int moveChance = Random.Range(0, 2);
        Debug.Log(moveChance);
        if (moveChance==0)
        {
            SignAction();
        }
    }

    void SignAction()
    {
        Hashtable hash = new Hashtable();
        hash.Add("y", 1.5f);
        hash.Add("time", 0.5f);
        iTween.ShakePosition(gameObject, hash);
        StartCoroutine(PillarAnim());
    }


    void MoveAnimation()
    {
        Hashtable hash = new Hashtable();
        hash.Add("y", moveDistance);
        hash.Add("easeType", "easeInExpo");
        hash.Add("oncompletetarget", gameObject);
        hash.Add("oncomplete", "ReturnAnimation");
        iTween.MoveTo(gameObject, hash);
    }

    void ReturnAnimation()
    {
        Hashtable hashR = new Hashtable();
        hashR.Add("y", returnDistance);
        hashR.Add("easeType", "easeInExpo");
        hashR.Add("delay", 1.0f);
        iTween.MoveTo(gameObject, hashR);
    }
}
