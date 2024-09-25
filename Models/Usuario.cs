using System;

public class Class1
{
	public Class1()
	{


    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int RolId { get; set; } // ForeignKey a Rol
    public Rol Rol { get; set; }

}
}
