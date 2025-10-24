using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private NPCDefine.NPCUnique _npcUnique = NPCDefine.NPCUnique.None;


    public NPCDefine.NPCUnique GetNPCUnique()
    {
        return _npcUnique;
    }
}