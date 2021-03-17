using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class CutomNetworkManager : NetworkManager
{
    [SerializeField] private string notificationMessage = string.Empty;
    public override void OnStartServer()
    {
        ServerChangeScene("Main");
    }

    [ContextMenu("SendNotification")]
    private void SendNotification()
    {
        NetworkServer.SendToAll(new Notification { content = notificationMessage });
    }
}
