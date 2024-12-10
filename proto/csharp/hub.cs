using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using MsgPack.Serialization;

namespace Abelkhan
{
/*this enum code is codegen by Abelkhan codegen for c#*/

/*this struct code is codegen by Abelkhan codegen for c#*/
/*this caller code is codegen by Abelkhan codegen for c#*/
/*this cb code is codegen by Abelkhan for c#*/
    public class gate_call_hub_rsp_cb : Abelkhan.Imodule {
        public gate_call_hub_rsp_cb(Abelkhan.modulemng modules) : base("gate_call_hub_rsp_cb")
        {
        }

    }

    public class gate_call_hub_caller : Abelkhan.Icaller {
        public static gate_call_hub_rsp_cb rsp_cb_gate_call_hub_handle = null;
        private Int32 uuid_e1565384_c90b_3a02_ae2e_d0d91b2758d1 = (Int32)RandomUUID.random();

        public gate_call_hub_caller(Abelkhan.Ichannel _ch, Abelkhan.modulemng modules) : base("gate_call_hub", _ch)
        {
            if (rsp_cb_gate_call_hub_handle == null)
            {
                rsp_cb_gate_call_hub_handle = new gate_call_hub_rsp_cb(modules);
            }
        }

        public void client_disconnect(string client_uuid){
            var _argv_0b9435aa_3d03_3778_acfb_c7bfbd4f3e60 = new List<MsgPack.MessagePackObject>();
            _argv_0b9435aa_3d03_3778_acfb_c7bfbd4f3e60.Add(client_uuid);
            call_module_method("gate_call_hub_client_disconnect", _argv_0b9435aa_3d03_3778_acfb_c7bfbd4f3e60);
        }

        public void client_exception(string client_uuid){
            var _argv_706b1331_3629_3681_9d39_d2ef3b6675ed = new List<MsgPack.MessagePackObject>();
            _argv_706b1331_3629_3681_9d39_d2ef3b6675ed.Add(client_uuid);
            call_module_method("gate_call_hub_client_exception", _argv_706b1331_3629_3681_9d39_d2ef3b6675ed);
        }

        public void client_call_hub(string client_uuid, byte[] rpc_argv){
            var _argv_e4b1f5c3_57b2_3ae3_b088_1e3a5d705263 = new List<MsgPack.MessagePackObject>();
            _argv_e4b1f5c3_57b2_3ae3_b088_1e3a5d705263.Add(client_uuid);
            _argv_e4b1f5c3_57b2_3ae3_b088_1e3a5d705263.Add(rpc_argv);
            call_module_method("gate_call_hub_client_call_hub", _argv_e4b1f5c3_57b2_3ae3_b088_1e3a5d705263);
        }

        public void migrate_client(string client_uuid, string target_hub){
            var _argv_871a9539_533c_387f_b7f2_4bd2ac7f4ef9 = new List<MsgPack.MessagePackObject>();
            _argv_871a9539_533c_387f_b7f2_4bd2ac7f4ef9.Add(client_uuid);
            _argv_871a9539_533c_387f_b7f2_4bd2ac7f4ef9.Add(target_hub);
            call_module_method("gate_call_hub_migrate_client", _argv_871a9539_533c_387f_b7f2_4bd2ac7f4ef9);
        }

    }
    public class gate_call_room_create_room_cb
    {
        private UInt64 cb_uuid;
        private gate_call_room_rsp_cb module_rsp_cb;

        public gate_call_room_create_room_cb(UInt64 _cb_uuid, gate_call_room_rsp_cb _module_rsp_cb)
        {
            cb_uuid = _cb_uuid;
            module_rsp_cb = _module_rsp_cb;
        }

        public event Action<string> on_create_room_cb;
        public event Action<Int32> on_create_room_err;
        public event Action on_create_room_timeout;

        public gate_call_room_create_room_cb callBack(Action<string> cb, Action<Int32> err)
        {
            on_create_room_cb += cb;
            on_create_room_err += err;
            return this;
        }

        public void timeout(UInt64 tick, Action timeout_cb)
        {
            TinyTimer.add_timer(tick, ()=>{
                module_rsp_cb.create_room_timeout(cb_uuid);
            });
            on_create_room_timeout += timeout_cb;
        }

        public void call_cb(string room_id)
        {
            if (on_create_room_cb != null)
            {
                on_create_room_cb(room_id);
            }
        }

        public void call_err(Int32 err_code)
        {
            if (on_create_room_err != null)
            {
                on_create_room_err(err_code);
            }
        }

        public void call_timeout()
        {
            if (on_create_room_timeout != null)
            {
                on_create_room_timeout();
            }
        }

    }

    public class gate_call_room_join_room_cb
    {
        private UInt64 cb_uuid;
        private gate_call_room_rsp_cb module_rsp_cb;

        public gate_call_room_join_room_cb(UInt64 _cb_uuid, gate_call_room_rsp_cb _module_rsp_cb)
        {
            cb_uuid = _cb_uuid;
            module_rsp_cb = _module_rsp_cb;
        }

        public event Action<string, string> on_join_room_cb;
        public event Action<Int32> on_join_room_err;
        public event Action on_join_room_timeout;

        public gate_call_room_join_room_cb callBack(Action<string, string> cb, Action<Int32> err)
        {
            on_join_room_cb += cb;
            on_join_room_err += err;
            return this;
        }

        public void timeout(UInt64 tick, Action timeout_cb)
        {
            TinyTimer.add_timer(tick, ()=>{
                module_rsp_cb.join_room_timeout(cb_uuid);
            });
            on_join_room_timeout += timeout_cb;
        }

        public void call_cb(string theme, string room_name)
        {
            if (on_join_room_cb != null)
            {
                on_join_room_cb(theme, room_name);
            }
        }

        public void call_err(Int32 err_code)
        {
            if (on_join_room_err != null)
            {
                on_join_room_err(err_code);
            }
        }

        public void call_timeout()
        {
            if (on_join_room_timeout != null)
            {
                on_join_room_timeout();
            }
        }

    }

    public class gate_call_room_match_room_cb
    {
        private UInt64 cb_uuid;
        private gate_call_room_rsp_cb module_rsp_cb;

        public gate_call_room_match_room_cb(UInt64 _cb_uuid, gate_call_room_rsp_cb _module_rsp_cb)
        {
            cb_uuid = _cb_uuid;
            module_rsp_cb = _module_rsp_cb;
        }

        public event Action<string, string, string> on_match_room_cb;
        public event Action<Int32> on_match_room_err;
        public event Action on_match_room_timeout;

        public gate_call_room_match_room_cb callBack(Action<string, string, string> cb, Action<Int32> err)
        {
            on_match_room_cb += cb;
            on_match_room_err += err;
            return this;
        }

        public void timeout(UInt64 tick, Action timeout_cb)
        {
            TinyTimer.add_timer(tick, ()=>{
                module_rsp_cb.match_room_timeout(cb_uuid);
            });
            on_match_room_timeout += timeout_cb;
        }

        public void call_cb(string room_id, string theme, string room_name)
        {
            if (on_match_room_cb != null)
            {
                on_match_room_cb(room_id, theme, room_name);
            }
        }

        public void call_err(Int32 err_code)
        {
            if (on_match_room_err != null)
            {
                on_match_room_err(err_code);
            }
        }

