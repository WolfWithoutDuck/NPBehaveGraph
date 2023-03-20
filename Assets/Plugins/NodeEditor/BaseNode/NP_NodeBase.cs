using GraphProcessor;
using NPBehave;

namespace Plugins.NodeEditor
{
    public abstract class NP_NodeBase : BaseNode
    {
        public int Level;

        public virtual NP_NodeDataBase NP_GetNodeData()
        {
            return null;
        }

        public virtual bool IsRootNode()
        {
            return false;
        }
    }
}