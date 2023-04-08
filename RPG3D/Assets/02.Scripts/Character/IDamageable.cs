using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal interface IDamageable
{
    public float hp { get; set; }
    public float hpMin { get; }
    public float hpMax { get; }
    public event Action<float> OnHpChanged;
    public event Action OnHpMin;
    public event Action OnHpMax;

    public void Damage(float amount);
}
