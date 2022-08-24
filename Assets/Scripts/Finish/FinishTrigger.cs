using UnityEngine;
using Cinemachine;
using System.Collections;

public class FinishTrigger : Interactable
{
    [SerializeField] private PathPoint _finalPathPoint;
    [SerializeField] private CinemachineVirtualCamera _wallsCamera;

    public override void Interact(Player player)
    {
        StartCoroutine(Interacting(player));
    }

    private IEnumerator Interacting(Player player)
    {
        player.Mover.MoveToFinish(_finalPathPoint);
        _wallsCamera.transform.SetParent(player.transform);
        _wallsCamera.m_LookAt = player.transform;

        yield return new WaitForSeconds(0.5f);

        _wallsCamera.Priority = 2;
        Time.timeScale = 0.5f;
    }
}