        public void call_timeout()
        {
            if (on_match_room_timeout != null)
            {
                on_match_room_timeout();
            }
        }

    }

/*this cb code is codegen by Abelkhan for c#*/
    public class gate_call_room_rsp_cb : Abelkhan.Imodule {
        public Dictionary<UInt64, gate_call_room_create_room_cb> map_create_room;
        public Dictionary<UInt64, gate_call_room_join_room_cb> map_join_room;
        public Dictionary<UInt64, gate_call_room_match_room_cb> map_match_room;
        public gate_call_room_rsp_cb(Abelkhan.modulemng modules) : base("gate_call_room_rsp_cb")
        {
            map_create_room = new Dictionary<UInt64, gate_call_room_create_room_cb>();
            modules.reg_method("gate_call_room_rsp_cb_create_room_rsp", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, create_room_rsp));
            modules.reg_method("gate_call_room_rsp_cb_create_room_err", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, create_room_err));
            map_join_room = new Dictionary<UInt64, gate_call_room_join_room_cb>();
            modules.reg_method("gate_call_room_rsp_cb_join_room_rsp", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, join_room_rsp));
            modules.reg_method("gate_call_room_rsp_cb_join_room_err", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, join_room_err));
            map_match_room = new Dictionary<UInt64, gate_call_room_match_room_cb>();
            modules.reg_method("gate_call_room_rsp_cb_match_room_rsp", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, match_room_rsp));
            modules.reg_method("gate_call_room_rsp_cb_match_room_err", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, match_room_err));
        }

        public void create_room_rsp(IList<MsgPack.MessagePackObject> inArray){
            var uuid = ((MsgPack.MessagePackObject)inArray[0]).AsUInt64();
            var _room_id = ((MsgPack.MessagePackObject)inArray[1]).AsString();
            var rsp = try_get_and_del_create_room_cb(uuid);
            if (rsp != null)
            {
                rsp.call_cb(_room_id);
            }
        }

        public void create_room_err(IList<MsgPack.MessagePackObject> inArray){
            var uuid = ((MsgPack.MessagePackObject)inArray[0]).AsUInt64();
            var _err_code = ((MsgPack.MessagePackObject)inArray[1]).AsInt32();
            var rsp = try_get_and_del_create_room_cb(uuid);
            if (rsp != null)
            {
                rsp.call_err(_err_code);
            }
        }

        public void create_room_timeout(UInt64 cb_uuid){
            var rsp = try_get_and_del_create_room_cb(cb_uuid);
            if (rsp != null){
                rsp.call_timeout();
            }
        }

        private gate_call_room_create_room_cb try_get_and_del_create_room_cb(UInt64 uuid){
            lock(map_create_room)
            {
                if (map_create_room.TryGetValue(uuid, out gate_call_room_create_room_cb rsp))
                {
                    map_create_room.Remove(uuid);
                }
                return rsp;
            }
        }

        public void join_room_rsp(IList<MsgPack.MessagePackObject> inArray){
            var uuid = ((MsgPack.MessagePackObject)inArray[0]).AsUInt64();
            var _theme = ((MsgPack.MessagePackObject)inArray[1]).AsString();
            var _room_name = ((MsgPack.MessagePackObject)inArray[2]).AsString();
            var rsp = try_get_and_del_join_room_cb(uuid);
            if (rsp != null)
            {
                rsp.call_cb(_theme, _room_name);
            }
        }

        public void join_room_err(IList<MsgPack.MessagePackObject> inArray){
            var uuid = ((MsgPack.MessagePackObject)inArray[0]).AsUInt64();
            var _err_code = ((MsgPack.MessagePackObject)inArray[1]).AsInt32();
            var rsp = try_get_and_del_join_room_cb(uuid);
            if (rsp != null)
            {
                rsp.call_err(_err_code);
            }
        }

        public void join_room_timeout(UInt64 cb_uuid){
            var rsp = try_get_and_del_join_room_cb(cb_uuid);
            if (rsp != null){
                rsp.call_timeout();
            }
        }

        private gate_call_room_join_room_cb try_get_and_del_join_room_cb(UInt64 uuid){
            lock(map_join_room)
            {
                if (map_join_room.TryGetValue(uuid, out gate_call_room_join_room_cb rsp))
                {
                    map_join_room.Remove(uuid);
                }
                return rsp;
            }
        }

        public void match_room_rsp(IList<MsgPack.MessagePackObject> inArray){
            var uuid = ((MsgPack.MessagePackObject)inArray[0]).AsUInt64();
            var _room_id = ((MsgPack.MessagePackObject)inArray[1]).AsString();
            var _theme = ((MsgPack.MessagePackObject)inArray[2]).AsString();
            var _room_name = ((MsgPack.MessagePackObject)inArray[3]).AsString();
            var rsp = try_get_and_del_match_room_cb(uuid);
            if (rsp != null)
            {
                rsp.call_cb(_room_id, _theme, _room_name);
            }
        }

        public void match_room_err(IList<MsgPack.MessagePackObject> inArray){
            var uuid = ((MsgPack.MessagePackObject)inArray[0]).AsUInt64();
            var _err_code = ((MsgPack.MessagePackObject)inArray[1]).AsInt32();
            var rsp = try_get_and_del_match_room_cb(uuid);
            if (rsp != null)
            {
                rsp.call_err(_err_code);
            }
        }

        public void match_room_timeout(UInt64 cb_uuid){
            var rsp = try_get_and_del_match_room_cb(cb_uuid);
            if (rsp != null){
                rsp.call_timeout();
            }
        }

        private gate_call_room_match_room_cb try_get_and_del_match_room_cb(UInt64 uuid){
            lock(map_match_room)
            {
                if (map_match_room.TryGetValue(uuid, out gate_call_room_match_room_cb rsp))
                {
                    map_match_room.Remove(uuid);
                }
                return rsp;
            }
        }

    }

    public class gate_call_room_caller : Abelkhan.Icaller {
        public static gate_call_room_rsp_cb rsp_cb_gate_call_room_handle = null;
        private Int32 uuid_24ac4ad1_da15_3ab8_b145_66592d61f431 = (Int32)RandomUUID.random();

        public gate_call_room_caller(Abelkhan.Ichannel _ch, Abelkhan.modulemng modules) : base("gate_call_room", _ch)
        {
            if (rsp_cb_gate_call_room_handle == null)
            {
                rsp_cb_gate_call_room_handle = new gate_call_room_rsp_cb(modules);
            }
        }

        public gate_call_room_create_room_cb create_room(string user_id, string theme, string room_name){
            var uuid_596b5288_d0f2_52ea_802a_a61621d93808 = (UInt32)Interlocked.Increment(ref uuid_24ac4ad1_da15_3ab8_b145_66592d61f431);

            var _argv_0f87a215_0b4f_3a78_9d92_9bd3f4aa6dee = new List<MsgPack.MessagePackObject>();
            _argv_0f87a215_0b4f_3a78_9d92_9bd3f4aa6dee.Add(uuid_596b5288_d0f2_52ea_802a_a61621d93808);
            _argv_0f87a215_0b4f_3a78_9d92_9bd3f4aa6dee.Add(user_id);
            _argv_0f87a215_0b4f_3a78_9d92_9bd3f4aa6dee.Add(theme);
            _argv_0f87a215_0b4f_3a78_9d92_9bd3f4aa6dee.Add(room_name);
            call_module_method("gate_call_room_create_room", _argv_0f87a215_0b4f_3a78_9d92_9bd3f4aa6dee);

            var cb_create_room_obj = new gate_call_room_create_room_cb(uuid_596b5288_d0f2_52ea_802a_a61621d93808, rsp_cb_gate_call_room_handle);
            lock(rsp_cb_gate_call_room_handle.map_create_room)
            {
                rsp_cb_gate_call_room_handle.map_create_room.Add(uuid_596b5288_d0f2_52ea_802a_a61621d93808, cb_create_room_obj);
            }
            return cb_create_room_obj;
        }

        public gate_call_room_join_room_cb join_room(string user_id, string room_id){
            var uuid_7d1a7e2e_e50d_5c5f_a3e7_9e9333ac2e8d = (UInt32)Interlocked.Increment(ref uuid_24ac4ad1_da15_3ab8_b145_66592d61f431);

            var _argv_ec52957c_a034_3900_98a3_cd55293c7ef2 = new List<MsgPack.MessagePackObject>();
            _argv_ec52957c_a034_3900_98a3_cd55293c7ef2.Add(uuid_7d1a7e2e_e50d_5c5f_a3e7_9e9333ac2e8d);
            _argv_ec52957c_a034_3900_98a3_cd55293c7ef2.Add(user_id);
            _argv_ec52957c_a034_3900_98a3_cd55293c7ef2.Add(room_id);
            call_module_method("gate_call_room_join_room", _argv_ec52957c_a034_3900_98a3_cd55293c7ef2);

            var cb_join_room_obj = new gate_call_room_join_room_cb(uuid_7d1a7e2e_e50d_5c5f_a3e7_9e9333ac2e8d, rsp_cb_gate_call_room_handle);
            lock(rsp_cb_gate_call_room_handle.map_join_room)
            {
                rsp_cb_gate_call_room_handle.map_join_room.Add(uuid_7d1a7e2e_e50d_5c5f_a3e7_9e9333ac2e8d, cb_join_room_obj);
            }
            return cb_join_room_obj;
        }

        public gate_call_room_match_room_cb match_room(string user_id, string theme){
            var uuid_98375ffb_e90b_5533_b9a9_c0dcd55fa179 = (UInt32)Interlocked.Increment(ref uuid_24ac4ad1_da15_3ab8_b145_66592d61f431);

            var _argv_7be997e8_0e81_3728_9f6b_2f2429d08950 = new List<MsgPack.MessagePackObject>();
            _argv_7be997e8_0e81_3728_9f6b_2f2429d08950.Add(uuid_98375ffb_e90b_5533_b9a9_c0dcd55fa179);
            _argv_7be997e8_0e81_3728_9f6b_2f2429d08950.Add(user_id);
            _argv_7be997e8_0e81_3728_9f6b_2f2429d08950.Add(theme);
            call_module_method("gate_call_room_match_room", _argv_7be997e8_0e81_3728_9f6b_2f2429d08950);

            var cb_match_room_obj = new gate_call_room_match_room_cb(uuid_98375ffb_e90b_5533_b9a9_c0dcd55fa179, rsp_cb_gate_call_room_handle);
            lock(rsp_cb_gate_call_room_handle.map_match_room)
            {
                rsp_cb_gate_call_room_handle.map_match_room.Add(uuid_98375ffb_e90b_5533_b9a9_c0dcd55fa179, cb_match_room_obj);
            }
            return cb_match_room_obj;
        }

        public void speak(string user_id, string room_id, string speak_json){
            var _argv_3635964a_2b13_34f8_a743_76afee0ec761 = new List<MsgPack.MessagePackObject>();
            _argv_3635964a_2b13_34f8_a743_76afee0ec761.Add(user_id);
            _argv_3635964a_2b13_34f8_a743_76afee0ec761.Add(room_id);
            _argv_3635964a_2b13_34f8_a743_76afee0ec761.Add(speak_json);
            call_module_method("gate_call_room_speak", _argv_3635964a_2b13_34f8_a743_76afee0ec761);
        }

    }
    public class hub_call_hub_reg_hub_cb
    {
        private UInt64 cb_uuid;
        private hub_call_hub_rsp_cb module_rsp_cb;

        public hub_call_hub_reg_hub_cb(UInt64 _cb_uuid, hub_call_hub_rsp_cb _module_rsp_cb)
        {
            cb_uuid = _cb_uuid;
            module_rsp_cb = _module_rsp_cb;
        }

        public event Action on_reg_hub_cb;
        public event Action on_reg_hub_err;
        public event Action on_reg_hub_timeout;

        public hub_call_hub_reg_hub_cb callBack(Action cb, Action err)
        {
            on_reg_hub_cb += cb;
            on_reg_hub_err += err;
            return this;
        }

        public void timeout(UInt64 tick, Action timeout_cb)
        {
            TinyTimer.add_timer(tick, ()=>{
                module_rsp_cb.reg_hub_timeout(cb_uuid);
            });
            on_reg_hub_timeout += timeout_cb;
        }

        public void call_cb()
        {
            if (on_reg_hub_cb != null)
            {
                on_reg_hub_cb();
            }
        }

        public void call_err()
        {
            if (on_reg_hub_err != null)
            {
                on_reg_hub_err();
            }
        }

        public void call_timeout()
        {
            if (on_reg_hub_timeout != null)
            {
                on_reg_hub_timeout();
            }
        }

    }

    public class hub_call_hub_seep_client_gate_cb
    {
        private UInt64 cb_uuid;
        private hub_call_hub_rsp_cb module_rsp_cb;

        public hub_call_hub_seep_client_gate_cb(UInt64 _cb_uuid, hub_call_hub_rsp_cb _module_rsp_cb)
        {
            cb_uuid = _cb_uuid;
            module_rsp_cb = _module_rsp_cb;
        }

        public event Action on_seep_client_gate_cb;
        public event Action<framework_error> on_seep_client_gate_err;
        public event Action on_seep_client_gate_timeout;

        public hub_call_hub_seep_client_gate_cb callBack(Action cb, Action<framework_error> err)
        {
            on_seep_client_gate_cb += cb;
            on_seep_client_gate_err += err;
            return this;
        }

        public void timeout(UInt64 tick, Action timeout_cb)
        {
            TinyTimer.add_timer(tick, ()=>{
                module_rsp_cb.seep_client_gate_timeout(cb_uuid);
            });
            on_seep_client_gate_timeout += timeout_cb;
        }

        public void call_cb()
        {
            if (on_seep_client_gate_cb != null)
            {
                on_seep_client_gate_cb();
            }
        }

        public void call_err(framework_error err)
        {
            if (on_seep_client_gate_err != null)
            {
                on_seep_client_gate_err(err);
            }
        }

        public void call_timeout()
        {
            if (on_seep_client_gate_timeout != null)
            {
                on_seep_client_gate_timeout();
            }
        }

    }

