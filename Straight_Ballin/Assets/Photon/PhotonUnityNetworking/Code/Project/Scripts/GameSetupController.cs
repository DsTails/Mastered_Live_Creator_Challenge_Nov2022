using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSetupController : MonoBehaviourPunCallbacks
{
    PhotonView _photonView;
    int indexIncrease = 1;

    //Store an array of the player start positions. (Ensures players don't spawn in a stack on top of each other)
    [SerializeField] Transform[] _playerStartPositions;
    //Records the number of players currently in a game. Set to 1 by default
    [SerializeField] int _playerNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        _photonView = GetComponent<PhotonView>();
        CreatePlayer(); //Method responsible for creating a networked object for each player that joins the room/scene
    }

    void CreatePlayer()
    {
        
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerChar"), SpawnManager.instance.SpawnPositions[_playerNum].position, SpawnManager.instance.SpawnPositions[_playerNum].rotation);
        photonView.RPC("RPC_SetIndex", RpcTarget.All, indexIncrease);
        
    }

    [PunRPC]
    void RPC_SetIndex(int indexPassed)
    {
        
        _playerNum++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
