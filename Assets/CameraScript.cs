using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    GameObject targetObj;
    Vector3 targetPos;
    public GameObject gameoverText;
    public PlayerController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        targetObj = GameObject.Find("Player");
        targetPos = targetObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;

        if (playerScript.isGameover == false)
        {
            // マウスの右クリックを押している間
            if (Input.GetMouseButton(0))
            {
                // マウスの移動量
                float mouseInputX = Input.GetAxis("Mouse X");
                float mouseInputY = Input.GetAxis("Mouse Y");

                // targetの位置のY軸を中心に、回転（公転）する
                transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * 400f);
                // カメラの垂直移動（※角度制限なし、必要が無ければコメントアウト）
               // transform.RotateAround(targetPos, transform.right, deltaAngleV);
            }
        }
        else
        {
            gameoverText.GetComponent<Text>().text = "Game Over";
            if (Input.GetMouseButtonDown(0))
            {
                //GameSceneを読み込む（追加）
                SceneManager.LoadScene("TrueScene");
            }
        }
    }
}
