using Entitas.Unity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using View.impl;

namespace Controller
{
    class BlockController : IController
    {
        public Model.TowerModel Grid;

        public BlockView View;

        public void Init()
        {
#if DEBUG
            Debug.Assert(Grid != null);
            Debug.Assert(View != null);
#endif
            View.OnClickChanged += View_OnClickChanged;
        }

        private void View_OnClickChanged(object sender, View.BlockViewClickChangedEventArgs e)
        {
            Grid.Block = View.GetComponent<EntityLink>().entity as GameEntity;
            Grid.Tower = Grid.Block.hasTileTower == true ?  Grid.Block.tileTower.Tower:null;
        }
    }
}
