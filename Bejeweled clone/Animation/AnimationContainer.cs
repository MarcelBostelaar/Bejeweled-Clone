using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled_clone.Animation
{
    class AnimationContainer
    {
        List<IAnimation> animations;
        public AnimationContainer()
        {
            animations = new List<IAnimation>();
        }

        public void AddAnimations(IEnumerable<IAnimation> animations)
        {
            this.animations.AddRange(animations);
            this.animations.Sort();
        }

        public void AddAnimations(IEnumerable<Tuple<Point, IAnimation>> animations)
        {
            foreach (var item in animations)
            {
                this.animations.Add(item.Item2);
            }
            this.animations.Sort();
        }

        public IEnumerable<IAnimation> Animations
        {
            get
            {
                return animations;
            }
        }

        public void Clean(GameTime gameTime)
        {
            List<IAnimation> cleaned = new List<IAnimation>();
            for (int i = 0; i < animations.Count; i++)
            {
                if (!animations[i].Done(gameTime))
                    cleaned.Add(animations[i]);
            }
            animations = cleaned;
        }

        public bool Done()
        {
            if (animations.Count == 0)
                return true;
            return false;
        }

        public static AnimationContainer operator +(AnimationContainer a, AnimationContainer b)
        {
            var i = new AnimationContainer();
            i.AddAnimations(a.animations);
            i.AddAnimations(b.animations);
            return i;
        }
    }
}
