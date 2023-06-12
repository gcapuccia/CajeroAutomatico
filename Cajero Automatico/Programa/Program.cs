/*Parcial 2
Se le solicita que desarrolle una aplicación que simule la operación de un cajero automático.
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
using System.Collections.Generic;
using System.Linq;
using Biblioteca;

//Implemento 3 clientenes
var Cliente1=new Cliente("Luciano","Rosas", "Empresa");
var Cliente2=new Cliente("Bruno","Gomez", "Monotributo");
var Cliente3=new Cliente("Cristian","Capucciati", "Monotributo");

//Impletento 3 Cajas de ahorro
var cuentaAhorro1 = new CajaAhorro("123", 12000.2, Cliente3);
var cuentaAhorro2 = new CajaAhorro("453", 27000.5, Cliente2);
var cuentaAhorro3 = new CajaAhorro("412", 1200.32, Cliente1);

//Implemento 3 cuentasCorrientes
var cuentaCorriente1 = new CuentaCorriente("555", 15000.0, Cliente2, 5000.0);
var cuentaCorriente2 = new CuentaCorriente("666", 27000.5, Cliente1, 3000.0);
var cuentaCorriente3 = new CuentaCorriente("777", 5700.5, Cliente3, 3000.0);


//-----------------ACCIONES en caja Ahorro--------------------
Console.WriteLine("--------------------------------CAJAS DE AHORRO-------------------------------------");
cuentaAhorro1.AplicarCredito(2000);
Console.WriteLine();

Console.WriteLine("--------------------------------");
try{
cuentaAhorro2.AplicarDebito(6000);
}catch(Exception ex){
    Console.WriteLine(ex.Message);
}
Console.WriteLine();


//-----------------ACCIONES en Cuenta Corriente--------------------
Console.WriteLine("---------------------------------CUENTAS CORRIENTES----------------------------------");
try{
cuentaCorriente1.AplicarDebito(16000);
}catch(Exception ex){
    Console.WriteLine(ex.Message);
}
Console.WriteLine();

Console.WriteLine("--------------------------------");
cuentaCorriente3.AplicarCredito(1000);
Console.WriteLine();

//----------------MOSTRAMOS LA LISTA DE MOVIMIENTOS
Console.WriteLine("---------------------------------------------------------------------");
Console.WriteLine("MOVIMIENTOS: ");
Registro.MostrarUltimosMovimientos();