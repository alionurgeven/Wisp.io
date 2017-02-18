using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Constants {

    ///	<description>>
    /// Body of constants for level Manager, Pool Manager, UI Manager
    /// for Anıl Sert 
    /// </description>


    ///	<description>>
    /// Body of constants for Collectables
    /// for Hayati İbiş
    /// </description>
    public static float NATURAL_PIECE_SIZE_MULTIPLIER = 1.5f;



    ///	<description>>>
    /// Body of constants for Ability Manager, Game Manager
    /// for Ali Onur Geven
    /// </description>


    ///	<description>
    ///  Body of constants for Wisp
    ///  for general use
    /// </description>
    /// 

    public static float BOUNDARY = 80.0f;
    public static Vector2 MAX_VECTOR = Vector2.one * BOUNDARY;
    public static Vector2 MIN_VECTOR = Vector2.one * -BOUNDARY;

    public static List<Color> colorList = new List<Color>();
    public static int MAX_NO_OF_NATURAL_PIECES = 250;
    public static int MAX_NO_OF_OTHER_PIECES = 5;

    public static int MAX_NO_OF_ENEMIES = 49;
}
