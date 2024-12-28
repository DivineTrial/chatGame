
namespace dbproxy_svr
{
    class Program
    {
        static void Main(string[] args)
        {
            var _dbproxy = new DBProxy.DBProxy(args[0], args[1]);
            var _ = new chat_room_msg_handle();

            Log.Log.trace("dbproxy start ok");

            _dbproxy.run().Wait();
        }
    }
}
