using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR;
using static global;


public class card_click : MonoBehaviourPun
{
    int hand = 0;

    bool p1 = false;
    bool p2 =false;

    GameObject ob;

    Vector3 po= new Vector3(100, 100, 0);

    void Update()
    {
        if (p1 == true && p2 == true)
        {
            //一回毎の結果
            mini_result();

            p1 = false;
            p2 = false;
        }
    }


    IEnumerator WaitForSecondsCoroutine()
    {
        // 5秒待機
        yield return new WaitForSeconds(5f);
    }

    public void mini_result()
    {

        //card裏を移動(消す)
        Vector3 po = new Vector3(100, 100, 0);

        switch (global_1.round_count)
        {
            case 1:
                // オブジェクト名で指定して検索し、移動

                GameObject targetObject5 = GameObject.Find("ura_1_5");
                targetObject5.transform.position = po;
                break;

            case 2:
                // オブジェクト名で指定して検索し、移動

                GameObject targetObject4 = GameObject.Find("ura_1_4");
                targetObject4.transform.position = po;
                break;

            case 3:
                // オブジェクト名で指定して検索し、移動
                GameObject targetObject3 = GameObject.Find("ura_1_3");
                targetObject3.transform.position = po;
                break;

            case 4:
                // オブジェクト名で指定して検索し、移動
                GameObject targetObject2 = GameObject.Find("ura_1_2");
                targetObject2.transform.position = po;
                break;

            case 5:
                // オブジェクト名で指定して検索し、移動
                GameObject targetObject1 = GameObject.Find("ura_1_1");
                targetObject1.transform.position = po;
                break;

            default:
                Debug.LogError("Invalid random number generated.");
                break;
        }

        Vector3 po2 = new Vector3(-1.5f, 0, 0);

        //card_1_4を移動(表示)
        switch (hand)
        {
            case 1:
                // オブジェクト名で指定して検索し、移動
                GameObject targetObject_g = GameObject.Find("gu_1_4");
                targetObject_g.transform.position = po2;
                break;
            
            case 2:
                // オブジェクト名で指定して検索し、移動
                GameObject targetObject_t = GameObject.Find("tyoki_1_4");
                targetObject_t.transform.position = po2;
                break;

            case 3:
                // オブジェクト名で指定して検索し、移動
                GameObject targetObject_p1 = GameObject.Find("pa_1_4");
                targetObject_p1.transform.position = po2;
                break;
        }

        //５秒間見せる
        StartCoroutine(WaitForSecondsCoroutine());


        //自分が選んだcardを移動(消す)
        po2 = new Vector3(100, 100, 0);
        GameObject targetObject_p = GameObject.Find("pa_1_4");


        //card_1_4を移動(消す)

        switch (hand)
        {
            case 1:
                // オブジェクト名で指定して検索し、移動
                GameObject targetObject_g = GameObject.Find("gu_1_4");
                targetObject_g.transform.position = po2;
                break;

            case 2:
                // オブジェクト名で指定して検索し、移動
                GameObject targetObject_t = GameObject.Find("tyoki_1_4");
                targetObject_t.transform.position = po2;
                break;

            case 3:
                // オブジェクト名で指定して検索し、移動
                GameObject targetObject_p1 = GameObject.Find("pa_1_4");
                targetObject_p1.transform.position = po2;
                break;
        }

    }
    

    public class ClickListener : MonoBehaviour
    {
        private GameObject targetObject;

        // クリックされたときに呼ばれるメソッド
        void OnMouseDown()
        {
            if (targetObject != null)
            {
                // クリックされたオブジェクトの名前を表示
                Debug.Log($"{targetObject.name} was clicked!");
            }
        }

        // このオブジェクトにクリックイベントを設定
        public void Setup(GameObject obj)
        {
            targetObject = obj;
        }
    }
    


    // 移動先の座標
    public Vector3 targetPosition = new Vector3(1.5f, 0f, 0f);

    // 移動を一度だけ許可するためのフラグ
    private bool objectMoved = false;

