using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishTank.Source
{
    using Microsoft.Xna.Framework;
    using System.Diagnostics;

    public class Fish: Entity
    {
        public const float EPS = 1e-5f;

        protected float fastVel;
        protected float slowVel;

        protected Target target;

        protected Vector2 tankDim;

        public Fish(Image img, Vector2 pos, bool flip, float fastVel, float slowVel, Vector2 tankDim):
            base(img, pos, flip)
        {
            this.fastVel = fastVel;
            this.slowVel = slowVel;
            this.tankDim = tankDim;
        }

        public override void Update(float dt)
        {
            if (target == null)
                AttemptAcquireTarget();
            else 
                MoveTowardsTarget(target, dt);
        } 

        protected virtual void CompleteTarget()
        {
            target = null;
        }

        private void MoveTowardsTarget(Target target, float dt)
        {
            Vector2 dv = target.pos - pos;
            float d = dv.Length();
            float v = dt * (target.urgent ? fastVel : slowVel);
            if (d < EPS | v > d)
                CompleteTarget();
            else
            {
                Vector2 rate = dv / d * v;
                pos += rate;
            }
        }

        private void AttemptAcquireTarget()
        {
            if (!AttemptAcquireUrgentTarget())
                SetWanderTarget();
        }

        private void SetWanderTarget()
        {
            Rectangle rect = img.GetBaseRectangle();
            float targetX = GoingLeft()? GetWanderLeftTarget(rect) : GetWanderRightTarget(rect);
            target = new Target(new Vector2(targetX, pos.Y), false);
        }

        private bool GoingLeft()
        {
            return flip = pos.X > tankDim.X/2;
        }

        private float GetWanderLeftTarget(Rectangle rect)
        {
            return -rect.Width - rect.X;
        }

        private float GetWanderRightTarget(Rectangle rect)
        {
            return tankDim.X + rect.Width + rect.X;
        }

        private bool AttemptAcquireUrgentTarget()
        {
            return false; // TODO: try to perceive Food
        }


    }
}
