using Systems.Cleanup;
using Systems.Input;
using Systems.Logic;
using Systems.UI;

namespace Systems
{
    public class RootSystem : Feature
    {
        public RootSystem(Contexts contexts) : base("Root System")
        {
            Add(new InputSystem(contexts));
            Add(new LogicSystem(contexts));
            Add(new UISystem(contexts));
            Add(new CleanupSystem(contexts));
        }
    }
}
