using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;  // シーン遷移用

public class RoomManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        // Photonサーバーに接続後、ランダムなルームに参加
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();  // ランダムルームに参加
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();  // サーバーに接続
        }
    }

    // ランダムルームへの参加が成功した場合
    public override void OnJoinedRoom()
    {
        Debug.Log("ルームに参加しました: " + PhotonNetwork.CurrentRoom.Name);
        CheckPlayerCount();  // プレイヤー数をチェック
    }

    // プレイヤーがルームに参加したとき
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        CheckPlayerCount();  // プレイヤー数をチェック
    }

    // プレイヤーがルームを退出したとき
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        CheckPlayerCount();  // プレイヤー数をチェック
    }

    // ルーム内のプレイヤー数をチェックし、2人になったらシーン遷移
    void CheckPlayerCount()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            int actorNumber = PhotonNetwork.LocalPlayer.ActorNumber;
            if (actorNumber == 1)
            {
                // プレイヤーが2人になったらシーン遷移
                SceneManager.LoadScene("vs_1");  // GameSceneに遷移
            }
            if (actorNumber == 2)
            {
                // プレイヤーが2人になったらシーン遷移
                SceneManager.LoadScene("vs_2");  // GameSceneに遷移
            }

        }
    }
}
