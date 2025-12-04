# Estado de formularios y requisitos solicitados

## Formulario de ventas (FrmVentas)
- Los textos principales (títulos y botones) usan un color azul (`ForeColor = Color.FromArgb(23, 58, 94)`) en lugar de negro, por lo que el requisito de "letras negras" no se cumple actualmente.【F:ShopSmart.UI/FrmVentas.Designer.cs†L47-L69】【F:ShopSmart.UI/FrmVentas.Designer.cs†L126-L153】
- La estructura visual está organizada con panel superior, filtros, grilla y pie; los botones están estilizados con colores sólidos y bordes planos, aunque no están en negro.【F:ShopSmart.UI/FrmVentas.Designer.cs†L24-L113】【F:ShopSmart.UI/FrmVentas.Designer.cs†L154-L204】

## Formulario principal (FrmPrincipal)
- Dispone de menú, panel de encabezado con búsqueda rápida y tarjetas en `FlowLayoutPanel`, pero no hay una organización adicional de botones o reordenamiento específico solicitado; solo existe el diseño actual sin ajustes de orden posteriores.【F:ShopSmart.UI/FrmPrincipal.Designer.cs†L7-L84】【F:ShopSmart.UI/FrmPrincipal.Designer.cs†L85-L136】
- No hay lógica visible que reubique u ordene dinámicamente los accesos; la pantalla mantiene la estructura previa con el menú y tarjetas configuradas en código estático.【F:ShopSmart.UI/FrmPrincipal.Designer.cs†L22-L136】

## Formulario de login (FrmLogin)
- El formulario permite inicio de sesión básico con lista fija de usuarios; no implementa ningún mecanismo de cambio de roles (vendedor, jefe, etc.) ni selección/visualización de rol en la interfaz.【F:ShopSmart.UI/FrmLogin.cs†L12-L45】【F:ShopSmart.UI/FrmLogin.Designer.cs†L17-L104】
- La interfaz es simple con campos de usuario y contraseña; no incluye controles para elegir rol ni lógica para aplicar permisos según rol.【F:ShopSmart.UI/FrmLogin.Designer.cs†L55-L104】【F:ShopSmart.UI/FrmLogin.cs†L12-L45】

## Conclusiones
- **No** se cumple el requisito de textos en negro en el formulario de ventas; se requieren ajustes de `ForeColor` a negro.
- El formulario principal no ha sido reordenado ni ajustado en botones más allá del diseño actual.
- Falta la funcionalidad de cambio de roles en el login; se necesitaría agregar selección y aplicación de roles (vendedor, jefe, etc.) para cumplir con el punto.
