using System;

namespace AttributedCarLibrary
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
    public sealed class VehicleAttribute : Attribute
    {
        public string Description { get; set; }
        public VehicleAttribute() { }
        public VehicleAttribute(string description)
            => Description = description;
    }
}
