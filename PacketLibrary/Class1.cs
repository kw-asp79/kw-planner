using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PacketLibrary
{

    // Packet이 송수신되기 전에 먼저 송수신 되는 클래스 (byte size를 미리 할당하기 위함)
    public class PacketInfo
    {
        public int size;
    }

    public enum ActionType
    {
        saveUser = 0,
        deleteUser,
        editUser,
        saveSchedule,
        deleteSchedule,
        editScedule,
        saveGroup,
        deleteGroup,
        editGroup,
        saveFriendship,
        deleteFriendship,
        editFriendship,
        nothing
    }

    [Serializable]
    public class Packet
    {
        public ActionType action;
        public Object data;

        public Packet()
        {
            action = ActionType.nothing;
            data = null;
        }

        public static byte[] Serialize(Packet packet, PacketInfo packetInfo)
        {
            MemoryStream memstrm = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(memstrm, packet);
            
            // Packet의 size를 구해서 PacketInfo 클래스에 할당
            int packetSize = (int)memstrm.Length;
            packetInfo.size = packetSize;

            // Packet 클래스를 Binary 데이터로 변환
            byte[] data = memstrm.GetBuffer();

            memstrm.Close();

            return data;
        }

        public static Packet Desserialize(byte[] data, PacketInfo packetInfo)
        {
            MemoryStream memstrm = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            int packetSize = packetInfo.size;

            // data의 offset이 0인 지점부터 packetSize만큼 memstrm으로 복사
            memstrm.Write(data, 0, packetSize);

            // Deserialize하기 전의 필수 작업
            memstrm.Position = 0;

            // Binary 데이터를 Packet 클래스로 변환
            Packet packet = (Packet)formatter.Deserialize(memstrm);

            memstrm.Close();

            return packet;
        }
    }
}
