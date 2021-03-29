using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Clase estática que contiene los distintos eventos que pueden lanzarse en el juego
public static class GameEvents
{

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


    public class V2Event : UnityEvent<Vector2> { };
    public class IntEvent : UnityEvent<int> { };

    //
    // Input reading
    //

        
    public static V2Event TouchPress = new V2Event();

    public static UnityEvent TouchRelease = new UnityEvent();

    public static V2Event TouchDelta = new V2Event();

    public static UnityEvent ChangeMovementType = new UnityEvent();

    public static IntEvent AddSoftCoins = new IntEvent();

}