/*this cb code is codegen by Abelkhan for c#*/
    public class hub_call_hub_rsp_cb : Abelkhan.Imodule {
        public Dictionary<UInt64, hub_call_hub_reg_hub_cb> map_reg_hub;
        public Dictionary<UInt64, hub_call_hub_seep_client_gate_cb> map_seep_client_gate;
        public hub_call_hub_rsp_cb(Abelkhan.modulemng modules) : base("hub_call_hub_rsp_cb")
        {
            map_reg_hub = new Dictionary<UInt64, hub_call_hub_reg_hub_cb>();
            modules.reg_method("hub_call_hub_rsp_cb_reg_hub_rsp", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, reg_hub_rsp));
            modules.reg_method("hub_call_hub_rsp_cb_reg_hub_err", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, reg_hub_err));
            map_seep_client_gate = new Dictionary<UInt64, hub_call_hub_seep_client_gate_cb>();
            modules.reg_method("hub_call_hub_rsp_cb_seep_client_gate_rsp", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, seep_client_gate_rsp));
            modules.reg_method("hub_call_hub_rsp_cb_seep_client_gate_err", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, seep_client_gate_err));
        }

        public void reg_hub_rsp(IList<MsgPack.MessagePackObject> inArray){
            var uuid = ((MsgPack.MessagePackObject)inArray[0]).AsUInt64();
            var rsp = try_get_and_del_reg_hub_cb(uuid);
            if (rsp != null)
            {
                rsp.call_cb();
            }
        }

        public void reg_hub_err(IList<MsgPack.MessagePackObject> inArray){
            var uuid = ((MsgPack.MessagePackObject)inArray[0]).AsUInt64();
            var rsp = try_get_and_del_reg_hub_cb(uuid);
            if (rsp != null)
            {
                rsp.call_err();
            }
        }

        public void reg_hub_timeout(UInt64 cb_uuid){
            var rsp = try_get_and_del_reg_hub_cb(cb_uuid);
            if (rsp != null){
                rsp.call_timeout();
            }
        }

        private hub_call_hub_reg_hub_cb try_get_and_del_reg_hub_cb(UInt64 uuid){
            lock(map_reg_hub)
            {
                if (map_reg_hub.TryGetValue(uuid, out hub_call_hub_reg_hub_cb rsp))
                {
                    map_reg_hub.Remove(uuid);
                }
                return rsp;
            }
        }

        public void seep_client_gate_rsp(IList<MsgPack.MessagePackObject> inArray){
            var uuid = ((MsgPack.MessagePackObject)inArray[0]).AsUInt64();
            var rsp = try_get_and_del_seep_client_gate_cb(uuid);
            if (rsp != null)
            {
                rsp.call_cb();
            }
        }

        public void seep_client_gate_err(IList<MsgPack.MessagePackObject> inArray){
            var uuid = ((MsgPack.MessagePackObject)inArray[0]).AsUInt64();
            var _err = (framework_error)((MsgPack.MessagePackObject)inArray[1]).AsInt32();
            var rsp = try_get_and_del_seep_client_gate_cb(uuid);
            if (rsp != null)
            {
                rsp.call_err(_err);
            }
        }

        public void seep_client_gate_timeout(UInt64 cb_uuid){
            var rsp = try_get_and_del_seep_client_gate_cb(cb_uuid);
            if (rsp != null){
                rsp.call_timeout();
            }
        }

        private hub_call_hub_seep_client_gate_cb try_get_and_del_seep_client_gate_cb(UInt64 uuid){
            lock(map_seep_client_gate)
            {
                if (map_seep_client_gate.TryGetValue(uuid, out hub_call_hub_seep_client_gate_cb rsp))
                {
                    map_seep_client_gate.Remove(uuid);
                }
                return rsp;
            }
        }

    }

    public class hub_call_hub_caller : Abelkhan.Icaller {
        public static hub_call_hub_rsp_cb rsp_cb_hub_call_hub_handle = null;
        private Int32 uuid_c5ce2cc4_e178_3cb8_ba26_976964de368f = (Int32)RandomUUID.random();

        public hub_call_hub_caller(Abelkhan.Ichannel _ch, Abelkhan.modulemng modules) : base("hub_call_hub", _ch)
        {
            if (rsp_cb_hub_call_hub_handle == null)
            {
                rsp_cb_hub_call_hub_handle = new hub_call_hub_rsp_cb(modules);
            }
        }

        public hub_call_hub_reg_hub_cb reg_hub(string hub_name, string hub_type){
            var uuid_98c51fef_38ce_530a_b8e9_1adcd50b1106 = (UInt32)Interlocked.Increment(ref uuid_c5ce2cc4_e178_3cb8_ba26_976964de368f);

            var _argv_e096e269_1e08_36d1_9ba4_b7db8c8ff8a7 = new List<MsgPack.MessagePackObject>();
            _argv_e096e269_1e08_36d1_9ba4_b7db8c8ff8a7.Add(uuid_98c51fef_38ce_530a_b8e9_1adcd50b1106);
            _argv_e096e269_1e08_36d1_9ba4_b7db8c8ff8a7.Add(hub_name);
            _argv_e096e269_1e08_36d1_9ba4_b7db8c8ff8a7.Add(hub_type);
            call_module_method("hub_call_hub_reg_hub", _argv_e096e269_1e08_36d1_9ba4_b7db8c8ff8a7);

            var cb_reg_hub_obj = new hub_call_hub_reg_hub_cb(uuid_98c51fef_38ce_530a_b8e9_1adcd50b1106, rsp_cb_hub_call_hub_handle);
            lock(rsp_cb_hub_call_hub_handle.map_reg_hub)
            {
                rsp_cb_hub_call_hub_handle.map_reg_hub.Add(uuid_98c51fef_38ce_530a_b8e9_1adcd50b1106, cb_reg_hub_obj);
            }
            return cb_reg_hub_obj;
        }

        public hub_call_hub_seep_client_gate_cb seep_client_gate(string client_uuid, string gate_name){
            var uuid_31169fc3_4fd4_512f_b157_203819bcbd47 = (UInt32)Interlocked.Increment(ref uuid_c5ce2cc4_e178_3cb8_ba26_976964de368f);

            var _argv_78da410b_1845_3253_9a34_d7cda82883b6 = new List<MsgPack.MessagePackObject>();
            _argv_78da410b_1845_3253_9a34_d7cda82883b6.Add(uuid_31169fc3_4fd4_512f_b157_203819bcbd47);
            _argv_78da410b_1845_3253_9a34_d7cda82883b6.Add(client_uuid);
            _argv_78da410b_1845_3253_9a34_d7cda82883b6.Add(gate_name);
            call_module_method("hub_call_hub_seep_client_gate", _argv_78da410b_1845_3253_9a34_d7cda82883b6);

            var cb_seep_client_gate_obj = new hub_call_hub_seep_client_gate_cb(uuid_31169fc3_4fd4_512f_b157_203819bcbd47, rsp_cb_hub_call_hub_handle);
            lock(rsp_cb_hub_call_hub_handle.map_seep_client_gate)
            {
                rsp_cb_hub_call_hub_handle.map_seep_client_gate.Add(uuid_31169fc3_4fd4_512f_b157_203819bcbd47, cb_seep_client_gate_obj);
            }
            return cb_seep_client_gate_obj;
        }

        public void hub_call_hub_mothed(byte[] rpc_argv){
            var _argv_a9f78ac2_6f35_36c5_8d6f_32629449149e = new List<MsgPack.MessagePackObject>();
            _argv_a9f78ac2_6f35_36c5_8d6f_32629449149e.Add(rpc_argv);
            call_module_method("hub_call_hub_hub_call_hub_mothed", _argv_a9f78ac2_6f35_36c5_8d6f_32629449149e);
        }

        public void migrate_client(string client_uuid){
            var _argv_871a9539_533c_387f_b7f2_4bd2ac7f4ef9 = new List<MsgPack.MessagePackObject>();
            _argv_871a9539_533c_387f_b7f2_4bd2ac7f4ef9.Add(client_uuid);
            call_module_method("hub_call_hub_migrate_client", _argv_871a9539_533c_387f_b7f2_4bd2ac7f4ef9);
        }

    }
