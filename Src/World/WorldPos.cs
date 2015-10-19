﻿using UnityEngine;
using System.Collections;
using System;
using System.Threading;

[Serializable]
public struct WorldPos
{
	public int x, y, z;

	public WorldPos (int x, int y, int z)
	{
		this.x = x;
		this.y = y;
		this.z = z;
	}

	public override int GetHashCode()
     {
         unchecked
         {
             int hash = 47;
 
             hash = hash * 227 + x.GetHashCode();
             hash = hash * 227 + y.GetHashCode();
             hash = hash * 227 + z.GetHashCode();
 
             return hash;
         }
     }

  	public override bool Equals(object obj)
     {
         if (GetHashCode() == obj.GetHashCode())
             return true;
         return false;
     }
}
