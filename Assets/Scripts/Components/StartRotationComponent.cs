using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Components
{
    [Game]
    public class StartRotationComponent : IComponent
    {
        public Quaternion Value;
    }
}
