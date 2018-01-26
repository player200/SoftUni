namespace SimpleMvc.Framework.Attributes.Property
{
    using System;

    public abstract class PropertyAttribute : Attribute
    {
        public abstract bool IsValid(object value);
    }
}