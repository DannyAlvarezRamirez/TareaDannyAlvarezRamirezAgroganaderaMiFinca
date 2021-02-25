using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaAgroganaderaMiFinca
{
    /*
     * esta clase se encarga de controlar las acciones que se vinculan 
     * con el ObjetoDueno(Array o arreglo de objetos tipo ObjetoDueno)
     */
    class ControladorDueno
    {
        //atributos
        private int tamano;
        private ObjetoDueno miObjetoDueno;
        private ObjetoDueno[] miArrayDueno;

        //constructores
        public ControladorDueno()
        {
            this.tamano = 10;
            this.miArrayDueno = new ObjetoDueno[this.tamano];
        }//fin constructor

        //parametros-metodos
        /*
         * GetObjetoDueno: este metodo se encarga de llenar los ObjetoDueno, verifica tambien qu no se ingresen
         * parametros vacios y devuelve el ObjetoDueno lleno correctamente
         */
        public ObjetoDueno GetObjetoDueno(int identificacionPersona, string nombrePersona, string primerApellido, string segundoApellido,
            string correoElectronicoDueno, string numeroCelularDueno, ObjetoFinca objFincaDueno)
        {
            if (nombrePersona != "" && primerApellido != "" && segundoApellido != "" && correoElectronicoDueno != "" && numeroCelularDueno != "")
            {
                return this.miObjetoDueno = new ObjetoDueno(identificacionPersona, nombrePersona, primerApellido, segundoApellido, 
                    correoElectronicoDueno, numeroCelularDueno, objFincaDueno);
            }//fin if datos no vacios
            else
            {
                return null;
            }//fin else datos vacios
        }//fin GetObjetoDueno
        /* RegistrarDueno: este metodo se encarga de registrar los objetos Dueno en un array programado manualmente
        * que es de tipo ObjetoDueno, de un tamano predeterminado 10. 
        * 
        */
        public string RegistrarDueno(int indice, ObjetoDueno objetoDueno)
        {
            String salida = "";
            if (indice >= 0 && indice < this.tamano)
            {
                if (this.miArrayDueno[indice] == null)
                {
                    this.miArrayDueno[indice] = objetoDueno;
                    salida = "Se agregó bien.";
                }//fin if array lleno
                else
                {
                    return "El indice está llena.";
                }//fin else array lleno
            }//fin if indice
            else
            {
                return "Indice fuera de rango.";
            }//fin else indice
            return salida;
        }//fin RegistrarDueno
        /* MostrarDueno: este metodo se encarga de mostrar la informacion que se encuentra dentro del array para poder
         * imprimirlo en la consola o pantalla.
         */
        public string MostrarDueno()
        {
            String salida = "";
            for (int i = 0; i < this.tamano; i++)
            {
                if (this.miArrayDueno[i] != null)
                {
                    salida += "\n*Indice: " + i + " = " + this.miArrayDueno[i].GetInformacionObjetoDueno();
                }//fin if
                else
                {
                    salida += "\n*Indice " + i + " = vacía.";
                }//fin else
            }//fin for
            return "\n****Lista de Duenos Actuales****\n" + salida;
        }//fin MostrarDueno
        /*
        *  VerificarIdentificacion: se encarga de verificar si ya existe o no un dueno con un numero que lo identifica como unico 
        */
        public int VerificarIdentificacion(int identificacion)
        {
            int salida = 0;
            int contador = 0;
            int fila = 0;
            //recorrer el arreglo 
            for (int i = 0; i < this.tamano; i++)
            {
                if (this.miArrayDueno[i] != null && this.miArrayDueno[i].IdentificacionPersona == identificacion)
                {
                    fila = i;
                    contador++;
                    break;
                }//fin if
            }//fin for
            //preguntar si contador es mayor que 0 entonces si existe
            if (contador > 0)
            {
                salida = fila;
            }//fin if
            else
            {
                salida = -1;
            }//fin else no existe, se puede proceder a registrar
            return salida;
        }//fin VerificarIdentificacion
    }//fin clase ControladorDueno
}
