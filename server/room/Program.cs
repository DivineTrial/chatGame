using Abelkhan;

namespace Room
{
    public class Room
    {
        static void Main(string[] args)
        {
            var _hub = new Hub.Hub(args[0], args[1], "Room", "static");

            _hub.on_hubproxy += on_hubproxy;
            _hub.on_hubproxy_reconn += on_hubproxy;

            _hub.onCloseServer += () => {
                _hub.closeSvr();
            };

            var _rooms = new RoomManager();
            var _room_msg_handle = new RoomMsgHandle(_rooms);

            Log.Log.trace("player start ok");

            _hub.run().Wait();
        }

        private static void on_hubproxy(Hub.HubProxy _proxy)
        {
        }
    }
}
