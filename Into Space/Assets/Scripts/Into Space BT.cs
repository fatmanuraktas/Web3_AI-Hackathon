using UnityEngine;
using BehaviorTree;
using Tree = BehaviorTree.Tree;

public class SlayerBT : Tree
{
    public Transform[] waypoints;
    public static float walkSpeed = 2f;

    protected override Node SetupTree()
    {
        Node root = new TaskPatrol(transform, waypoints);
        return root;
    }
}