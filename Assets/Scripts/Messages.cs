using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;

public struct Notification : NetworkMessage
{
    public string content;
}

public class Messages : MonoBehaviour
{
    [SerializeField] private TMP_Text notificationText = null;

    private void Start()
    {
        if (!NetworkClient.active) { return; }

        NetworkClient.RegisterHandler<Notification>(OnNotification);
    }

    private void OnNotification(NetworkConnection conn, Notification msg)
    {
        notificationText.text += $"\n{msg.content}";
    }
}
