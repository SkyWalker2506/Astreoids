using System;

public interface IDamager
{
    public Action<int> OnDamage { get; set; }
}