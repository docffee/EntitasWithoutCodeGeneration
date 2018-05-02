﻿/**
 * Created by Mikhail Tokarev (Deepscorn) on 15/07/17
 */
using Entitas;

public static class Pools
{
    static Pool _pool;

    public static Pool pool
    {
        get
        {
            if (_pool == null)
            {
                _pool = new Pool(ComponentIds.TotalComponents, 0, new PoolMetaData("Pool", ComponentIds.componentNames, ComponentIds.componentTypes));
#if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)
                if (UnityEngine.Application.isPlaying)
                {
                    var poolObserver = new Entitas.Unity.VisualDebugging.PoolObserver(_pool);
                    UnityEngine.Object.DontDestroyOnLoad(poolObserver.entitiesContainer);
                }
#endif
            }

            return _pool;
        }
    }
}