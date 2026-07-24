Shader "Masked/Mask"
{
    SubShader
    {
        // Render mask after regular geometry
        // Render mask before masked geometry and transform
        Tags {"Queue" = "Geometry+1"}

        // Draw only depth buffer, skip RGDA channels
        ColorMask 0
        ZWrite On

        Pass {}
    }
}