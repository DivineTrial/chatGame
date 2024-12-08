using Abelkhan;
using Gate;
using Service;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace gate_svr
{
    public class RoomManager {
        private Gate.GateService _gate;
        private Dictionary<string, HubProxy> RoomHubProxy = new();

        public RoomManager(Gate.GateService gate)
        {
            _gate = gate;
        }

        public void req_hub(string roomId, HubProxy _p)
        {
            RoomHubProxy.Add(roomId, _p);
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

            var createRoomHandle = new CreateRoomHandle(_gate._hubsvrmanager, rooms);
            Service.HttpService.post("/create_room_handle", createRoomHandle.DoCreateRoom);

            var speakHandle = new SpeakHandle(_gate._hubsvrmanager, rooms);
            Service.HttpService.post("/speak", speakHandle.DoSpeak);

            _gate.run().Wait();
        }
    }
}
