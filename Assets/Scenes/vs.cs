using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vs : MonoBehaviour
{
    public GameObject gu_1_1;
    public GameObject tyoki_1_1;
    public GameObject pa_1_1;

    public GameObject gu_1_2;
    public GameObject tyoki_1_2;
    public GameObject pa_1_2;

    public GameObject gu_1_3;
    public GameObject tyoki_1_3;
    public GameObject pa_1_3;

    public GameObject gu_1_4;
    public GameObject tyoki_1_4;
    public GameObject pa_1_4;

    public GameObject ura_1_1;
    public GameObject ura_1_2;
    public GameObject ura_1_3;
    public GameObject ura_1_4;


    // Start is called before the first frame update
    void Start()
    {


        // 最初の乱数を発生させてオブジェクトを移動
        MoveObjectToPosition(Random.Range(1, 4), new Vector3(2, -3, 0), gu_1_2, tyoki_1_2, pa_1_2);

        // 次の乱数を発生させてオブジェクトを移動
        MoveObjectToPosition(Random.Range(1, 4), new Vector3(4, -3, 0), gu_1_3, tyoki_1_3, pa_1_3);
    }

    void MoveObjectToPosition(int randomNumber, Vector3 position, GameObject gu, GameObject tyoki, GameObject pa)
    {
        switch (randomNumber)
        {
            case 1:
                gu.transform.position = position;
                break;

            case 2:
                tyoki.transform.position = position;
                Debug.Log($"{tyoki.name} moved to {position}");
                break;

            case 3:
                pa.transform.position = position;
                Debug.Log($"{pa.name} moved to {position}");
                break;


            default:
                Debug.LogError("Invalid random number generated.");
                break;
        }
    }

    void game_start_1P()
    {
        int ran_1 = Random.Range(1, 4); // 1から3の間の乱数
        int ran_2 = Random.Range(1, 4); // 1から3の間の乱数
        transform.Translate(2, -3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
