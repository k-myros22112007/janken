using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR;


public class card_click : MonoBehaviourPun
{
    int hand = 0;

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
        // クリックしたオブジェクトがすでに移動済みの場合、処理を中断
        if (objectMoved) return;

        // タグが条件に合致する場合、移動
        if (gameObject.CompareTag("gu_1") || gameObject.CompareTag("gu_2") ||
            gameObject.CompareTag("gu_3") || gameObject.CompareTag("gu_4") ||
            gameObject.CompareTag("tyoki_1") || gameObject.CompareTag("tyoki_2") ||
            gameObject.CompareTag("tyoki_3") || gameObject.CompareTag("tyoki_4") ||
            gameObject.CompareTag("pa_1") || gameObject.CompareTag("pa_2") ||
            gameObject.CompareTag("pa_3") || gameObject.CompareTag("pa_4"))
        {
            transform.position = targetPosition;
            objectMoved = true; // フラグを立てて他のオブジェクトが移動しないようにする
            Debug.Log($"{gameObject.name} moved to {targetPosition}");
            if (gameObject.CompareTag("gu_1") || gameObject.CompareTag("gu_2") || gameObject.CompareTag("gu_3") || gameObject.CompareTag("gu_4"))
            {
                hand = 1;
            }
            if (gameObject.CompareTag("tyoki_1") || gameObject.CompareTag("tyoki_2") ||gameObject.CompareTag("tyoki_3") || gameObject.CompareTag("tyoki_4"))
            {
                hand = 2;
            }
            if (gameObject.CompareTag("pa_1") || gameObject.CompareTag("pa_2") || gameObject.CompareTag("pa_3") || gameObject.CompareTag("pa_4"))
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
    }

    private void sendhand()
    {
        photonView.RPC("ReceiveJankenHand", RpcTarget.Others, hand);
    }
}
