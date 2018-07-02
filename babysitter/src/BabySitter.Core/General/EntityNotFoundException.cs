using System;

namespace BabySitter.Core.General
{
    public class EntityNotFoundException : Exception
    {
        
    }
    
    public class EntityNotFoundException<T> : EntityNotFoundException
    {
        
    }
}