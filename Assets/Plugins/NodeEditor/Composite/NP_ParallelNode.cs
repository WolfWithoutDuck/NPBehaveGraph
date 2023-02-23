using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using GraphProcessor;

namespace Plugins.NodeEditor
{
    [NodeMenuItem("NPBehave行为树/Composite/Parallel", typeof(NPBehaveGraph))]
    public class NP_ParallelNode : NP_CompositeNodeBase
    {
        public override string name => "并行节点";
        

    }
}