/*this cb code is codegen by Abelkhan for c#*/
    public class hub_call_client_rsp_cb : Abelkhan.Imodule {
        public hub_call_client_rsp_cb(Abelkhan.modulemng modules) : base("hub_call_client_rsp_cb")
        {
        }

    }

    public class hub_call_client_caller : Abelkhan.Icaller {
        public static hub_call_client_rsp_cb rsp_cb_hub_call_client_handle = null;
        private Int32 uuid_44e0e3b5_d5d3_3ab4_87a3_bdf8d8aefeeb = (Int32)RandomUUID.random();

        public hub_call_client_caller(Abelkhan.Ichannel _ch, Abelkhan.modulemng modules) : base("hub_call_client", _ch)
        {
            if (rsp_cb_hub_call_client_handle == null)
            {
                rsp_cb_hub_call_client_handle = new hub_call_client_rsp_cb(modules);
            }
        }

        public void call_client(byte[] rpc_argv){
            var _argv_623087d1_9b59_38f3_9ea7_54d2c06e5bab = new List<MsgPack.MessagePackObject>();
            _argv_623087d1_9b59_38f3_9ea7_54d2c06e5bab.Add(rpc_argv);
            call_module_method("hub_call_client_call_client", _argv_623087d1_9b59_38f3_9ea7_54d2c06e5bab);
        }

    }
    public class client_call_hub_heartbeats_cb
    {
        private UInt64 cb_uuid;
        private client_call_hub_rsp_cb module_rsp_cb;

        public client_call_hub_heartbeats_cb(UInt64 _cb_uuid, client_call_hub_rsp_cb _module_rsp_cb)
        {
            cb_uuid = _cb_uuid;
            module_rsp_cb = _module_rsp_cb;
        }

        public event Action<UInt64> on_heartbeats_cb;
        public event Action on_heartbeats_err;
        public event Action on_heartbeats_timeout;

        public client_call_hub_heartbeats_cb callBack(Action<UInt64> cb, Action err)
        {
            on_heartbeats_cb += cb;
            on_heartbeats_err += err;
            return this;
        }

        public void timeout(UInt64 tick, Action timeout_cb)
        {
            TinyTimer.add_timer(tick, ()=>{
                module_rsp_cb.heartbeats_timeout(cb_uuid);
            });
            on_heartbeats_timeout += timeout_cb;
        }

        public void call_cb(UInt64 timetmp)
        {
            if (on_heartbeats_cb != null)
            {
                on_heartbeats_cb(timetmp);
            }
        }

        public void call_err()
        {
            if (on_heartbeats_err != null)
            {
                on_heartbeats_err();
            }
        }

        public void call_timeout()
        {
            if (on_heartbeats_timeout != null)
            {
                on_heartbeats_timeout();
            }
        }

    }

