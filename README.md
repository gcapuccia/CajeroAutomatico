# CajeroAutomatico
Aplicación que simula la operación de un cajero automático.

Detalles de implementación: 

Las clases a desarrollar como mínimo (puede agregar las que necesite) son:
-Cuenta
-Cliente 
** Cliente Nombre, Apellido (String, solo lectura), Usuario 
(String, solo lectura). Cliente solo podrá instanciarse si se le proporciona el nombre de Nombre y apellido.

** Cuenta expondrá los atributos Numero (String, solo lectura), Saldo (Double, solo lectura). 
Las Cuentas deberán tener siempre un Número y Saldo. 
Estos deberán proporcionarse en un constructor. 
Además debe contener una propiedad del tipo Cliente que también debe proporcionarse en el constructor.

*Cuenta contiene un método AplicarCredito que recibe un monto que debe ser sumado al saldo.

*Cuenta contiene un método AplicarDebito que recibe un monto y deba ser descontado al saldo. 
Este método debe permitir a las clases heredadas dar una nueva implementación si lo desean.

*Crear las clases CajaAhorro y CuentaCorriente que hereden de Cuenta. 

*CuentaCorriente debe contener una propiedad Descubierto que debe ser pasada en el constructor. 
Al aplicar el débito debe tener en cuenta el descubierto, si el saldo de la cuenta es negativo y 
supera el monto permitido del descubierto, el método debe lanzar una exception que debe ser capturada por
el programa.

*Al aplicar un débito a una CajaAhorro, se verificará si hay saldo disponible. 
Si no lo hubiera, se mostrará una exception con un mensaje “El saldo no puede ser negativo”. 
Dicho evento será capturado por el programa.  

*Crear la clase Movimiento con los campos Fecha, Monto y enum TipoMovimiento que puede ser Debito o Credito. 

*Crear una clase Registro (que para utilizarla no deba ser instanciada) en la que cada movimiento en
las operaciones llamará a la clase Registro con el método AgregarMovimiento, 
que reciba un objeto del tipo Movimiento. Dichos movimientos quedarán almacenados en una colección 
interna y podrán ser consultados desde el método MostrarUltimosMovimientos.

*Crear instancias de cada tipo de cuenta, generar movimientos y mostrar al final los movimientos.

*/
