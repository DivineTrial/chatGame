using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Gate;
using Service;

namespace gate_svr
{
    public class JoinRoomRequest
    {
        public string UserID = string.Empty;
        public string Roomid = string.Empty;
    }

    public class JoinRoomResponse
    {
        public int ErrCode;
    }

    public class JoinRoomHandle
    {
        private RoomManager _rooms;

        public JoinRoomHandle(RoomManager rooms)
        {
            _rooms = rooms;
        }

        public async Task DoJoinRoom(AbelkhanHttpRequest req)
        {
            var json = System.Text.Encoding.UTF8.GetString(req.Content);
            var request = Newtonsoft.Json.JsonConvert.DeserializeObject<SpeakRequest>(json);

            var status = Microsoft.AspNetCore.Http.StatusCodes.Status200OK;
            var hearders = new Dictionary<string, string>() { { "Content-Type", "application/json" } };

            if (request != null)
            {
                var _hub = await _rooms.get_hub(request.Roomid);
                if (_hub == null)
                {
                    if (_rooms.HashHubProxy(request.Roomid, out var _p))
                    {
                        await _rooms.req_hub(request.Roomid, _p);
                        _hub = _p;
                    }
                }
                if (_hub != null)
                {
                    var task = new TaskCompletionSource();

                    _hub.RoomCaller.join_room(request.UserID, request.Roomid).callBack(async (_, _) =>
                    {
                        var rsp = new JoinRoomResponse()
                        {
                            ErrCode = 0,
                        };
                        var json_str = Newtonsoft.Json.JsonConvert.SerializeObject(rsp);
                        var json_bytes = System.Text.Encoding.UTF8.GetBytes(json_str);
                        await req.Response(status, hearders, json_bytes);
                        task.SetResult();
                    }, async (err) =>
                    {
                        var status = Microsoft.AspNetCore.Http.StatusCodes.Status200OK;
                        var hearders = new Dictionary<string, string>() { { "Content-Type", "application/json" } };
                        var rsp = new JoinRoomResponse()
                        {
                            ErrCode = err,
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

            var err_rsp = new JoinRoomResponse()
            {
                ErrCode = -1,
            };
            var json_err_str = Newtonsoft.Json.JsonConvert.SerializeObject(err_rsp);
            var json_err_bytes = System.Text.Encoding.UTF8.GetBytes(json_err_str);
            await req.Response(status, hearders, json_err_bytes);
        }
    }
    
}
