using UnityEngine;
using System;
using UnityEngine.UI;
using System.Text;
using NativeWebSocket;

// This script is used for the creation and management of websockets
public class SocketButton : MonoBehaviour
{
    // Result is the text that is on the button
    public Text Result;

    // We use static so that other functions and script can access our variables easily
    // These bool variables are used to control socket connect and disconnect
    static bool socketReady = false, startSocket = false;
    static WebSocket websocket;

    // Host and Port is public InputField to allow user to change the
    // Host IP Address and Port number on the interface
    public InputField Host;
    public InputField Port;


    async void Update()
    {
        // checks if user wants to start socket and if socket has already started
        if (startSocket && !socketReady)
        {
            // Changes the text on the button
            Result.text = "Disconnect from Socket";
            // socketUrl takes the text value of Host and Port InputFields to create the websocket url
            String socketUrl = "ws://" + Host.text + ":" + Port.text;
            // Gets the websocket by calling StartClient()
            websocket = StartClient(socketUrl);
            // Connects the created websocket to server
            await websocket.Connect();
        } else if (!startSocket && socketReady)
        {
            // Closest the existing websocket connection
            CloseSocket();
            // Changes the text on the button
            Result.text = "Connect to Socket";
        } else
        {
            return;
        }
    }

    public void controlSocket()
    {
        // inverts startSocket value
        startSocket = !startSocket;
    }

    // StartClient creates the websocket that will be used for connection and returns it
    // Changes socketReady to true indicating that the socket is ready to be used
    public static WebSocket StartClient(String socketUrl)
    {
        websocket = new WebSocket(socketUrl);
        socketReady = true;
        return websocket;
    }

    // CloseSocket sends the disconnect message to server and closes connection
    // Changes socketReady to false indicating that the socket is no longer ready to be used
    public async static void CloseSocket()
    {
        SendCommand("!DISCONNECT");
        await websocket.Close();
        socketReady = false;
    }

    // SendCommand gets the byte version of message to be sent and sends the byte version to server
    public async static void SendCommand(String message)
    {
        byte[] msg = Encoding.ASCII.GetBytes(message);
        await websocket.Send(msg);
    }

    // When the application is closed this function is called
    void OnApplicationQuit()
    {
        // Check if websocket currently exists
        if (websocket.State == WebSocketState.Closed)
        {
            Debug.Log("Socket is already closed");
        } else
        {
            CloseSocket();
        }
    }
}