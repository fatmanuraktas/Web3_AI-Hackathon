using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BehaviorTree
{
    public enum NodeState
    {
        RUNNING,
        SUCCESS,
        FAILURE
    }
    public class Node
    {
       protected NodeState state;
        public Node parent;
        public List<Node> children= new List<Node>();
        private Dictionary<string, object> dataContext = new Dictionary<string, object>();


        public virtual NodeState Evaluate() => NodeState.FAILURE;

        public Node()
        {
            parent = null;
        }

        public Node(List<Node> children)
        {
            foreach (Node child in children)
            {
                Attach(child);
            }
        }
        public void Attach(Node node) {
            node.parent = this;
            children.Add(node);
        }
        //setting data to add
        public void SetData(string key, object value)
        {
            dataContext[key] = value;
        }
        public object GetData(string key) {
            object val = null;
            if (dataContext.TryGetValue(key, out val)) {
                return val;
            }
            Node node = parent;
            if (node != null) {
                val = node.GetData(key);
            }
            return val;
        }
        public bool ClearData(string key) {
            bool cleared = false;
            if (dataContext.ContainsKey(key)) {
                dataContext.Remove(key);
                return true;
            }
            Node node = parent;
            if (node != null) {
                cleared = node.ClearData(key);
            }
            return cleared;
        }

    }
}