using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameTag : MonoBehaviourPun
{
    [SerializeField] private Text playerNameText = null;
    
    void Start()
    {
        if (photonView.IsMine) { return; }

        SetName();
    }

    private void SetName()
    {
        playerNameText.text = photonView.Owner.NickName;
    }
}
