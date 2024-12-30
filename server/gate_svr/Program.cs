using Abelkhan;
using Gate;
using Microsoft.AspNetCore.Mvc.Routing;
using Service;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace gate_svr
{
    public class RoomManager {
        private Gate.GateService _gate;
        private Dictionary<string, HubProxy> RoomHubProxy = new();

        private SortedVector<string, HubProxy> RoomHashList = new ();

        public RoomManager(Gate.GateService gate)
        {
            _gate = gate;
        }

        public void init_hub(HubProxy _p)
        {
            RoomHashList.Add(_p._hub_name, _p);
        }

        public bool HashHubProxy(string roomId, out HubProxy _proxy)
        {
            var index = roomId.GetHashCode() % RoomHashList.Count();
            return RoomHashList.TryGetValueByIndex(index, out _proxy);
        }

        public async Task req_hub(string roomId, HubProxy _p)
        {
            RoomHubProxy.Add(roomId, _p);
            await _gate._redis_handle.SetStrData(roomId, _p._hub_name);
        }

        public async Task<HubProxy?> get_hub(string roomId)
        {
            if (RoomHubProxy.TryGetValue(roomId, out var _p))
            {
                return _p;
            }
            else
            {
                if (_gate != null && _gate._redis_handle != null)
                {
                    var hub_name = await _gate._redis_handle.GetStrData(roomId);
                    if (string.IsNullOrEmpty(hub_name))
                    {
                        return null;
                    }
                    if (_gate._hubsvrmanager.get_hub(hub_name, out var _proxy))
                    {
                        return _proxy;
                    }
                }
            }
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var _gate = new Gate.GateService(args[0], args[1]);

            Log.Log.trace("gate_svr start ok");

            var _http_host = _gate.Config.get_value_string("http_outside_host");
            var _http_port = (ushort)_gate.Config.get_value_int("http_outside_port");
            var _httpservice = new Service.HttpService(_http_host, _http_port);
            _httpservice.run();

            var rooms = new RoomManager(_gate);

            _gate.on_hubproxy += (_p) =>
            {
                if (_p._hub_type == "Room")
                {
                    rooms.init_hub(_p);
                }
            };

            var createRoomHandle = new CreateRoomHandle(rooms);
            Service.HttpService.post("/create_room_handle", createRoomHandle.DoCreateRoom);

            var joinRoomHandle = new JoinRoomHandle(rooms);
            Service.HttpService.post("/join_room_handle", joinRoomHandle.DoJoinRoom);

            var speakHandle = new SpeakHandle(rooms);
            Service.HttpService.post("/speak", speakHandle.DoSpeak);

            _gate.run().Wait();
        }
    }
}
