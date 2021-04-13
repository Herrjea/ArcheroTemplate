using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Clase estática que contiene los distintos eventos que pueden lanzarse en el juego
public static class GameEvents
{
    #region Howto

    /**** Ejemplo de evento sin parámetros
     *
     * 
     * public static UnityEvent [[EventName]] = new UnityEvent();
     * 
     */

    /**** Ejemplo de evento con parámetros específicos
     * 
     * 
     * 1 --> Creo la clase a la que pertenecerá el evento
     * 
     * public class [[MyEventType]] : UnityEvent<[[param_type]]>
     * 
     * 2 --> Creo el evento
     * 
     * public static [[MyEventType]] [[EventName]] = new [[MyEventType]]();
     * 
     */

    /**** Ejemplo de evento con parámetros especificados por una clase
     * 
     * 
     * 1 --> Creo la clase que contendrá los parámetros
     * 
     * public class [[MyEventType]]Data 
     * {
     * 
     *     int _param1;
     *     float _param2;
     *     
     *     public [[MyEventType]]Data(int param1, float param2)
     *     {
     *         _param1 = param1;
     *         _param2 = param2;
     *     }
     * }
     * 
     * 2 --> Creo la clase a la que pertenecerá el evento
     * 
     * public class [[MyEventType]] : UnityEvent<[[MyEventType]]Data>{};
     * 
     * 
     * 3 --> Creo el evento
     * 
     * public static [[MyEventType]] [[EventName]] = new [[MyEventType]]();
     * 
     */

    #endregion


    #region Needed types

    public class FloatEvent : UnityEvent<float> { };
    public class V2Event : UnityEvent<Vector2> { };
    public class V2V2Event : UnityEvent<Vector2, Vector2> { };
    public class IntEvent : UnityEvent<int> { };
    public class IntIntEvent : UnityEvent<int, int> { };
    public class V3Event : UnityEvent<Vector3> { };
    public class PoolV3TransEvent : UnityEvent<ObjectPool, Vector3, Transform> { };
    public class PlAbEvent : UnityEvent<PlayerAbility> { };

    #endregion


    //
    // Input reading
    //

        
    public static V2Event TouchPress = new V2Event();
    public static UnityEvent TouchRelease = new UnityEvent();
    public static V2V2Event TouchDelta = new V2V2Event();

    public static UnityEvent ChangeMovementType = new UnityEvent();

    //
    // Metagame
    //

    public static IntEvent AddSoftCoins = new IntEvent();

    //
    // Gameplay
    //

    public static UnityEvent StartShooting = new UnityEvent();
    public static UnityEvent StopShooting = new UnityEvent();
    public static UnityEvent ToggleShooting = new UnityEvent();

    public static PoolV3TransEvent PlayerShot = new PoolV3TransEvent();

    public static FloatEvent PlayeGotHit = new FloatEvent();

    public static UnityEvent PlayerDied = new UnityEvent();
    public static V3Event EnemyDied = new V3Event();

    public static IntIntEvent SubWaveFinished = new IntIntEvent();
    public static PlAbEvent NewMaxHealthAbility = new PlAbEvent();
    public static PlAbEvent NewProjSptrengthAbility = new PlAbEvent();
}
