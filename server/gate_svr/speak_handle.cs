using Amazon.Runtime.Internal.Transform;
using Gate;
using Service;

namespace gate_svr
{
    public class SpeakRequest
    {
        public string UserID = string.Empty;
        public string Roomid = string.Empty;
        public string SpeakJson = string.Empty;
    }

    public class SpeakResponse
    {
        public int ErrCode;
    }

    public class SpeakHandle
    {
        private HubSvrManager _hubmanager;
        private RoomManager _rooms;

        public SpeakHandle(HubSvrManager hubmgr, RoomManager rooms)
        {
            _hubmanager = hubmgr;
            _rooms = rooms;
        }

        public async Task DoSpeak(AbelkhanHttpRequest req)
        {
            var task = new TaskCompletionSource();

            var json = System.Text.Encoding.UTF8.GetString(req.Content);
            var request = Newtonsoft.Json.JsonConvert.DeserializeObject<SpeakRequest>(json);

            var status = Microsoft.AspNetCore.Http.StatusCodes.Status200OK;
            var hearders = new Dictionary<string, string>() { { "Content-Type", "application/json" } };

            if (request != null)
            {
                var _hub = await _rooms.get_hub(request.Roomid);
                if (_hub != null)
                {
                    _hub.RoomCaller.speak(request.UserID, request.Roomid, request.SpeakJson);
                    var rsp = new SpeakResponse()
                    {
                        ErrCode = 0,
                    };
                    var json_str = Newtonsoft.Json.JsonConvert.SerializeObject(rsp);
                    var json_bytes = System.Text.Encoding.UTF8.GetBytes(json_str);
                    await req.Response(status, hearders, json_bytes);
                    return;
                }
            }

            var err_rsp = new CreateRoomResponse()
            {
                ErrCode = -1,
            };
            var json_err_str = Newtonsoft.Json.JsonConvert.SerializeObject(err_rsp);
            var json_err_bytes = System.Text.Encoding.UTF8.GetBytes(json_err_str);
            await req.Response(status, hearders, json_err_bytes);
        }
    }
    
}
