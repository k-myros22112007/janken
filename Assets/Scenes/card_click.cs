using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class card_click : MonoBehaviour
{
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
        // �N���b�N�����I�u�W�F�N�g�����łɈړ��ς݂̏ꍇ�A�����𒆒f
        if (objectMoved) return;

        // �^�O�������ɍ��v����ꍇ�A�ړ�
        if (gameObject.CompareTag("gu_1") || gameObject.CompareTag("gu_2") ||
            gameObject.CompareTag("gu_3") || gameObject.CompareTag("gu_4") ||
            gameObject.CompareTag("tyoki_1") || gameObject.CompareTag("tyoki_2") ||
            gameObject.CompareTag("tyoki_3") || gameObject.CompareTag("tyoki_4") ||
            gameObject.CompareTag("pa_1") || gameObject.CompareTag("pa_2") ||
            gameObject.CompareTag("pa_3") || gameObject.CompareTag("pa_4"))
        {
            transform.position = targetPosition;
            objectMoved = true; // �t���O�𗧂Ăđ��̃I�u�W�F�N�g���ړ����Ȃ��悤�ɂ���
            Debug.Log($"{gameObject.name} moved to {targetPosition}");
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
}
