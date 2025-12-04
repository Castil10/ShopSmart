using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopSmart.Core.Models;

namespace ShopSmart.Tests;

[TestClass]
public class UsuarioTests
{
    [TestMethod]
    public void Usuario_TieneValoresPredeterminados()
    {
        var usuario = new Usuario();

        Assert.AreEqual(string.Empty, usuario.NombreUsuario);
        Assert.AreEqual(string.Empty, usuario.Contrasena);
        Assert.AreEqual("Administrador", usuario.Rol);
    }
}