    void OnMouseDown()
    {
        p1 = true;

        // クリックしたオブジェクトがすでに移動済みの場合、処理を中断
        if (!p1) return;

        // タグが条件に合致する場合、移動
        if (gameObject.CompareTag("gu_1") || gameObject.CompareTag("gu_2") ||
            gameObject.CompareTag("gu_3") ||
            gameObject.CompareTag("tyoki_1") || gameObject.CompareTag("tyoki_2") ||
            gameObject.CompareTag("tyoki_3") ||
            gameObject.CompareTag("pa_1") || gameObject.CompareTag("pa_2") ||
            gameObject.CompareTag("pa_3"))
        {
            transform.position = targetPosition;
            objectMoved = true; // フラグを立てて他のオブジェクトが移動しないようにする
            Debug.Log($"{gameObject.name} movedhhhhhhhhhhhhhhhhhhhh to {targetPosition}");

            if (gameObject.CompareTag("gu_1") || gameObject.CompareTag("gu_2") || gameObject.CompareTag("gu_3") )
            {
                hand = 1;
            }
            if (gameObject.CompareTag("tyoki_1") || gameObject.CompareTag("tyoki_2") ||gameObject.CompareTag("tyoki_3") )
            {
                hand = 2;
            }
            if (gameObject.CompareTag("pa_1") || gameObject.CompareTag("pa_2") || gameObject.CompareTag("pa_3"))
            {
                hand = 3;
            }

            InvokeRepeating("sendhand",1f,1f);


            // 他のプレイヤーに手を送信するRPCを呼び出す
            photonView.RPC("ReceiveJankenHand", RpcTarget.Others, hand);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // シーン内のすべてのGameObjectを取得
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            // 各GameObjectにColliderがあるか確認
            if (obj.GetComponent<Collider>() != null)
            {
                // クリック時のイベントを追加
                // ここでは、クリックされたオブジェクトの名前を表示します
                obj.AddComponent<ClickListener>().Setup(obj);
            }
        }

        // 必要に応じてColliderの存在をチェック
        if (GetComponent<Collider>() == null)
        {
            Debug.LogWarning($"{gameObject.name} does not have a Collider component.");
        }
    }

    [PunRPC]
    public void ReceiveJankenHand(int enemy_hand)
    {
        p2 = true;

        if (hand == 0)
        {
            return;
        }
        //こちら側が勝利
        else if((hand ==1 && enemy_hand == 2) || (hand == 2 && enemy_hand == 3) || (hand == 3 || enemy_hand == 1))
        {
            CancelInvoke("sendhand");
        }
        //こちら側が負け
        else if((hand == 1 && enemy_hand == 3) || (hand == 2 && enemy_hand == 1) || (hand == 3 || enemy_hand == 2))
        {
            CancelInvoke("sendhand");
        }
        //あいこ
        else
        {
            CancelInvoke("sendhand");
        }

        global_1.round_count += 1;

        transform.Translate(-1.5f, 0, 0);


        Vector3 newPosition = new Vector3(100, 100, 0);

        switch (global_1.round_count)
        {
            case 1:
                // オブジェクト名で指定して検索し、移動

                GameObject targetObject5 = GameObject.Find("ura_1_5");
                targetObject5.transform.position = newPosition;
                break;

            case 2:
                // オブジェクト名で指定して検索し、移動

                GameObject targetObject4 = GameObject.Find("ura_1_4");
                targetObject4.transform.position = newPosition;
                break;

            case 3:
                // オブジェクト名で指定して検索し、移動
                GameObject targetObject3 = GameObject.Find("ura_1_3");
                targetObject3.transform.position = newPosition;
                break;

            case 4:
                // オブジェクト名で指定して検索し、移動
                GameObject targetObject2 = GameObject.Find("ura_1_2");
                targetObject2.transform.position = newPosition;
                break;

            case 5:
                // オブジェクト名で指定して検索し、移動
                GameObject targetObject1 = GameObject.Find("ura_1_1");
                targetObject1.transform.position = newPosition;
                break;

            default:
                Debug.LogError("Invalid random number generated.");
                break;
        }
    }

    private void sendhand()
    {
        photonView.RPC("ReceiveJankenHand", RpcTarget.Others, hand);
    }


}
