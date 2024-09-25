using System;

public class Class1
{
	public Class1()
	{


    public int Id { get; set; }
    public string Nombre { get; set; }

    public Herramienta()
    {
        if (string.IsNullOrEmpty(Nombre))
        {
            throw new ArgumentException("El nombre de la herramienta es requerido.");
        }
    }
}
}
