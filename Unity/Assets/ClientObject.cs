using System.Collections.Concurrent;
using System.Threading;
using NetMQ;
using UnityEngine;
using NetMQ.Sockets;
using UnitiyAPI;

public class NetMqListener
{
    private readonly Thread _listenerWorker;

    private bool _listenerCancelled;

    public delegate void MessageDelegate(byte[] message);

    private readonly MessageDelegate _messageDelegate;

    private readonly ConcurrentQueue<byte[]> _messageQueue = new ConcurrentQueue<byte[]>();

    private void ListenerWork()
    {
        AsyncIO.ForceDotNet.Force();
        using (var subSocket = new SubscriberSocket())
        {
            subSocket.Options.ReceiveHighWatermark = 1000;
            subSocket.Connect("tcp://localhost:12345");
            subSocket.Subscribe("");
            while (!_listenerCancelled)
            {
                byte[] frameString;
                if (!subSocket.TryReceiveFrameBytes(out frameString)) continue;
                Debug.Log(frameString);
                _messageQueue.Enqueue(frameString);
            }
            subSocket.Close();
        }
        NetMQConfig.Cleanup();
    }

    public void Update()
    {
        while (!_messageQueue.IsEmpty)
        {
            byte[] message;
            if (_messageQueue.TryDequeue(out message))
            {
                _messageDelegate(message);
            }
            else
            {
                break;
            }
        }
    }

    public NetMqListener(MessageDelegate messageDelegate)
    {
        _messageDelegate = messageDelegate;
        _listenerWorker = new Thread(ListenerWork);
    }

    public void Start()
    {
        _listenerCancelled = false;
        _listenerWorker.Start();
    }

    public void Stop()
    {
        _listenerCancelled = true;
        _listenerWorker.Join();
    }
}

public class ClientObject : MonoBehaviour
{
    private NetMqListener _netMqListener;

    public delegate void ObjectCommandReceived(ObjectManagement p_obj);
    public delegate void CameraControlCommandReceived(CameraView p_obj);

    public event ObjectCommandReceived ObjectCommandReceivedEvent;
    public event CameraControlCommandReceived CameraControlCommandReceivedEvent;

    private void HandleMessage(byte[] message)
    {
        Debug.Log("asdasdasdas");
        var msg = UnityGlobalCommand.Parser.ParseFrom(message);

        switch (msg.OpCode)
        {
            case CommandOpCode.CameraControl:
                if (CameraControlCommandReceivedEvent != null)
                {
                    CameraControlCommandReceivedEvent.Invoke(msg.CameraView);
                }
                break;
            case CommandOpCode.ObjectManagement:
                if (ObjectCommandReceivedEvent != null)
                {
                    ObjectCommandReceivedEvent.Invoke(msg.ObjectManagement);
                }
                break;
        }
    }

    private void Start()
    {
        _netMqListener = new NetMqListener(HandleMessage);
        _netMqListener.Start();
    }

    private void Update()
    {
        _netMqListener.Update();
    }

    private void OnDestroy()
    {
        _netMqListener.Stop();
    }
}
