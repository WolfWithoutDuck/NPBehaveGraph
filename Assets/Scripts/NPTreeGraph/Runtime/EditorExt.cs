using System.Collections;
using System.Collections.Generic;
using GraphProcessor;
using NPBehave;
using UnityEngine;
using Root = NPBehave.Root;

namespace NPBehave
{
    public partial class Root
    {
        [Output(null, false), Vertical] public bool __output;
    }

    public partial class Decorate
    {
        [Output(null, false), Vertical] public bool __output;
        [Input(null, false), Vertical] public bool __input;
    }

    public partial class Task
    {
        [Input(null, false), Vertical] public bool __input;
    }

    public partial class Composite
    {
        [Output(null, false), Vertical] public bool __output;
        [Input(null, true), Vertical] public bool __input;
    }

    public abstract partial class Node : BaseNode
    {

    }
}