using System;
using System.Collections.Generic;

/// <summary>
/// Marble base class, define some basic properties
/// </summary>
public class MarbleBase
{
    protected float m_Radius;
    protected float m_Mass;
    protected MarbleType m_Type;


    public MarbleBase()
    {
        m_Radius = 0.3f;
        m_Mass = 1f;
        m_Type = MarbleType.Normal;
    }

}
