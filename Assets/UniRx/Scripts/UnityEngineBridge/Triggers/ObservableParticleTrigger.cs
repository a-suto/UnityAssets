using System; // require keep for Windows Universal App
using UnityEngine;

namespace UniRx.Triggers
{
    [DisallowMultipleComponent]
    public class ObservableParticleTrigger : ObservableTriggerBase
    {
        Subject<GameObject> onParticleCollision;
#if UNITY_2018_2_OR_NEWER
        Subject<Unit> onParticleSystemStopped;
#endif
#if UNITY_5_4_OR_NEWER
        Subject<Unit> onParticleTrigger;
#endif

        /// <summary>OnParticleCollision is called when a particle hits a collider.</summary>
        void OnParticleCollision(GameObject other)
        {
            if (onParticleCollision != null) onParticleCollision.OnNext(other);
        }

        /// <summary>OnParticleCollision is called when a particle hits a collider.</summary>
        public IObservable<GameObject> OnParticleCollisionAsObservable()
        {
            return onParticleCollision ?? (onParticleCollision = new Subject<GameObject>());
        }

#if UNITY_2018_2_OR_NEWER

        /// <summary>OnParticleSystemStopped is called when all particles in the system have died, and no new particles will be born.</summary>
        void OnParticleSystemStopped()
        {
            if (onParticleSystemStopped != null) onParticleSystemStopped.OnNext(Unit.Default);
        }

        /// <summary>OnParticleSystemStopped is called when all particles in the system have died, and no new particles will be born.</summary>
        public IObservable<Unit> OnParticleSystemStoppedAsObservable()
        {
            return onParticleSystemStopped ?? (onParticleSystemStopped = new Subject<Unit>());
        }

#endif

#if UNITY_5_4_OR_NEWER

        /// <summary>OnParticleTrigger is called when any particles in a particle system meet the conditions in the trigger module.</summary>
        void OnParticleTrigger()
        {
            if (onParticleTrigger != null) onParticleTrigger.OnNext(Unit.Default);
        }

        /// <summary>OnParticleTrigger is called when any particles in a particle system meet the conditions in the trigger module.</summary>
        public IObservable<Unit> OnParticleTriggerAsObservable()
        {
            return onParticleTrigger ?? (onParticleTrigger = new Subject<Unit>());
        }

#endif

        protected override void RaiseOnCompletedOnDestroy()
        {
            if (onParticleCollision != null)
            {
                onParticleCollision.OnCompleted();
            }
#if UNITY_2018_2_OR_NEWER
            if (onParticleSystemStopped != null)
            {
                onParticleSystemStopped.OnCompleted();
            }
#endif
#if UNITY_5_4_OR_NEWER
            if (onParticleTrigger != null)
            {
                onParticleTrigger.OnCompleted();
            }
#endif
        }
    }
}