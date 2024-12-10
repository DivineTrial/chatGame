using Abelkhan;
using Amazon.Runtime.Internal;


namespace Room
{
    class RoomMsgHandle
    {
        private readonly Abelkhan.gate_call_room_module _gate_call_room_module;
        private readonly RoomManager rooms;

        public RoomMsgHandle(RoomManager _rooms)
        {
            rooms = _rooms;

            _gate_call_room_module = new Abelkhan.gate_call_room_module(Abelkhan.ModuleMgrHandle._modulemng);
            _gate_call_room_module.on_create_room += _gate_call_room_module_on_create_room;
            _gate_call_room_module.on_speak += _gate_call_room_module_on_speak;
        }

        private void _gate_call_room_module_on_speak(string UserID, string Roomid, string SpeakJson)
        {
            Log.Log.trace("on_speak begin!");

            try
            {
                var room = rooms.GetRoom(Roomid);
                if (room != null)
                {
                    room.Speak(UserID, SpeakJson);
                }
            }
            catch (System.Exception err)
            {
                Log.Log.err("on_speak err:{0}", err);
            }

            Log.Log.trace("on_speak end!");
        }

        private void _gate_call_room_module_on_create_room(string UserID, string Theme, string RoomName)
        {
            Log.Log.trace("on_create_room begin!");

            if (_gate_call_room_module.rsp.Value != null)
            {
                var rsp = (Abelkhan.gate_call_room_create_room_rsp)_gate_call_room_module.rsp.Value;
                try
                {
                    var roomId = rooms.CreateRoom(UserID, Theme, RoomName);
                    rsp.rsp(roomId);
                }
                catch (System.Exception err)
                {
                    Log.Log.err("on_create_room err:{0}", err);
                    rsp.err((int)Abelkhan.framework_error.enum_create_room_error);
                }
            }

            Log.Log.trace("on_create_room end!");
        }
    }
}
