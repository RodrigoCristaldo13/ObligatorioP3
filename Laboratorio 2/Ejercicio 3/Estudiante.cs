using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ejercicio_3
{
    public class Estudiante
    {
        public int _Id { get; private set; }
        public string _Nombre { get; set; }
        public string _Apellido { get; set; }
        public DateTime _FechaNacimiento { get; set; }

        public double _PromedioAcademico { get; set; }
    
    public Estudiante(int id, string nombre, string apellido, DateTime fechaNacimiento, double promedioAcademico)
    {
        _Id = id;
        _Nombre = nombre;
        _Apellido = apellido;
        _FechaNacimiento = fechaNacimiento;
        _PromedioAcademico = promedioAcademico;
    }

    public bool TieneExcelenciaAcademica()
    {
        return _PromedioAcademico > 95;
    }
    public override string ToString()
    {
        return $"Estudiante {_Id}: {_Nombre} {_Apellido}, Fecha de Nacimiento: {_FechaNacimiento.ToShortDateString()}, Promedio Académico: {_PromedioAcademico}";
    }
}
}
