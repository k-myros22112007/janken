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
            //��񖈂̌���
            mini_result();

            p1 = false;
            p2 = false;
        }
    }


    IEnumerator WaitForSecondsCoroutine()
    {
        // 5�b�ҋ@
        yield return new WaitForSeconds(5f);
    }

    public void mini_result()
    {

        //card�����ړ�(����)
        Vector3 po = new Vector3(100, 100, 0);

        switch (global_1.round_count)
        {
            case 1:
                // �I�u�W�F�N�g���Ŏw�肵�Č������A�ړ�

                GameObject targetObject5 = GameObject.Find("ura_1_5");
                targetObject5.transform.position = po;
                break;

            case 2:
                // �I�u�W�F�N�g���Ŏw�肵�Č������A�ړ�

                GameObject targetObject4 = GameObject.Find("ura_1_4");
                targetObject4.transform.position = po;
                break;

            case 3:
                // �I�u�W�F�N�g���Ŏw�肵�Č������A�ړ�
                GameObject targetObject3 = GameObject.Find("ura_1_3");
                targetObject3.transform.position = po;
                break;

            case 4:
                // �I�u�W�F�N�g���Ŏw�肵�Č������A�ړ�
                GameObject targetObject2 = GameObject.Find("ura_1_2");
                targetObject2.transform.position = po;
                break;

            case 5:
                // �I�u�W�F�N�g���Ŏw�肵�Č������A�ړ�
                GameObject targetObject1 = GameObject.Find("ura_1_1");
                targetObject1.transform.position = po;
                break;

            default:
                Debug.LogError("Invalid random number generated.");
                break;
        }

        Vector3 po2 = new Vector3(-1.5f, 0, 0);

        //card_1_4���ړ�(�\��)
        switch (hand)
        {
            case 1:
                // �I�u�W�F�N�g���Ŏw�肵�Č������A�ړ�
                GameObject targetObject_g = GameObject.Find("gu_1_4");
                targetObject_g.transform.position = po2;
                break;
            
            case 2:
                // �I�u�W�F�N�g���Ŏw�肵�Č������A�ړ�
                GameObject targetObject_t = GameObject.Find("tyoki_1_4");
                targetObject_t.transform.position = po2;
                break;

            case 3:
                // �I�u�W�F�N�g���Ŏw�肵�Č������A�ړ�
                GameObject targetObject_p1 = GameObject.Find("pa_1_4");
                targetObject_p1.transform.position = po2;
                break;
        }

        //�T�b�Ԍ�����
        StartCoroutine(WaitForSecondsCoroutine());


        //�������I��card���ړ�(����)
        po2 = new Vector3(100, 100, 0);
        GameObject targetObject_p = GameObject.Find("pa_1_4");


        //card_1_4���ړ�(����)

        switch (hand)
        {
            case 1:
                // �I�u�W�F�N�g���Ŏw�肵�Č������A�ړ�
                GameObject targetObject_g = GameObject.Find("gu_1_4");
                targetObject_g.transform.position = po2;
                break;

            case 2:
                // �I�u�W�F�N�g���Ŏw�肵�Č������A�ړ�
                GameObject targetObject_t = GameObject.Find("tyoki_1_4");
                targetObject_t.transform.position = po2;
                break;

            case 3:
                // �I�u�W�F�N�g���Ŏw�肵�Č������A�ړ�
                GameObject targetObject_p1 = GameObject.Find("pa_1_4");
                targetObject_p1.transform.position = po2;
                break;
        }

    }
    

    public class ClickListener : MonoBehaviour
    {
        private GameObject targetObject;

        // �N���b�N���ꂽ�Ƃ��ɌĂ΂�郁�\�b�h
        void OnMouseDown()
        {
            if (targetObject != null)
            {
                // �N���b�N���ꂽ�I�u�W�F�N�g�̖��O��\��
                Debug.Log($"{targetObject.name} was clicked!");
            }
        }

        // ���̃I�u�W�F�N�g�ɃN���b�N�C�x���g��ݒ�
        public void Setup(GameObject obj)
        {
            targetObject = obj;
        }
    }
    


    // �ړ���̍��W
    public Vector3 targetPosition = new Vector3(1.5f, 0f, 0f);

    // �ړ�����x���������邽�߂̃t���O
    private bool objectMoved = false;

    void OnMouseDown()
    {
        p1 = true;

        // �N���b�N�����I�u�W�F�N�g�����łɈړ��ς݂̏ꍇ�A�����𒆒f
        if (!p1) return;

        // �^�O�������ɍ��v����ꍇ�A�ړ�
        if (gameObject.CompareTag("gu_1") || gameObject.CompareTag("gu_2") ||
            gameObject.CompareTag("gu_3") ||
            gameObject.CompareTag("tyoki_1") || gameObject.CompareTag("tyoki_2") ||
            gameObject.CompareTag("tyoki_3") ||
            gameObject.CompareTag("pa_1") || gameObject.CompareTag("pa_2") ||
            gameObject.CompareTag("pa_3"))
        {
            transform.position = targetPosition;
            objectMoved = true; // �t���O�𗧂Ăđ��̃I�u�W�F�N�g���ړ����Ȃ��悤�ɂ���
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


            // ���̃v���C���[�Ɏ�𑗐M����RPC���Ăяo��
            photonView.RPC("ReceiveJankenHand", RpcTarget.Others, hand);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // �V�[�����̂��ׂĂ�GameObject���擾
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            // �eGameObject��Collider�����邩�m�F
            if (obj.GetComponent<Collider>() != null)
            {
                // �N���b�N���̃C�x���g��ǉ�
                // �����ł́A�N���b�N���ꂽ�I�u�W�F�N�g�̖��O��\�����܂�
                obj.AddComponent<ClickListener>().Setup(obj);
            }
        }

        // �K�v�ɉ�����Collider�̑��݂��`�F�b�N
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
        //�����瑤������
        else if((hand ==1 && enemy_hand == 2) || (hand == 2 && enemy_hand == 3) || (hand == 3 || enemy_hand == 1))
        {
            CancelInvoke("sendhand");
        }
        //�����瑤������
        else if((hand == 1 && enemy_hand == 3) || (hand == 2 && enemy_hand == 1) || (hand == 3 || enemy_hand == 2))
        {
            CancelInvoke("sendhand");
        }
        //������
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
                // �I�u�W�F�N�g���Ŏw�肵�Č������A�ړ�

                GameObject targetObject5 = GameObject.Find("ura_1_5");
                targetObject5.transform.position = newPosition;
                break;

            case 2:
                // �I�u�W�F�N�g���Ŏw�肵�Č������A�ړ�

                GameObject targetObject4 = GameObject.Find("ura_1_4");
                targetObject4.transform.position = newPosition;
                break;

            case 3:
                // �I�u�W�F�N�g���Ŏw�肵�Č������A�ړ�
                GameObject targetObject3 = GameObject.Find("ura_1_3");
                targetObject3.transform.position = newPosition;
                break;

            case 4:
                // �I�u�W�F�N�g���Ŏw�肵�Č������A�ړ�
                GameObject targetObject2 = GameObject.Find("ura_1_2");
                targetObject2.transform.position = newPosition;
                break;

            case 5:
                // �I�u�W�F�N�g���Ŏw�肵�Č������A�ړ�
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
