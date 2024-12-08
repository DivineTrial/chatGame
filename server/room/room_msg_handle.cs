using Abelkhan;


namespace Room
{
    class RoomMsgHandle
    {
        private readonly Abelkhan.gate_call_room_module _gate_call_room_module;

        public RoomMsgHandle()
        {
            _gate_call_room_module = new Abelkhan.gate_call_room_module(Abelkhan.ModuleMgrHandle._modulemng);

            _gate_call_room_module.on_create_room += _gate_call_room_module_on_create_room;
            _gate_call_room_module.on_speak += _gate_call_room_module_on_speak;
        }

        private void _gate_call_room_module_on_speak(string arg1, string arg2, string arg3)
        {
            throw new NotImplementedException();
        }

        private void _gate_call_room_module_on_create_room(string arg1, string arg2, string arg3, string arg4)
        {
            throw new NotImplementedException();
        }
    }
}
