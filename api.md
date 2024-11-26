1. /login post  
   入参:  
   {  
     "session_id": session_id,  
     "token": token,  
     "nice_name": nice_name,  
   }  
   返回值:  
   {  
     "game_uuid": game_uuid  
   }  

   聊天数据结构:  
   chat_data  
   {  
     "chat": [  
        {  
          "session_id": session_id,  
          "game_uuid": game_uuid,  
          "nice_name": nice_name,  
          "chat_serial_num": chat_serial_num,  
          "note": note,  
        }  
     ];   
   }  
2. /join_room post  
   入参:  
   {  
     "session_id": session_id,  
     "game_uuid": game_uuid,  
     "room_id": room_id  
   }  
   返回值:  
   {  
     "room_id": room_id,  
     "chat_data":[chat_data],  
   }  
3. /match_room post  
   入参:  
   {  
     "session_id": session_id,  
     "game_uuid": game_uuid,  
     "topic": topic  
   }  
   返回值:  
   {  
     "room_id": room_id,  
     "chat_data":[chat_data],  
   }  
4. /speak post  
   入参:  
   {  
     "session_id": session_id,  
     "game_uuid": game_uuid,  
     "note": note,  
   }  
   返回值:  
   {  
     "room_id": room_id,  
     "chat_data": chat_data,  
   }  
5. /query post  
   入参:  
   {  
     "session_id": session_id,  
     "game_uuid": game_uuid,  
   }  
   返回值:  
   {  
     "room_id": room_id,  
     "chat_data": [chat_data],  
   }  
6. /history post  
   入参:  
   {  
     "session_id": session_id,  
     "game_uuid": game_uuid,  
     "start_chat_serial_num": start_chat_serial_num,  
     "end_chat_serial_num" end_chat_serial_num,  
   }  
   返回值:  
   {  
     "room_id": room_id,  
     "chat_data": [chat_data],  
   }  