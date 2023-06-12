namespace Biblioteca;


public class Cliente
{
    //public string Nombre{set{Nombre=value;}}
    //public string Apellido{set{Apellido=value;}}
    public string Nombre{get;}
    public string Apellido{get;}
    
    public Cliente(string Nombre, string Apellido)
    {
        this.Nombre = Nombre;
        this.Apellido = Apellido;
    }

    public string? Usuario{get;}

    public Cliente(string Nombre, string Apellido, string Usuario):this(Nombre,Apellido){
        this.Usuario = Usuario;
    }

}

public abstract class Cuenta
{
    public string? Numero{get;}
    private double _saldo;
    public double Saldo
    {
        get{return _saldo;}
        set{_saldo = value;}
    }

    public Cliente Cliente;

    public Cuenta(string Numero, double Saldo, Cliente cliente){
        this.Numero = Numero;
        this.Saldo = Saldo;
        this.Cliente = cliente;
    }

    public abstract void AplicarCredito(double Monto);
        //*Cuenta contiene un método AplicarCredito que recibe un monto que debe ser sumado al saldo.

    public abstract void AplicarDebito(double Monto);
        //*Cuenta contiene un método AplicarDebito que recibe un monto y deba ser descontado al saldo. 
        //Este método debe permitir a las clases heredadas dar una nueva implementación si lo desean.
    
}

public class CuentaCorriente :Cuenta
{
    public double Descubierto{get;set;}
    public CuentaCorriente(string Numero, double Saldo, Cliente cliente,double Descubierto) : base(Numero, Saldo, cliente)
    {
        this.Descubierto = Descubierto;
    }

    public override void AplicarCredito(double Monto){
        Console.WriteLine("Cuenta Corriente "+ Cliente.Usuario +" Del Cliente " + Cliente.Nombre + " " + Cliente.Apellido);
        double TotalSaldo = Saldo + Descubierto;
        Console.WriteLine("Saldo De la Cuenta Corriente es: " + Saldo + "$ mas el Descubrimiento de " + Descubierto + "$ es de " + TotalSaldo + "$");
        Saldo +=Monto;
        TotalSaldo = Saldo + Descubierto;
        Console.WriteLine("Se ACREDITO "+ Monto +"$ al cliente " + Cliente.Usuario);
        Console.WriteLine("Nuevo Monto en la caja de ahorro " + Saldo + "$ mas el Descubrimiento de " + Descubierto + "$ es de " + TotalSaldo + "$");
        Registro.AgregarMovimiento(new Movimiento(DateTime.Now,Monto, Movimiento.TipoMovimiento.Credito));
    }

    public override void AplicarDebito(double Monto){
        /*Al aplicar el débito debe tener en cuenta el descubierto, si el saldo de la cuenta es negativo y 
        supera el monto permitido del descubierto, el método debe lanzar una exception que debe ser capturada por
        el programa.*/
        Excep.ComprobarNegativo(Monto);
        double debito = Monto;
        Console.WriteLine("Cuenta Corriente "+ Cliente.Usuario +" Del Cliente " + Cliente.Nombre + " " + Cliente.Apellido);
        double TotalSaldo = Saldo + Descubierto;
        Console.WriteLine("Saldo De la Cuenta Corriente es: " + Saldo + "$ mas el Descubrimiento de " + Descubierto + "$ es de " + TotalSaldo + "$");
        if (Saldo>Monto)
        {
            Saldo -= Monto;
            Registro.AgregarMovimiento(new Movimiento(DateTime.Now,Monto, Movimiento.TipoMovimiento.Debito));
        }else{
            Monto -= Saldo;
            Saldo = 0;
            Descubierto -= Monto;
            TotalSaldo = Saldo + Descubierto;
        }
        Excep.ComprobarSaldo(TotalSaldo);
        Registro.AgregarMovimiento(new Movimiento(DateTime.Now, debito, Movimiento.TipoMovimiento.Debito));
        Console.WriteLine("Se DEBITO "+ debito +"$ al cliente " + Cliente.Nombre);
        Console.WriteLine("Nuevo Saldo en Cuenta Corriente es: " + Saldo + "$ + Descubrimiento: " + Descubierto + "$, Total: " + TotalSaldo + "$");
    }
    
}

public class CajaAhorro : Cuenta
{
    public CajaAhorro(string Numero, double Saldo, Cliente cliente) : base(Numero, Saldo, cliente)
    {
    }

    public override void AplicarCredito(double Monto){
            Console.WriteLine("Caja de ahorro "+ Cliente.Usuario +" Del Cliente " + Cliente.Nombre + " " + Cliente.Apellido);
            Console.WriteLine("Saldo Caja de ahorro nº2 " + Saldo + "$");
            Saldo += Monto;
            Console.WriteLine("Se ACREDITO "+ Monto +"$ al cliente " + Cliente.Nombre);
            Console.WriteLine("Nuevo Monto en la caja de ahorro " + Saldo + "$");
            Registro.AgregarMovimiento(new Movimiento(DateTime.Now,Monto, Movimiento.TipoMovimiento.Credito));
    }

    public override void AplicarDebito(double Monto){
        /*Al aplicar un débito a una CajaAhorro, se verificará si hay saldo disponible. 
        Si no lo hubiera, se mostrará una exception con un mensaje “El saldo no puede ser negativo”. 
        Dicho evento será capturado por el programa.*/
            Excep.ComprobarNegativo(Monto);
            Console.WriteLine("Caja de ahorro "+ Cliente.Usuario +" Del Cliente " + Cliente.Nombre + " " + Cliente.Apellido);
            Console.WriteLine("Saldo Caja de ahorro " + Saldo + "$");
            Saldo -= Monto;
            Excep.ComprobarSaldo(Saldo);
            Console.WriteLine("Se DEBITO "+ Monto +"$ al cliente " + Cliente.Usuario);
            Console.WriteLine("Nuevo Monto en la caja de ahorro " + Saldo + "$");
            Registro.AgregarMovimiento(new Movimiento(DateTime.Now,Monto, Movimiento.TipoMovimiento.Debito));        
    }

}

public class Movimiento{
    public DateTime Fecha { get; set; }

    public double Monto {get; set;}

    public TipoMovimiento Tipo{get;set;}

    public enum TipoMovimiento{
        Debito,
        Credito
        }

    public Movimiento(DateTime Fecha, double Monto, TipoMovimiento Tipo){
        this.Fecha = Fecha;
        this.Monto = Monto;
        this.Tipo = Tipo;
    }

 }



public static class Registro{

    private static List<Movimiento> movimientos = new List<Movimiento>();

    public static void AgregarMovimiento(Movimiento movimiento){
        movimientos.Add(movimiento);
    }

    public static void MostrarUltimosMovimientos(){

        var ultimosMovimientos = movimientos.ToList();

        foreach (var movimiento in ultimosMovimientos)
        {
            Console.WriteLine($"Fecha: {movimiento.Fecha}, Monto: {movimiento.Monto}, Tipo: {movimiento.Tipo}");
        }
    }

}

public static class Excep{

    public static void ComprobarSaldo(double sal){
    if(sal<0){
        throw new Exception("El saldo no puede ser negativo");
        }
    }

    public static void ComprobarNegativo(double Monto){
        if(Monto<0){
            throw new Exception("No se pueden ingresar Montos negativos");
        }
    }


}







