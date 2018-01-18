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
            Grid.OnColorChanged += Grid_OnColorChanged;
            Grid.OnValueChanged += Grid_OnValueChanged;
        }

        private void Grid_OnValueChanged(object sender, Model.GameEntityChangedEventArgs e)
        {
            View.HasTower = (View.GetComponent<EntityLink>().entity as GameEntity).hasTileTower;
        }

        private void Grid_OnColorChanged(object sender, Model.voidChangedEventArgs e)
        {
            View.Color = false;
        }

        private void View_OnClickChanged(object sender, View.BlockViewClickChangedEventArgs e)
        {
            GameEntity entity = View.GetComponent<EntityLink>().entity as GameEntity;
            Grid.Tower = entity.hasTileTower == true ? entity.tileTower.Tower : null;
            Grid.Block = entity;

            View.Color = true;
        }

    }
}
