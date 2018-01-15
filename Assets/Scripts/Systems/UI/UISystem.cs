using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Systems.UI;

namespace Systems.UI
{
    class UISystem: Feature
    {
        public UISystem(Contexts contexts) : base("UI System")
        {
            Add(new PrefabSystem(contexts));
        }
    }
}
