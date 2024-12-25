using Amazon.Runtime.Internal.Transform;
using Gate;
using Service;

namespace gate_svr
{
    public class CreateRoomRequest
    {
        public string UserID = string.Empty;
        public string Theme = string.Empty;
        public string RoomName = string.Empty;
    }

    public class CreateRoomResponse
    {
        public int ErrCode;
        public string RoomID = string.Empty;
    }

    public class CreateRoomHandle
    {
        private HubSvrManager _hubmanager;
        private RoomManager _roommanager;

        public CreateRoomHandle(HubSvrManager hubmgr, RoomManager rooms)
        {
            _hubmanager = hubmgr;
            _roommanager = rooms;
        }

        public async Task DoCreateRoom(AbelkhanHttpRequest req)
        {
            if (_hubmanager.get_hub_proxy("Room", out var _p))
            {
                var json = System.Text.Encoding.UTF8.GetString(req.Content);
                var request = Newtonsoft.Json.JsonConvert.DeserializeObject<CreateRoomRequest>(json);
                if (request != null)
                {
                    var task = new TaskCompletionSource();

                    _p.RoomCaller.create_room(request.UserID, request.Theme, request.RoomName).callBack(async (room_id) =>
                    {
                        _roommanager.req_hub(room_id, _p);

                        var status = Microsoft.AspNetCore.Http.StatusCodes.Status200OK;
                        var hearders = new Dictionary<string, string>() { { "Content-Type", "application/json" } };
                        var rsp = new CreateRoomResponse()
                        {
                            ErrCode = 0,
                            RoomID = room_id,
                        };
                        var json_str = Newtonsoft.Json.JsonConvert.SerializeObject(rsp);
                        var json_bytes = System.Text.Encoding.UTF8.GetBytes(json_str);
                        await req.Response(status, hearders, json_bytes);
                        task.SetResult();
                    }, async (err) =>
                    {
                        var status = Microsoft.AspNetCore.Http.StatusCodes.Status200OK;
                        var hearders = new Dictionary<string, string>() { { "Content-Type", "application/json" } };
                        var rsp = new CreateRoomResponse()
                        {
                            ErrCode = err,
                            RoomID = string.Empty,
                        };
                        var json_str = Newtonsoft.Json.JsonConvert.SerializeObject(rsp);
                        var json_bytes = System.Text.Encoding.UTF8.GetBytes(json_str);
                        await req.Response(status, hearders, json_bytes);
                        task.SetResult();
                    });
                    await task.Task;
                    return;
                }
            }

            var status = Microsoft.AspNetCore.Http.StatusCodes.Status200OK;
            var hearders = new Dictionary<string, string>() { { "Content-Type", "application/json" } };
            var rsp = new CreateRoomResponse()
            {
                ErrCode = -1,
                RoomID = string.Empty,
            };
            var json_str = Newtonsoft.Json.JsonConvert.SerializeObject(rsp);
            var json_bytes = System.Text.Encoding.UTF8.GetBytes(json_str);
            await req.Response(status, hearders, json_bytes);
        }
    }
    
}