/*this cb code is codegen by Abelkhan for c#*/
    public class client_call_hub_rsp_cb : Abelkhan.Imodule {
        public Dictionary<UInt64, client_call_hub_heartbeats_cb> map_heartbeats;
        public client_call_hub_rsp_cb(Abelkhan.modulemng modules) : base("client_call_hub_rsp_cb")
        {
            map_heartbeats = new Dictionary<UInt64, client_call_hub_heartbeats_cb>();
            modules.reg_method("client_call_hub_rsp_cb_heartbeats_rsp", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, heartbeats_rsp));
            modules.reg_method("client_call_hub_rsp_cb_heartbeats_err", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, heartbeats_err));
        }

        public void heartbeats_rsp(IList<MsgPack.MessagePackObject> inArray){
            var uuid = ((MsgPack.MessagePackObject)inArray[0]).AsUInt64();
            var _timetmp = ((MsgPack.MessagePackObject)inArray[1]).AsUInt64();
            var rsp = try_get_and_del_heartbeats_cb(uuid);
            if (rsp != null)
            {
                rsp.call_cb(_timetmp);
            }
        }

        public void heartbeats_err(IList<MsgPack.MessagePackObject> inArray){
            var uuid = ((MsgPack.MessagePackObject)inArray[0]).AsUInt64();
            var rsp = try_get_and_del_heartbeats_cb(uuid);
            if (rsp != null)
            {
                rsp.call_err();
            }
        }

        public void heartbeats_timeout(UInt64 cb_uuid){
            var rsp = try_get_and_del_heartbeats_cb(cb_uuid);
            if (rsp != null){
                rsp.call_timeout();
            }
        }

        private client_call_hub_heartbeats_cb try_get_and_del_heartbeats_cb(UInt64 uuid){
            lock(map_heartbeats)
            {
                if (map_heartbeats.TryGetValue(uuid, out client_call_hub_heartbeats_cb rsp))
                {
                    map_heartbeats.Remove(uuid);
                }
                return rsp;
            }
        }

    }

    public class client_call_hub_caller : Abelkhan.Icaller {
        public static client_call_hub_rsp_cb rsp_cb_client_call_hub_handle = null;
        private Int32 uuid_e4b1f5c3_57b2_3ae3_b088_1e3a5d705263 = (Int32)RandomUUID.random();

        public client_call_hub_caller(Abelkhan.Ichannel _ch, Abelkhan.modulemng modules) : base("client_call_hub", _ch)
        {
            if (rsp_cb_client_call_hub_handle == null)
            {
                rsp_cb_client_call_hub_handle = new client_call_hub_rsp_cb(modules);
            }
        }

        public void connect_hub(string client_uuid){
            var _argv_dc2ee339_bef5_3af9_a492_592ba4f08559 = new List<MsgPack.MessagePackObject>();
            _argv_dc2ee339_bef5_3af9_a492_592ba4f08559.Add(client_uuid);
            call_module_method("client_call_hub_connect_hub", _argv_dc2ee339_bef5_3af9_a492_592ba4f08559);
        }

        public client_call_hub_heartbeats_cb heartbeats(){
            var uuid_a514ca5f_2c67_5668_aac0_354397bdce36 = (UInt32)Interlocked.Increment(ref uuid_e4b1f5c3_57b2_3ae3_b088_1e3a5d705263);

            var _argv_6fbd85be_a054_37ed_b3ea_cced2f90fda4 = new List<MsgPack.MessagePackObject>();
            _argv_6fbd85be_a054_37ed_b3ea_cced2f90fda4.Add(uuid_a514ca5f_2c67_5668_aac0_354397bdce36);
            call_module_method("client_call_hub_heartbeats", _argv_6fbd85be_a054_37ed_b3ea_cced2f90fda4);

            var cb_heartbeats_obj = new client_call_hub_heartbeats_cb(uuid_a514ca5f_2c67_5668_aac0_354397bdce36, rsp_cb_client_call_hub_handle);
            lock(rsp_cb_client_call_hub_handle.map_heartbeats)
            {
                rsp_cb_client_call_hub_handle.map_heartbeats.Add(uuid_a514ca5f_2c67_5668_aac0_354397bdce36, cb_heartbeats_obj);
            }
            return cb_heartbeats_obj;
        }

        public void call_hub(byte[] rpc_argv){
            var _argv_c06f6974_e54a_3491_ae66_1e1861dd19e3 = new List<MsgPack.MessagePackObject>();
            _argv_c06f6974_e54a_3491_ae66_1e1861dd19e3.Add(rpc_argv);
            call_module_method("client_call_hub_call_hub", _argv_c06f6974_e54a_3491_ae66_1e1861dd19e3);
        }

    }
