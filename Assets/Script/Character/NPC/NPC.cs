using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private NPCDefine.NPCUnique _npcUnique = NPCDefine.NPCUnique.None;

    [SerializeField]
    private MissionDefine.MissionUnique _missionUnique = MissionDefine.MissionUnique.None;

    public NPCDefine.NPCUnique GetNPCUnique()
    {
        return _npcUnique;
    }

    public MissionDefine.MissionUnique GetMissionUnique()
    {
        return _missionUnique;
    }

}