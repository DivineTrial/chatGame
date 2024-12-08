using Abelkhan;


namespace Room
{
    public class ChatUser
    {
        public string userId;
        public string chatId;
        public object ticker;

        public ChatUser(string _userId, string _chatId)
        {
            userId = _userId;
            chatId = _chatId;
        }
    }

    public class ChatRoom
    {
        public string roomId;
        public List<ChatUser> userList;


    }

    public class RoomManager
    {
        public RoomManager()
        {
        }
    }
}