/*this module code is codegen by Abelkhan codegen for c#*/
    public class gate_call_hub_module : Abelkhan.Imodule {
        private Abelkhan.modulemng modules;
        public gate_call_hub_module(Abelkhan.modulemng _modules) : base("gate_call_hub")
        {
            modules = _modules;
            modules.reg_method("gate_call_hub_client_disconnect", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, client_disconnect));
            modules.reg_method("gate_call_hub_client_exception", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, client_exception));
            modules.reg_method("gate_call_hub_client_call_hub", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, client_call_hub));
            modules.reg_method("gate_call_hub_migrate_client", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, migrate_client));
        }

        public event Action<string> on_client_disconnect;
        public void client_disconnect(IList<MsgPack.MessagePackObject> inArray){
            var _client_uuid = ((MsgPack.MessagePackObject)inArray[0]).AsString();
            if (on_client_disconnect != null){
                on_client_disconnect(_client_uuid);
            }
        }

        public event Action<string> on_client_exception;
        public void client_exception(IList<MsgPack.MessagePackObject> inArray){
            var _client_uuid = ((MsgPack.MessagePackObject)inArray[0]).AsString();
            if (on_client_exception != null){
                on_client_exception(_client_uuid);
            }
        }

        public event Action<string, byte[]> on_client_call_hub;
        public void client_call_hub(IList<MsgPack.MessagePackObject> inArray){
            var _client_uuid = ((MsgPack.MessagePackObject)inArray[0]).AsString();
            var _rpc_argv = ((MsgPack.MessagePackObject)inArray[1]).AsBinary();
            if (on_client_call_hub != null){
                on_client_call_hub(_client_uuid, _rpc_argv);
            }
        }

        public event Action<string, string> on_migrate_client;
        public void migrate_client(IList<MsgPack.MessagePackObject> inArray){
            var _client_uuid = ((MsgPack.MessagePackObject)inArray[0]).AsString();
            var _target_hub = ((MsgPack.MessagePackObject)inArray[1]).AsString();
            if (on_migrate_client != null){
                on_migrate_client(_client_uuid, _target_hub);
            }
        }

    }
    public class gate_call_room_create_room_rsp : Abelkhan.Response {
        private UInt64 uuid_23854e65_5189_3f0a_a35a_e9ce5a5cd896;
        public gate_call_room_create_room_rsp(Abelkhan.Ichannel _ch, UInt64 _uuid) : base("gate_call_room_rsp_cb", _ch)
        {
            uuid_23854e65_5189_3f0a_a35a_e9ce5a5cd896 = _uuid;
        }

        public void rsp(string room_id_23a611c3_17ce_35ff_9f9b_8e3b1cd4c568){
            var _argv_0f87a215_0b4f_3a78_9d92_9bd3f4aa6dee = new List<MsgPack.MessagePackObject>();
            _argv_0f87a215_0b4f_3a78_9d92_9bd3f4aa6dee.Add(uuid_23854e65_5189_3f0a_a35a_e9ce5a5cd896);
            _argv_0f87a215_0b4f_3a78_9d92_9bd3f4aa6dee.Add(room_id_23a611c3_17ce_35ff_9f9b_8e3b1cd4c568);
            call_module_method("gate_call_room_rsp_cb_create_room_rsp", _argv_0f87a215_0b4f_3a78_9d92_9bd3f4aa6dee);
        }

        public void err(Int32 err_code_3d12aba6_1dd0_305b_bdbe_29145b62fbf3){
            var _argv_0f87a215_0b4f_3a78_9d92_9bd3f4aa6dee = new List<MsgPack.MessagePackObject>();
            _argv_0f87a215_0b4f_3a78_9d92_9bd3f4aa6dee.Add(uuid_23854e65_5189_3f0a_a35a_e9ce5a5cd896);
            _argv_0f87a215_0b4f_3a78_9d92_9bd3f4aa6dee.Add(err_code_3d12aba6_1dd0_305b_bdbe_29145b62fbf3);
            call_module_method("gate_call_room_rsp_cb_create_room_err", _argv_0f87a215_0b4f_3a78_9d92_9bd3f4aa6dee);
        }

    }

    public class gate_call_room_join_room_rsp : Abelkhan.Response {
        private UInt64 uuid_6e02bfb4_d123_329c_ba0e_83177d046a8c;
        public gate_call_room_join_room_rsp(Abelkhan.Ichannel _ch, UInt64 _uuid) : base("gate_call_room_rsp_cb", _ch)
        {
            uuid_6e02bfb4_d123_329c_ba0e_83177d046a8c = _uuid;
        }

        public void rsp(string theme_de7bffbf_9322_3919_82fe_0b6fb2103fb8, string room_name_b184ba68_7ed2_3a68_9cf3_97573edb6681){
            var _argv_ec52957c_a034_3900_98a3_cd55293c7ef2 = new List<MsgPack.MessagePackObject>();
            _argv_ec52957c_a034_3900_98a3_cd55293c7ef2.Add(uuid_6e02bfb4_d123_329c_ba0e_83177d046a8c);
            _argv_ec52957c_a034_3900_98a3_cd55293c7ef2.Add(theme_de7bffbf_9322_3919_82fe_0b6fb2103fb8);
            _argv_ec52957c_a034_3900_98a3_cd55293c7ef2.Add(room_name_b184ba68_7ed2_3a68_9cf3_97573edb6681);
            call_module_method("gate_call_room_rsp_cb_join_room_rsp", _argv_ec52957c_a034_3900_98a3_cd55293c7ef2);
        }

        public void err(Int32 err_code_3d12aba6_1dd0_305b_bdbe_29145b62fbf3){
            var _argv_ec52957c_a034_3900_98a3_cd55293c7ef2 = new List<MsgPack.MessagePackObject>();
            _argv_ec52957c_a034_3900_98a3_cd55293c7ef2.Add(uuid_6e02bfb4_d123_329c_ba0e_83177d046a8c);
            _argv_ec52957c_a034_3900_98a3_cd55293c7ef2.Add(err_code_3d12aba6_1dd0_305b_bdbe_29145b62fbf3);
            call_module_method("gate_call_room_rsp_cb_join_room_err", _argv_ec52957c_a034_3900_98a3_cd55293c7ef2);
        }

    }

    public class gate_call_room_match_room_rsp : Abelkhan.Response {
        private UInt64 uuid_dbf154a2_3b9f_351b_bea1_93da35e3c902;
        public gate_call_room_match_room_rsp(Abelkhan.Ichannel _ch, UInt64 _uuid) : base("gate_call_room_rsp_cb", _ch)
        {
            uuid_dbf154a2_3b9f_351b_bea1_93da35e3c902 = _uuid;
        }

        public void rsp(string room_id_23a611c3_17ce_35ff_9f9b_8e3b1cd4c568, string theme_de7bffbf_9322_3919_82fe_0b6fb2103fb8, string room_name_b184ba68_7ed2_3a68_9cf3_97573edb6681){
            var _argv_7be997e8_0e81_3728_9f6b_2f2429d08950 = new List<MsgPack.MessagePackObject>();
            _argv_7be997e8_0e81_3728_9f6b_2f2429d08950.Add(uuid_dbf154a2_3b9f_351b_bea1_93da35e3c902);
            _argv_7be997e8_0e81_3728_9f6b_2f2429d08950.Add(room_id_23a611c3_17ce_35ff_9f9b_8e3b1cd4c568);
            _argv_7be997e8_0e81_3728_9f6b_2f2429d08950.Add(theme_de7bffbf_9322_3919_82fe_0b6fb2103fb8);
            _argv_7be997e8_0e81_3728_9f6b_2f2429d08950.Add(room_name_b184ba68_7ed2_3a68_9cf3_97573edb6681);
            call_module_method("gate_call_room_rsp_cb_match_room_rsp", _argv_7be997e8_0e81_3728_9f6b_2f2429d08950);
        }

        public void err(Int32 err_code_3d12aba6_1dd0_305b_bdbe_29145b62fbf3){
            var _argv_7be997e8_0e81_3728_9f6b_2f2429d08950 = new List<MsgPack.MessagePackObject>();
            _argv_7be997e8_0e81_3728_9f6b_2f2429d08950.Add(uuid_dbf154a2_3b9f_351b_bea1_93da35e3c902);
            _argv_7be997e8_0e81_3728_9f6b_2f2429d08950.Add(err_code_3d12aba6_1dd0_305b_bdbe_29145b62fbf3);
            call_module_method("gate_call_room_rsp_cb_match_room_err", _argv_7be997e8_0e81_3728_9f6b_2f2429d08950);
        }

    }

    public class gate_call_room_module : Abelkhan.Imodule {
        private Abelkhan.modulemng modules;
        public gate_call_room_module(Abelkhan.modulemng _modules) : base("gate_call_room")
        {
            modules = _modules;
            modules.reg_method("gate_call_room_create_room", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, create_room));
            modules.reg_method("gate_call_room_join_room", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, join_room));
            modules.reg_method("gate_call_room_match_room", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, match_room));
            modules.reg_method("gate_call_room_speak", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, speak));
        }

        public event Action<string, string, string> on_create_room;
        public void create_room(IList<MsgPack.MessagePackObject> inArray){
            var _cb_uuid = ((MsgPack.MessagePackObject)inArray[0]).AsUInt64();
            var _user_id = ((MsgPack.MessagePackObject)inArray[1]).AsString();
            var _theme = ((MsgPack.MessagePackObject)inArray[2]).AsString();
            var _room_name = ((MsgPack.MessagePackObject)inArray[3]).AsString();
            rsp.Value = new gate_call_room_create_room_rsp(current_ch.Value, _cb_uuid);
            if (on_create_room != null){
                on_create_room(_user_id, _theme, _room_name);
            }
            rsp.Value = null;
        }

        public event Action<string, string> on_join_room;
        public void join_room(IList<MsgPack.MessagePackObject> inArray){
            var _cb_uuid = ((MsgPack.MessagePackObject)inArray[0]).AsUInt64();
            var _user_id = ((MsgPack.MessagePackObject)inArray[1]).AsString();
            var _room_id = ((MsgPack.MessagePackObject)inArray[2]).AsString();
            rsp.Value = new gate_call_room_join_room_rsp(current_ch.Value, _cb_uuid);
            if (on_join_room != null){
                on_join_room(_user_id, _room_id);
            }
            rsp.Value = null;
        }

        public event Action<string, string> on_match_room;
        public void match_room(IList<MsgPack.MessagePackObject> inArray){
            var _cb_uuid = ((MsgPack.MessagePackObject)inArray[0]).AsUInt64();
            var _user_id = ((MsgPack.MessagePackObject)inArray[1]).AsString();
            var _theme = ((MsgPack.MessagePackObject)inArray[2]).AsString();
            rsp.Value = new gate_call_room_match_room_rsp(current_ch.Value, _cb_uuid);
            if (on_match_room != null){
                on_match_room(_user_id, _theme);
            }
            rsp.Value = null;
        }

        public event Action<string, string, string> on_speak;
        public void speak(IList<MsgPack.MessagePackObject> inArray){
            var _user_id = ((MsgPack.MessagePackObject)inArray[0]).AsString();
            var _room_id = ((MsgPack.MessagePackObject)inArray[1]).AsString();
            var _speak_json = ((MsgPack.MessagePackObject)inArray[2]).AsString();
            if (on_speak != null){
                on_speak(_user_id, _room_id, _speak_json);
            }
        }

    }
    public class hub_call_hub_reg_hub_rsp : Abelkhan.Response {
        private UInt64 uuid_d47a6c8a_5494_35bb_9bc5_60d20f624f67;
        public hub_call_hub_reg_hub_rsp(Abelkhan.Ichannel _ch, UInt64 _uuid) : base("hub_call_hub_rsp_cb", _ch)
        {
            uuid_d47a6c8a_5494_35bb_9bc5_60d20f624f67 = _uuid;
        }

        public void rsp(){
            var _argv_e096e269_1e08_36d1_9ba4_b7db8c8ff8a7 = new List<MsgPack.MessagePackObject>();
            _argv_e096e269_1e08_36d1_9ba4_b7db8c8ff8a7.Add(uuid_d47a6c8a_5494_35bb_9bc5_60d20f624f67);
            call_module_method("hub_call_hub_rsp_cb_reg_hub_rsp", _argv_e096e269_1e08_36d1_9ba4_b7db8c8ff8a7);
        }

        public void err(){
            var _argv_e096e269_1e08_36d1_9ba4_b7db8c8ff8a7 = new List<MsgPack.MessagePackObject>();
            _argv_e096e269_1e08_36d1_9ba4_b7db8c8ff8a7.Add(uuid_d47a6c8a_5494_35bb_9bc5_60d20f624f67);
            call_module_method("hub_call_hub_rsp_cb_reg_hub_err", _argv_e096e269_1e08_36d1_9ba4_b7db8c8ff8a7);
        }

    }

    public class hub_call_hub_seep_client_gate_rsp : Abelkhan.Response {
        private UInt64 uuid_3068725f_71fe_3459_a18d_b3f1dc698c98;
        public hub_call_hub_seep_client_gate_rsp(Abelkhan.Ichannel _ch, UInt64 _uuid) : base("hub_call_hub_rsp_cb", _ch)
        {
            uuid_3068725f_71fe_3459_a18d_b3f1dc698c98 = _uuid;
        }

        public void rsp(){
            var _argv_78da410b_1845_3253_9a34_d7cda82883b6 = new List<MsgPack.MessagePackObject>();
            _argv_78da410b_1845_3253_9a34_d7cda82883b6.Add(uuid_3068725f_71fe_3459_a18d_b3f1dc698c98);
            call_module_method("hub_call_hub_rsp_cb_seep_client_gate_rsp", _argv_78da410b_1845_3253_9a34_d7cda82883b6);
        }

        public void err(framework_error err_ad2710a2_3dd2_3a8f_a4c8_a7ebbe1df696){
            var _argv_78da410b_1845_3253_9a34_d7cda82883b6 = new List<MsgPack.MessagePackObject>();
            _argv_78da410b_1845_3253_9a34_d7cda82883b6.Add(uuid_3068725f_71fe_3459_a18d_b3f1dc698c98);
            _argv_78da410b_1845_3253_9a34_d7cda82883b6.Add((int)err_ad2710a2_3dd2_3a8f_a4c8_a7ebbe1df696);
            call_module_method("hub_call_hub_rsp_cb_seep_client_gate_err", _argv_78da410b_1845_3253_9a34_d7cda82883b6);
        }

    }

    public class hub_call_hub_module : Abelkhan.Imodule {
        private Abelkhan.modulemng modules;
        public hub_call_hub_module(Abelkhan.modulemng _modules) : base("hub_call_hub")
        {
            modules = _modules;
            modules.reg_method("hub_call_hub_reg_hub", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, reg_hub));
            modules.reg_method("hub_call_hub_seep_client_gate", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, seep_client_gate));
            modules.reg_method("hub_call_hub_hub_call_hub_mothed", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, hub_call_hub_mothed));
            modules.reg_method("hub_call_hub_migrate_client", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, migrate_client));
        }

        public event Action<string, string> on_reg_hub;
        public void reg_hub(IList<MsgPack.MessagePackObject> inArray){
            var _cb_uuid = ((MsgPack.MessagePackObject)inArray[0]).AsUInt64();
            var _hub_name = ((MsgPack.MessagePackObject)inArray[1]).AsString();
            var _hub_type = ((MsgPack.MessagePackObject)inArray[2]).AsString();
            rsp.Value = new hub_call_hub_reg_hub_rsp(current_ch.Value, _cb_uuid);
            if (on_reg_hub != null){
                on_reg_hub(_hub_name, _hub_type);
            }
            rsp.Value = null;
        }

        public event Action<string, string> on_seep_client_gate;
        public void seep_client_gate(IList<MsgPack.MessagePackObject> inArray){
            var _cb_uuid = ((MsgPack.MessagePackObject)inArray[0]).AsUInt64();
            var _client_uuid = ((MsgPack.MessagePackObject)inArray[1]).AsString();
            var _gate_name = ((MsgPack.MessagePackObject)inArray[2]).AsString();
            rsp.Value = new hub_call_hub_seep_client_gate_rsp(current_ch.Value, _cb_uuid);
            if (on_seep_client_gate != null){
                on_seep_client_gate(_client_uuid, _gate_name);
            }
            rsp.Value = null;
        }

        public event Action<byte[]> on_hub_call_hub_mothed;
        public void hub_call_hub_mothed(IList<MsgPack.MessagePackObject> inArray){
            var _rpc_argv = ((MsgPack.MessagePackObject)inArray[0]).AsBinary();
            if (on_hub_call_hub_mothed != null){
                on_hub_call_hub_mothed(_rpc_argv);
            }
        }

        public event Action<string> on_migrate_client;
        public void migrate_client(IList<MsgPack.MessagePackObject> inArray){
            var _client_uuid = ((MsgPack.MessagePackObject)inArray[0]).AsString();
            if (on_migrate_client != null){
                on_migrate_client(_client_uuid);
            }
        }

    }
    public class hub_call_client_module : Abelkhan.Imodule {
        private Abelkhan.modulemng modules;
        public hub_call_client_module(Abelkhan.modulemng _modules) : base("hub_call_client")
        {
            modules = _modules;
            modules.reg_method("hub_call_client_call_client", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, call_client));
        }

        public event Action<byte[]> on_call_client;
        public void call_client(IList<MsgPack.MessagePackObject> inArray){
            var _rpc_argv = ((MsgPack.MessagePackObject)inArray[0]).AsBinary();
            if (on_call_client != null){
                on_call_client(_rpc_argv);
            }
        }

    }
    public class client_call_hub_heartbeats_rsp : Abelkhan.Response {
        private UInt64 uuid_2c1e76dd_8bad_3bd6_a208_e15a8eb56f56;
        public client_call_hub_heartbeats_rsp(Abelkhan.Ichannel _ch, UInt64 _uuid) : base("client_call_hub_rsp_cb", _ch)
        {
            uuid_2c1e76dd_8bad_3bd6_a208_e15a8eb56f56 = _uuid;
        }

        public void rsp(UInt64 timetmp_3c36cb1d_ce2b_3926_8169_233374fa19ac){
            var _argv_6fbd85be_a054_37ed_b3ea_cced2f90fda4 = new List<MsgPack.MessagePackObject>();
            _argv_6fbd85be_a054_37ed_b3ea_cced2f90fda4.Add(uuid_2c1e76dd_8bad_3bd6_a208_e15a8eb56f56);
            _argv_6fbd85be_a054_37ed_b3ea_cced2f90fda4.Add(timetmp_3c36cb1d_ce2b_3926_8169_233374fa19ac);
            call_module_method("client_call_hub_rsp_cb_heartbeats_rsp", _argv_6fbd85be_a054_37ed_b3ea_cced2f90fda4);
        }

        public void err(){
            var _argv_6fbd85be_a054_37ed_b3ea_cced2f90fda4 = new List<MsgPack.MessagePackObject>();
            _argv_6fbd85be_a054_37ed_b3ea_cced2f90fda4.Add(uuid_2c1e76dd_8bad_3bd6_a208_e15a8eb56f56);
            call_module_method("client_call_hub_rsp_cb_heartbeats_err", _argv_6fbd85be_a054_37ed_b3ea_cced2f90fda4);
        }

    }

    public class client_call_hub_module : Abelkhan.Imodule {
        private Abelkhan.modulemng modules;
        public client_call_hub_module(Abelkhan.modulemng _modules) : base("client_call_hub")
        {
            modules = _modules;
            modules.reg_method("client_call_hub_connect_hub", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, connect_hub));
            modules.reg_method("client_call_hub_heartbeats", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, heartbeats));
            modules.reg_method("client_call_hub_call_hub", Tuple.Create<Abelkhan.Imodule, Action<IList<MsgPack.MessagePackObject> > >((Abelkhan.Imodule)this, call_hub));
        }

        public event Action<string> on_connect_hub;
        public void connect_hub(IList<MsgPack.MessagePackObject> inArray){
            var _client_uuid = ((MsgPack.MessagePackObject)inArray[0]).AsString();
            if (on_connect_hub != null){
                on_connect_hub(_client_uuid);
            }
        }

        public event Action on_heartbeats;
        public void heartbeats(IList<MsgPack.MessagePackObject> inArray){
            var _cb_uuid = ((MsgPack.MessagePackObject)inArray[0]).AsUInt64();
            rsp.Value = new client_call_hub_heartbeats_rsp(current_ch.Value, _cb_uuid);
            if (on_heartbeats != null){
                on_heartbeats();
            }
            rsp.Value = null;
        }

        public event Action<byte[]> on_call_hub;
        public void call_hub(IList<MsgPack.MessagePackObject> inArray){
            var _rpc_argv = ((MsgPack.MessagePackObject)inArray[0]).AsBinary();
            if (on_call_hub != null){
                on_call_hub(_rpc_argv);
            }
        }

    }

}
