using Abelkhan;


namespace Room
{
    public class ChatUser
    {
        public bool isAI;
        public string userId;
        public string roomId;
        public object? ticker;

        public ChatUser(string _userId, string _roomId)
        {
            userId = _userId;
            roomId = _roomId;
            isAI = false;
        }

        public ChatUser(string _roomId)
        {
            userId = string.Empty;
            roomId = _roomId;
            isAI = true;
        }

        public void WaitSpeak()
        {
            if (isAI)
            {
                AISpeak();
            }
            else
            {
                ticker = Hub.Hub._timer.addticktime(15000, PassSpeak);
            }
        }

        public void AISpeak()
        {

        }

        public void PassSpeak(long _)
        {

        }

        public void Speak(string json)
        {
            Hub.Hub._timer.deltimer(ticker);
        }
    }

    public class ChatRoom
    {
        public string roomId;
        public string Theme;
        public string RoomName;
        public List<ChatUser> userList;
        public int curr_speak_index = 0;

        public ChatRoom(string _roomId, string _userId, string _theme, string _roomName)
        {
            roomId = _roomId;
            Theme = _theme;
            RoomName = _roomName;

            userList = new List<ChatUser>();
            userList.Add(new ChatUser(_userId, roomId));
            userList.Add(new ChatUser(roomId));

            userList[curr_speak_index].WaitSpeak();
        }

        public void JoinRoom(string _userId)
        {
            foreach (ChatUser user in userList)
            {
                if (user.userId == _userId)
                {
                    return;
                }
            }
            userList.Add(new ChatUser(_userId, roomId));
        }

        public void Speak(string _userId, string _json)
        {
            if (userList[curr_speak_index].userId != _userId)
            {
                Log.Log.err($"not in speak time userId:{_userId}");
                return;
            }

            userList[curr_speak_index++].Speak(_json);
            if (curr_speak_index == userList.Count)
            {
                curr_speak_index = 0;
            }
            userList[curr_speak_index++].WaitSpeak();
        }
    }

    public class RoomManager
    {
        private Dictionary<string, ChatRoom> rooms;

        public RoomManager()
        {
            rooms = new Dictionary<string, ChatRoom>();
        }

        public void CreateRoom(string _roomId, string _userId, string Theme, string RoomName)
        {
            var room = new ChatRoom(_roomId, _userId, Theme, RoomName);
            rooms[room.roomId] = room;
        }

        public Task<ChatRoom?> JoinRoom(string _userId, string _roomId)
        {
            var task = new TaskCompletionSource<ChatRoom?>();

            if (rooms.TryGetValue(_roomId, out var room))
            {
                room.JoinRoom(_userId);
                task.SetResult(room);
                return task.Task;
            }

            Hub.Hub.get_random_dbproxyproxy().SupabaseCaller.get_chat_room(_roomId).callBack((_db_room) =>
            {
                var room = new ChatRoom(_db_room.roomId, _userId, _db_room.Theme, _db_room.RoomName);
                rooms[room.roomId] = room;
                task.SetResult(room);
            }, () =>
            {
                task.SetResult(null);
            });

            return task.Task;
        }

        public ChatRoom? GetRoom(string roomId)
        {
            if (rooms.TryGetValue(roomId, out var room))
            {
                return room; 
            }
            return null;
        }
    }
}
