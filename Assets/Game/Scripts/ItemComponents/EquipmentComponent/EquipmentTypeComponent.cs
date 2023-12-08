using UnityEngine;

public class EquipmentTypeComponent
{
    [SerializeField] private EquipmentTypes _type;
    public EquipmentTypes GetEquipmentType() => _type;
}