using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;  // �V�[���J�ڗp

public class RoomManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        // Photon�T�[�o�[�ɐڑ���A�����_���ȃ��[���ɎQ��
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();  // �����_�����[���ɎQ��
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();  // �T�[�o�[�ɐڑ�
        }
    }

    // �����_�����[���ւ̎Q�������������ꍇ
    public override void OnJoinedRoom()
    {
        Debug.Log("���[���ɎQ�����܂���: " + PhotonNetwork.CurrentRoom.Name);
        CheckPlayerCount();  // �v���C���[�����`�F�b�N
    }

    // �v���C���[�����[���ɎQ�������Ƃ�
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        CheckPlayerCount();  // �v���C���[�����`�F�b�N
    }

    // �v���C���[�����[����ޏo�����Ƃ�
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        CheckPlayerCount();  // �v���C���[�����`�F�b�N
    }

    // ���[�����̃v���C���[�����`�F�b�N���A2�l�ɂȂ�����V�[���J��
    void CheckPlayerCount()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            int actorNumber = PhotonNetwork.LocalPlayer.ActorNumber;
            if (actorNumber == 1)
            {
                // �v���C���[��2�l�ɂȂ�����V�[���J��
                SceneManager.LoadScene("vs_1");  // GameScene�ɑJ��
            }
            if (actorNumber == 2)
            {
                // �v���C���[��2�l�ɂȂ�����V�[���J��
                SceneManager.LoadScene("vs_2");  // GameScene�ɑJ��
            }

        }
    }
}
