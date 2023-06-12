
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
