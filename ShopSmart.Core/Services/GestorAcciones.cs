using ShopSmart.Core.DataStructures;
using ShopSmart.Core.Models;

namespace ShopSmart.Core.Services;

public class GestorAcciones
{
    private readonly StackCustom<AccionSistema> _acciones = new();

    public void RegistrarAccion(string descripcion, Action deshacer)
    {
        _acciones.Push(new AccionSistema
        {
            Descripcion = descripcion,
            Deshacer = deshacer
        });
    }

    public bool DeshacerUltimaAccion()
    {
        if (_acciones.Count == 0)
        {
            return false;
        }

        var accion = _acciones.Pop();
        accion.Deshacer?.Invoke();
        return true;
    }
}
