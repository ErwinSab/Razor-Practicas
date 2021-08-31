using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RAZOR_Prac_2.Pages
{
    public class Empleado
    {   //se crea propiedades que almacenaran los datos
        public string _nombre { get; set; }
        public string _apellido { get; set; }
        public string _cargo { get; set; }
        public double _salario { get; set; }
        //se crea variales que enviaran los datos
        public double Dfp
        { get { return MontoDfp(_salario); } }
        public double Drs
        { get { return MontoDrs(_salario); } }
        public double Disr
        { get { return MontoDisr(_salario); } }
        public double Td
        { get { return MontoTd(Dfp + Drs + Disr); } }
        public double Sn
        { get { return MontoSn(_salario - Td); } }
        //se configuran las variables para realizar su operacion 
        private double MontoSn(double MontoSn)
        {
            MontoSn = _salario - Td;
            return MontoSn;
        }
        private double MontoTd(double MontoTd)
        {
            MontoTd = Dfp + Drs + Disr;
            return MontoTd;
        }
        private double MontoDisr(double _salario)
        {   double sala = _salario * 12;
            double isr = Dfp+Drs;
            if (sala > 867123.01)
            {
                isr = (_salario - isr) - 72260.25;
                _salario = (isr * 0.25) + 6648.00;
            } 
            else if (sala < 867123.01 & sala > 624329.00)
            {
                isr = (_salario - isr) - 52027.42;
                _salario = ( isr* 0.20)+2601.33;
            } 
            else if (sala < 624329.01 & sala > 416220.00)
            {
                isr = (_salario - isr) - 34685;
                _salario = (isr * 0.15);
            } 
            else {_salario = (_salario * 0);
            }
            return (_salario);
        }
        private double MontoDrs(double _salario)
        {
            double SalaMin = 13482.00 * 10;
            if (_salario > SalaMin)
            {
                _salario = SalaMin;
            }
            return (_salario * 0.0304);
        }
        private double MontoDfp(double _salario)
        {
            double SalaMin = 13482.00 * 20;
            if (_salario > SalaMin)
            {
                _salario = SalaMin;
            }
            return (_salario * 0.0287);
        }
    }
    public class NominaModel : PageModel
    {
        private readonly ILogger<NominaModel> _logger;
        public List<Empleado> empleados { get; set; }

        public NominaModel(ILogger<NominaModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            empleados = new List<Empleado>
            {
                new Empleado()
                {
                    _nombre = "Maria",
                    _apellido = "Gonzales",
                    _cargo = "Programador",
                    _salario = 50500
                },
                new Empleado()
                {
                    _nombre = "Fernando",
                    _apellido = "Pineda",
                    _cargo = "Gerente",
                    _salario = 65700
                },
                new Empleado()
                {
                     _nombre = "Johan",
                    _apellido = "Gutierres",
                    _cargo = "Soporte",
                    _salario = 28500
                },
                new Empleado()
                {
                     _nombre = "Rosalia",
                    _apellido = "Mendosa",
                    _cargo = "Gerente",
                    _salario = 65700
                },
                new Empleado()
                {
                     _nombre = "Steicy",
                    _apellido = "Pou",
                    _cargo = "Administrador",
                    _salario = 47800
                }
            };
        }
    }
}
