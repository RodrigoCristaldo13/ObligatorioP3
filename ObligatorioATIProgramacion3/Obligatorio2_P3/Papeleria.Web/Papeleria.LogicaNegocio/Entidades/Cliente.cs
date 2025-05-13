using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.Interfaces;
using Papeleria.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    [Index(nameof(Rut), IsUnique = true)]
    public class Cliente : IValidable
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Rut del Cliente es obligatorio")]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "El Rut del Cliente debe contener exactamente 12 dígitos numéricos"),MinLength(12),MaxLength(12)]
        public string Rut { get; set; }
        public NombreCompleto NombreCompleto { get; set; }
        public string RazonSocial { get; set; }
        public Direccion Direccion { get; set; }
        public double Distancia { get; set; }

        public Cliente()
        {

        }
       
        public void Validar()
        {
            ValidarRut();
            ValidarRazonSocial();
            ValidarNombreCompleto();
        }

        private void ValidarNombreCompleto()
        {
            if (NombreCompleto.Nombre.Length < 5 || NombreCompleto.Nombre.Length > 100) { throw new ClienteInvalidoException("Nombre de Contacto del Cliente no cumple el formato establecido"); }
            if (NombreCompleto.Apellido.Length < 5 || NombreCompleto.Apellido.Length > 100) { throw new ClienteInvalidoException("Apellido de Contacto del Cliente no cumple el formato establecido"); }
        }

        private void ValidarRazonSocial()
        {
            if (String.IsNullOrEmpty(RazonSocial)) { throw new ClienteInvalidoException("La Razon Social no puede ser vacia"); }
        }
        private void ValidarRut()
        {
            if (string.IsNullOrWhiteSpace(Rut))
            {
                throw new ClienteInvalidoException("El Rut del Cliente es obligatorio");
            }

            if (!Regex.IsMatch(Rut, @"^\d{12}$"))
            {
                throw new ClienteInvalidoException("El Rut del Cliente debe contener exactamente 12 dígitos numéricos");
            }
        }
    }
}
