using UnityEngine;

public class PlayerCheckCollision : MonoBehaviour
{
    private Player _player = null;

    public void SetPlayer(Player player)
    {
        _player = player;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_player != null)
        {
            _player.OnTriggerEnter_NPC(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(_player != null)
        {
            _player.OnTriggerExit_NPC(other);
        }
    }
}
