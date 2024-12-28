
using Abelkhan;
using Supabase.Gotrue;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace dbproxy_svr
{
    [Table("Rooms")]
    class Room : BaseModel
    {
        [PrimaryKey("RoomId")]
        public string? RoomId { get; set; }

        [Column("Theme")]
        public string? Theme { get; set; }

        [Column("RoomName")]
        public string? RoomName { get; set; }

        [Column("UserList")]
        public List<string>? UserList { get; set; }
    }

    public class chat_room_msg_handle
    {
        private readonly string url = "https://ytkmjescpqpnoqrbnepy.supabase.co";
        private readonly string key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Inl0a21qZXNjcHFwbm9xcmJuZXB5Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3MzUzNjc0OTcsImV4cCI6MjA1MDk0MzQ5N30.HgQvI5REHbXlY3_RdNqoFGxYsO6wsEIZZlioSUxhZKE";

        private readonly Abelkhan.hub_call_dbproxy_supabase_module _hub_call_dbproxy_supabase_module;
        private readonly Supabase.Client supabase;

        public chat_room_msg_handle()
        {
            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };
            supabase = new Supabase.Client(url, key, options);

            _hub_call_dbproxy_supabase_module = new Abelkhan.hub_call_dbproxy_supabase_module(Abelkhan.ModuleMgrHandle._modulemng);
            _hub_call_dbproxy_supabase_module.on_create_chat_room += _hub_call_dbproxy_supabase_module_on_create_chat_room;
            _hub_call_dbproxy_supabase_module.on_get_chat_room += _hub_call_dbproxy_supabase_module_on_get_chat_room;
        }

        public async Task Init()
        {
            await supabase.InitializeAsync();
        }

        private async void _hub_call_dbproxy_supabase_module_on_get_chat_room(string roomId)
        {
            Log.Log.trace("begin on_get_chat_room!");

            if (_hub_call_dbproxy_supabase_module.rsp.Value != null)
            {
                var rsp = (Abelkhan.hub_call_dbproxy_supabase_get_chat_room_rsp)_hub_call_dbproxy_supabase_module.rsp.Value;
                try
                {
                    var result = await supabase.From<Room>().Where(x => x.RoomId == roomId).Get();
                    if (result != null && result.Model != null)
                    {
                        var room = new Abelkhan.ChatRoom()
                        {
                            roomId = result.Model.RoomId,
                            Theme = result.Model.Theme,
                            RoomName = result.Model.RoomName,
                            userList = new(),
                        };
                        if (result.Model.UserList != null)
                        {
                            foreach (var userId in result.Model.UserList)
                            {
                                room.userList.Add(new ChatUser()
                                {
                                    isAI = false,
                                    userId = userId,
                                    roomId = roomId,
                                });
                            }
                        }
                        rsp.rsp(room);
                    }
                    else
                    {
                        Log.Log.err("on_get_chat_room:{0} not find in db!", roomId);
                        rsp.err();
                    }
                }
                catch (System.Exception ex)
                {
                    Log.Log.err("ex:{0}", ex);
                    rsp.err();
                }
            }

            Log.Log.trace("end on_get_chat_room!");
        }

        private async void _hub_call_dbproxy_supabase_module_on_create_chat_room(Abelkhan.ChatRoom room)
        {
            Log.Log.trace("begin on_create_chat_room!");
            
            if (_hub_call_dbproxy_supabase_module.rsp.Value != null)
            {
                var rsp = (Abelkhan.hub_call_dbproxy_supabase_create_chat_room_rsp)_hub_call_dbproxy_supabase_module.rsp.Value;
                try
                {
                    var model = new Room()
                    {
                        RoomId = room.roomId,
                        Theme = room.Theme,
                        RoomName = room.RoomName,
                        UserList = room.userList.Select(s => s.userId).ToList(),
                    };
                    await supabase.From<Room>().Insert(model);
                    rsp.rsp();
                }
                catch (System.Exception ex)
                {
                    Log.Log.err("ex:{0}", ex);
                    rsp.err();
                }
            }

            Log.Log.trace("end on_create_chat_room");
        }

    }
}
